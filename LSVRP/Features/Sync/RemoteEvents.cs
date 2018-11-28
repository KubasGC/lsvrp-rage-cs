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
using System.Linq;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Libraries;
using LSVRP.Managers;

namespace LSVRP.Features.Sync
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.syncmanager.setlocalplayerdata")]
        public void Event_SetLocalPlayerData(Client player, string dataName, object dataValue)
        {
            Library.SetPlayerSyncedData(player, dataName, dataValue);
        }

        [RemoteEvent("server.syncmanager.syncdataafterlogin")]
        public void Event_SyncDataAfterLogin(Client player)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "client.syncmanager.loadallplayersdata",
                Library.GetJsonPlayersData());
        }

        [RemoteEvent("server.player.sync")]
        public void Event_PlayerSync(Client player, int remoteId)
        {
            Client target = NAPI.Pools.GetAllPlayers().FirstOrDefault(t => t.Value == remoteId);
            if (target == default(Client)) return;

            Library.SyncPlayerForPlayer(target, player);
        }

        [RemoteEvent("server.player.crouch")]
        public void Event_PlayerCrouch(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (Global.GetTimestamp() - charData.LastCrouchChange < 1) return;

            charData.LastCrouchChange = Global.GetTimestamp();
            charData.IsCrouching = !charData.IsCrouching;
            Library.SyncPlayerForPlayer(player);
        }
    }
}