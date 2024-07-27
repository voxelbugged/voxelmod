using voxelmod.Content.NPCs.Bosses;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Consumables
{
	// Basic code for a boss treasure bag
	public class CorvusTreasureBag : ModItem
	{
		public override void SetStaticDefaults() {
			// This set is one that every boss bag should have.
			// It will create a glowing effect around the item when dropped in the world.
			// It will also let our boss bag drop dev armor..
			ItemID.Sets.BossBag[Type] = true;
			ItemID.Sets.PreHardmodeLikeBossBag[Type] = true; // ..But this set ensures that dev armor will only be dropped on special world seeds, since that's the behavior of pre-hardmode boss bags.

			Item.ResearchUnlockCount = 3;
		}

		public override void SetDefaults() {
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.width = 32;
			Item.height = 32;
			Item.rare = ItemRarityID.Orange;
			Item.expert = true; // This makes sure that "Expert" displays in the tooltip and the item name color changes
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot) {
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.StarBar>(), 1, 20, 30));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.ShineShard>(), 1, 60, 90));
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<Corvus>()));
		}
	}
}
