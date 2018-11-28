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

namespace LSVRP.Features.Groups
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.vehPaint.save")]
        public void Event_VehPaintSave(Client player, int colorOne, int colorTwo)
        {
            // TODO Event_VehPaintSave
        }

        public void Event_OnMarkerEnter(Client player, string markerName)
        {
            if (markerName == "emergency.blip")
            {
                Character charData = Account.GetPlayerData(player);
                if (charData == null) return;
                charData.EmergencyBlip = false;
                NAPI.ClientEvent.TriggerClientEvent(player, "client.markers.destroyMarker", "emergency.blip");
            }
        }
    }
}