using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.Localization;

namespace LimbusMod.Items.Tooltips
{
    public class TremorTooltips : GlobalItem 
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.BreakerBlade)
            {
                int tremorBurst = 33; // Chance to trigger tremor burst
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.TremorBurst", tremorBurst);
                tooltips.Add(new TooltipLine(Mod, "Tremor", text)); 
            }
            
            // Vérifier pour DD2SquireDemonSword
            if (item.type == ItemID.AdamantiteSword)
            {
                int tremorPotency = 3;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.TremorPotency", tremorPotency);
                tooltips.Add(new TooltipLine(Mod, "Tremor", text));
            }

            if (item.type == ItemID.MaceWhip)
            {
                int tremorCount = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.TremorCount", tremorCount);
                tooltips.Add(new TooltipLine(Mod, "Tremor", text));
            }
        
        }
    }
}