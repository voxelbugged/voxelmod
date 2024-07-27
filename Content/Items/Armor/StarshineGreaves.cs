using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class StarshineGreaves : ModItem
	{
		public static readonly int MoveSpeedBonus = 12;
        public static readonly int SwingSpeedBonus = 12;

		public override void SetDefaults() {
			Item.width = 22; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 5); // How many coins the item is worth
			Item.rare = ItemRarityID.Orange; // The rarity of the item
			Item.defense = 7; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += MoveSpeedBonus / 100f;
            player.GetAttackSpeed(DamageClass.Melee) += SwingSpeedBonus / 100f;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<Items.Materials.StarBar>(15)
                .AddIngredient<Items.Materials.ShineShard>(20)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
