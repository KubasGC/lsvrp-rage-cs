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
using System.Collections.Generic;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Base;
using LSVRP.Features.Clothes;
using LSVRP.Features.Dialogs;
using LSVRP.Libraries;
using LSVRP.Managers;

namespace LSVRP.Features.Shops
{
    public class Commands : Script
    {
        [Command("sklep", Alias = "shop")]
        public void Command_Sklep(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (player.IsInVehicle)
            {
                Ui.ShowError(player, "Nie możesz siedzieć w pojeździe, jeśli chcesz skorzystać ze sklepu.");
                return;
            }

            Shop nearestShop = Library.GetNearestShop(player.Position, 5.0, ShopTypes.Shop);
            if (nearestShop == null)
            {
                Ui.ShowError(player, "Nie jesteś w sklepie.");
                return;
            }

            List<ShopProduct> products = Library.GetShopProducts(nearestShop.Id);
            if (products.Count == 0)
            {
                Ui.ShowInfo(player, "W sklepie nie ma nic do kupienia.");
                return;
            }

            List<DialogColumn> dialogColumns = new List<DialogColumn>
            {
                new DialogColumn("Nazwa", 70),
                new DialogColumn("Cena", 20)
            };

            List<DialogRow> dialogRows = new List<DialogRow>();
            foreach (ShopProduct product in products)
                dialogRows.Add(new DialogRow(product.Id, new[] {product.Name, $"${product.Price:0,0}"}));

            string[] dialogButtons = {"Kup", "Anuluj"};

            Dialogs.Library.CreateDialog(player, DialogId.ShopListItem, $"Sklep \"{nearestShop.Name}\"", dialogColumns,
                dialogRows, dialogButtons);
        }

        [Command("binco")]
        public void CmdBinco(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (player.IsInVehicle)
            {
                Ui.ShowError(player, "Nie możesz siedzieć w pojeździe, jeśli chcesz skorzystać ze sklepu.");
                return;
            }

            Shop nearestShop = Library.GetNearestShop(player.Position, 5.0, ShopTypes.Binco);
            if (nearestShop == null)
            {
                Ui.ShowError(player, "Nie jesteś w sklepie.");
                return;
            }

            NAPI.ClientEvent.TriggerClientEvent(player, "client.charBinco.toggle", true,
                charData.Sex == CharSex.Male ? 0 : 1);
        }

        [Command("abinco", GreedyArg = true)]
        public void CmdABinco(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (charData.AdminLevel == 0) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/abinco [stworz, usun]");
                return;
            }

            string fOption = arguments[0].ToLower();

            if (fOption == "stworz")
            {
                Vector3 pPos = player.Position;
                pPos.Z -= 1f;

                Shop newShop = Library.CreateShop("Binco", pPos, ShopTypes.Binco);
                newShop.Name = $"Binco {newShop.Id}";
                newShop.Save();

                Ui.ShowInfo(player, "Binco zostało stworzone.");
            }
            else if (fOption == "usun")
            {
                Shop nearestShop = Library.GetNearestShop(player.Position, 3.0, ShopTypes.Binco);
                if (nearestShop == null)
                {
                    Ui.ShowError(player, "Obok Ciebie nie znajduje się żaden sklep Binco.");
                    return;
                }

                Library.DestroyShop(nearestShop);
                Ui.ShowInfo(player, "Binco zostało usunięte.");
            }
            else
            {
                Ui.ShowError(player, "Niepoprawny wybór.");
            }
        }
    }
}