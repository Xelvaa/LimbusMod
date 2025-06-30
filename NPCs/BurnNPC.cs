using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LimbusMod.Items.Accessories;
using LimbusMod.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using ReLogic.Graphics;

namespace LimbusMod.NPCs
{
    public class BurnNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public int burnPotency = 0;
        public int burnCount = 0;
        private int burnTimer = 0;

        public override void ResetEffects(NPC npc)
        {
            if (burnCount > 99)
            {
                burnCount = 99;
            }

            if (!Main.hardMode)
            {
                burnPotency = Math.Min(burnPotency, 33);
            }
            else if (Main.hardMode && !NPC.downedPlantBoss)
            {
                burnPotency = Math.Min(burnPotency, 66);
            }
            else if (NPC.downedPlantBoss)
            {
                burnPotency = Math.Min(burnPotency, 99);
            }

            if (burnCount == 0 && burnPotency > 0)
            {
                burnCount = 1;
            }

            if (burnCount > 0 && burnPotency <= 0)
            {
                burnPotency = 1;
            }
        }

        public override void AI(NPC npc)
        {
            if (burnCount > 0)
            {
                burnTimer++;

                if (burnTimer >= 90)
                {
                    ApplyBurn(npc);
                    burnTimer = 0;
                }
            }
        }

        private void ApplyBurn(NPC npc)
        {
            burnTimer = 0;

            if (burnCount > 0)
            {
                burnCount--; 
                bool hasGlimpse = Main.LocalPlayer.GetModPlayer<BurnPlayer>().hasGlimpseOfFlames;
                int burnDamage = burnPotency; 

                npc.life -= burnDamage;

                if (hasGlimpse)
                {
                    int bonusDamage = (burnPotency * burnCount) / 3;
                    npc.life -= bonusDamage; 
                    burnCount = burnCount / 2; 

                    CombatText.NewText(npc.Hitbox, Color.OrangeRed, bonusDamage, true);
                }

                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Torch, 0f, 0f, 0, Color.Red, 1.5f);
                }

                CombatText.NewText(npc.Hitbox, Color.Red, burnDamage, true);
            }

            if (burnCount <= 0)
            {
                burnPotency = 0;
            }
        }

        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (burnCount > 0 || burnPotency > 0)
            {
                string burnText = $"{burnPotency} / {burnCount}";
                DynamicSpriteFont font = FontAssets.MouseText.Value;
                float scale = 1.35f;
                Vector2 textSize = font.MeasureString(burnText) * scale;

                Vector2 textPosition = npc.Bottom - Main.screenPosition;
                textPosition.Y += 10;
                textPosition.X -= textSize.X / 2;

                spriteBatch.DrawString(font, burnText, textPosition, Color.Red, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }
    }
}



