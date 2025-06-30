using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LimbusMod.NPCs;
using LimbusMod.Players;
using Microsoft.Xna.Framework;

namespace LimbusMod.Items.Accessories
{
    public class BoneStake : ModItem
    {
        public override void SetDefaults() 
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 2, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RupturePlayer>().hasBoneStake = true;
        }
    }
}