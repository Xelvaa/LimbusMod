using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace LimbusMod.NPCs
{
    public class BurnNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        // Burn variables
        public int burnPotency = 0; // Potency
        public int burnCount = 0;  // Count
        private int burnTimer = 0; // Timer to trigger burn damage

        private int previousBurnPotency = 0;
        private int previousBurnCount = 0;

        public override void ResetEffects(NPC npc)
        {
            if (burnCount > 0 && burnPotency <= 0)
            {
                burnPotency = 1;
            }

            if (burnCount <= 0)
            {
                burnPotency = 0;
                burnTimer = 0;
            }

            DisplayBurnInfo(npc);
        }

        public override void AI(NPC npc)
        {
            if (burnCount > 0)
            {
                burnTimer++;

                // displays immediately the values when they are changed 
                DisplayBurnInfo(npc);

                // Trigger burn damage every 3 seconds (180 ticks)
                if (burnTimer >= 180)
                {
                    ApplyBurn(npc);
                    burnTimer = 0; // Reset timer after applying burn
                }
            }
        }

        private void DisplayBurnInfo(NPC npc)
        {
            if (burnPotency != previousBurnPotency)
            {
                CombatText.NewText(npc.Hitbox, Color.OrangeRed, burnPotency, true);
                previousBurnPotency = burnPotency;
            }

            if (burnCount != previousBurnCount)
            {
                Rectangle textPosition = new Rectangle(npc.Hitbox.X, npc.Hitbox.Bottom + 100, npc.Hitbox.Width, 10);
                CombatText.NewText(textPosition, Color.Orange, burnCount, true);
                previousBurnCount = burnCount;
            }
        }

        private void ApplyBurn(NPC npc)
        {
            burnTimer = 0;

            if (burnCount > 0 || burnPotency > 0)
            {
                // burn count reduction
                burnCount--;

                // damage equals to burn potency
                int burnDamage = burnPotency;
                npc.life -= burnDamage;

                // particules
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Torch, 0f, 0f, 0, Color.OrangeRed, 1.5f);
                }

                // displays the burn damage
                CombatText.NewText(npc.Hitbox, Color.Red, burnDamage, true);
            }

            if (burnCount <= 0)
            {
                burnPotency = 0;
            }
        }
    }
}

