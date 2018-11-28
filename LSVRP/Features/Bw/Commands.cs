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
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Admin;
using LSVRP.Features.Dialogs;
using LSVRP.Libraries;
using LSVRP.Managers;

namespace LSVRP.Features.Bw
{
    public class Commands : Script
    {
        [Command("abw", GreedyArg = true)]
        public void Command_Abw(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel < 1) return;
            if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.CoreBw, true)) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 2)
            {
                Ui.ShowUsage(player, "/abw [ID gracza] [Czas w minutach | 0 zdejmuje BW]");
                return;
            }

            int targetId = Command.GetNumberFromString(arguments[0]);
            if (targetId == Command.InvalidNumber)
            {
                Ui.ShowError(player, "Podano niepoprawne Id gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(targetId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono takiego gracza.");
                return;
            }

            int time = Command.GetNumberFromString(arguments[1]);
            if (time == Command.InvalidNumber || time < 0 || time > 60)
            {
                Ui.ShowError(player, "Możesz ustawić czas BW w zakresie [0 - 60] minut.");
                return;
            }

            if (time == 0)
            {
                if (targetData.BwTime == 0)
                {
                    Ui.ShowError(player, "Gracz nie jest nieprzytomny.");
                    return;
                }


                Library.EndBw(targetData);
                Ui.ShowInfo(player, $"Ściągnąłeś BW graczowi {Player.GetPlayerIcName(targetData)}");
                Player.SendFormattedChatMessage(targetData.PlayerHandle, "Administrator ściągnął Tobie BW.",
                    Constants.ColorDelRio);
            }
            else
            {
                if (targetData.BwTime > 0)
                {
                    Ui.ShowError(player, "Ten gracz ma już BW.");
                    return;
                }

                Library.SetPlayerBw(targetData, time * 60);
                Ui.ShowInfo(targetData.PlayerHandle, $"Otrzymałeś BW. Ockniesz się za {time * 60} sekund.");
            }
        }

        [Command("smierc", Alias = "akceptujsmierc")]
        public void CommandSmierc(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (!Library.DoesPlayerHasBw(charData))
            {
                Ui.ShowError(player, "Aby użyć tej komendy musisz być w stanie brutalnego pobicia (BW).");
                return;
            }

            if (charData.OnlineTime < 36000)
            {
                Ui.ShowError(player, "Aby uśmiercić swoją postać musisz mieć na niej przegrane co najmniej 10h.");
                return;
            }

            Dialogs.Library.CreateDialog(player, DialogId.BwEnterDescription, "Character Kill",
                "Wprowadź opis śmierci postaci. Możesz zamieścić tutaj informacje takie jak odniesione rany, czy widoczne powody śmierci.",
                "", new[] {"Uśmierć postać", "Anuluj"});
        }
    }
}