using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace LimbusMod.Buffs
{
    public class PoiseBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false; // Show remaining time for the buff
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            // Custom debuff logic handled in ModNPC
        }
    }
}