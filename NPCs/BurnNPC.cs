using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using ReLogic.Graphics; 

namespace LimbusMod.NPCs
{
    public class BurnNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        // Burn variables
        public int burnPotency = 0; // Potency
        public int burnCount = 0;  // Count
        private int burnTimer = 0; // Timer to trigger burn damage

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
        }

        public override void AI(NPC npc)
        {
            if (burnCount > 0)
            {
                burnTimer++;

                // Trigger burn damage every 3 seconds (180 ticks)
                if (burnTimer >= 180)
                {
                    ApplyBurn(npc);
                    burnTimer = 0; // Reset timer after applying burn
                }
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

                // Particules
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Torch, 0f, 0f, 0, Color.Red, 1.5f);
                }

                // damage displayed
                CombatText.NewText(npc.Hitbox, Color.Red, burnDamage, true);
            }

            if (burnCount <= 0)
            {
                burnPotency = 0;
            }
        }

        // Draw the burn count/potency counter
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (burnCount > 0 || burnPotency > 0) // displays only if the target is burn
            {
                string burnText = $"{burnPotency} / {burnCount}";
                DynamicSpriteFont font = FontAssets.MouseText.Value; // Recup the font
                float scale = 1.35f; 
                Vector2 textSize = font.MeasureString(burnText) * scale;

                // fix the position under the entity
                Vector2 textPosition = npc.Bottom - Main.screenPosition;
                textPosition.Y += 10; 
                textPosition.X -= textSize.X / 2; 

                // text
                spriteBatch.DrawString(font, burnText, textPosition, Color.Red, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }
    }
}




