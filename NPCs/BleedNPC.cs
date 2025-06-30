using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using ReLogic.Graphics; 

namespace LimbusMod.NPCs
{
    public class BleedNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        // Bleed variables
        public int bleedPotency = 0; // Potency
        public int bleedCount = 0;  // Count
        private int bleedTimer = 0; // Timer to trigger Bleed damage

        public override void ResetEffects(NPC npc)
        {
            if (bleedCount > 60)
            {
                bleedCount = 60;
            }

            if (!Main.hardMode)
            {
                bleedPotency = Math.Min(bleedPotency, 20);
            }
            else if (Main.hardMode && !NPC.downedPlantBoss)
            {
                bleedPotency = Math.Min(bleedPotency, 40);
            }
            else if (NPC.downedPlantBoss)
            {
                bleedPotency = Math.Min(bleedPotency, 60);
            }

            if (bleedCount > 0 && bleedPotency <= 0)
            {
                bleedPotency = 1;
            }

            if (bleedCount <= 0)
            {
                bleedPotency = 0;
                bleedTimer = 0;
            }
        }

        public override void AI(NPC npc)
        {
            if (bleedCount > 0)
            {
                bleedTimer++;

                // Trigger Bleed damage every second (60 ticks)
                if (bleedTimer >= 60)
                {
                    ApplyBleed(npc);
                    bleedTimer = 0; // Reset timer after applying Bleed
                }
            }
        }

        private void ApplyBleed(NPC npc)
        {
            bleedTimer = 0;

            if (bleedCount > 0 || bleedPotency > 0)
            {
                // Bleed count reduction
                bleedCount--;

                // Damage equals to Bleed potency
                int bleedDamage = bleedPotency;
                npc.life -= bleedDamage;

                // Dusts
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, 0f, 0f, 0, Color.Red, 1.5f);
                }

                // damage displayed
                CombatText.NewText(npc.Hitbox, Color.Orange, bleedDamage, true);
            }

            if (bleedCount <= 0)
            {
                bleedPotency = 0;
            }
        }

        // Draw the Bleed count/potency counter
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (bleedCount > 0 || bleedPotency > 0) // Displays only if the target is Bleed
            {
                string bleedText = $"{bleedPotency} / {bleedCount}";
                DynamicSpriteFont font = FontAssets.MouseText.Value; // Recup the font
                float scale = 1.35f; 
                Vector2 textSize = font.MeasureString(bleedText) * scale;

                // Fix the position under the npc
                Vector2 textPosition = npc.Bottom - Main.screenPosition;
                textPosition.Y += 10; 
                textPosition.X -= textSize.X / 2; 

                // Text
                spriteBatch.DrawString(font, bleedText, textPosition, Color.Orange, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }
    }
}




