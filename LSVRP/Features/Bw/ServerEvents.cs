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

namespace LSVRP.Features.Bw
{
    public class ServerEvents : Script
    {
        [ServerEvent(Event.PlayerDeath)]
        public void Event_OnPlayerDeath(Client player, Client killer, uint reason)
        {
            Library.SetPlayerBw(player, 600, true);
        }
    }
}