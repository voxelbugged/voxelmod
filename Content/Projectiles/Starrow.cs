using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace voxelmod.Content.Projectiles
{
	public class Starrow : ModProjectile
	{
		
		public override void SetDefaults()
		{
			Projectile.arrow = true;
			Projectile.width = 1;
			Projectile.height = 10;
			Projectile.aiStyle = ProjAIStyleID.Arrow;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			AIType = ProjectileID.JestersArrow;
            Projectile.penetrate = 2;
		}

		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
        
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            return true;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(6)) {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.GoldCoin);
            }
            if (Main.rand.NextBool(4)) {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.PlatinumCoin);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255);
        }
	}
}
