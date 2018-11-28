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
using LSVRP.Features.Groups;
using LSVRP.Libraries;
using LSVRP.Managers;
using Log = LSVRP.Libraries.Log;

namespace LSVRP.Features.Chat
{
    public static class Library
    {
        /// <summary>
        /// Wysyła wiadomość czatu do danej grupy
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="groupSlot"></param>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        public static void SendPlayerMessageGroup(Character charData, int groupSlot, GroupMessageType messageType,
            string message)
        {
            GroupMember groupPlayerData = Groups.Library.GetPlayerGroupBySlot(charData.PlayerHandle, groupSlot);
            if (groupPlayerData == null)
            {
                Ui.ShowError(charData.PlayerHandle, "Nie posiadasz grupy o takim slocie.");
                return;
            }

            Group groupData = Groups.Library.GetGroupData(groupPlayerData.GroupId);
            if (groupData == null)
            {
                Ui.ShowError(charData.PlayerHandle, "Wystąpił problem z pobraniem informacji o grupie.");
                return;
            }

            switch (messageType)
            {
                case GroupMessageType.Ic:
                    if (!Groups.Library.DoesGroupHasPerm(groupData.Id, Permissions.SharedChatIc))
                    {
                        Ui.ShowError(charData.PlayerHandle, "Grupa nie posiada dostępu do radia IC.");
                        return;
                    }

                    if (!Groups.Library.DoesPlayerHasPerm(charData.PlayerHandle, groupData.Id,
                        Permissions.SharedChatIc))
                    {
                        Ui.ShowError(charData.PlayerHandle, "Nie posiadasz uprawnień do użycia radia IC.");
                        return;
                    }

                    Groups.Library.SendGroupIcMessage(groupData.Id,
                        $"{Player.GetPlayerIcName(charData)}: {Command.UpperFirst(message)}");
                    SendPlayerLocalMessage(charData, Command.UpperFirst(message), "mówi (radio)",
                        charData.PlayerHandle);
                    break;
                case GroupMessageType.Ooc:
                    if (!Groups.Library.DoesGroupHasPerm(groupData.Id, Permissions.SharedChatOoc))
                    {
                        Ui.ShowError(charData.PlayerHandle, "Grupa nie posiada dostępu do radia OOC.");
                        return;
                    }

                    if (!Groups.Library.DoesPlayerHasPerm(charData.PlayerHandle, groupData.Id,
                        Permissions.SharedChatOoc))
                    {
                        Ui.ShowError(charData.PlayerHandle, "Nie posiadasz uprawnień do użycia radia OOC.");
                        return;
                    }

                    if (groupData.ChatDisabled)
                    {
                        Ui.ShowError(charData.PlayerHandle,
                            $"Czat OOC w grupie \"{groupData.Name}\" został wyłączony.");
                        return;
                    }

                    Groups.Library.SendGroupOocMessage(groupData.Id,
                        $"{Player.GetPlayerOocName(charData, true)}: {Command.UpperFirst(message)}");
                    break;
                default: return;
            }
        }

