using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Weapons
{
	public class GlassStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Item.staff[Type] = true;
		}

		public override void SetDefaults() {

			Item.DefaultToStaff(ProjectileID.SapphireBolt, 5.5f, 40, 3);
			Item.SetWeaponValues(12, 3);
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.StoneBlock, 10)
				.AddIngredient(ItemID.Glass, 8)
                .AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
