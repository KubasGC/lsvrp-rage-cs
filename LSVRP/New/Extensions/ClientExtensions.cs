using System;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Items;
using LSVRP.New.Core.Items;
using LSVRP.New.Enums;
using LSVRP.New.Helpers;
using Newtonsoft.Json;

namespace LSVRP.New.Extensions
{
    public static class ClientExtensions
    {
        public static Character GetData(this Client player)
        {
            return LSVRP.Managers.Account.GetPlayerData(player) ?? throw new NotImplementedException();
        }

        public static void ShowItemUi(this Character charData, bool refreshOnly = false, bool withMessage = true)
        {
            IEnumerable<Entities.Item.ItemEntity> playerItems =
                ItemsHelper.GetItemsByOwner(OwnerType.Player, charData.Id);
            List<ClientItem> pItems = playerItems.Select(t => new ClientItem(t.Id, t.Name, t.Used)).ToList();
            charData.PlayerHandle.TriggerEvent(refreshOnly ? "client.items.refreshItems" : "client.items.showItems",
                JsonConvert.SerializeObject(pItems, Formatting.None));
        }
    }
}