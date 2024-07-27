using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;

namespace voxelmod.Content.Projectiles
{
	public class ChargedFeatherProjectile : ModProjectile
	{
		
		public override void SetDefaults()
		{
			Projectile.width = 24;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = false;
			Projectile.hostile = true;
			AIType = ProjectileID.Bullet;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
		}

        public override void AI()
        {
            if (Main.rand.NextBool(6)) {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.GoldCoin);
            }
            if (Main.rand.NextBool(4)) {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.PlatinumCoin);
            }
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255);
        }
	}
}
