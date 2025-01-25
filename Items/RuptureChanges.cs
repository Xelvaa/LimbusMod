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
            if (item.type == ItemID.CobaltSword)
            {
                // Add 3 rupture potency
                var ruptureNPC = target.GetGlobalNPC<RuptureNPC>();
                ruptureNPC.rupturePotency = Math.Min(ruptureNPC.rupturePotency + 3, 40); 
            }

            if (item.type == ItemID.DD2SquireDemonSword)
            {
                // Add 2 rupture count
                var ruptureNPC = target.GetGlobalNPC<RuptureNPC>();
                ruptureNPC.ruptureCount = Math.Min(ruptureNPC.ruptureCount + 2, 35); 
            }

            if (item.type == ItemID.EnchantedSword)
            {
                var ruptureNPC = target.GetGlobalNPC<RuptureNPC>();
                ruptureNPC.ruptureCount = Math.Min(ruptureNPC.ruptureCount + 2, 15); 
            }
        }
    }
    public class RuptureProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (projectile.type == ProjectileID.EnchantedBeam) 
            {
                var ruptureNPC = target.GetGlobalNPC<RuptureNPC>();
                ruptureNPC.rupturePotency = Math.Min(ruptureNPC.rupturePotency + 1, 10); 
            }
        }
    }
}
