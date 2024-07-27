using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class PaperPants : ModItem
	{
        public static readonly int GenericCritBonus = 2;

		public override void SetDefaults() {
			Item.width = 22; // Width of the item
			Item.height = 18; // Height of the item
			Item.defense = 0; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) {
            player.GetCritChance(DamageClass.Generic) += GenericCritBonus;
		}

		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient<Content.Items.Materials.Paper>(25)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
