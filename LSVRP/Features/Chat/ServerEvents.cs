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
using LSVRP.Libraries;
using LSVRP.Managers;

namespace LSVRP.Features.Chat
{
    public class ServerEvents : Script
    {
        /// <summary>
        /// Event wykonujący się w momencie wysłania przez gracza wiadomości
        /// </summary>
        /// <param name="player"></param>
        /// <param name="message"></param>
        [ServerEvent(Event.ChatMessage)]
        public void Event_OnChatMessage(Client player, string message)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (message.StartsWith("!"))
            {
                if (message.Length < 5)
                {
                    Ui.ShowUsage(player, "![slot grupy] [treść]");
                    return;
                }

                int groupSlot = Command.GetNumberFromString(message.Substring(1, 2));
                if (groupSlot == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano błędny slot grupy.");
                    return;
                }

                Library.SendPlayerMessageGroup(charData, groupSlot, GroupMessageType.Ic, message.Substring(3));
            }
            else if (message.StartsWith("@"))
            {
                if (message.Length < 5)
                {
                    Ui.ShowUsage(player, "@[slot grupy] [treść]");
                    return;
                }

                int groupSlot = Command.GetNumberFromString(message.Substring(1, 2));
                if (groupSlot == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano błędny slot grupy.");
                    return;
                }

                Library.SendPlayerMessageGroup(charData, groupSlot, GroupMessageType.Ooc, message.Substring(3));
            }
            else if (message.StartsWith("."))
            {
                string animName = message.Substring(1).ToLower();
                Animation animData = Animations.Library.GetAnimation(animName);
                if (animData == null)
                {
                    Ui.ShowError(player, "Animacja nie istnieje.");
                    return;
                }

                Animations.Library.PlayAnimation(charData, animData);
            }
            else
            {
                // TODO: emotikonki
                if (Bw.Library.DoesPlayerHasBw(charData))
                {
                    Ui.ShowError(player, "Nie możesz rozmawiać w trakcie trwania BW.");
                    return;
                }
                // TODO: Telefon

                Library.SendPlayerLocalMessage(charData, message, "mówi");
            }
        }
    }
}