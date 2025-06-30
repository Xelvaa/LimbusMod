/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.Localization;

namespace LimbusMod.Items.Tooltips
{
    public class BleedTooltips : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {   //Go to Localization/US.hjson to see the tooltips 
            if (item.type == ItemID.BloodButcherer)
            {
                int bleedPotency = 3; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BleedPotency", bleedPotency);
                tooltips.Add(new TooltipLine(Mod, "Bleed", text));
            }
            
            if (item.type == ItemID.DD2SquireBetsySword) 
            {
                int bleedCount = 1; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BleedCount", bleedCount);
                tooltips.Add(new TooltipLine(Mod, "Bleed", text));
            }
            
            if (item.type == ItemID.SanguineStaff) 
            {
                int bleedPotency = 1; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BleedPotency", bleedPotency);
                tooltips.Add(new TooltipLine(Mod, "Bleed", text));
            }

            if (item.type == ItemID.SharpTears) 
            {
                int bleedCount = 1; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BleedPotency", bleedCount);
                tooltips.Add(new TooltipLine(Mod, "Bleed", text));
            }

            if (item.type == ItemID.IchorArrow) 
            {
                int bleedPotency = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BleedCount", bleedPotency);
                tooltips.Add(new TooltipLine(Mod, "Bleed", text));
            }

            if (item.type == ItemID.IchorBullet) 
            {
                int bleedPotency = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BleedPotency", bleedPotency);
                tooltips.Add(new TooltipLine(Mod, "Bleed", text));
            }
        }
    }
}*/