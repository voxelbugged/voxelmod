using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Tools
{
	public class StarSmasher : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.width = 38;
			Item.height = 38;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 8f;
			Item.value = Item.sellPrice(gold: 2, silver: 80);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.hammer = 75; 
			Item.attackSpeedOnlyAffectsWeaponAnimation = true;
            Item.ArmorPenetration = 10;
            Item.scale = 2f;
		}
        public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(6)) {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.GoldCoin);
			}
            if (Main.rand.NextBool(4)) {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.PlatinumCoin);
			}
		}
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<Items.Materials.StarBar>(14)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
