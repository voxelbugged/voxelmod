using voxelmod.Content.Projectiles;
using voxelmod.Content.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace voxelmod.Content.Items.Weapons
{ 
	public class StarSlinger : ModItem
	{
        public override void SetDefaults() {
			Item.width = 52;
			Item.height = 20;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Green;
			Item.useTime = 12; 
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true; 
			Item.UseSound = SoundID.Item5;
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 13; 
			Item.knockBack = 2.5f; 
			Item.noMelee = true; 
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 12f; 
            //Item.DefaultToBow(12, 6666);
			Item.useAmmo = AmmoID.Arrow;
            Item.value = Item.sellPrice(gold: 2, silver: 40);
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<Items.Materials.StarBar>(12)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-2f, -2f);
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			if (type == ProjectileID.WoodenArrowFriendly) { 
				type = ModContent.ProjectileType<Starrow>();
			}
		}
	}
}
