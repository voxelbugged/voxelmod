using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Materials
{
	public class BlackFeather : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = Item.CommonMaxStack; 
			Item.value = Item.sellPrice(copper: 10);
		}
	}
}
