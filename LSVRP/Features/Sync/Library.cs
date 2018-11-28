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
using Newtonsoft.Json;
using System.Collections.Generic;
using Log = LSVRP.Modules.Log;
using LogType = LSVRP.Modules.LogType;

namespace LSVRP.Features.Sync
{
    public static class Library
    {
        /// <summary>
        /// Słownik zawierający wszystkie synchronizowane dane graczy.
        /// </summary>
        private static readonly Dictionary<int, Dictionary<string, object>> PlayersData =
            new Dictionary<int, Dictionary<string, object>>();

        public static string GetJsonPlayersData()
        {
            return JsonConvert.SerializeObject(PlayersData, Formatting.None);
        }

        /// <summary>
        /// Ustawia synchronizowane dane dla danego gracza.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="dataName"></param>
        /// <param name="dataValue"></param>
        public static void SetPlayerSyncedData(Client player, string dataName, object dataValue)
        {
            if (!PlayersData.ContainsKey(player.Value)) PlayersData.Add(player.Value, new Dictionary<string, object>());

            if (PlayersData[player.Value].ContainsKey(dataName)) PlayersData[player.Value].Remove(dataName);
            PlayersData[player.Value].Add(dataName, dataValue);
            foreach (Client entry in NAPI.Pools.GetAllPlayers())
                NAPI.ClientEvent.TriggerClientEvent(entry, "client.syncmanager.loadplayerdata", player.Value, dataName,
                    dataValue);

            Log.ConsoleLog("SYNC",
                $"Ustawiono dla gracza {Player.GetPlayerDebugName(player)} [dataName: {dataName} " +
                $"dataValue: {dataValue}]", LogType.Debug);
        }

        /// <summary>
        /// Ustawia synchronizowane dane dla danego gracza.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="data"></param>
        public static void SetPlayerSyncedData(Client player, IEnumerable<PlayerData> data)
        {
            if (!PlayersData.ContainsKey(player.Value)) PlayersData.Add(player.Value, new Dictionary<string, object>());

            foreach (PlayerData dataEntry in data)
            {
                if (PlayersData[player.Value].ContainsKey(dataEntry.Name))
                    PlayersData[player.Value].Remove(dataEntry.Name);
                PlayersData[player.Value].Add(dataEntry.Name, dataEntry.Value);
            }

            string serializedObject = JsonConvert.SerializeObject(data, Formatting.None);
            foreach (Client entry in NAPI.Pools.GetAllPlayers())
                NAPI.ClientEvent.TriggerClientEvent(entry, "client.syncmanager.loadplayermoredata", player.Value,
                    serializedObject);

            Log.ConsoleLog("SYNC",
                $"Ustawiono dla gracza {Player.GetPlayerDebugName(player)} [wiele danych]", LogType.Debug);
        }

        /// <summary>
        /// Zwraca synchronizowane dane danego gracza.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="dataName"></param>
        /// <returns></returns>
        public static object GetPlayerData(Client player, string dataName)
        {
            if (!PlayersData.ContainsKey(player.Value)) return null;
            return PlayersData[player.Value].ContainsKey(dataName) ? PlayersData[player.Value][dataName] : null;
        }

        /// <summary>
        /// Sprawdza czy gracz ma ustawioną daną o podanej nazwie
        /// </summary>
        /// <param name="player"></param>
        /// <param name="dataName"></param>
        /// <returns></returns>
        public static bool HasPlayerData(Client player, string dataName)
        {
            return PlayersData[player.Value].ContainsKey(dataName);
        }

        /// <summary>
        /// Usuwa synchronizowane dane dla danego gracza.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="dataName"></param>
        public static void DeletePlayerData(Client player, string dataName)
        {
            if (!PlayersData.ContainsKey(player.Value)) return;
            if (!PlayersData[player.Value].ContainsKey(dataName)) return;
            PlayersData[player.Value].Remove(dataName);
            foreach (Client entry in NAPI.Pools.GetAllPlayers())
                NAPI.ClientEvent.TriggerClientEvent(entry, "client.syncmanager.deleteplayerdata", player.Value,
                    dataName);

            Log.ConsoleLog("SYNC",
                $"Usunięto dla gracza {Player.GetPlayerDebugName(player)} [dataName: {dataName}]", LogType.Debug);
        }

        /// <summary>
        /// Usuwa wszystkie synchronizowane dane dla danego gracza.
        /// </summary>
        /// <param name="player"></param>
        public static void ResetPlayerData(Client player)
        {
            if (!PlayersData.ContainsKey(player.Value)) return;
            PlayersData.Remove(player.Value);
            foreach (Client entry in NAPI.Pools.GetAllPlayers())
                NAPI.ClientEvent.TriggerClientEvent(entry, "client.syncmanager.resetplayerdata", player.Value);

            Log.ConsoleLog("SYNC",
                $"Zresetowano dla gracza {Player.GetPlayerDebugName(player)}", LogType.Debug);
        }

        public static void SyncPlayerForPlayer(Client player, Client forPlayer = null)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData?.SkinLook == null) return;

            List<int> nicknameDescs = new List<int>();

            if (charData.OnlineTime < 36000) nicknameDescs.Add(1); // Nowa postać

            if (charData.DrugAddictions != null)
            {
                if (charData.DrugAddictions.MarijuanaTime > 0) nicknameDescs.Add(2); // Zrelaksowany
                if (charData.DrugAddictions.CocaineTime > 0) nicknameDescs.Add(3); // Nadpobudliwy
            }

            if (charData.BwTime > 0) nicknameDescs.Add(4);

            string mugshotData = !HasPlayerData(player, "MugshotTitle") ||
                                 !HasPlayerData(player, "MugshotTop") ||
                                 !HasPlayerData(player, "MugshotMiddle") ||
                                 !HasPlayerData(player, "MugshotBottom") ? null : JsonConvert.SerializeObject(new
                                 {
                                     title = GetPlayerData(player, "MugshotTitle"),
                                     top = GetPlayerData(player, "MugshotTop"),
                                     middle = GetPlayerData(player, "MugshotMiddle"),
                                     bottom = GetPlayerData(player, "MugshotBottom")
                                 });

            if (forPlayer != null)
            {
                Character targetData = Account.GetPlayerData(forPlayer);
                if (targetData == null) return;

                NAPI.ClientEvent.TriggerClientEvent(targetData.PlayerHandle, "client.syncmanager.syncplayer",
                    player.Value, charData.WalkingStyleAnim ?? "null", charData.IsCrouching, charData.HairId,
                    charData.HairColor, JsonConvert.SerializeObject(charData.Tattoos),
                    JsonConvert.SerializeObject(charData.SyncedTattoos), JsonConvert.SerializeObject(nicknameDescs),
                    charData.GetBlendSync(),
                    charData.AnimPlayer == null ? null : JsonConvert.SerializeObject(charData.AnimPlayer),
                    mugshotData);
            }
            else
            {
                foreach (Character targetData in Account.GetStreamedPlayers(charData))
                    NAPI.ClientEvent.TriggerClientEvent(targetData.PlayerHandle, "client.syncmanager.syncplayer",
                        player.Value, charData.WalkingStyleAnim ?? "null", charData.IsCrouching, charData.HairId,
                        charData.HairColor, JsonConvert.SerializeObject(charData.Tattoos),
                        JsonConvert.SerializeObject(charData.SyncedTattoos),
                        JsonConvert.SerializeObject(nicknameDescs), charData.GetBlendSync(),
                        charData.AnimPlayer == null ? null : JsonConvert.SerializeObject(charData.AnimPlayer),
                        mugshotData);
            }
        }
    }
}