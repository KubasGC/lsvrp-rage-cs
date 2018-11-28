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
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Libraries;
using LSVRP.Managers;
using Newtonsoft.Json;

namespace LSVRP.Features.Base
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.scoretab.pressed")]
        public void Event_ScoretabPressed(Client player)
        {
            List<PlayerListData> output = new List<PlayerListData>();
            foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
                output.Add(new PlayerListData(entry.Value.ServerId,
                    Command.AddSlashes(Player.GetPlayerIcName(entry.Value)), entry.Value.VisualPoints,
                    NAPI.Player.GetPlayerPing(entry.Value.PlayerHandle)));

            output = output.OrderBy(t => t.Id).ToList();

            NAPI.ClientEvent.TriggerClientEvent(player, "client.scoretab.show",
                JsonConvert.SerializeObject(output, Formatting.None));
        }
    }
}