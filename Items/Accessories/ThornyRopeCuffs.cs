using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LimbusMod.NPCs;
using LimbusMod.Players;
using Microsoft.Xna.Framework;

namespace LimbusMod.Items.Accessories
{
    public class ThornyRopeCuffs : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 5, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RupturePlayer>().hasThornyRopeCuffs = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Vine, 2);
            recipe.AddIngredient(ItemID.Stinger, 9);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}