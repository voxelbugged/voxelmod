using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Materials
{
	public class StarBar : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults() {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.StarBar>());
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = Item.CommonMaxStack; 
			Item.value = Item.sellPrice(silver: 20);
            Item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.MeteoriteBar)
                .AddIngredient(ItemID.FallenStar)
                .AddIngredient(ItemID.Feather)
                .AddIngredient<Items.Materials.BlackFeather>()
				.AddTile(TileID.Furnaces)
				.Register();
		}
	}
}
