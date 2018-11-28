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
using System.Linq;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Dialogs;
using LSVRP.Features.Items;
using LSVRP.Libraries;
using LSVRP.Managers;
using LSVRP.New.Enums;
using LSVRP.New.Helpers;
using Library = LSVRP.Features.Sync.Library;

namespace LSVRP.Features.Base
{
    public class Commands : Script
    {
        [Command("pomoc")]
        public void Command_Pomoc(Client player)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "client.help.toggle");
        }

        [Command("opis", GreedyArg = true)]
        public void CmdOpis(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1) Ui.ShowUsage(player, "/opis [treść opisu] | Aby usunąć użyj komendy /opis usun.");

            if (arguments[0].ToLower() == "usun")
            {
                Library.DeletePlayerData(player, "player.description");
                Ui.ShowInfo(player, "Opis został usunięty pomyślnie.");
                return;
            }

            Library.SetPlayerSyncedData(player, "player.description", Command.GetConcatString(arguments));
            NAPI.ClientEvent.TriggerClientEvent(player, "client.descriptions.showDesc");
            Ui.ShowInfo(player, "Opis został ustawiony pomyślnie.");
        }

        [Command("pokaz", GreedyArg = true)]
        public void Command_Pokaz(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/pokaz [dowod | prawko | id] [ID gracza]");
                return;
            }

            int playerId = Command.GetNumberFromString(arguments[1]);
            if (playerId < 0)
            {
                Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(playerId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza.");
                return;
            }


            string option = arguments[0].ToLower();
            if (option == "dowod")
            {
                Ui.ShowInfo(targetData.PlayerHandle,
                    $"Dowód osobisty:\nImię i nazwisko: {charData.Name} {charData.Lastname}");
                Chat.Library.SendPlayerMeMessage(charData,
                    $"pokazuje dowód osobisty graczowi {Player.GetPlayerIcName(targetData)}", true);
            }
            else if (option == "prawko")
            {
                if (!charData.DriverLicense)
                {
                    Ui.ShowError(player, "Nie posiadasz prawa jazdy.");
                    return;
                }

                Ui.ShowInfo(targetData.PlayerHandle,
                    $"Prawo jazdy:\nImię i nazwisko: {charData.Name} {charData.Lastname}");
                Chat.Library.SendPlayerMeMessage(charData,
                    $"pokazuje prawo jazdy graczowi {Player.GetPlayerIcName(targetData)}", true);
            }
            else if (option == "id")
            {
                int groupDuty = Groups.Library.GetPlayerGroupDuty(charData);
                if (groupDuty == 0)
                {
                    Ui.ShowError(player, "Nie jesteś na duty żadnej grupy.");
                    return;
                }

                GroupMember pGroupData = Groups.Library.GetPlayerGroupData(charData, groupDuty);
                Group groupData = Groups.Library.GetGroupData(groupDuty);
                if (pGroupData == null || groupData == null)
                {
                    Ui.ShowError(player, "Wystąpił błąd.");
                    return;
                }

                Ui.ShowInfo(targetData.PlayerHandle,
                    $"Identyfikator {groupData.Name}\nImię i nazwisko: {charData.Name} {charData.Lastname}\n" +
                    $"{pGroupData.RankName}");
                Chat.Library.SendPlayerMeMessage(charData,
                    $"pokazuje identyfikator graczowi {Player.GetPlayerIcName(targetData)}", true);
            }
        }

        [Command("styl")]
        public void Command_Styl(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            using (Database.Database db = new Database.Database())
            {
                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("Styl chodzenia", 90)
                };

                List<DialogRow> dialogRows = new List<DialogRow>();
                foreach (WalkingStyle walkingStyle in db.WalkingStyles.ToList())
                    dialogRows.Add(new DialogRow(walkingStyle.Id,
                        new[]
                        {
                            walkingStyle.Id == charData.WalkingStyle
                                ? $"<span style=\"color: green\">{walkingStyle.Name}</span>"
                                : walkingStyle.Name
                        }));

                string[] dialogButtons = {"Wybierz", "Anuluj"};

                Dialogs.Library.CreateDialog(player, DialogId.PlayerWalkingStyleChoose,
                    "Wybieranie stylu poruszania się", dialogColumns, dialogRows, dialogButtons);
            }
        }

        [Command("spawn")]
        public void Command_Spawn(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            List<DialogColumn> dialogColumns = new List<DialogColumn>
            {
                new DialogColumn("Nazwa", 100)
            };
            List<DialogRow> dialogRows = new List<DialogRow>();
            dialogRows.Add(new DialogRow("centrum", new[] {"Centrum"}));
            //todo hotel
            var playerGroups = Groups.Library.GetPlayerGroups(player);
            foreach (var group in playerGroups)
            {
                var groupData = Groups.Library.GetGroupData(group.GroupId);
                if (groupData != null && Groups.Library.IsGroupSpawnSet(groupData))
                    dialogRows.Add(new DialogRow($"g-{groupData.Id}", new[] {$"Grupa: {groupData.Name}"}));
            }

            Dialogs.Library.CreateDialog(player, DialogId.SelectSpawn, "Wybór spawnu", dialogColumns, dialogRows,
                new[] {"Wybierz", "Anuluj"});
        }

        [Command("wepchnij", GreedyArg = true)]
        public void CommandWepchnij(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/wepchnij [ID gracza]");
                return;
            }

            if (!player.IsInVehicle || player.VehicleSeat != -1)
            {
                Ui.ShowInfo(player, "Musisz siedzieć w pojeździe na miejscu kierowcy aby wepchnąć gracza do pojazdu.");
                return;
            }

            int playerId = Command.GetNumberFromString(arguments[0]);
            if (playerId == Command.InvalidNumber)
            {
                Ui.ShowError(player, "Podano niepoprawne Id gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(playerId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza.");
                return;
            }

            if (Global.GetDistanceBetweenPositions(charData.PlayerHandle.Position, targetData.PlayerHandle.Position) >
                5.0 || targetData.PlayerHandle.Dimension != charData.PlayerHandle.Dimension)
            {
                Ui.ShowError(player, "Gracz jest za daleko.");
                return;
            }

            if (!Bw.Library.DoesPlayerHasBw(targetData))
            {
                Ui.ShowError(player, "Gracz nie posiada BW.");
                return;
            }

            if (targetData.PlayerHandle.IsInVehicle)
            {
                Ui.ShowError(player, "Gracz jest już w pojeździe.");
                return;
            }

            int maxOccupants = NAPI.Vehicle.GetVehicleMaxOccupants((VehicleHash) player.Vehicle.Model);
            int seatId = -10;
            for (int i = 0; i < maxOccupants - 1; i++)
            {
                bool found = false;
                foreach (Client entry in NAPI.Vehicle.GetVehicleOccupants(player.Vehicle))
                    if (entry.VehicleSeat == i)
                    {
                        found = true;
                        break;
                    }

                if (!found) continue;

                seatId = i;
                break;
            }

            if (seatId == -10)
            {
                Ui.ShowError(player, "W pojedzie nie ma juæ wolnego miejsca.");
                return;
            }

            NAPI.Player.SetPlayerIntoVehicle(targetData.PlayerHandle, player.Vehicle, seatId);
            Chat.Library.SendPlayerDoMessage(targetData,
                $"{Player.GetPlayerIcName(targetData)} został wepchnięty do pojazdu przez " +
                $"{Player.GetPlayerIcName(charData)}.", true);
        }

        [Command("plac", Alias = "pay", GreedyArg = true)]
        public void CmdPlac(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 2)
            {
                Ui.ShowUsage(player, "/plac [ID gracza] [kwota]");
                return;
            }

            int playerId = Command.GetNumberFromString(arguments[0]);
            int ammount = Command.GetNumberFromString(arguments[1]);

            if (playerId == Command.InvalidNumber || ammount == Command.InvalidNumber || ammount <= 0)
            {
                Ui.ShowUsage(player, "/plac [ID gracza] [kwota]");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(playerId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza.");
                return;
            }

            if (charData == targetData)
            {
                Ui.ShowError(player, "Czy płacenie pieniędzy sobie ma jakiś sens?");
                return;
            }

            if (Global.GetDistanceBetweenPositions(charData.PlayerHandle.Position, targetData.PlayerHandle.Position) >
                2.5 || targetData.PlayerHandle.Dimension != charData.PlayerHandle.Dimension)
            {
                Ui.ShowError(player, "Gracz jest za daleko.");
                return;
            }

            if (charData.Cash < ammount)
            {
                Ui.ShowError(player, "Nie posiadasz takiej kwoty w portfelu.");
                return;
            }

            if (Money.Library.TakePlayerWalletCash(charData, ammount,
                $"/plac dla: {Player.GetPlayerDebugName(targetData)}"))
            {
                Money.Library.GivePlayerWalletCash(targetData, ammount,
                    $"/plac od: {Player.GetPlayerDebugName(charData)}");

                Player.SendFormattedChatMessage(charData.PlayerHandle,
                    $"Dałeś ${ammount} graczowi {Player.GetPlayerIcName(targetData)}", Constants.ColorPictonBlue);
                Player.SendFormattedChatMessage(targetData.PlayerHandle,
                    $"Dostałeś ${ammount} od gracza {Player.GetPlayerIcName(charData)}", Constants.ColorPictonBlue);


                Chat.Library.SendPlayerMeMessage(charData,
                    $"podaje trochę pieniędzy graczowi {Player.GetPlayerIcName(targetData)}.", true);

                return;
            }

            Ui.ShowError(player, "Nie udało się.");
        }

        [Command("sprobuj", GreedyArg = true)]
        public void CmdSprobuj(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/sprobuj [akcja]");
                return;
            }

            string output;
            string message = Command.GetConcatString(arguments);
            if (Global.GetRandom(1, 2) == 1)
            {
                if (charData.Sex == CharSex.Female) output = "zawiodła, próbując ";
                else output = "zawiódł, próbując ";
            }
            else
            {
                if (charData.Sex == CharSex.Female) output = "odniosła sukces, próbując ";
                else output = "odniósł sukces, próbując ";
            }

            output += message;
            Chat.Library.SendPlayerMeMessage(charData, Command.UpperFirst(output, true, false), true);
        }

        [Command("time", Alias = "czas")]
        public void CmdTime(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (!charData.HasItemType(ItemType.Watch))
            {
                Ui.ShowError(player, "Nie posiadasz zegarka w swoim ekwipunku.");
                return;
            }

            Chat.Library.SendPlayerMeMessage(charData, "spogląda na zegarek.", true);
            Player.SendFormattedChatMessage(player,
                $"Aktualna godzina: {DateTime.Now.Hour:00}:{DateTime.Now.Minute:00}:{DateTime.Now.Second:00}",
                Constants.ColorPictonBlue);
        }
    }
}