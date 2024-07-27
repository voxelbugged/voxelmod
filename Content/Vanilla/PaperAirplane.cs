using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Vanilla
{
	public class PaperAirplane : GlobalItem
	{
		public override void SetDefaults(Item item)
        {
			if (item.type == ItemID.PaperAirplaneA || item.type == ItemID.PaperAirplaneB)
            { 
                item.StatsModifiedBy.Add(Mod);
				item.damage = 8;       
			}
		}
        public override void AddRecipes() {
            Recipe.Create(ItemID.PaperAirplaneA)
                .AddIngredient<Content.Items.Materials.Paper>(2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
	}
}