        /// <summary>
        /// Wysyła lokalną wiadomość czatu
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="message"></param>
        /// <param name="pronoun"></param>
        /// <param name="ignoredEntity"></param>
        /// <param name="action"></param>
        /// <param name="messageType"></param>
        public static void SendPlayerLocalMessage(Character charData, string message, string pronoun,
            Client ignoredEntity = null, bool action = true, LocalMessageType messageType = LocalMessageType.Talk)
        {
            string messageOutput = $"{Player.GetPlayerIcName(charData)} {pronoun}: {Command.UpperFirst(message)}";
            double radius =
                messageType == LocalMessageType.Shout ? Constants.RadiusShout :
                messageType == LocalMessageType.Whisper ? Constants.RadiusQuiet :
                messageType == LocalMessageType.Megaphone ? Constants.RadiusMegapthone :
                Constants.RadiusTalk;

            IEnumerable<Character> playersInRadius = Global.GetPlayersInRange(charData.PlayerHandle.Position, radius,
                charData.PlayerHandle.Dimension);

            List<int> asterisks = new List<int>();
            if (action)
            {
                asterisks = GetAsterisksInText(messageOutput);
                if (asterisks.Count > 0 && asterisks.Count % 2 != 0) asterisks.RemoveAt(asterisks.Count - 1);
            }

            foreach (Character entry in playersInRadius)
            {
                if (ignoredEntity != null && ignoredEntity == entry.PlayerHandle) continue;

                string outputMessage = $"{messageOutput}";
                double progress =
                    Global.GetDistanceBetweenPositions(charData.PlayerHandle.Position, entry.PlayerHandle.Position) /
                    radius;

                int cr = (int) Math.Floor(Global.Lerp(255, 60, (float) progress));
                int cg = (int) Math.Floor(Global.Lerp(255, 60, (float) progress));
                int cb = (int) Math.Floor(Global.Lerp(255, 60, (float) progress));

                if (messageType == LocalMessageType.Megaphone)
                {
                    cr = (int) Math.Floor(Global.Lerp(252, 173, (float) progress));
                    cg = (int) Math.Floor(Global.Lerp(249, 170, (float) progress));
                    cb = (int) Math.Floor(Global.Lerp(63, 10, (float) progress));
                }

                if (action)
                    if (asterisks.Count > 0)
                    {
                        int r = (int) Math.Floor(Global.Lerp(194, 144, (float) progress)),
                            g = (int) Math.Floor(Global.Lerp(162, 112, (float) progress)),
                            b = (int) Math.Floor(Global.Lerp(218, 168, (float) progress));
                        for (int i = asterisks.Count - 1; i > -1; i--)
                            if (i % 2 == 0)
                                outputMessage = $"{outputMessage.Substring(0, asterisks[i])}!{{{r}, {g}, {b}}}" +
                                                $"{outputMessage.Substring(asterisks[i])}";
                            else
                                outputMessage = $"{outputMessage.Substring(0, asterisks[i] + 1)}!{{{cr}, {cg}, {cb}}}" +
                                                $"{outputMessage.Substring(asterisks[i] + 1)}";
                    }

                entry.PlayerHandle.SendChatMessage($"!{{{cr}, {cg}, {cb}}}{outputMessage}");
                Log.LogPlayer(charData, messageOutput, LogType.ChatIc);
            }
        }

        /// <summary>
        /// Wysyła lokalną wiadomość czatu
        /// </summary>
        /// <param name="player"></param>
        /// <param name="message"></param>
        /// <param name="pronoun"></param>
        /// <param name="ignoredEntity"></param>
        /// <param name="action"></param>
        /// <param name="messageType"></param>
        public static void SendPlayerLocalMessage(Client player, string message, string pronoun,
            Client ignoredEntity = null, bool action = true, LocalMessageType messageType = LocalMessageType.Talk)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            SendPlayerLocalMessage(charData, message, pronoun, ignoredEntity, action, messageType);
        }

        /// <summary>
        /// Wysyła lokalną wiadomość czatu
        /// </summary>
        /// <param name="charId"></param>
        /// <param name="message"></param>
        /// <param name="pronoun"></param>
        /// <param name="ignoredEntity"></param>
        /// <param name="action"></param>
        /// <param name="messageType"></param>
        public static void SendPlayerLocalMessage(int charId, string message, string pronoun,
            Client ignoredEntity = null, bool action = true, LocalMessageType messageType = LocalMessageType.Talk)
        {
            Character charData = Account.GetPlayerData(charId);
            if (charData == null) return;
            SendPlayerLocalMessage(charData, message, pronoun, ignoredEntity, action, messageType);
        }


