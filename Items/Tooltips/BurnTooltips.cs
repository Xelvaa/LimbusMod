/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.Localization;

namespace LimbusMod.Items.Tooltips
{
    public class BurnTooltips : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {   //Go to Localization/US.hjson to see the tooltips 
            if (item.type == ItemID.FieryGreatsword)
            {
                int burnPotency = 3; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BurnPotency", burnPotency);
                tooltips.Add(new TooltipLine(Mod, "Burn", text));
            }
            
            if (item.type == ItemID.DD2SquireDemonSword) 
            {
                int burnCount = 1; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BurnCount", burnCount);
                tooltips.Add(new TooltipLine(Mod, "Burn", text));
            }
            
            if (item.type == ItemID.TheHorsemansBlade) 
            {
                int burnPotency = 5; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BurnPotency", burnPotency);
                tooltips.Add(new TooltipLine(Mod, "Burn", text));
            }

            if (item.type == ItemID.Flamelash) 
            {
                int burnPotency = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BurnPotency", burnPotency);
                tooltips.Add(new TooltipLine(Mod, "Burn", text));
            }

            if (item.type == ItemID.Sunfury) 
            {
                int burnCount = 1; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BurnCount", burnCount);
                tooltips.Add(new TooltipLine(Mod, "Burn", text));
            }

            if (item.type == ItemID.LunarFlareBook) 
            {
                int burnPotency = 1; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.BurnPotency", burnPotency);
                tooltips.Add(new TooltipLine(Mod, "Burn", text));
            }
        }
    }
}*/