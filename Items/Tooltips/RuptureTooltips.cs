using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.Localization;

namespace LimbusMod.Items.Tooltips
{
    public class RuptureTooltips : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {   //Go to Localization/US.hjson to see the tooltips 
            if (item.type == ItemID.CobaltSword)
            {
                int rupturePotency = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }
            
            if (item.type == ItemID.DD2SquireDemonSword) 
            {
                int ruptureCount = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }
            
            if (item.type == ItemID.EnchantedSword)
            {
                int ruptureCount = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.CobaltNaginata)
            {
                int ruptureCount = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }
        }
    }
}