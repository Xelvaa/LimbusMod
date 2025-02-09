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
        private int tremorTimer = 0;  // Reset tremor count

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
        
        private int previousTremorPotency = 0;
        private int previousTremorCount = 0;

        private void ApplyTremor(NPC npc, ref NPC.HitModifiers modifiers)
        {

            if (tremorPotency <= 0 && tremorCount <= 0)
            {
                return;
            }

            if (tremorPotency > 0)                
            {
                if (tremorPotency != previousTremorPotency)                
                {             
                CombatText.NewText(npc.Hitbox, Color.Yellow, tremorPotency, true);
                previousTremorPotency = tremorPotency; 
                }
            }

            if (tremorCount > 0)
            {
                if (tremorCount != previousTremorCount)                
                {   
                Rectangle textPosition = new Rectangle(npc.Hitbox.X, npc.Hitbox.Bottom + 100, npc.Hitbox.Width, 10);
                CombatText.NewText(textPosition, Color.Orange, tremorCount, true);
                previousTremorCount = tremorCount;
                }
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
                                dust.scale = 0.75f + (trueDamage * 0.01f);

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
    }
}


