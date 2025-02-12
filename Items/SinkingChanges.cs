using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LimbusMod.Buffs;
using LimbusMod.NPCs;
using Microsoft.Xna.Framework;
using System; 

namespace LimbusMod.Items
{
    public class SinkingItem : GlobalItem
    {
        public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (item.type == ItemID.PurpleClubberfish)
            {   
                var sinkingNPC = target.GetGlobalNPC<SinkingNPC>();
                sinkingNPC.sinkingPotency = Math.Min(sinkingNPC.sinkingPotency + 2, 45); 
            }

            if (item.type == ItemID.Muramasa)
            {
                var sinkingNPC = target.GetGlobalNPC<SinkingNPC>();
                sinkingNPC.sinkingPotency = Math.Min(sinkingNPC.sinkingPotency + 2, 45); 
            } 
        }
    }
    public class SinkingProjectile : GlobalProjectile 
    {
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (projectile.type == ProjectileID.WaterStream) 
            {
                var sinkingNPC = target.GetGlobalNPC<SinkingNPC>();
                sinkingNPC.sinkingCount = Math.Min(sinkingNPC.sinkingCount + 2, 40);  
            }
            if (projectile.type == ProjectileID.WaterBolt) 
            {
                var sinkingNPC = target.GetGlobalNPC<SinkingNPC>();
                sinkingNPC.sinkingPotency = Math.Min(sinkingNPC.sinkingPotency + 2, 45); 
            }

            if (projectile.type == ProjectileID.Typhoon) 
            {
                var sinkingNPC = target.GetGlobalNPC<SinkingNPC>();
                sinkingNPC.sinkingCount = Math.Min(sinkingNPC.sinkingCount + 2, 45);  
            }

            if (projectile.type == ProjectileID.Bubble) 
            {
                var sinkingNPC = target.GetGlobalNPC<SinkingNPC>();
                sinkingNPC.sinkingPotency = Math.Min(sinkingNPC.sinkingPotency + 2, 45); 
            }

            if (projectile.type == ProjectileID.FinalFractal) 
            {
                var sinkingNPC = target.GetGlobalNPC<SinkingNPC>();
                sinkingNPC.sinkingPotency = Math.Min(sinkingNPC.sinkingPotency + 10, 45); 
                sinkingNPC.sinkingCount = Math.Min(sinkingNPC.sinkingCount + 10, 45);  
            }
        }
    }
}