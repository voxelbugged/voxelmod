using voxelmod.Content.Projectiles;
using voxelmod.Content.Items.Consumables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using System;
using Terraria.Audio;
using Terraria.Graphics.CameraModifiers;

namespace voxelmod.Content.NPCs.Bosses
{
    [AutoloadBossHead]
	public class Corvus : ModNPC
	{
        float speed;
        float yOffset = 0f;
        float projectileSpeed = 10f;
        float chargedProjectileSpeed = 12.5f;
        float catchupAmount = 3f;
        int attackLength = 90;
        int attackTimer = 240;
        int attackCounter = 0;
        int attackNumber = 4;
        int projectileMod = 10;
        int chargedMod = 20;
        int catchupRange = 1620;
        bool dashPhase = true;
        bool phaseTwo = false;
        bool catchingUp = false;
		public override void SetStaticDefaults() {
			NPCID.Sets.MPAllowedEnemies[Type] = true;
			NPCID.Sets.BossBestiaryPriority.Add(Type);
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
			Main.npcFrameCount[Type] = 4;

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() { 
				Velocity = 1f 
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}

		public override void SetDefaults() {
            NPC.boss = true;
			NPC.width = 144;
			NPC.height = 104;
			NPC.damage = 60;
			NPC.defense = 12;
			NPC.lifeMax = 6666;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.ForceRoar;
			NPC.value = Item.sellPrice(gold: 6, silver: 6, copper: 6);
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
            NPC.npcSlots = 10f;
			NPC.aiStyle = 1;
            NPC.SpawnWithHigherTime(30);

			AIType = 1;
			AnimationType = NPCID.CaveBat;

            if (Main.expertMode)
            {
                projectileSpeed *= 1.5f;
                chargedProjectileSpeed *= 1.5f;
            }
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot) {
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Materials.StarBar>(), 1, 20, 31));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Materials.ShineShard>(), 1, 60, 91));
            npcLoot.Add(notExpertRule);
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<CorvusTreasureBag>()));
		}

		public override void BossLoot(ref string name, ref int potionType) {
            potionType = ItemID.HealingPotion;
		}
        
        public override bool ModifyCollisionData(Rectangle victimHitbox, ref int immunityCooldownSlot, ref MultipliableFloat damageMultiplier, ref Rectangle npcHitbox) {
            npcHitbox.Y -= 24;
            npcHitbox.Height -= 24;
            return true;
        }               
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * balance * bossAdjustment * 0.75f);
        } 
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				//BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("the giant birb that makes all of the rules"),

				// By default the last added IBestiaryBackgroundImagePathAndColorProvider will be used to show the background image.
				// The ExampleSurfaceBiome ModBiomeBestiaryInfoElement is automatically populated into bestiaryEntry.Info prior to this method being called
				// so we use this line to tell the game to prioritize a specific InfoElement for sourcing the background image.
				//new BestiaryPortraitBackgroundProviderPreferenceInfoElement(ModContent.GetInstance<ExampleSurfaceBiome>().ModBiomeBestiaryInfoElement),
			});
		}
        public override void AI() {
            if (NPC.life < NPC.lifeMax/2)
            {
                if (Main.rand.NextBool(6)) {
                    Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y - 24), NPC.width, NPC.height - 24, DustID.GoldCoin);
                }
                if (!phaseTwo) {
                    SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
				    PunchCameraModifier modifier = new PunchCameraModifier(NPC.Center, (Main.rand.NextFloat() * ((float)Math.PI * 2f)).ToRotationVector2(), 20f, 6f, 20, 1000f, FullName);
				    Main.instance.CameraModifiers.Add(modifier);
                }
                phaseTwo = true;
            }
            if (Main.rand.NextBool(4)) {
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y - 24), NPC.width, NPC.height - 24, DustID.PlatinumCoin);
            }
			// This should almost always be the first code in AI() as it is responsible for finding the proper player target
			if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active) {
				NPC.TargetClosest();
			}

			Player player = Main.player[NPC.target];
            if(!player.dead)
            {
                Vector2 moveTo = player.Center;
                Vector2 move = moveTo - NPC.Center;
                speed = 4f * (Vector2.Distance(NPC.Center, player.Center)/370f);
                if(Main.expertMode)
                {
                    speed = 4f * (Vector2.Distance(NPC.Center, player.Center)/333f);
                }
                if(Main.getGoodWorld)
                {
                    speed = 4f * (Vector2.Distance(NPC.Center, player.Center)/300f);
                }
                speed *= 1.5f - 0.5f * (float)NPC.life/(float)NPC.lifeMax;
                if(attackTimer <= attackLength)
                {
                    if(dashPhase)
                    {
                        //speed *= 1.5f; //+ (float)attackTimer/(float)attackLength;
                    }
                    else if(Main.netMode != NetmodeID.MultiplayerClient)
                    {
                            if(attackTimer % projectileMod == 0)
                            {
                                Vector2 ToPlayer = NPC.DirectionTo(player.Center) * projectileSpeed;
                                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y + yOffset, ToPlayer.X, ToPlayer.Y, ModContent.ProjectileType<BlackFeatherProjectile>(), 16, 0f);
                                SoundEngine.PlaySound(SoundID.Item32, NPC.Center);
                            }
                            if(phaseTwo && attackTimer % chargedMod == 0)
                            {
                                Vector2 ToPlayer = NPC.DirectionTo(player.Center) * chargedProjectileSpeed;
                                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y + yOffset, ToPlayer.X, ToPlayer.Y, ModContent.ProjectileType<ChargedFeatherProjectile>(), 16, 0f);
                            }
                        
                    }
                }
                if(Main.netMode != NetmodeID.MultiplayerClient)
                {
                    if(attackTimer == attackLength && dashPhase)
                    {
                        for (int i = 0; i < 24; i++)
                            {
                                float angle = MathHelper.ToRadians(15 * i); 

                                float velocityX = (float)Math.Cos(angle) * projectileSpeed;
                                float velocityY = (float)Math.Sin(angle) * projectileSpeed;
                                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y + yOffset, velocityX, velocityY, ModContent.ProjectileType<BlackFeatherProjectile>(), 16, 0f);
                            }
                        SoundEngine.PlaySound(SoundID.Item32, NPC.Center);
                    }
                    if(attackTimer == attackLength/2 && dashPhase && phaseTwo)
                    {
                        for (int i = 0; i < 24; i++)
                            {
                                float angle = MathHelper.ToRadians((15 * i) + 7.5f);

                                float velocityX = (float)Math.Cos(angle) * projectileSpeed;
                                float velocityY = (float)Math.Sin(angle) * projectileSpeed;
                                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y + yOffset, velocityX, velocityY, ModContent.ProjectileType<ChargedFeatherProjectile>(), 16, 0f);
                            }
                        SoundEngine.PlaySound(SoundID.Item32, NPC.Center);
                    }
                }
                NPC.velocity = NPC.DirectionTo(player.Center) * speed;
            }
            attackTimer -= 1;
            if(attackTimer == 0)
            {
                attackTimer = 240;
                if (Main.expertMode) {
				    attackTimer = 180;
			    }
                if (Main.getGoodWorld)
                {
                    attackTimer = 120;
                }
                attackCounter += 1;
                if(attackCounter == 3)
                {
                    dashPhase = !dashPhase;
                    attackCounter = 0;
                }
            }
			if (player.dead) {
				// If the targeted player is dead, flee
				NPC.velocity.Y -= 0.04f;
				// This method makes it so when the boss is in "despawn range" (outside of the screen), it despawns in 10 ticks
				NPC.EncourageDespawn(10);
				return;
			}
        }
	}
}
