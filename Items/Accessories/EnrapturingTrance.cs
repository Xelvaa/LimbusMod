using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LimbusMod.NPCs;
using LimbusMod.Players;
using LimbusMod.Items.Accessories;
using Microsoft.Xna.Framework;

namespace LimbusMod.Items.Accessories
{
    public class EnrapturingTrance : ModItem
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
            player.GetModPlayer<RupturePlayer>().hasTalisman = true;
            player.GetModPlayer<RupturePlayer>().hasThornyRopeCuffs = true;
            player.GetModPlayer<RupturePlayer>().hasBattery = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<StandardDutyBattery>());
            recipe.AddIngredient(ModContent.ItemType<ThornyRopeCuffs>());
            recipe.AddIngredient(ModContent.ItemType<TalismanBundle>());
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}

