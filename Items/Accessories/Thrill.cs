using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LimbusMod.Items;
using LimbusMod.NPCs;
using LimbusMod.Players;
using Microsoft.Xna.Framework;

namespace LimbusMod.Items.Accessories
{
    public class Thrill : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.value = Item.buyPrice(gold: 20);
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RupturePlayer>().hasThrill = true;
        }
    }
}