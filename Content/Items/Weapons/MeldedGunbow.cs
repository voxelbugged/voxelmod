using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Audio;

namespace voxelmod.Content.Items.Weapons
{ 
	public class MeldedGunbow : ModItem
	{
        bool shootsArrow = false;
        public override void SetDefaults() {
			Item.width = 52;
			Item.height = 14;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Pink;
			Item.useTime = 13; 
			Item.useAnimation = 13;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true; 
			Item.UseSound = SoundID.Item11;
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 50; 
			Item.knockBack = 2.5f; 
			Item.noMelee = true; 
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 11f; 
			Item.useAmmo = AmmoID.Bullet;
            Item.value = Item.sellPrice(gold: 20, silver: 20);
		}

		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient<Items.Weapons.HallowedRifle>()
                .AddIngredient(ItemID.HallowedRepeater)
				.AddIngredient(ItemID.ChlorophyteBar, 18)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-4f, -2f);
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if(shootsArrow)
            {
                Item.useAmmo = AmmoID.Arrow;
            }
            else
            {
                Item.useAmmo = AmmoID.Bullet;
            }
            shootsArrow = !shootsArrow;
            return true;
		}
    }
}
