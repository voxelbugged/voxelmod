using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Accessories
{
	public class BeetleHeart : ModItem
	{
        int damageBoost;
        int defenseBoost;
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 60);
			Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            damageBoost = (int)Math.Round(((float)player.statLife/(float)player.statLifeMax2)*6f);
            defenseBoost = 6 - damageBoost;
            player.GetDamage(DamageClass.Generic) += damageBoost/100f;
            Item.defense = defenseBoost;
		}

        public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient(ItemID.RedHusk)
                .AddIngredient(ItemID.VioletHusk)
                .AddIngredient(ItemID.CyanHusk)
                .AddTile(TileID.TinkerersWorkbench)
				.Register();
		}
	}
}
