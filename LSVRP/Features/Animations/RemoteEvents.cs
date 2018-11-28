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

namespace LSVRP.Features.Animations
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.anim.stopAnim")]
        public void StopAnim(Client player)
        {
            NAPI.Player.StopPlayerAnimation(player);
            NAPI.ClientEvent.TriggerClientEvent(player, "client.animation.hideInfo");
        }
    }
}