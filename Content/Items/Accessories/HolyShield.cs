using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
	public class HolyShield : ModItem
	{
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 34;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(gold: 10);
			Item.accessory = true;
            Item.lifeRegen = 2;
            Item.defense = 2;
            Item.rare = ItemRarityID.Lime;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            player.longInvince = true;
            player.pStone = true;
            player.fireWalk = true;
            player.noKnockback = true;
		}

        public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.SoulofFright, 5)
                .AddIngredient(ItemID.SoulofMight, 5)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddIngredient<Items.Accessories.HallowedCharm>()
                .AddIngredient(ItemID.ObsidianShield)
                .AddTile(TileID.TinkerersWorkbench)
				.Register();
		}
	}
}
