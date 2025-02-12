using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using ReLogic.Graphics; 

namespace LimbusMod.NPCs
{
    public class RuptureNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        // Rupture variables
        public int rupturePotency = 0; // Potency
        public int ruptureCount = 0;  // Count

        public override void ResetEffects(NPC npc)
        {
            if (ruptureCount > 0 && rupturePotency <= 0)
            {
                rupturePotency = 1; 
            }
            if (ruptureCount <= 0)
            {
                rupturePotency = 0;
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
                ruptureCount--;

                // Fixed damage from potency
                int trueDamage = rupturePotency; 
                npc.life -= trueDamage;  

                // Small dusts when the enemy is hit
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 160, 0f, 0f, 0, Color.Cyan, 1.5f);
                }

                // Display rupture damage
                CombatText.NewText(npc.Hitbox, Color.Cyan, rupturePotency, true);
            }

            if (ruptureCount == 1 || ruptureCount <= 0)
            {
                rupturePotency = 0; 
            }
        }

        // Draw the rupture counter under the NPC
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (ruptureCount > 0 || rupturePotency > 0) // Display only if rupture is active
            {
                string ruptureText = $"{rupturePotency} / {ruptureCount}";
                DynamicSpriteFont font = FontAssets.MouseText.Value; 
                float scale = 1.35f;
                Vector2 textSize = font.MeasureString(ruptureText) * scale;

                // Position under the NPC with automatic stacking
                Vector2 textPosition = npc.Bottom - Main.screenPosition;
                textPosition.Y += 10; // Adjust height under the NPC
                textPosition.X -= textSize.X / 2; 

                // Draw the text
                spriteBatch.DrawString(font, ruptureText, textPosition, Color.Cyan, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }
    }
}


