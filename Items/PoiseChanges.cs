/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LimbusMod.Players;
using Microsoft.Xna.Framework;

namespace LimbusMod.Items
{
    public class PoiseItem : GlobalItem
    {
        public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (item.type == ItemID.Katana)
            {
                // Add 2 poise potency and 2 poise count
                var poisePlayer = player.GetModPlayer<PoisePlayer>();
                poisePlayer.poisePotency += 2;
                poisePlayer.poiseCount += 2;
            }
        }
    }
    
    public class PoiseProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (projectile.type == ProjectileID.ChlorophyteArrow)
            {
                // Add 2 poise potency and 2 poise count to the player
                var poisePlayer = Main.player[projectile.owner].GetModPlayer<PoisePlayer>();
                poisePlayer.poisePotency += 2;
                poisePlayer.poiseCount += 2;
            }
        }
    }
}
*/