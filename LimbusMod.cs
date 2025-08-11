using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace LimbusMod
{
    public class LimbusMod : Mod
    {
        public static class LimbusModExclusions
        {
            public static readonly HashSet<int> ExcludedProjectiles = new HashSet<int>
			{
				ProjectileID.CrystalShard,
				ProjectileID.CrystalLeafShot,
				ProjectileID.StyngerShrapnel,
				ProjectileID.PygmySpear,
				ProjectileID.BabySlime,
				ProjectileID.FrostBlastFriendly,
				ProjectileID.HornetStinger,
				ProjectileID.ImpFireball,
				ProjectileID.BabySpider,
				ProjectileID.SpiderEgg,
				ProjectileID.MiniRetinaLaser,
				ProjectileID.Spazmamini,
				ProjectileID.VenomSpider,
				ProjectileID.RainFriendly,
				ProjectileID.JumperSpider,
				ProjectileID.DangerousSpider,
				ProjectileID.OneEyedPirate,
				ProjectileID.SoulscourgePirate,
				ProjectileID.PirateCaptain,
				ProjectileID.MiniSharkron,
				ProjectileID.UFOLaser,
				ProjectileID.ClingerStaff,
				ProjectileID.Raven,
				ProjectileID.DD2FlameBurstTowerT1Shot,
				ProjectileID.DD2FlameBurstTowerT2Shot,
				ProjectileID.DD2FlameBurstTowerT3Shot,
				ProjectileID.DD2BallistraProj,
				ProjectileID.DD2ExplosiveTrapT1Explosion,
				ProjectileID.DD2ExplosiveTrapT2Explosion,
				ProjectileID.DD2ExplosiveTrapT3Explosion,
				ProjectileID.DD2LightningAuraT1,
				ProjectileID.DD2LightningAuraT2,
				ProjectileID.DD2LightningAuraT3,
				ProjectileID.ClusterFragmentsI,
				ProjectileID.ClusterFragmentsII,
				ProjectileID.ClusterSnowmanFragmentsI,
				ProjectileID.ClusterSnowmanFragmentsII,
				ProjectileID.ClingerStaff,
				ProjectileID.SeedlerThorn,
				ProjectileID.Raven,
				ProjectileID.DD2FlameBurstTowerT1Shot,
				ProjectileID.DD2FlameBurstTowerT2Shot,
				ProjectileID.DD2FlameBurstTowerT3Shot,
				ProjectileID.DD2BallistraProj,
				ProjectileID.DD2ExplosiveTrapT1Explosion,
				ProjectileID.DD2ExplosiveTrapT2Explosion,
				ProjectileID.DD2ExplosiveTrapT3Explosion,
				ProjectileID.DD2LightningAuraT1,
				ProjectileID.DD2LightningAuraT2,
				ProjectileID.DD2LightningAuraT3,
				ProjectileID.ReleaseDoves,
				ProjectileID.TitaniumStormShard,
				ProjectileID.VolatileGelatinBall,
				ProjectileID.FlinxMinion,
				ProjectileID.AbigailMinion,
				ProjectileID.InsanityShadowFriendly,
				ProjectileID.Smolstar,
				ProjectileID.BatOfLight,
				ProjectileID.StardustGuardian,
				ProjectileID.StardustDragon1,
				ProjectileID.StardustDragon2,
				ProjectileID.StardustDragon3,
				ProjectileID.StardustDragon4,
				ProjectileID.StardustCellMinionShot,
				ProjectileID.WeatherPainShot,
				ProjectileID.PhantasmArrow,
            };
        }
    }
}