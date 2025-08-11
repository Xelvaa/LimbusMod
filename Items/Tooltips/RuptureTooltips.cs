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
        {
            // Tooltips 
            if (item.type == ItemID.CobaltSword)
            {
                int rupturePotency = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                string cobaltText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.CobaltSword");
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
                tooltips.Add(new TooltipLine(Mod, "Cobalt", cobaltText));
            }

            if (item.type == ItemID.NightsEdge)
            {
                int rupturePotency = 2;
                string potencyText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                TooltipLine potencyTooltip = new TooltipLine(Mod, "RupturePotency", potencyText);
                tooltips.Add(potencyTooltip);

                string additionalText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.NightEdge");
                TooltipLine additionalTooltip = new TooltipLine(Mod, "NightEdgeExtra", additionalText);

                int potencyIndex = tooltips.IndexOf(potencyTooltip);
                if (potencyIndex != -1)
                {
                    tooltips.Insert(potencyIndex + 1, additionalTooltip);
                }
                else
                {
                    tooltips.Add(additionalTooltip);
                }
            }

            if (item.type == ItemID.TrueNightsEdge)
            {
                int rupturePotency = 2;
                string potencyText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                TooltipLine potencyTooltip = new TooltipLine(Mod, "RupturePotency", potencyText);
                tooltips.Add(potencyTooltip);

                string additionalText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.TrueNightEdge");
                TooltipLine additionalTooltip = new TooltipLine(Mod, "TrueNightEdgeExtra", additionalText);

                int potencyIndex = tooltips.IndexOf(potencyTooltip);
                if (potencyIndex != -1)
                {
                    tooltips.Insert(potencyIndex + 1, additionalTooltip);
                }
                else
                {
                    tooltips.Add(additionalTooltip);
                }
            }

            if (item.type == ItemID.DD2SquireDemonSword)
            {
                int ruptureCount = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.EnchantedSword)
            {
                int rupturePotency = 1; 
                int ruptureCount = 2;   
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureMelee", rupturePotency, ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.CobaltNaginata)
            {
                int ruptureCount = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.Meowmere)
            {
                int rupturePotency = 1; 
                int ruptureCount = 3;   
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureMelee", rupturePotency, ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.TerraBlade)
            {
                int rupturePotency = 1;
                int ruptureCount = 3;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureMelee", rupturePotency, ruptureCount);
                string terraText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.TerraBlade");
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
                tooltips.Add(new TooltipLine(Mod, "RuptureExcalibur", terraText));
            }

            if (item.type == ItemID.Excalibur)
            {
                int rupturePotency = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                string excaliburText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.Excalibur");
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
                tooltips.Add(new TooltipLine(Mod, "RuptureExcalibur", excaliburText));
            }

            if (item.type == ItemID.TrueExcalibur)
            {
                int rupturePotency = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                string excaliburText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.TrueExcalibur");
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
                tooltips.Add(new TooltipLine(Mod, "RuptureExcalibur", excaliburText));
            }

            if (item.type == ItemID.Code1)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.Chik)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.Gungnir)
            {
                int ruptureCount = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.EnchantedBoomerang)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.Trimarang)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.BallOHurt)
            {
                int ruptureCount = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.DaoofPow)
            {
                int ruptureCount = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.Arkhalis)
            {
                int rupturePotency = 1;
                int ruptureCount = 1;
                string potencyText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                string countText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "RupturePotency", potencyText));
                tooltips.Add(new TooltipLine(Mod, "RuptureCount", countText));
            }

            if (item.type == ItemID.Terragrim)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.PiercingStarlight)
            {
                int ruptureCount = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.DemonBow || item.type == ItemID.CobaltRepeater || item.type == ItemID.HallowedRepeater || item.type == ItemID.FairyQueenRangedItem)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.Bows", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.IceBow)
            {
                int ruptureCount = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.HolyArrow)
            {
                int rupturePotencyChance = 50;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotencyChance", rupturePotencyChance);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.CursedBullet)
            {
                int rupturePotencyChance = 50;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotencyChance", rupturePotencyChance);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.CursedArrow)
            {
                int rupturePotencyChance = 50;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotencyChance", rupturePotencyChance);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.ShimmerArrow)
            {
                int rupturePotencyChance = 50;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotencyChance", rupturePotencyChance);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.JestersArrow)
            {
                int rupturePotencyChance = 50;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotencyChance", rupturePotencyChance);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.CrystalBullet)
            {
                int rupturePotencyChance = 50;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotencyChance", rupturePotencyChance);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.NanoBullet)
            {
                int rupturePotencyChance = 50;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotencyChance", rupturePotencyChance);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.EmeraldStaff)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.MagicMissile)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.SkyFracture)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.CrystalVileShard)
            {
                int ruptureCount = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.BookStaff)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.ShadowbeamStaff)
            {
                int rupturePotency = 2;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.CrystalStorm)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.MagicalHarp)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.FairyQueenMagicItem)
            {
                int rupturePotency = 1;
                string text = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                tooltips.Add(new TooltipLine(Mod, "Rupture", text));
            }

            if (item.type == ItemID.ThornWhip)
            {
                int rupturePotency = 2;
                int ruptureCount = 1;
                string potencyText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                TooltipLine potencyTooltip = new TooltipLine(Mod, "RupturePotency", potencyText);
                tooltips.Add(potencyTooltip);

                string countText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                TooltipLine countTooltip = new TooltipLine(Mod, "RuptureCount", countText);

                int potencyIndex = tooltips.IndexOf(potencyTooltip);
                if (potencyIndex != -1)
                {
                    tooltips.Insert(potencyIndex + 1, countTooltip);
                }
                else
                {
                    tooltips.Add(countTooltip);
                }
            }

            if (item.type == ItemID.RainbowWhip)
            {
                int rupturePotency = 2;
                int ruptureCount = 1;
                string potencyText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RupturePotency", rupturePotency);
                TooltipLine potencyTooltip = new TooltipLine(Mod, "RupturePotency", potencyText);
                tooltips.Add(potencyTooltip);

                string countText = Language.GetTextValue("Mods.LimbusMod.CommonItemTooltip.RuptureCount", ruptureCount);
                TooltipLine countTooltip = new TooltipLine(Mod, "RuptureCount", countText);

                int potencyIndex = tooltips.IndexOf(potencyTooltip);
                if (potencyIndex != -1)
                {
                    tooltips.Insert(potencyIndex + 1, countTooltip);
                }
                else
                {
                    tooltips.Add(countTooltip);
                }
            }
        }
    }
}