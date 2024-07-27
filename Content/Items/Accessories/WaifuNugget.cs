using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Accessories
{
	public class WaifuNugget : ModItem
	{
		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 24;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(gold: 2, silver: 50);
			Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            Player localPlayer = Main.player[Main.myPlayer];
            localPlayer.AddBuff(ModContent.BuffType<Content.Buffs.EdgyBirdWife>(), 2);
		}
	}
}
