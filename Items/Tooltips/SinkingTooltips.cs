/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.Localization;

namespace LimbusMod.Items.Tooltips
{
    public class SinkingTooltips : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {   //Go to Localization/US.hjson to see the tooltips 
            if (item.type == ItemID.PurpleClubberfish)
            {
                int sinkingPotency = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.SinkingPotency", sinkingPotency);
                tooltips.Add(new TooltipLine(Mod, "Sinking", text));
            }
            
            if (item.type == ItemID.Muramasa) 
            {
                int sinkingPotency = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.SinkingPotency", sinkingPotency); 
                tooltips.Add(new TooltipLine(Mod, "Sinking", text));
            }
            
            if (item.type == ItemID.WaterBolt)
            {
                int sinkingPotency = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.SinkingPotency", sinkingPotency);
                tooltips.Add(new TooltipLine(Mod, "Sinking", text));
            }

            if (item.type == ItemID.AquaScepter)
            {
                int sinkingCount = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.SinkingCount", sinkingCount);
                tooltips.Add(new TooltipLine(Mod, "Sinking", text));
            }

            if (item.type == ItemID.BubbleGun)
            {
                int sinkingPotency = 1; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.SinkingPotency", sinkingPotency);
                tooltips.Add(new TooltipLine(Mod, "Sinking", text));
            }

            if (item.type == ItemID.RazorbladeTyphoon)
            {
                int sinkingCount = 2; 
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.SinkingCount", sinkingCount);
                tooltips.Add(new TooltipLine(Mod, "Sinking", text));
            }
        }
    }
}*/