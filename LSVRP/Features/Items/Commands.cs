/*
* LSVRP C# Engine
* Script dedicated for Role-play server in Grand Theft Auto V game based on the external Multiplayer called Rage Multiplayer.
* @Author: Kubas (Jakub Skakuj)
* @StartDate: Jun 2018
*
* @urls:
* 		@RAGE-MP  	    https://rage.mp
* 		@LSVRP:			https://lsvrp.pl
*
* All Rights Reserved
* Copyright prohibited
*/

/*using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Admin;
using LSVRP.Features.Dialogs;
using LSVRP.Libraries;
using LSVRP.Managers;
using LSVRP.New.Entities.Item;
using LSVRP.New.Extensions;
using LSVRP.New.Factories;
using LSVRP.New.Helpers;
using LSVRP.New.Managers;
using Log = LSVRP.Libraries.Log;

namespace LSVRP.Features.Items
{
    public class Commands : Script
    {
        [Command("p", GreedyArg = true)]
        public void Command_P(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length == 0)
            {
                // Library.ShowUi(player);
                charData.ShowItemUi();
                return;
            }

            if (arguments[0].ToLower() == "podnies")
            {
                // TODO in vehicle
                IEnumerable<ItemEntity> itemsList =
                    ItemsHelper.GetItemsInSphere(player.Position, 5.0, (int) player.Dimension);
                if (!itemsList.Any())
                {
                    Ui.ShowError(player, "Obok Ciebie nie leżą żadne przedmioty.");
                    return;
                }

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("Przedmiot", 90)
                };
                List<DialogRow> dialogRows = itemsList
                    .Select(entry => new DialogRow(entry.Id, new[] {$"{entry.Name} (UID: {entry.Id})"})).ToList();

                string[] dialogButtons = {"Podnieś", "Anuluj"};
                Dialogs.Library.CreateDialog(player, DialogId.ItemPickDialog, "Podnoszenie przedmiotu", dialogColumns,
                    dialogRows, dialogButtons);
            }
            else
            {
                charData.ShowItemUi();
            }
        }

        [Command("ap", GreedyArg = true)]
        public void Command_Ap(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel < 1) return;
            if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.ItemCreate, true))
                return;
            string legend = "/ap [stworz, usun]";
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            string option = arguments[0].ToLower();
            if (option == "stworz")
            {
                legend = "/ap stworz [typ] [wartość 1] [wartość 2] [nazwa]";
                if (arguments.Length < 4)
                {
                    Ui.ShowUsage(player, legend);
                    return;
                }

                int type = Command.GetNumberFromString(arguments[1]),
                    value1 = Command.GetNumberFromString(arguments[2]),
                    value2 = Command.GetNumberFromString(arguments[3]);

                string name = Command.GetConcatString(arguments, 4);
                if (type == Command.InvalidNumber || value1 == Command.InvalidNumber || value2 == Command.InvalidNumber)
                {
                    Ui.ShowUsage(player, legend);
                    return;
                }
                
                ItemFactory itemFactory = new ItemFactory();
                ItemEntity createdItem = itemFactory.CreateWithSave(new Item
                {
                    Name = name,
                    OwnerType = OwnerType.Player,
                    Owner = charData.Id,
                    Type = (ItemType) type,
                    Value1 = value1,
                    Value2 = value2,
                    Value3 = ""
                });

                Ui.ShowInfo(player, $"Stworzyłeś przedmiot {createdItem.Name} [UID: {createdItem.Id}]");
            }
            else if (option == "usun")
            {
                // todo sprawdzanie liczby argumentow
                int itemId = Command.GetNumberFromString(arguments[1]);
                if (itemId == Command.InvalidNumber)
                {
                    Ui.ShowUsage(player, "/ap usun [uid]");
                    return;
                }

                ItemEntity item = ItemsManager.Items.FirstOrDefault(t => t.Id == itemId);
                if (item == null)
                {
                    Ui.ShowError(player, "Nie znaleziono przedmiotu o podanym ID.");
                    return;
                }

                
                Ui.ShowInfo(player, $"Przedmiot {item.Name} [UID: {itemId}] został usunięty");
                Log.LogPlayer(charData, $"usuwa przemiot {item.Name} [UID: {itemId}]");
                
                item.Delete();
            }
        }
    }
}*/