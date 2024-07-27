using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Weapons
{
	public class HolyVitality : ModItem
	{
        int randomType;
        int numProjectiles;
		public override void SetStaticDefaults() {
			Item.staff[Type] = true;
		}

		public override void SetDefaults() {

			Item.DefaultToStaff(ProjectileID.RubyBolt, 20, 20, 12);
			Item.SetWeaponValues(32, 5);
            Item.rare = ItemRarityID.Pink;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.HallowedBar, 10)
				.AddIngredient(ItemID.AegisCrystal)
                .AddIngredient<Items.Weapons.GlassCannoncane>()
                .AddTile(TileID.MythrilAnvil)
				.Register();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			numProjectiles = (int)Math.Ceiling(((float)player.statLife/(float)player.statLifeMax2)*6f) - 1;
			for (int i = 0; i < numProjectiles; i++) {
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

				newVelocity *= 0.6f - Main.rand.NextFloat(0.2f);

                randomType = Main.rand.Next(new int[] {ProjectileID.AmethystBolt, ProjectileID.TopazBolt});
				Projectile.NewProjectileDirect(source, position, newVelocity, randomType, damage, knockback, player.whoAmI);
			}

			return true;
		}
	}
}
