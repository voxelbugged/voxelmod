using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class PaperShirt : ModItem
	{
		public static readonly int GenericCritBonus = 3;

		public override void SetDefaults() {
			Item.width = 30; // Width of the item
			Item.height = 20; // Height of the item
			Item.defense = 0; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) {
            player.GetCritChance(DamageClass.Generic) += GenericCritBonus;
		}

		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient<Content.Items.Materials.Paper>(30)
                .AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
