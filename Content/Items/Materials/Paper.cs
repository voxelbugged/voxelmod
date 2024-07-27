using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Materials
{
	public class Paper : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 50;
		}

		public override void SetDefaults() {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.StarBar>());
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = Item.CommonMaxStack; 
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.Wood, 2)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
