using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Accessories
{
	public class HallowedCharm : ModItem
	{
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 20;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(gold: 8);
			Item.accessory = true;
            Item.lifeRegen = 2;
            Item.rare = ItemRarityID.LightPurple;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            player.longInvince = true;
            player.pStone = true;
		}

        public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.HallowedBar, 5)
                .AddIngredient(ItemID.PhilosophersStone)
                .AddIngredient(ItemID.CrossNecklace)
                .AddTile(TileID.TinkerersWorkbench)
				.Register();
		}
	}
}
