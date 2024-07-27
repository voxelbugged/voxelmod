using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;

namespace voxelmod.Content.Projectiles
{
	public class BlackFeatherProjectileFriendly : ModProjectile
	{
		
		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			AIType = ProjectileID.Bullet;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.penetrate = 6;
            Projectile.tileCollide = false;
		}

        public override void AI()
        {
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
