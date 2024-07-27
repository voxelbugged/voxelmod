using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class StarshineHat : ModItem
{
        public static readonly int ManaCostReductionPercent = 12;
		public static readonly int MaxMinionIncrease = 1;

		public override void SetStaticDefaults() {
			// If your head equipment should draw hair while drawn, use one of the following:
			// ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
			// ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
			// ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
			// ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;

			//SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(AdditiveGenericDamageBonus);
		}

		public override void SetDefaults() {
			Item.width = 26; // Width of the item
			Item.height = 22; // Height of the item
			Item.value = Item.sellPrice(gold: 3, silver: 50); // How many coins the item is worth
			Item.rare = ItemRarityID.Orange; // The rarity of the item
			Item.defense = 7; // The amount of defense the item will give when equipped
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
			player.manaCost -= ManaCostReductionPercent / 100f;
			player.maxMinions += MaxMinionIncrease;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<Items.Materials.StarBar>(10)
                .AddIngredient<Items.Materials.ShineShard>(15)
                .AddTile(TileID.Anvils)
				.Register();
		}
	}
}
