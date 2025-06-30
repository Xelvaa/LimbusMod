/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LimbusMod.Buffs;
using LimbusMod.NPCs;
using Microsoft.Xna.Framework;
using System; 

namespace LimbusMod.Items
{
    public class TremorItem : GlobalItem
    {
        public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var tremorNPC = target.GetGlobalNPC<TremorNPC>();

            if (item.type == ItemID.BreakerBlade)
            {   //33% chance to trigger tremor burst
                tremorNPC.tremorPotency += 1; 
                TremorNPC.ApplyTremorBurstStatic(target, 0.5f, ref target.GetGlobalNPC<TremorNPC>().tremorPotency, ref target.GetGlobalNPC<TremorNPC>().tremorCount);
            }

            if (item.type == ItemID.AdamantiteSword)
            {
                tremorNPC.tremorPotency += 3; 
                TremorNPC.ApplyTremorBurstStatic(target, 0.1f, ref target.GetGlobalNPC<TremorNPC>().tremorPotency, ref target.GetGlobalNPC<TremorNPC>().tremorCount);
            }
        }
    }
    public class TremorProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var tremorNPC = target.GetGlobalNPC<TremorNPC>();
            
            if (projectile.type == ProjectileID.NebulaArcanumExplosionShotShard) 
            {
                TremorNPC.ApplyTremorBurstStatic(target, 0.20f, ref target.GetGlobalNPC<TremorNPC>().tremorPotency, ref target.GetGlobalNPC<TremorNPC>().tremorCount);
            }

            if (projectile.type == ProjectileID.MaceWhip) 
            {
                tremorNPC.tremorCount += 1; 
            }
        }
    }
}
*/