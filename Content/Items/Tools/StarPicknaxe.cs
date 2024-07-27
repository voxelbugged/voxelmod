using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Tools
{
	public class StarPicknaxe : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 17;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 38;
			Item.useTime = 17;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5f;
			Item.value = Item.sellPrice(gold: 3, silver: 20);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.axe = 20;
			Item.pick = 100; 
			Item.attackSpeedOnlyAffectsWeaponAnimation = true;
            Item.useTurn = true;
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
				.AddIngredient<Items.Materials.StarBar>(16)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
