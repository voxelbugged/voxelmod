using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Accessories
{
	public class BeautifulBouquet : ModItem
	{
        int critBoost;
        int reductionBoost;
        int damageBoost;
        int defenseBoost;
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 32;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(gold: 1, silver: 20);
			Item.accessory = true;
            Item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            damageBoost = (int)Math.Round(((float)player.statLife/(float)player.statLifeMax2)*6f);
            defenseBoost = 6 - damageBoost;
            player.GetDamage(DamageClass.Generic) += damageBoost/100f;
            Item.defense = defenseBoost;
            critBoost = (int)Math.Round(((float)player.statLife/(float)player.statLifeMax2)*6f);
            reductionBoost = 6 - critBoost;
            player.GetCritChance(DamageClass.Generic) += critBoost;
            player.endurance += (reductionBoost/100f)*(1f-player.endurance);
		}

        public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient<Items.Accessories.BeetleHeart>()
                .AddIngredient<Items.Accessories.MutantFlower>()
                .AddIngredient(ItemID.Vine, 2)
                .AddIngredient(ItemID.JungleSpores, 8)
                .AddTile(TileID.TinkerersWorkbench)
				.Register();
		}
	}
}
