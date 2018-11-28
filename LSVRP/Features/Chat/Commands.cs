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
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Items;
using LSVRP.Libraries;
using LSVRP.Managers;
using LSVRP.New.Enums;
using Log = LSVRP.Libraries.Log;

namespace LSVRP.Features.Chat
{
    public class Commands : Script
    {
        [Command("me", GreedyArg = true)]
        public void Command_Me(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/me [akcja]");
                return;
            }

            Library.SendPlayerMeMessage(charData, Command.UpperFirst(Command.GetConcatString(arguments), true, false),
                false);
        }

        [Command("do", GreedyArg = true)]
        public void Command_Do(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/do [akcja]");
                return;
            }

            Library.SendPlayerDoMessage(charData, Command.UpperFirst(Command.GetConcatString(arguments), true, true),
                false);
        }

        [Command("b", GreedyArg = true)]
        public void Command_B(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/b [treść wiadomości]");
                return;
            }

            IEnumerable<Character> playersInRadius = Global.GetPlayersInRange(charData.PlayerHandle.Position,
                Constants.RadiusTalk, charData.PlayerHandle.Dimension);

            string outputMessage =
                $"(( {Player.GetPlayerIcName(charData, true)} " +
                $"{Command.UpperFirst(Command.GetConcatString(arguments))} ))";
            foreach (Character entry in playersInRadius)
            {
                double progress =
                    Global.GetDistanceBetweenPositions(charData.PlayerHandle.Position, entry.PlayerHandle.Position) /
                    Constants.RadiusTalk;
                int r = (int) Math.Floor(Global.Lerp(252, 202, (float) progress)),
                    g = (int) Math.Floor(Global.Lerp(232, 182, (float) progress)),
                    b = (int) Math.Floor(Global.Lerp(232, 182, (float) progress));

                entry.PlayerHandle.SendChatMessage($"!{{{r}, {g}, {b}}}{outputMessage}");
                Log.LogPlayer(entry, outputMessage, LogType.ChatOoc);
            }
        }

        [Command("k", Alias = "krzyk", GreedyArg = true)]
        public void Command_K(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/k(rzyk) [treść wiadomości]");
                return;
            }

            string message = Command.UpperFirst(Command.GetConcatString(arguments), false);
            if (!message.EndsWith("!")) message += "!";
            Library.SendPlayerLocalMessage(charData, message, "krzyczy", null, true, LocalMessageType.Shout);
        }

        [Command("s", Alias = "szept", GreedyArg = true)]
        public void Command_S(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/s(zept) [treść wiadomości]");
                return;
            }

            string message = Command.UpperFirst(Command.GetConcatString(arguments), false);
            Library.SendPlayerLocalMessage(charData, message, "szepcze", null, true, LocalMessageType.Whisper);
        }

        [Command("m", Alias = "megafon", GreedyArg = true)]
        public void Command_M(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (!charData.HasItemType(ItemType.Megaphone))
            {
                Ui.ShowError(player, "Nie posiadasz megafonu w swoim ekwipunku.");
                return;
            }

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/m(egafon) [treść wiadomości]");
                return;
            }

            string message = Command.UpperFirst(Command.GetConcatString(arguments), false);
            if (!message.EndsWith("!")) message += "!";
            Library.SendPlayerLocalMessage(charData, message, "(megafon)", null, true, LocalMessageType.Megaphone);
        }

        [Command("w", GreedyArg = true)]
        public void Command_W(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 2)
            {
                Ui.ShowUsage(player, "/w [ID gracza] [treść wiadomości]");
                return;
            }

            int serverId = Command.GetNumberFromString(arguments[0]);
            if (serverId == Command.InvalidNumber)
            {
                Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(serverId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza o podanym Id.");
                return;
            }

            string message = Command.UpperFirst(Command.GetConcatString(arguments, 1));
            if (charData.Id == targetData.Id)
            {
                Ui.ShowError(player, "Nie możesz wysyłać prywatnych wiadomości do siebie.");
                return;
            }

            if (targetData.WhisperBlock && !charData.HasAdminDuty)
            {
                Ui.ShowError(player, "Gracz ma zablokowane otrzymywanie prywatnych wiadomości.");
                return;
            }

            string forTarget = $"!{{#DEA909}}{Player.GetPlayerIcName(charData, true)}: {message}";
            string forSender = $"!{{#E0E02F}}{Player.GetPlayerIcName(targetData, true)}: {message}";

            NAPI.Chat.SendChatMessageToPlayer(charData.PlayerHandle, forSender);
            NAPI.Chat.SendChatMessageToPlayer(targetData.PlayerHandle, forTarget);

            Log.LogPlayer(charData, "(NADAWCA) " + forSender, LogType.PwSend);
            Log.LogPlayer(targetData, "(ODBIORCA) " + forTarget, LogType.PwSend);

            targetData.LastWhisper = charData.PlayerHandle;
        }

        [Command("re", GreedyArg = true)]
        public void Command_Re(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/re [treść wiadomości]");
                return;
            }

            if (charData.LastWhisper == null)
            {
                Ui.ShowWarning(player, "Z nikim ostatnio nie pisałeś.");
                return;
            }

            Character targetData = Account.GetPlayerData(charData.LastWhisper);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza o podanym Id.");
                charData.LastWhisper = null;
                return;
            }

            string message = Command.UpperFirst(Command.GetConcatString(arguments, 1));
            if (charData.Id == targetData.Id)
            {
                Ui.ShowError(player, "Nie możesz wysyłać prywatnych wiadomości do siebie.");
                return;
            }

            if (targetData.WhisperBlock && !charData.HasAdminDuty)
            {
                Ui.ShowError(player, "Gracz ma zablokowane otrzymywanie prywatnych wiadomości.");
                return;
            }

            string forTarget = $"!{{#DEA909}}{Player.GetPlayerIcName(charData, true)}: {message}";
            string forSender = $"!{{#E0E02F}}{Player.GetPlayerIcName(targetData, true)}: {message}";

            NAPI.Chat.SendChatMessageToPlayer(charData.PlayerHandle, forSender);
            NAPI.Chat.SendChatMessageToPlayer(targetData.PlayerHandle, forTarget);

            Log.LogPlayer(charData, "(NADAWCA) " + forSender, LogType.PwSend);
            Log.LogPlayer(targetData, "(ODBIORCA) " + forTarget, LogType.PwSend);

            targetData.LastWhisper = charData.PlayerHandle;
        }
    }
}