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
using LSVRP.Managers;
using LSVRP.Modules;
using Log = LSVRP.Modules.Log;

// ReSharper disable UnusedMember.Global

namespace LSVRP.Features.Login
{
    public class ServerEvents : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public async void Event_PlayerConnected(Client player)
        {
            if (Timers.Library.TimersOffline)
            {
                player.SendChatMessage("Trwa restart serwera, wróć później.");
                player.Kick("Trwa restart serwera, wróć później.");
                return;
            }

            Log.ConsoleLog("ENTRY",
                $"{player.Name} wszedł do gry (ip: {player.Address} sc: {player.SocialClubName}, serial: {player.Serial})",
                LogType.Debug);
            player.Dimension = 50000;
            bool doesPlayerHasBan = await Library.DoesClientHasBan(player);
            if (doesPlayerHasBan)
            {
                player.SendChatMessage("Jesteś zbanowany.");
                player.Kick("Jesteś zbanowany.");
            }
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void Event_PlayerDisconnected(Client player, DisconnectionType disconnectionType, string reason)
        {
            Log.ConsoleLog("ENTRY", $"{player.Name} wyszedł z gry (ip: {player.Address} sc: {player.SocialClubName})",
                LogType.Debug);


            Character charData = Account.GetPlayerData(player);
            if (charData != null)
            {
                int groupDuty = Groups.Library.GetPlayerGroupDuty(charData);
                if (groupDuty != 0) Groups.Library.TogglePlayerDuty(charData, groupDuty, false);

                charData.SaveAsync();
            }

            Sync.Library.ResetPlayerData(player);
            Jobs.Courier.Library.StopCourier(player); // Wyłączenie zleceń kuriera.

            // Zawsze ostatnie.
            Account.RemovePlayerData(player);
        }
    }
}