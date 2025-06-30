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
    public class BurnPlayer : ModPlayer
    {
        public bool hasParaffin; 
        public bool hasStewpot; 
        public bool hasAshes; 
        public bool hasGlimpseOfFlames;

        public override void ResetEffects()
        {
            hasParaffin = false;
            hasGlimpseOfFlames = false;
        }

        private void ApplyBurnEffects(NPC target, bool isFromWeapon, bool isFromProjectile)
        {
            BurnNPC burnNPC = target.GetGlobalNPC<BurnNPC>();

            if (hasParaffin)
            {
                burnNPC.burnPotency += 1;
            }
        }

        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
        }
    }
}