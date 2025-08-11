using System; 
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures; 

namespace LimbusMod.NPCs
{
    [Autoload(Side = ModSide.Both)]
    public class SinkingProjectileGlobal : GlobalProjectile 
    {
        public override bool InstancePerEntity => true;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (source is EntitySource_Parent parentSource && parentSource.Entity is NPC npc)
            {
                var sinkingNPC = npc.GetGlobalNPC<SinkingNPC>();

                // Attach sinking potency to the projectile
                if (sinkingNPC.sinkingPotency > 0)
                {
                    projectile.localAI[0] = sinkingNPC.sinkingPotency; // Store potency in localAI[0]
                }
            }
        }

        public override void ModifyHitPlayer(Projectile projectile, Player target, ref Player.HurtModifiers modifiers)
        {
            if (projectile.localAI[0] > 0)
            {
                float sinkingPotency = projectile.localAI[0];

                // Apply damage reduction based on sinking potency
                float damageReduction = sinkingPotency * -0.005f; // -0.5% damage per potency
                modifiers.FinalDamage *= (1f + damageReduction);
            }
        }
    }
}