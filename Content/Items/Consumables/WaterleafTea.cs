using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Consumables
{
	public class WaterleafTea : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 5;
			/*ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(240, 240, 240),
				new Color(200, 200, 200),
				new Color(140, 140, 140)
			};*/
		}

		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 22;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(copper: 24);
			Item.buffType = BuffID.WellFed2; 
			Item.buffTime = 18000; 
		}
        public override void AddRecipes() {
			CreateRecipe()  
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.Waterleaf)
                .AddTile(TileID.TeaKettle)
				.Register();
		}
	}
}
