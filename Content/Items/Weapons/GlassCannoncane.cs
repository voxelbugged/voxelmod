using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Weapons
{
	public class GlassCannoncane : ModItem
	{
        int randomType;
        int numProjectiles;
		public override void SetStaticDefaults() {
			Item.staff[Type] = true;
		}

		public override void SetDefaults() {

			Item.DefaultToStaff(ProjectileID.SapphireBolt, 12, 40, 12);
			Item.SetWeaponValues(12, 3);
            Item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Obsidian, 10)
				.AddIngredient(ItemID.LifeCrystal)
                .AddIngredient<Items.Weapons.GlassStaff>()
                .AddTile(TileID.Anvils)
				.Register();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			numProjectiles = (int)Math.Ceiling(((float)player.statLife/(float)player.statLifeMax2)*6f);

			for (int i = 0; i < numProjectiles; i++) {
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

				newVelocity *= 1f - Main.rand.NextFloat(0.2f);

                randomType = Main.rand.Next(new int[] {type, ProjectileID.AmethystBolt});
				Projectile.NewProjectileDirect(source, position, newVelocity, randomType, damage, knockback, player.whoAmI);
			}

			return false;
		}
	}
}
