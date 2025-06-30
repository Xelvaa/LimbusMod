using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LimbusMod.Players;

namespace LimbusMod.Items
{
    public class DebuffWeapons : GlobalItem
    {
        // list of rupture weapons
        private static readonly List<int> RuptureClassWeapons = new List<int>
        {
            ItemID.CobaltSword,
            ItemID.NightsEdge,
            ItemID.DD2SquireDemonSword, 
            ItemID.EnchantedSword,
            ItemID.CobaltNaginata,
            ItemID.Excalibur,
            ItemID.TrueExcalibur,
            ItemID.Code1,
            ItemID.Chik,
            ItemID.Gungnir,
            ItemID.EnchantedBoomerang,
            ItemID.Trimarang,
            ItemID.BallOHurt,
            ItemID.DaoofPow,
            ItemID.Arkhalis,
            ItemID.Terragrim,
            ItemID.PiercingStarlight,
            ItemID.CrystalBullet,
            ItemID.NanoBullet,
            ItemID.DemonBow,
            ItemID.CobaltRepeater,
            ItemID.HallowedRepeater,
            ItemID.FairyQueenRangedItem,
            ItemID.EmeraldStaff,
            ItemID.Vilethorn,
            ItemID.MagicMissile,
            ItemID.SkyFracture,
            ItemID.CrystalVileShard,
            ItemID.BookStaff,
            ItemID.NettleBurst,
            ItemID.ShadowbeamStaff,
            ItemID.CrystalStorm,
            ItemID.MagicalHarp,
            ItemID.FairyQueenMagicItem,
            ItemID.ThornWhip,
            ItemID.RainbowWhip
        };

        private static readonly List<int> BurnClassWeapons = new List<int>
        {
            ItemID.FieryGreatsword,
        };


        public override void SetDefaults(Item item)
        {
        }

        public override void ModifyWeaponCrit(Item item, Player player, ref float crit)
        {
            if (RuptureClassWeapons.Contains(item.type) && player.GetModPlayer<RupturePlayer>().hasTalisman)
            {
                crit += 5f; 
            }
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (RuptureClassWeapons.Contains(item.type) && player.GetModPlayer<RupturePlayer>().hasBattery)
            {
                damage += 0.1f; 
            }

            if (BurnClassWeapons.Contains(item.type) && player.GetModPlayer<BurnPlayer>().hasStewpot)
            {
                damage += 0.12f; 
            }
        }
    }
}