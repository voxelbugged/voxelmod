using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Weapons
{
	public class HydraFlower : ModItem
	{
        int shotCounter = 0;
		public override void SetStaticDefaults() {
			//Item.staff[Type] = true;
		}

		public override void SetDefaults() {
			Item.DefaultToStaff(ProjectileID.BallofFrost, 10, 12, 10);
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(gold: 11, silver: 50);
			Item.noMelee = true;
			Item.shootsEveryUse = true;
			Item.SetWeaponValues(60, 6.5f);
            Item.rare = ItemRarityID.Pink;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.FlowerofFire)
				.AddIngredient(ItemID.CursedFlames)
				.AddIngredient(ItemID.FlowerofFrost)
                .AddTile(TileID.MythrilAnvil)
				.Register();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shotCounter++;
            if(shotCounter == 1)
            {
                Projectile.NewProjectileDirect(source, position, velocity, ProjectileID.BallofFire, damage, knockback, player.whoAmI);
            }
            else if(shotCounter == 2)
            {
                Projectile.NewProjectileDirect(source, position, velocity, ProjectileID.CursedFlameFriendly, damage, knockback, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectileDirect(source, position, velocity, ProjectileID.BallofFrost, damage, knockback, player.whoAmI);
                shotCounter = 0;
            }
			return false;
		}
	}
}
