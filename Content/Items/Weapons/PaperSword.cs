using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Weapons
{ 
	public class PaperSword : ModItem
	{
		public override void SetDefaults()
		{
            Item.ResearchUnlockCount = 25;
			Item.damage = 8;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
            //Item.useTurn = true;
            Item.maxStack = Item.CommonMaxStack; 
            Item.shoot = ProjectileID.PurificationPowder;
            Item.consumable = true;
            Item.ChangePlayerDirectionOnShoot = false;
		}
		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient<Content.Items.Materials.Paper>(2)
                .AddTile(TileID.WorkBenches)
				.Register();
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            return false;
		}
	}
}
