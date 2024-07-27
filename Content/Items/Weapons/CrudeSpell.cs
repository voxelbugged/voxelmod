using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Weapons
{
	public class CrudeSpell : ModItem
	{
		public override void SetStaticDefaults() {
			Item.staff[Type] = true;
            Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults() {

			Item.DefaultToStaff(ProjectileID.ChlorophyteBullet, 3f, 34, 3);
			Item.SetWeaponValues(8, 2);
            Item.maxStack = Item.CommonMaxStack; 
            Item.consumable = true;
		}

		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient<Content.Items.Materials.Paper>(2)
                .AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
