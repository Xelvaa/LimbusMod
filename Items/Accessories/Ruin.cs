using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LimbusMod.NPCs;
using LimbusMod.Players;
using Microsoft.Xna.Framework;

namespace LimbusMod.Items.Accessories
{
    public class Ruin : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(0, 20, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RupturePlayer>().hasApocalypseShard = true;
            player.GetModPlayer<RupturePlayer>().hasBoneStake = true;
            player.GetModPlayer<RupturePlayer>().hasThunderbranch = true;
            player.GetModPlayer<RupturePlayer>().hasRevolver = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EerieEffigy>());
            recipe.AddIngredient(ModContent.ItemType<BrokenRevolver>());
            recipe.AddIngredient(ModContent.ItemType<Thunderbranch>());
            recipe.AddIngredient(ItemID.BeetleHusk, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
   