        /// <summary>
        /// Wysyła wiadomość /me.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="message"></param>
        /// <param name="systemMe"></param>
        public static void SendPlayerMeMessage(Character charData, string message, bool systemMe)
        {
            if (charData == null) return;
            message = Command.UpperFirst(message, true, false);
            string outputMessage = systemMe ? "* " : "** ";
            outputMessage += $"{Player.GetPlayerIcName(charData)} {message}";
            IEnumerable<Character> playersInRadius = Global.GetPlayersInRange(charData.PlayerHandle.Position,
                Constants.RadiusTalk, charData.PlayerHandle.Dimension);

            foreach (Character entry in playersInRadius)
            {
                double progress =
                    Global.GetDistanceBetweenPositions(charData.PlayerHandle.Position, entry.PlayerHandle.Position) /
                    Constants.RadiusTalk;
                int r = (int) Math.Floor(Global.Lerp(194, 144, (float) progress)),
                    g = (int) Math.Floor(Global.Lerp(162, 112, (float) progress)),
                    b = (int) Math.Floor(Global.Lerp(218, 168, (float) progress));

                entry.PlayerHandle.SendChatMessage($"!{{{r}, {g}, {b}}}{outputMessage}");
                Log.LogPlayer(entry, outputMessage, LogType.ActionIc);
            }
        }

        /// <summary>
        /// Wysyła wiadomość /me
        /// </summary>
        /// <param name="player"></param>
        /// <param name="message"></param>
        /// <param name="systemMe"></param>
        public static void SendPlayerMeMessage(Client player, string message, bool systemMe)
        {
            SendPlayerMeMessage(Account.GetPlayerData(player), message, systemMe);
        }

        /// <summary>
        /// Wysyła wiadomość /me
        /// </summary>
        /// <param name="charId"></param>
        /// <param name="message"></param>
        /// <param name="systemMe"></param>
        public static void SendPlayerMeMessage(int charId, string message, bool systemMe)
        {
            SendPlayerMeMessage(Account.GetPlayerData(charId), message, systemMe);
        }

        /// <summary>
        /// Wysyła wiadomość /do
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="message"></param>
        /// <param name="systemDo"></param>
        public static void SendPlayerDoMessage(Character charData, string message, bool systemDo)
        {
            if (charData == null) return;
            message = Command.UpperFirst(message);
            string outputMessage = systemDo ? "* " : "** ";
            outputMessage += $"{message} (( {Player.GetPlayerIcName(charData)} ))";
            IEnumerable<Character> playersInRadius = Global.GetPlayersInRange(charData.PlayerHandle.Position,
                Constants.RadiusTalk, charData.PlayerHandle.Dimension);

            foreach (Character entry in playersInRadius)
            {
                entry.PlayerHandle.SendChatMessage($"!{{#9A9CCD}}{outputMessage}");
                Log.LogPlayer(entry, outputMessage, LogType.ActionIc);
            }
        }

        /// <summary>
        /// Wysyła wiadomość /do
        /// </summary>
        /// <param name="player"></param>
        /// <param name="message"></param>
        /// <param name="systemDo"></param>
        public static void SendPlayerDoMessage(Client player, string message, bool systemDo)
        {
            SendPlayerMeMessage(Account.GetPlayerData(player), message, systemDo);
        }

        /// <summary>
        /// Wysyła wiadomość /do
        /// </summary>
        /// <param name="charId"></param>
        /// <param name="message"></param>
        /// <param name="systemDo"></param>
        public static void SendPlayerDoMessage(int charId, string message, bool systemDo)
        {
            SendPlayerMeMessage(Account.GetPlayerData(charId), message, systemDo);
        }

        /// <summary>
        /// Pobiera wszystkie gwiazdki z tekstu ("*")
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static List<int> GetAsterisksInText(string text)
        {
            List<int> output = new List<int>();
            for (int i = 0; i < text.Length; i++)
                if (text[i] == '*')
                    output.Add(i);

            return output;
        }
    }
}