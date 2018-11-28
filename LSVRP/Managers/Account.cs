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
using System.Linq;
using System.Threading.Tasks;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Libraries;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Log = LSVRP.Modules.Log;
using LogType = LSVRP.Modules.LogType;
using Tattoo = LSVRP.Features.Tattoos.Tattoo;

namespace LSVRP.Managers
{
    public static class Account
    {
        /// <summary>
        /// Typy ServerData
        /// </summary>
        public enum ServerData
        {
            AdminReportId,
            GroupPanelId,
            ReportedPlayer,
            DialogVehicleId,
            DialogVehicleAdminEdit,
            TargetingAtVehicle,
            ChoosedClothSet,
            DialogGroupId,
            DialogGroupOrderId,
            DialogGroupOrderQuantity,
            DialogGroupAdminData,
            CornerId,
            CornerMaxPrice,
            CornerItemCount,
            CornerItem,
            ItemReloadWeaponAmmoItem,
            PenaltyPlayerId,
            PenaltyReason,
            TempDialogData
        }

        private static readonly Dictionary<int, Character>
            CharactersList = new Dictionary<int, Character>();

        /// <summary>
        /// Pobiera słownik zawierający wszystkich graczy
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, Character> GetAllPlayers()
        {
            return CharactersList;
        }

        /// <summary>
        /// Pobiera listę streamowanych aktualnie graczy.
        /// </summary>
        /// <param name="charData"></param>
        /// <returns></returns>
        public static IEnumerable<Character> GetStreamedPlayers(Character charData)
        {
            List<Character> output = new List<Character>();
            if (charData == null || charData.PlayerHandle == null ||
                !NAPI.Entity.DoesEntityExist(charData.PlayerHandle)) return output;

            Vector3 pPosition = charData.PlayerHandle.Position;

            foreach (KeyValuePair<int, Character> entry in GetAllPlayers())
            {
                if (entry.Value.PlayerHandle == null ||
                    !NAPI.Entity.DoesEntityExist(entry.Value.PlayerHandle)) continue;
                if (entry.Value.PlayerHandle.Dimension != charData.PlayerHandle.Dimension) continue;
                if (Global.GetDistanceBetweenPositions(pPosition, entry.Value.PlayerHandle.Position) >
                    Constants.StreamDistance) continue;

                output.Add(entry.Value);
            }

            return output;
        }

        public static void SetServerData(Character charData, ServerData serverData, object data)
        {
            if (charData == null) return;

            if (!charData.ServerData.ContainsKey(serverData))
                charData.ServerData.Add(serverData, data);
            else
                charData.ServerData[serverData] = data;
        }

        public static void RemoveServerData(Character charData, ServerData serverData)
        {
            if (charData.ServerData.ContainsKey(serverData)) charData.ServerData.Remove(serverData);
        }

        public static object GetServerData(Character charData, ServerData serverData)
        {
            return charData.ServerData.ContainsKey(serverData) ? charData.ServerData[serverData] : null;
        }

        /// <summary>
        /// Pobiera dane gracza po Id na serwerze
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public static Character GetPlayerDataByServerId(int playerId)
        {
            foreach (KeyValuePair<int, Character> entry in CharactersList)
                if (entry.Value.ServerId == playerId)
                    return entry.Value;

            return null;
        }

        /// <summary>
        /// Pobiera dane gracza korzystając z NetHandle
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static Character GetPlayerData(Client player)
        {
            if (player == null) return null;
            return CharactersList.ContainsKey(player.Value) ? CharactersList[player.Value] : null;
        }

        /// <summary>
        /// Pobiera dane gracza korzystając z Id postaci
        /// </summary>
        /// <param name="charId"></param>
        /// <returns></returns>
        public static Character GetPlayerData(int charId)
        {
            foreach (KeyValuePair<int, Character> entry in CharactersList)
                if (entry.Value.Id == charId)
                    return entry.Value;

            return null;
        }

