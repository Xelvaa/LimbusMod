using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.DataStructures;
using ReLogic.Graphics;

namespace LimbusMod.Players
{
    public class PoisePlayer : ModPlayer
    {
        // Poise variables
        public int poisePotency = 0; // Poise Potency
        public int poiseCount = 0;   // Poise Count

        public override void ResetEffects()
        {
            // Enforce poise count limit (max 99)
            if (poiseCount > 99)
            {
                poiseCount = 99;
            }

            // Enforce poise potency limit (max 99, no game progression restrictions)
            poisePotency = System.Math.Min(poisePotency, 99);

            // Ensure consistency: if count is 0, potency should be 0; if count > 0, potency must be at least 1
            if (poiseCount == 0 && poisePotency > 0)
            {
                poisePotency = 0;
            }
            if (poiseCount > 0 && poisePotency <= 0)
            {
                poisePotency = 1;
            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (poiseCount > 0)
            {
                // Calculate Poise Crit chance (5% * Poise Potency)
                float poiseCritChance = poisePotency * 0.05f;
                bool isPoiseCrit = Main.rand.NextFloat() < poiseCritChance;

                if (isPoiseCrit)
                {
                    // Apply 20% multiplicative damage increase
                    modifiers.FinalDamage *= 1.2f;
                    poiseCount--; // Reduce poise count by 1 on crit
                }

                // Display blue dust effect
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(target.position, target.width, target.height, DustID.BlueTorch, 0f, 0f, 0, Color.Blue, 1.5f);
                }
            }

            // Reset potency when poise count runs out
            if (poiseCount <= 0)
            {
                poisePotency = 0;
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (poiseCount > 0)
            {
                // Calculate Poise Crit chance (5% * Poise Potency)
                float poiseCritChance = poisePotency * 0.05f;
                bool isPoiseCrit = Main.rand.NextFloat() < poiseCritChance;

                if (isPoiseCrit)
                {
                    // Apply 20% multiplicative damage increase
                    modifiers.FinalDamage *= 1.2f;
                    poiseCount--; // Reduce poise count by 1 on crit
                }

                // Display blue dust effect
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(target.position, target.width, target.height, DustID.BlueTorch, 0f, 0f, 0, Color.Blue, 1.5f);
                }
            }

            // Reset potency when poise count runs out
            if (poiseCount <= 0)
            {
                poisePotency = 0;
            }
        }

        // Draw the poise counter under the player
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (poiseCount > 0 || poisePotency > 0) // Display only if poise is active
            {
                string poiseText = $"{poisePotency} / {poiseCount}";
                DynamicSpriteFont font = FontAssets.MouseText.Value;
                float scale = 1.35f;
                Vector2 textSize = font.MeasureString(poiseText) * scale;

                // Position under the player
                Vector2 textPosition = Player.Bottom - Main.screenPosition;
                textPosition.Y += 10; // Adjust height under the player
                textPosition.X -= textSize.X / 2;

                // Draw the text in blue (hex #0000FF)
                Main.spriteBatch.DrawString(font, poiseText, textPosition, Color.Blue, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }
    }
}