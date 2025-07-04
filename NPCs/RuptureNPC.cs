using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using ReLogic.Graphics; 
using LimbusMod.Players;

namespace LimbusMod.NPCs
{
    public class RuptureNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        // Rupture variables
        public int rupturePotency = 0; // Potency
        public int ruptureCount = 0;  // Count
        private int thrillDamageTimer = 0;

        public override void ResetEffects(NPC npc)
        {
            // Enforcing rupture count limit (always 99 max)
            if (ruptureCount > 60)
            {
                ruptureCount = 60;
            }

            if (!Main.hardMode)
            {
                rupturePotency = Math.Min(rupturePotency, 20);
            }
            else if (Main.hardMode && !NPC.downedPlantBoss)
            {
                rupturePotency = Math.Min(rupturePotency, 40);
            }
            else if (NPC.downedPlantBoss)
            {
                rupturePotency = Math.Min(rupturePotency, 60);
            }

             if (Main.player[npc.target].GetModPlayer<RupturePlayer>().hasThrill)
            {
                if (ruptureCount == 0 && rupturePotency == 0)
                {
                    rupturePotency = 4;
                    ruptureCount = 3;
                }
            }

            if (ruptureCount == 0 && rupturePotency > 0)
            {
                ruptureCount = 1;
            }

            if (ruptureCount > 0 && rupturePotency <= 0)
            {
                rupturePotency = 1;
            }
        }

        public override void AI(NPC npc)
        {
            if (Main.player[npc.target].GetModPlayer<RupturePlayer>().hasThrill && rupturePotency >= 5)
            {
                thrillDamageTimer++;
                int ticksPer5Seconds = 60 * 5;
                if (thrillDamageTimer >= ticksPer5Seconds)
                {
                    int trueDamage = (rupturePotency * ruptureCount) / 2;
                    npc.life -= trueDamage;
                    ruptureCount--;
                    ruptureCount--;

                    CombatText.NewText(npc.Hitbox, Color.Cyan, trueDamage, true);

                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, 160, 0f, 0f, 0, Color.Cyan, 1.75f);
                    }

                    thrillDamageTimer = 0;
                }
            }
        }

        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref NPC.HitModifiers modifiers)
        {
            ApplyRupture(npc, ref modifiers, player, item.type, -1); 
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            Player player = Main.player[projectile.owner];
            ApplyRupture(npc, ref modifiers, player, -1, projectile.type); 
        }

        private void ApplyRupture(NPC npc, ref NPC.HitModifiers modifiers, Player player, int itemId, int projectileId)
        {
            if ((itemId != -1 && LimbusMod.LimbusModExclusions.ExcludedItems.Contains(itemId)) || 
                (projectileId != -1 && LimbusMod.LimbusModExclusions.ExcludedProjectiles.Contains(projectileId)))
            {
                return;
            }

            if ((itemId != -1 && LimbusMod.LimbusModExclusions.SemiExcludedItems.Contains(itemId)) || 
                (projectileId != -1 && LimbusMod.LimbusModExclusions.SemiExcludedProjectiles.Contains(projectileId)) &&
                 Main.rand.NextFloat() < 0.80f)
            {
                return;
            }
            
            if (ruptureCount > 0)
            {
                ruptureCount--;

                // Check if the player has Bone Stake
                bool hasBoneStake = player.GetModPlayer<RupturePlayer>().hasBoneStake;
                
                float damageMultiplier = hasBoneStake ? 1.2f : 1f;
                int trueDamage = (int)(rupturePotency * damageMultiplier); 
                // Apply rupture damage 
                npc.life -= trueDamage;

                // Small dusts when the enemy is hit
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 160, 0f, 0f, 0, Color.Cyan, 1.5f);
                }

                // Display rupture damage
                CombatText.NewText(npc.Hitbox, Color.Cyan, trueDamage, true);
            }

            // Reset potency when rupture count runs out
            if (ruptureCount <= 0)
            {
                bool hasThornyRopeCuffs = player.GetModPlayer<RupturePlayer>().hasThornyRopeCuffs;
                if (hasThornyRopeCuffs && rupturePotency > 8)
                {
                    rupturePotency = Math.Max(1, rupturePotency - 10); 
                    ruptureCount = 1;
                }
                else
                {
                    rupturePotency = 0; 
                }
            }
        }

        // Draw the rupture counter under the NPC
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            bool hasThrill = Main.player[npc.target].GetModPlayer<RupturePlayer>().hasThrill;

            if ((ruptureCount > 0 || rupturePotency > 0) && (!hasThrill || rupturePotency > 4))// Display only if rupture is active
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



