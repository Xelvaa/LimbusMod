/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LimbusMod.Buffs;
using LimbusMod.NPCs;
using Microsoft.Xna.Framework;
using System; 

namespace LimbusMod.Items
{
    public class BleedItem : GlobalItem
    {
        public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (item.type == ItemID.BloodButcherer)
            {
                // Add 2 bleed potency
                var bleedNPC = target.GetGlobalNPC<BleedNPC>();
                bleedNPC.bleedPotency += 3; 
            }

            if (item.type == ItemID.DD2SquireBetsySword)
            {
                var bleedNPC = target.GetGlobalNPC<BleedNPC>();
                bleedNPC.bleedCount += 1; 
            }
        }
    }
    
    public class BleedProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (projectile.type == ProjectileID.BatOfLight) 
            {
                var bleedNPC = target.GetGlobalNPC<BleedNPC>();
                bleedNPC.bleedPotency += 1;
            }
            if (projectile.type == ProjectileID.SharpTears) 
            {
                var bleedNPC = target.GetGlobalNPC<BleedNPC>();
                bleedNPC.bleedCount += 1; 
            }
            if (projectile.type == ProjectileID.IchorBullet) 
            {
                var bleedNPC = target.GetGlobalNPC<BleedNPC>();
                bleedNPC.bleedPotency += 2; 
            }
            if (projectile.type == ProjectileID.IchorArrow) 
            {
                var bleedNPC = target.GetGlobalNPC<BleedNPC>();
                bleedNPC.bleedPotency += 2;
            }
        }
    }
}*/
