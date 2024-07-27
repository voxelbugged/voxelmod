using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PaperHat : ModItem
{
        public static readonly int GenericCritBonus = 2;

		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			Item.width = 22; // Width of the item
			Item.height = 20; // Height of the item
			Item.defense = 0; // The amount of defense the item will give when equipped
		}
		/*// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<ExampleBreastplate>() && legs.type == ModContent.ItemType<ExampleLeggings>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player) {
			player.setBonus = SetBonusText.Value; // This is the setbonus tooltip: "Increases dealt damage by 20%"
			player.GetDamage(DamageClass.Generic) += AdditiveGenericDamageBonus / 100f; // Increase dealt damage for all weapon classes by 20%
		}*/
        public override void UpdateEquip(Player player) {
            player.GetCritChance(DamageClass.Generic) += GenericCritBonus;
		}

		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient<Content.Items.Materials.Paper>(20)
                .AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
