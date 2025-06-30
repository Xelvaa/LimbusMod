using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LimbusMod.NPCs;
using LimbusMod.Players;
using Microsoft.Xna.Framework;

namespace LimbusMod.Items.Accessories
{
    public class ShardofApocalypse : ModItem
    {
        public override void SetDefaults() 
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 5, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RupturePlayer>().hasApocalypseShard = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ItemID.ShadowScale, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe2.AddIngredient(ItemID.TissueSample, 8);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
    }
}