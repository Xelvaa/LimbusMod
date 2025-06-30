using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LimbusMod.NPCs;
using LimbusMod.Players;
using Microsoft.Xna.Framework;

namespace LimbusMod.Items.Accessories
{
    public class Thunderbranch : ModItem
    {
        public override void SetDefaults() 
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(0, 10, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RupturePlayer>().hasThunderbranch = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofFlight, 15);
            recipe.AddIngredient(ItemID.MythrilBar, 10);
            recipe.AddIngredient(ItemID.Pearlwood, 40);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.SoulofFlight, 15);
            recipe2.AddIngredient(ItemID.OrichalcumBar, 10);
            recipe2.AddIngredient(ItemID.Pearlwood, 40);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.Register();
        }
    }
}