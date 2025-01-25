using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace LimbusMod.NPCs
{
    public class RuptureNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        // rupture variables
        public int rupturePotency = 0; // potency
        public int ruptureCount = 0;  // count
        private int ruptureTimer = 0; // reset rupture count

        public override void ResetEffects(NPC npc)
        {
            if (ruptureCount > 0 && rupturePotency <= 0)
            {
                rupturePotency = 1; 
            }
            if (ruptureCount <= 0)
            {
                rupturePotency = 0;
                ruptureTimer = 0;
            }
        }

        public override void AI(NPC npc)
        {
            // reduce rupture timer if rupture count not applied
            if (ruptureCount > 0)
            {
                ruptureTimer++;

                // after 10 seconds, reset rupture
                if (ruptureTimer >= 600)
                {
                    rupturePotency = 0;
                    ruptureCount = 0;
                    ruptureTimer = 0;
                }
            }
        }

        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref NPC.HitModifiers modifiers)
        {
            ApplyRupture(npc, ref modifiers);
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            ApplyRupture(npc, ref modifiers);
        }

        private void ApplyRupture(NPC npc, ref NPC.HitModifiers modifiers)
        {
            if (ruptureCount > 0 || rupturePotency > 0)
            {
                // reduce rupture count
                ruptureCount--;

                // Reset the timer
                ruptureTimer = 0;

                // fixed damage from potency
                int trueDamage = rupturePotency; 
                npc.life -= trueDamage;  

                // small dusts when the enemy is hit
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 160, 0f, 0f, 0, Color.Cyan, 1.5f);
                }

                // display rupture damage and count
                CombatText.NewText(npc.Hitbox, Color.Cyan, rupturePotency, true);

                if (ruptureCount > 0)
                {
                Rectangle textPosition = new Rectangle(npc.Hitbox.X, npc.Hitbox.Bottom + 100, npc.Hitbox.Width, 10);
                CombatText.NewText(textPosition, Color.Lime, ruptureCount, true);
                }
            }

            if (ruptureCount == 1)
            {
                rupturePotency = 0; 
            }

            if (ruptureCount <= 0)
            {
                rupturePotency = 0;
            }
        }
    }
}

