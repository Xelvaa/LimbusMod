using Terraria;
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
            if (item.type == ItemID.BreakerBlade)
            {   //33% chance to trigger tremor burst
                TremorNPC.ApplyTremorBurstStatic(target, 0.33f, ref target.GetGlobalNPC<TremorNPC>().tremorPotency, ref target.GetGlobalNPC<TremorNPC>().tremorCount);
            }

            if (item.type == ItemID.AdamantiteSword)
            {
                var tremorNPC = target.GetGlobalNPC<TremorNPC>();
                tremorNPC.tremorPotency = Math.Min(tremorNPC.tremorPotency + 3, 50); 
            }
        }
    }
    public class TremorProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (projectile.type == ProjectileID.MaceWhip) 
            {
                var tremorNPC = target.GetGlobalNPC<TremorNPC>();
                tremorNPC.tremorCount = Math.Min(tremorNPC.tremorCount + 1, 40); 
            }
        }
    }
}
