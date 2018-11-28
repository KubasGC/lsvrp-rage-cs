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
using System;
using System.Collections.Generic;
using System.Timers;
using GTANetworkAPI;
using LSVRP.Features.Dialogs;
using LSVRP.Libraries;
using LSVRP.Managers;
using Log = LSVRP.Modules.Log;

namespace LSVRP.Features.Corners
{
    public class Commands : Script
    {
        [Command("corner", GreedyArg = true)]
        public void Command_Corner(Client player, string args = "")
        {
            var charData = Account.GetPlayerData(player);
            if (!Groups.Library.IsPlayerInCriminalGroup(charData))
            {
                Ui.ShowError(player, "Brak uprawień");
                return;
            }

            if (Account.GetServerData(charData, Account.ServerData.CornerId) != null)
            {
                Library.StopCornerSell(charData);
                Ui.ShowInfo(player, "Handel zakończony");
            }

            var corner = Library.GetPlayerCorner(player);
            if (corner == null)
            {
                Ui.ShowError(player, "Nie znajdujesz się na cornerze");
                return;
            }

            var hour = new DateTime().Hour;
            if (!Library.IsTimeOkToSellDrugs())
            {
                Ui.ShowError(player, "Handel na cornerach dowzoliny jest w godzinach 18-2");
                return;
            }

            Account.SetServerData(charData, Account.ServerData.CornerId, corner.Id);
            var time = Library.GetNextCornerSellTime(corner);
            if (time > 0)
            {
                var timer = new Timer(time);
                timer.AutoReset = false;
                timer.Elapsed += (sender, e) => Library.SellDrugs(player.Handle.Value, corner.Id);
                timer.Start();
                Ui.ShowInfo(player, "Handel rozpoczęty, nie opuszczaj cornera i oczekuj na klientów.");
            }
            else
            {
                Ui.ShowError(player, "Błąd");
            }
        }

        [Command("acorner", GreedyArg = true)]
        public void Command_Acorner(Client player, string args = "")
        {
            var charData = Account.GetPlayerData(player);
            if (charData == null)
                return;

            if (!Admin.Library.DoesPlayerHasAdminPerm(charData, "corners", true))
                return;

            const string legend = "/acorner [stworz, usun, goto, lista, highrisk]";
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            string option = arguments[0].ToLower();
            if (option == "stworz")
            {
                if (arguments.Length < 2)
                {
                    Ui.ShowUsage(player, "/acorner stworz [nazwa]");
                    return;
                }

                string name = Command.GetConcatString(arguments, 1);
                Log.ConsoleLog("debug", name);
                var pos = player.Position;

                var corner = Library.CreateCorner(name, pos.X, pos.Y, pos.Z, (int) player.Dimension);
                Ui.ShowInfo(player, $"Pomyslnie stworzono corner {corner.Name} [UID: {corner.Id}]");
            }
            else if (option == "goto")
            {
                if (arguments.Length < 2)
                {
                    Ui.ShowUsage(player, "/acorner goto [UID]");
                    return;
                }

                int cornerId = Command.GetNumberFromString(arguments[1]);
                if (cornerId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Niepoprawne id cornera");
                    return;
                }

                var corner = Library.GetCornerData(cornerId);
                if (corner == null)
                {
                    Ui.ShowError(player, "Nie znaleziono cornera o podanym id");
                    return;
                }

                player.Position = corner.GetPosition();
                player.Dimension = (uint) corner.Dimension;
            }
            else if (option == "usun")
            {
                if (arguments.Length < 2)
                {
                    Ui.ShowUsage(player, "/acorner usun [UID]");
                    return;
                }

                int cornerId = Command.GetNumberFromString(arguments[1]);
                if (cornerId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Niepoprawne id cornera");
                    return;
                }

                var corner = Library.GetCornerData(cornerId);
                if (corner == null)
                {
                    Ui.ShowError(player, "Nie znaleziono cornera o podanym id");
                    return;
                }

                Library.DeleteCorner(corner);
                Ui.ShowInfo(player, $"Usunąleś corner UID: {cornerId}");
            }
            else if (option == "lista")
            {
                var allCorners = Library.GetCorners();
                List<DialogRow> dialogRows = new List<DialogRow>();
                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("UID", 20),
                    new DialogColumn("Nazwa", 50),
                    new DialogColumn("HighRisk", 20)
                };
                foreach (var entry in allCorners)
                {
                    var c = entry.Value;
                    dialogRows.Add(new DialogRow(c.Id, new[]
                    {
                        c.Id.ToString(),
                        c.Name,
                        c.HighRisk ? "Tak" : "-"
                    }));
                }

                string[] dialogButtons = {"OK"};
                Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.None, "Lista cornerów",
                    dialogColumns, dialogRows, dialogButtons);
            }
            else if (option == "highrisk")
            {
                if (arguments.Length < 3)
                {
                    Ui.ShowUsage(player, "/acorner highrisk [UID] [0/1]");
                    return;
                }

                int cornerId = Command.GetNumberFromString(arguments[1]);
                int arg = Command.GetNumberFromString(arguments[2]);
                bool highRisk = arg > 0 && arg != Command.InvalidNumber;
                if (cornerId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Niepoprawne id cornera");
                    return;
                }

                var corner = Library.GetCornerData(cornerId);
                if (corner == null)
                {
                    Ui.ShowError(player, "Nie znaleziono cornera o podanym id");
                    return;
                }

                corner.HighRisk = highRisk;
                corner.Save();
                Ui.ShowInfo(player, $"Zmieniłeś status highrisk cornera UID: {cornerId} na {highRisk}");
            }
        }
    }
}