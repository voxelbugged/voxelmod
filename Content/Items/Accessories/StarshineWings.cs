using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class StarshineWings : ModItem
	{
		public override void SetStaticDefaults() {
			// These wings use the same values as the solar wings
			// Fly time: 180 ticks = 3 seconds
			// Fly speed: 9
			// Acceleration multiplier: 2.5
			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(60, 7f, 1.5f);
		}

		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 28;
			Item.value = Item.sellPrice(gold: 3, silver: 50);
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.85f; // Falling glide speed
			ascentWhenRising = 0.15f; // Rising speed
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 1.5f;
			constantAscend = 0.135f;
		}
        public override bool WingUpdate(Player player, bool inUse)
        {
            if(inUse)
            {
                if (Main.rand.NextBool(6)) {
                    Dust.NewDust(player.position, player.width, player.height, DustID.GoldCoin);
                }
                if (Main.rand.NextBool(4)) {
                    Dust.NewDust(player.position, player.width, player.height, DustID.PlatinumCoin);
                }
            }
            return false;
        }
		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<Items.Materials.StarBar>(10)
                .AddIngredient<Items.Materials.ShineShard>(15)
				.AddTile(TileID.Anvils)
				.SortBefore(Main.recipe.First(recipe => recipe.createItem.wingSlot != -1)) // Places this recipe before any wing so every wing stays together in the crafting menu.
				.Register();
		}
	}
}
