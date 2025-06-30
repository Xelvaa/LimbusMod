using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LimbusMod.NPCs;
using LimbusMod.Players;
using LimbusMod.Items.Accessories;
using Microsoft.Xna.Framework;

namespace LimbusMod.Items.Accessories
{
    public class EerieEffigy : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(0, 15, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RupturePlayer>().hasApocalypseShard = true;
            player.GetModPlayer<RupturePlayer>().hasBoneStake = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BoneStake>());
            recipe.AddIngredient(ModContent.ItemType<ShardofApocalypse>());
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
