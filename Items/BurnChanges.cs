using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LimbusMod.Buffs;
using LimbusMod.NPCs;
using Microsoft.Xna.Framework;
using System; 

namespace LimbusMod.Items
{
    public class BurnItem : GlobalItem
    {
        public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (item.type == ItemID.FieryGreatsword)
            {
                // Add 2 burn potency
                var burnNPC = target.GetGlobalNPC<BurnNPC>();
                burnNPC.burnPotency = Math.Min(burnNPC.burnPotency + 3, 35); 
            }

            if (item.type == ItemID.DD2SquireDemonSword)
            {
                // Add 1 burn count
                var burnNPC = target.GetGlobalNPC<BurnNPC>();
                burnNPC.burnCount = Math.Min(burnNPC.burnCount + 1, 99); 
            }

            if (item.type == ItemID.TheHorsemansBlade)
            {
                var burnNPC = target.GetGlobalNPC<BurnNPC>();
                burnNPC.burnPotency = Math.Min(burnNPC.burnPotency + 5, 25); 
            }
        }
    }
    
    public class BurnProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (projectile.type == ProjectileID.Flamelash) 
            {
                var burnNPC = target.GetGlobalNPC<BurnNPC>();
                burnNPC.burnPotency = Math.Min(burnNPC.burnPotency + 1, 99); 
            }
            if (projectile.type == ProjectileID.Sunfury) 
            {
                var burnNPC = target.GetGlobalNPC<BurnNPC>();
                burnNPC.burnCount = Math.Min(burnNPC.burnCount + 1, 99); 
            }
            if (projectile.type == ProjectileID.LunarFlare) 
            {
                var burnNPC = target.GetGlobalNPC<BurnNPC>();
                burnNPC.burnPotency = Math.Min(burnNPC.burnPotency + 1, 99); 
            }
        }
    }
}
