using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LimbusMod.Buffs;
using LimbusMod.NPCs;
using Microsoft.Xna.Framework;
using System; 

namespace LimbusMod.Items
{
    public class RuptureItem : GlobalItem
    {
        public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var ruptureNPC = target.GetGlobalNPC<RuptureNPC>(); 	

            if (LimbusMod.LimbusModExclusions.ExcludedItems.Contains(item.type))
            {
                return;
            }

            if (item.type == ItemID.EnchantedSword)
            {
                ruptureNPC.ruptureCount += 2; 
            }
            
            if (item.type == ItemID.CobaltSword)
            {
                // Add 2 rupture potency 
                ruptureNPC.rupturePotency += 2; 
            }

            if (item.type == ItemID.DD2SquireDemonSword)
            {
                // Add 2 rupture count 
                ruptureNPC.ruptureCount += 2; 
            }

            if (item.type == ItemID.BeamSword)
            {
                // Add 2 rupture count 
                ruptureNPC.ruptureCount += 2; 
            }

            if (item.type == ItemID.Meowmere)
            {
                // Add 2 rupture count 
                ruptureNPC.ruptureCount += 3; 
            }

            if (item.type == ItemID.TerraBlade) 
            {
                ruptureNPC.ruptureCount += 3; 
            }

        }
    }
    
    public class RuptureProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var ruptureNPC = target.GetGlobalNPC<RuptureNPC>(); 
            var burnNPC = target.GetGlobalNPC<BurnNPC>(); 
            Player player = Main.player[projectile.owner];

            if (LimbusMod.LimbusModExclusions.ExcludedProjectiles.Contains(projectile.type))
            {
                return;
            }

            if (LimbusMod.LimbusModExclusions.SemiExcludedProjectiles.Contains(projectile.type))
            {
                if (Main.rand.NextFloat() < 0.80f)
                {
                    return; 
                } 
            }

            if (projectile.arrow && player.HeldItem != null && 
                (player.HeldItem.type == ItemID.DemonBow || 
                 player.HeldItem.type == ItemID.CobaltRepeater || 
                 player.HeldItem.type == ItemID.HallowedRepeater || 
                 player.HeldItem.type == ItemID.FairyQueenRangedItem))
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.EnchantedBeam) 
            {
                ruptureNPC.rupturePotency += 1; 
            }
            if (projectile.type == ProjectileID.CobaltNaginata) 
            {
                ruptureNPC.ruptureCount += 2; 
            }
            if (projectile.type == ProjectileID.Meowmere) 
            {
                ruptureNPC.rupturePotency += 1; 
            }
            if (projectile.type == ProjectileID.NightsEdge)
            {
                ruptureNPC.rupturePotency += 2;

                // apply shadowflame if rupture potency >= 10
                if (ruptureNPC.rupturePotency >= 10)
                {
                    target.AddBuff(BuffID.ShadowFlame, 180); 
                    burnNPC.burnPotency += 1;
                }
            }
            if (projectile.type == ProjectileID.Excalibur) 
            {
                ruptureNPC.rupturePotency += 2; 
            }

            if (projectile.type == ProjectileID.TrueExcalibur) 
            {
                ruptureNPC.rupturePotency += 2; 
            }

            if (projectile.type == ProjectileID.TerraBlade2Shot) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.TerraBlade2) 
            {
                ruptureNPC.ruptureCount += 3;
            }

            if (projectile.type == ProjectileID.Code1) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.Chik) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.Gungnir) 
            {
                ruptureNPC.ruptureCount += 2; 
            }

            if (projectile.type == ProjectileID.EnchantedBoomerang) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.Trimarang) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.BallOHurt) 
            {
                ruptureNPC.ruptureCount += 2; 
            }

            if (projectile.type == ProjectileID.TheDaoofPow) 
            {
                ruptureNPC.ruptureCount += 2;  
            }

            if (projectile.type == ProjectileID.Arkhalis) 
            {
                ruptureNPC.rupturePotency += 1; 
                ruptureNPC.ruptureCount += 1;  
            }

            if (projectile.type == ProjectileID.Terragrim) 
            {
                ruptureNPC.rupturePotency += 1;
            }

            if (projectile.type == ProjectileID.PiercingStarlight) 
            {
                ruptureNPC.ruptureCount += 2;
            }

            if (projectile.type == ProjectileID.FrostArrow) 
            {
                ruptureNPC.ruptureCount += 2; 
            }

            if (projectile.type == ProjectileID.CrystalBullet) 
            {
                if (Main.rand.NextFloat() < 0.50f)
                {
                    ruptureNPC.rupturePotency += 1;
                } 
            }

            if (projectile.type == ProjectileID.NanoBullet) 
            {
                if (Main.rand.NextFloat() < 0.50f)
                {
                    ruptureNPC.rupturePotency += 1;
                } 
            }

            if (projectile.type == ProjectileID.EmeraldBolt) 	
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.VilethornBase || projectile.type == ProjectileID.VilethornTip) 
            {
                ruptureNPC.ruptureCount += 2;  
            }

            if (projectile.type == ProjectileID.MagicMissile) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.SkyFracture) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.CrystalVileShardHead || projectile.type == ProjectileID.CrystalVileShardShaft) 
            {
                ruptureNPC.ruptureCount += 2; 
            }

            if (projectile.type == ProjectileID.BookStaffShot) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.NettleBurstRight || projectile.type == ProjectileID.NettleBurstLeft || projectile.type == ProjectileID.NettleBurstEnd) 
            {
                ruptureNPC.ruptureCount += 2; 
            }

            if (projectile.type == ProjectileID.ShadowBeamFriendly) 
            {
                ruptureNPC.rupturePotency += 2; 
            }

            if (projectile.type == ProjectileID.CrystalStorm) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.TiedEighthNote) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.EighthNote) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.QuarterNote) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.FairyQueenMagicItemShot) 
            {
                ruptureNPC.rupturePotency += 1; 
            }

            if (projectile.type == ProjectileID.ThornWhip) 
            {
                ruptureNPC.ruptureCount += 1;  
                ruptureNPC.rupturePotency += 2; 
            }

            if (projectile.type == ProjectileID.RainbowWhip) 
            {
                ruptureNPC.ruptureCount += 1;  
                ruptureNPC.rupturePotency += 2; 
            }
        }
    }
}
