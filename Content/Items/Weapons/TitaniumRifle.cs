using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace voxelmod.Content.Items.Weapons
{ 
	public class TitaniumRifle : ModItem
	{
        public override void SetDefaults() {
			Item.width = 52;
			Item.height = 14;
			Item.scale = 1f;
			Item.rare = ItemRarityID.LightRed;
			Item.useTime = 17; 
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true; 
			Item.UseSound = SoundID.Item11;
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 43; 
			Item.knockBack = 2.5f; 
			Item.noMelee = true; 
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 10.5f; 
			Item.useAmmo = AmmoID.Bullet;
            Item.value = Item.sellPrice(gold: 2, silver: 80);
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.TitaniumBar, 13)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-4f, -2f);
		}

	}
}
