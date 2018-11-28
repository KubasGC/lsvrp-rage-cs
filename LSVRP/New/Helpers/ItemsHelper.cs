using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Items;
using LSVRP.New.Constants;
using LSVRP.New.Entities.Item;
using LSVRP.New.Enums;
using LSVRP.New.Managers;

namespace LSVRP.New.Helpers
{
    public static class ItemsHelper
    {
        public static bool DoesCharacterHasItemType(Character charData, ItemType itemType)
        {
            return ItemsManager.Items.Count(t => t.CheckOwner(charData) && t.Type == itemType) > 0;
        }

        public static bool DoesCharacterHasItemTypeUsed(Character charData, ItemType itemType)
        {
            return ItemsManager.Items.Count(t =>
                       t.CheckOwner(charData) && t.Type == itemType && t.Used) > 0;
        }

        public static IEnumerable<ItemEntity> GetItemsInSphere(Vector3 position, double radius, int dimension)
        {
            return (from entry in ItemsManager.Items
                where entry.OwnerType == OwnerType.Ground
                where entry.Dimension == dimension && entry.Position.DistanceToSquared(position) < radius
                select entry).ToList();
        }

        public static IEnumerable<ItemEntity> GetItemsByOwner(OwnerType ownerType, int owner)
        {
            return (from entry in ItemsManager.Items
                where entry.OwnerType == ownerType && entry.Owner == owner
                select entry).ToList();
        }

        public static string GetItemTypeName(ItemType itemType)
        {
            return ItemsConstants.ItemTypesName.ContainsKey(itemType)
                ? ItemsConstants.ItemTypesName[itemType]
                : "Nieznany";
        }

        public static int GetPlayerUsedWeaponsCount(this Character charData)
        {
            return charData == null
                ? 0
                : ItemsManager.Items.Count(t => t.CheckOwner(charData) && t.Type == ItemType.Weapon && t.Used);
        }
    }
}