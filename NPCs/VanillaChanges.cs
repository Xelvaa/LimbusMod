using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using LimbusMod.Items.Accessories;

namespace LimbusMod.NPCs
{
    public class VanillaChanges : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.ArmsDealer)
            {
                shop.Add(new Item(ModContent.ItemType<BrokenRevolver>()) { shopCustomPrice = Item.buyPrice(gold: 10) });
            }
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Skeleton || npc.type == NPCID.BigPantlessSkeleton || npc.type == NPCID.SmallPantlessSkeleton ||
                npc.type == NPCID.BigMisassembledSkeleton || npc.type == NPCID.SmallMisassembledSkeleton || npc.type == NPCID.BigHeadacheSkeleton ||
                npc.type == NPCID.SmallHeadacheSkeleton || npc.type == NPCID.BigSkeleton || npc.type == NPCID.SmallSkeleton ||
                npc.type == NPCID.HeadacheSkeleton || npc.type == NPCID.MisassembledSkeleton || npc.type == NPCID.PantlessSkeleton ||
                npc.type == NPCID.UndeadViking || npc.type == NPCID.ArmoredViking || npc.type == NPCID.UndeadMiner ||
                npc.type == NPCID.ArmoredSkeleton || npc.type == NPCID.HeavySkeleton)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BoneStake>(), 20)); 
            }

            if (npc.type == NPCID.Plantera)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Thrill>(), 2)); 
            }
        }
    }
}