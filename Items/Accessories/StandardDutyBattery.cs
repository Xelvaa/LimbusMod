using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LimbusMod.NPCs;
using LimbusMod.Players;
using Microsoft.Xna.Framework;

namespace LimbusMod.Items.Accessories
{
    public class StandardDutyBattery : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(0, 10, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RupturePlayer>().hasBattery = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Granite, 50);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}