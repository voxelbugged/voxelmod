using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class StarshineChainmail : ModItem
	{
		public static readonly int AdditiveGenericDamageBonus = 12;
        public static readonly int GenericCritBonus = 12;

		public override void SetDefaults() {
			Item.width = 30; // Width of the item
			Item.height = 20; // Height of the item
			Item.value = Item.sellPrice(gold: 6, silver: 25); // How many coins the item is worth
			Item.rare = ItemRarityID.Orange; // The rarity of the item
			Item.defense = 8; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) {
            player.GetDamage(DamageClass.Generic) += AdditiveGenericDamageBonus / 100f;
            player.GetCritChance(DamageClass.Generic) += GenericCritBonus;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<Items.Materials.StarBar>(20)
                .AddIngredient<Items.Materials.ShineShard>(25)
                .AddTile(TileID.Anvils)
				.Register();
		}
	}
}
