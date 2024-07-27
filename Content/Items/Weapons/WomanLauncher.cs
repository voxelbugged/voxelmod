using voxelmod.Content.Projectiles;
using voxelmod.Content.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace voxelmod.Content.Items.Weapons
{ 
	public class WomanLauncher : ModItem
	{
        public override void SetDefaults() {
			Item.width = 52;
			Item.height = 20;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Purple;
			Item.useTime = 10; 
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true; 
			Item.UseSound = SoundID.Item5;
			Item.DamageType = DamageClass.Summon;
			Item.damage = 1; 
			Item.knockBack = 6.9f; 
			Item.noMelee = true; 
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 12f; 
            //Item.DefaultToBow(12, 6666);
			Item.useAmmo = AmmoID.Arrow;
            Item.value = Item.sellPrice(gold: 2, silver: 40);
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-2f, -2f);
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            type = ModContent.ProjectileType<EdgyBirdWife>();
		}
	}
}
