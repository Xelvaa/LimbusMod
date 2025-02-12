using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Audio; 

namespace LimbusMod.NPCs
{
    public class TremorNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        // Tremor variables
        public int tremorPotency = 0; // potency
        public int tremorCount = 0;   // count

        public override void ResetEffects(NPC npc)
        {
            if (tremorCount > 0 && tremorPotency <= 0)
            {
                tremorPotency = 1;
            }

            if (tremorCount <= 0)
            {
                tremorPotency = 0;
            }
        }

        public override void AI(NPC npc)
        {
        }

        // Apply the Tremor debuff through item or projectile hits
        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref NPC.HitModifiers modifiers)
        {
            ApplyTremor(npc, ref modifiers);
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            ApplyTremor(npc, ref modifiers);
        }   
        
        private void ApplyTremor(NPC npc, ref NPC.HitModifiers modifiers)
        {

            if (tremorPotency <= 0 && tremorCount <= 0)
            {
                return;
            }
        }

        // Tremor Burst area
        public static void ApplyTremorBurstStatic(NPC npc, float chance, ref int tremorPotency, ref int tremorCount)
        {
            if (Main.rand.NextFloat() < chance)
            {
                if (tremorPotency > 0)
                {
                    // Explosion radius
                    float radius = 3 + (tremorPotency / 20f);

                    // Tremor Burst sound
                    Terraria.Audio.SoundEngine.PlaySound(new Terraria.Audio.SoundStyle("LimbusMod/Sounds/TremorBurstSound"));

                    foreach (NPC target in Main.npc)
                    {
                        if (target.active && !target.friendly && target.Distance(npc.Center) <= radius * 16f)
                        {
                            // Applies true damage equal to tremor potency x 5
                            int trueDamage = tremorPotency * 5;
                            target.life -= trueDamage;

                            // Dust part
                            for (int i = 0; i < tremorPotency; i++)
                            {
                                Dust dust = Dust.NewDustDirect(target.position, target.width, target.height, 64, 0f, 0f, 0, Color.Yellow, 0.75f);
                                
                                // Increase the scale of the dusts when the tremor potency is higher
                                dust.scale = 1f + (trueDamage * 0.005f);

                                float velocityMultiplier = 2f + (trueDamage * 0.02f); 
                                dust.velocity = new Vector2(
                                    Main.rand.NextFloat(-1f, 1f) * velocityMultiplier, 
                                    Main.rand.NextFloat(-1f, 1f) * velocityMultiplier  
                                );

                                dust.noGravity = true;

                                dust.rotation = Main.rand.NextFloat(0f, MathHelper.TwoPi);
                            }

                            if (tremorPotency > 0)
                            {
                                CombatText.NewText(target.Hitbox, Color.Yellow, trueDamage, true);
                            }
                        }
                    }

                    tremorCount--;
                }
            }
        }

        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (tremorCount > 0 || tremorPotency > 0) // displays only if the target has tremor
            {
                string tremorText = $"{tremorPotency} / {tremorCount}";
                DynamicSpriteFont font = FontAssets.MouseText.Value; // Recup the font
                float scale = 1.35f; 
                Vector2 textSize = font.MeasureString(tremorText) * scale;

                // fix the position under the entity
                Vector2 textPosition = npc.Bottom - Main.screenPosition;
                textPosition.Y += 10; 
                textPosition.X -= textSize.X / 2; 

                // text
                spriteBatch.DrawString(font, tremorText, textPosition, Color.Yellow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }
    }
}


