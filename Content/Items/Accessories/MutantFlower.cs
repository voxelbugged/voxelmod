using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Accessories
{
	public class MutantFlower : ModItem
	{
        int critBoost;
        int reductionBoost;
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 36;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 60);
			Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            critBoost = (int)Math.Round(((float)player.statLife/(float)player.statLifeMax2)*6f);
            reductionBoost = 6 - critBoost;
            player.GetCritChance(DamageClass.Generic) += critBoost;
            player.endurance += (reductionBoost/100f)*(1f-player.endurance);
		}

        public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient(ItemID.YellowMarigold)
                .AddIngredient(ItemID.PinkPricklyPear)
                .AddIngredient(ItemID.SkyBlueFlower)
                .AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
