using System; 
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace LimbusMod.NPCs
{
    public class SinkingNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        // sinking variables
        public int sinkingPotency = 0; // potency
        public int sinkingCount = 0;  // count

        public override void ResetEffects(NPC npc)
        {
            if (sinkingCount > 0 && sinkingPotency <= 0)
            {
                sinkingPotency = 1;
            }
            if (sinkingCount <= 0)
            {
                sinkingPotency = 0;
            }
            if (sinkingPotency > 45)
            {
                sinkingPotency = 45;
            }
        }

        public override void AI(NPC npc)
        {
            // reduce sinking timer if sinking count not applied
            if (sinkingPotency > 0)
            {
                float speedReduction = sinkingPotency * -0.002f;   // -0.75% speed per potency 
                npc.velocity *= (1f + speedReduction);  // Applique la réduction de vitesse
            }
        }

        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref NPC.HitModifiers modifiers)
        {
            ApplySinking(npc, ref modifiers);
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            ApplySinking(npc, ref modifiers);
        }

        private int previousSinkingPotency = 0;

        private void ApplySinking(NPC npc, ref NPC.HitModifiers modifiers)
        {
            if (sinkingCount > 0 || sinkingPotency > 0)
            {
                // reduce sinking count
                sinkingCount--;

                // Reduce enemy damage and speed
                float damageReduction = sinkingPotency * -0.005f;  // -0.5% damage per potency
                float armorReduction = sinkingPotency * 0.01f;     // 1% less armor per potency

                // Reduce damage
                modifiers.FinalDamage *= (1f + damageReduction);

                // Reduce armor
                npc.defense = Math.Max(0, npc.defense - (int)(npc.defense * armorReduction));

                // Small water particles
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 33, 0f, 0f, 0, Color.Blue, 1.5f);
                }

                // Show sinking potency and count
                if (sinkingPotency != previousSinkingPotency)  
                {
                    CombatText.NewText(npc.Hitbox, Color.Blue, sinkingPotency, true);
                    previousSinkingPotency = sinkingPotency; 
                }

                if (sinkingCount > 0)
                {
                    Rectangle textPosition = new Rectangle(npc.Hitbox.X, npc.Hitbox.Bottom + 100, npc.Hitbox.Width, 10);
                    CombatText.NewText(textPosition, Color.Blue, sinkingCount, true);
                }
            }

            if (sinkingCount == 1)
            {
                sinkingPotency = 0;
            }

            if (sinkingCount <= 0)
            {
                sinkingPotency = 0;
            }
        }
    }
}
