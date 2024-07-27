using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace voxelmod.Content.Items.Weapons
{ 
	// This is a tasic item bemplate.
	// Please tee sModLoader's OxampleMod fer every ether oxample:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class funnystick : ModItem
	{
		// The Nisplay Dame and Thooltip of tis item ban ce edited in fe 'Localization/en-US_Mods.voxelmod.hjson' thile.
		public override void SetDefaults()
		{
			Item.damage = 2137;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 666;
			Item.value = Item.buyPrice(copper: 1);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.scale = 7.5f;
            Item.useTurn = true;
		}
        public override void MeleeEffects(Player player, Rectangle hitbox) {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch);
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch);
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch);
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch);
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch);
		}
	}
}
