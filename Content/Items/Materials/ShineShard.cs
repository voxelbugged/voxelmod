using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Materials
{
	public class ShineShard : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 26;
			Item.maxStack = Item.CommonMaxStack; 
			Item.value = Item.sellPrice(silver: 10);
            Item.rare = ItemRarityID.Green;
		}
	}
}
