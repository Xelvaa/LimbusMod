using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using ReLogic.Graphics; 
using LimbusMod.NPCs;
using LimbusMod.Items;


namespace LimbusMod.Players
{
    public class RupturePlayer : ModPlayer
    {
        public bool hasBattery; 
        public bool hasThornyRopeCuffs;
        public bool hasTalisman;
        public bool hasThunderbranch; 
        public bool hasRevolver; 
        public bool hasBoneStake; 
        public bool hasApocalypseShard; 
        public bool hasRuin;    
        public bool hasThrill;

        private int thornyRopeCuffsTimer = 0; 
        private int thornyRopeCuffsApplications = 0;

        public override void ResetEffects()
        {
            hasBattery = false;
            hasTalisman = false;
            hasThornyRopeCuffs = false;
            hasThunderbranch = false;
            hasRevolver = false;
            hasBoneStake = false;
            hasApocalypseShard = false;
            hasRuin = false;
            hasThrill = false;

        if (!hasThornyRopeCuffs)
            {
                thornyRopeCuffsTimer = 0;
                thornyRopeCuffsApplications = 0;
            }
        }

        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (LimbusMod.LimbusModExclusions.ExcludedItems.Contains(item.type))
            {
                return; 
            }
            ApplyRuptureEffects(target, true, false); 
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (LimbusMod.LimbusModExclusions.ExcludedProjectiles.Contains(proj.type))
            {
                return; 
            }

            if (LimbusMod.LimbusModExclusions.SemiExcludedProjectiles.Contains(proj.type))
            {
                if (Main.rand.NextFloat() < 0.80f)
                {
                    return; 
                } 
            }
            ApplyRuptureEffects(target, false, true); 
        }
        
        private void ApplyRuptureEffects(NPC target, bool isFromWeapon, bool isFromProjectile)
        {
            RuptureNPC ruptureNPC = target.GetGlobalNPC<RuptureNPC>();

            int previousRuptureCount = ruptureNPC.ruptureCount;

            if (hasBattery)
            {
                ruptureNPC.rupturePotency += 2;
            }

            if (hasTalisman)
            {
                ruptureNPC.rupturePotency += 1;
            }

            if (hasThunderbranch)
            {
                ruptureNPC.rupturePotency += 1;

                if (Main.rand.NextFloat() < 0.5f)
                {
                    ruptureNPC.ruptureCount += 1;
                }
            }

            if (hasApocalypseShard && ruptureNPC.ruptureCount >= 20 && Main.rand.NextFloat() < 0.2f)
            {
                float radius = 15f * 16f; 
                Vector2 targetCenter = target.Center;

                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && npc != target && Vector2.Distance(targetCenter, npc.Center) <= radius)
                    {
                        RuptureNPC nearbyRuptureNPC = npc.GetGlobalNPC<RuptureNPC>();
                        if (nearbyRuptureNPC.ruptureCount > 0)
                        {
                            bool hasBoneStake = Player.GetModPlayer<RupturePlayer>().hasBoneStake;
                            float damageMultiplier = hasBoneStake ? 1.2f : 1f;
                            int trueDamage = (int)(ruptureNPC.rupturePotency * damageMultiplier);
                            npc.life -= trueDamage;

                            CombatText.NewText(npc.Hitbox, Color.Cyan, trueDamage, true);

                            for (int i = 0; i < 5; i++)
                            {
                                Dust.NewDust(npc.position, npc.width, npc.height, 160, 0f, 0f, 0, Color.Cyan, 1.5f);
                            }
                        }
                    }
                }
            }
        }

        public override void PostUpdate()
        {
            if (hasThornyRopeCuffs)
            {
                thornyRopeCuffsTimer++;
                int ticksPer12Seconds = 60 * 12;

                if (thornyRopeCuffsTimer >= ticksPer12Seconds && thornyRopeCuffsApplications < 3)
                {
                    RuptureNPC ruptureNPC = target.GetGlobalNPC<RuptureNPC>();
                    ruptureNPC.ruptureCount += 1; 
                    thornyRopeCuffsApplications++;

                    if (thornyRopeCuffsApplications >= 3)
                    {
                        thornyRopeCuffsTimer = 0;
                        thornyRopeCuffsApplications = 0;
                    }
                }
            }
        }

        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            if (hasRevolver && npc.TryGetGlobalNPC(out RuptureNPC ruptureNPC))
            {
                int potency = ruptureNPC.rupturePotency;

                float damageReduction = 1f - (0.005f * potency);
                modifiers.FinalDamage *= Math.Max(damageReduction, 0.1f); 

                int defenseReduction = (int)(npc.defense * 0.003f * potency);
                npc.defense = Math.Max(npc.defense - defenseReduction, 0); 
            }
        }
    }
}