        /// <summary>
        /// Usuwa dane gracza
        /// </summary>
        /// <param name="player"></param>
        public static void RemovePlayerData(Client player)
        {
            Character charData = GetPlayerData(player);
            if (charData == null) return;

            Log.ConsoleLog("ACCOUNT",
                $"Gracz {Player.GetPlayerDebugName(charData)} wyszedl. Usunięto PlayerData.", LogType.Debug);
            charData.InGame = false;
            charData.LastLogin = Global.GetTimestamp();
            charData.Save();

            CharactersList.Remove(player.Value);
        }

        public static void RemovePlayerData(Character charData)
        {
            if (charData == null) return;

            charData.InGame = false;
            charData.LastLogin = Global.GetTimestamp();
            charData.Save();
            CharactersList.Remove(charData.PlayerHandle.Value);
        }


        /// <summary>
        /// Pobiera z bazy danych dane gracza.
        /// </summary>
        /// <param name="charId"></param>
        /// <returns></returns>
        public static Character GetPlayerDataOnly(int charId)
        {
            using (Database.Database db = new Database.Database())
            {
                return db.Characters.FirstOrDefault(t => t.Id == charId);
            }
        }

        /// <summary>
        /// Laduje do pamięci dane gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="charId"></param>
        /// <returns></returns>
        public static async Task<Character> LoadPlayerData(Client player, int charId)
        {
            using (Database.Database db = new Database.Database())
            {
                Character charInfo = await db.Characters.FirstOrDefaultAsync(t => t.Id == charId);
                if (charInfo == null) return null;
                ForumMember memberData =
                    await db.ForumMembers.FirstOrDefaultAsync(t => t.MemberId == charInfo.MemberId);
                charInfo.AdminLevel = 0;
                charInfo.HasAdminDuty = false;
                charInfo.HasMask = false;
                charInfo.HasCustomName = false;
                charInfo.CustomName = null;
                charInfo.AdminPerm = new List<object>();
                charInfo.LastWhisper = null;
                charInfo.WhisperBlock = false;
                charInfo.Cuff = null;
                charInfo.RadioBlock = false;
                charInfo.HasInvisibleEnabled = false;
                charInfo.ServerId = player.Value;
                charInfo.ServerData = new Dictionary<ServerData, object>();
                charInfo.IsCrouching = false;
                charInfo.Tattoos = new List<Tattoo>();
                charInfo.SyncedTattoos = new List<int>();
                charInfo.UsedWeapon = null;
                charInfo.PlayerHandle = player;
                charInfo.AnimPlayer = null;
                charInfo.LoadDrugs();

                List<Database.Models.Tattoo> tattoos =
                    await db.Tattoos.Where(t => t.CharId == charInfo.Id).ToListAsync();
                foreach (Database.Models.Tattoo entry in tattoos) charInfo.SyncedTattoos.Add(entry.TattooId);

                WalkingStyle charWalkingStyle =
                    await db.WalkingStyles.FirstOrDefaultAsync(t => t.Id == charInfo.WalkingStyle);

                if (charWalkingStyle == default(WalkingStyle))
                {
                    charInfo.WalkingStyleAnim = null;
                }
                else
                {
                    charInfo.WalkingStyleAnim = charWalkingStyle.AnimName;
                    if (charInfo.WalkingStyleAnim.Length < 2) charInfo.WalkingStyleAnim = null;
                }

                try
                {
                    charInfo.AdminPerm = JsonConvert.DeserializeObject<List<object>>(memberData.AdminFlags);
                }
                catch (Exception e)
                {
                    Log.ConsoleLog("ACCOUNT", $"(USER {charInfo.Name} {charInfo.Lastname}) {e.Message}",
                        LogType.Error);
                    charInfo.AdminPerm = new List<object>();
                }


                CharactersList.Add(charInfo.PlayerHandle.Value, charInfo);

                return charInfo;
            }
        }

        /// <summary>
        /// Zapisuje gracza
        /// </summary>
        /// <param name="player"></param>
        public static void SavePlayer(Client player)
        {
            Character playerData = GetPlayerData(player);
            playerData?.Save();
        }

        /// <summary>
        /// Zapisuje gracza
        /// </summary>
        /// <param name="charId"></param>
        public static void SavePlayer(int charId)
        {
            Character playerData = GetPlayerData(charId);
            playerData?.Save();
        }
    }
}