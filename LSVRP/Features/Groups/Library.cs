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
using System.Threading;
using System.Threading.Tasks;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Dialogs;
using LSVRP.Libraries;
using LSVRP.Managers;
using LSVRP.New.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Log = LSVRP.Modules.Log;
using LogType = LSVRP.Modules.LogType;

namespace LSVRP.Features.Groups
{
    public static class Library
    {
        /// <summary>
        /// Słownik zawierający informacje o wszystkich załadowanych grupach
        /// </summary>
        private static readonly Dictionary<int, Group> GroupsList = new Dictionary<int, Group>();

        /// <summary>
        /// Słownik zawierający ilość osób online w danym typie grupy.
        /// </summary>
        private static readonly Dictionary<int, int> GroupTypesOnline = new Dictionary<int, int>();

        /// <summary>
        /// Zwraca słownik zawierający wszystkie załadowane grupy
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, Group> GetGroups()
        {
            return GroupsList;
        }

        /// <summary>
        /// Funkcja uruchamiana wraz ze startem serwera. Ładuje wszystkie grupy do pamięci
        /// </summary>
        public static void LoadGroups()
        {
            double startTime = Global.GetTimestampMs();
            using (Database.Database db = new Database.Database())
            {
                List<Group> loadedGroups = db.Groups.ToList();
                foreach (Group entry in loadedGroups)
                    /* try
                         {
                             List<object> permissions =
                                 JsonConvert.DeserializeObject<List<object>>(entry.Permissions ?? "");
                             entry.ListedPermissions = permissions;
                         }
                         catch (Exception e)
                         {
                             Modules.Log.ConsoleLog("GROUPS", $"{e.Message}", Modules.LogType.Error);
                         }
     
                         GroupsList.Add(entry.Id, entry);*/
                    LoadGroup(entry);

                Log.ConsoleLog("GROUPS",
                    $"Załadowano grupy ({GroupsList.Count}) | {Global.GetTimestampMs() - startTime}ms");
            }
        }

        public static void LoadGroup(Group groupData)
        {
            try
            {
                List<object> permissions =
                    JsonConvert.DeserializeObject<List<object>>(groupData.Permissions ?? "");
                groupData.ListedPermissions = permissions;
            }
            catch (Exception e)
            {
                Log.ConsoleLog("GROUPS", $"{e.Message}", LogType.Error);
            }

            if (groupData.ListedPermissions == null) groupData.ListedPermissions = new List<object>();

            GroupsList.Add(groupData.Id, groupData);
        }

        public static void BuildEmergencyGroups(Client player)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                if (!GroupTypesOnline.ContainsKey((int) GroupType.Pd) ||
                    !GroupTypesOnline.ContainsKey((int) GroupType.Fd)) return;

                int factions = 0;

                if (GroupTypesOnline[(int) GroupType.Pd] > 0) factions += 1;
                if (GroupTypesOnline[(int) GroupType.Fd] > 0) factions += 2;

                NAPI.ClientEvent.TriggerClientEvent(player, "client.syncmanager.syncFactions",
                    factions);
            });

            /*new Thread(() =>
            {
                if (!GroupTypesOnline.ContainsKey((int) GroupType.Pd) ||
                    !GroupTypesOnline.ContainsKey((int) GroupType.Fd)) return;

                int factions = 0;

                if (GroupTypesOnline[(int) GroupType.Pd] > 0) factions += 1;
                if (GroupTypesOnline[(int) GroupType.Fd] > 0) factions += 2;

                NAPI.ClientEvent.TriggerClientEvent(player, "client.syncmanager.syncFactions",
                    factions);
            }).Start();*/
        }

        /// <summary>
        /// Recount grup emergency i ustawienie właściwych markerów w prawym dolnym rogu HUDu.
        /// </summary>
        private static void CountEmergencyGroups()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                int policeCount = 0;
                int fireCount = 0;

                foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
                {
                    if (entry.Value == null) continue;

                    if (GetPlayerGroupTypes(entry.Value, true).Any(t => t == (int) GroupType.Pd))
                        policeCount++;
                    if (GetPlayerGroupTypes(entry.Value, true).Any(t => t == (int) GroupType.Fd))
                        fireCount++;
                }

                bool changed = !GroupTypesOnline.ContainsKey((int) GroupType.Pd) ||
                               policeCount > 0 && GroupTypesOnline[(int) GroupType.Pd] == 0 ||
                               policeCount == 0 && GroupTypesOnline[(int) GroupType.Pd] != 0 ||
                               !GroupTypesOnline.ContainsKey((int) GroupType.Fd) ||
                               fireCount > 0 && GroupTypesOnline[(int) GroupType.Fd] == 0 ||
                               fireCount == 0 && GroupTypesOnline[(int) GroupType.Fd] != 0;

                if (!changed) return;

                int factions = 0;
                if (policeCount > 0) factions += 1;
                if (fireCount > 0) factions += 2;

                if (GroupTypesOnline.ContainsKey((int) GroupType.Pd))
                    GroupTypesOnline.Remove((int) GroupType.Pd);
                if (GroupTypesOnline.ContainsKey((int) GroupType.Fd))
                    GroupTypesOnline.Remove((int) GroupType.Fd);

                GroupTypesOnline.Add((int) GroupType.Pd, policeCount);
                GroupTypesOnline.Add((int) GroupType.Fd, fireCount);

                foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
                    NAPI.ClientEvent.TriggerClientEvent(entry.Value.PlayerHandle,
                        "client.syncmanager.syncFactions",
                        factions);
            });

            /*new Thread(() =>
            {
                int policeCount = 0;
                int fireCount = 0;

                foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
                {
                    if (entry.Value == null) continue;

                    if (GetPlayerGroupTypes(entry.Value, true).Any(t => t == (int) GroupType.Pd))
                        policeCount++;
                    if (GetPlayerGroupTypes(entry.Value, true).Any(t => t == (int) GroupType.Fd))
                        fireCount++;
                }

                bool changed = !GroupTypesOnline.ContainsKey((int) GroupType.Pd) ||
                               policeCount > 0 && GroupTypesOnline[(int) GroupType.Pd] == 0 ||
                               policeCount == 0 && GroupTypesOnline[(int) GroupType.Pd] != 0 ||
                               !GroupTypesOnline.ContainsKey((int) GroupType.Fd) ||
                               fireCount > 0 && GroupTypesOnline[(int) GroupType.Fd] == 0 ||
                               fireCount == 0 && GroupTypesOnline[(int) GroupType.Fd] != 0;

                if (!changed) return;

                int factions = 0;
                if (policeCount > 0) factions += 1;
                if (fireCount > 0) factions += 2;

                if (GroupTypesOnline.ContainsKey((int) GroupType.Pd))
                    GroupTypesOnline.Remove((int) GroupType.Pd);
                if (GroupTypesOnline.ContainsKey((int) GroupType.Fd))
                    GroupTypesOnline.Remove((int) GroupType.Fd);

                GroupTypesOnline.Add((int) GroupType.Pd, policeCount);
                GroupTypesOnline.Add((int) GroupType.Fd, fireCount);

                foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
                    NAPI.ClientEvent.TriggerClientEvent(entry.Value.PlayerHandle,
                        "client.syncmanager.syncFactions",
                        factions);
            }).Start();*/
        }

        /// <summary>
        /// Zwraca listę typów grup gracza.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="onDuty"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetPlayerGroupTypes(Character charData, bool onDuty = false)
        {
            if (charData == null) return null;
            List<int> output = new List<int>();

            List<GroupMember> pGroups = GetPlayerGroups(charData.PlayerHandle);
            if (pGroups == null) return output;
            foreach (GroupMember entry in pGroups)
            {
                if (onDuty && !entry.Duty) continue;

                Group groupData = GetGroupData(entry.GroupId);
                if (groupData == null) continue;

                if (!output.Contains((int) groupData.Type)) output.Add((int) groupData.Type);
            }

            return output;
        }


        /// <summary>
        /// Zwraca informacje o grupie o podanym Id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static Group GetGroupData(int groupId)
        {
            return GroupsList.ContainsKey(groupId) ? GroupsList[groupId] : null;
        }

        /// <summary>
        /// Zwraca listę zawierającą grupy o określonym typie
        /// </summary>
        /// <param name="groupType"></param>
        /// <returns></returns>
        public static List<Group> GetGroupsByType(int groupType)
        {
            List<Group> output = new List<Group>();
            foreach (KeyValuePair<int, Group> entry in GroupsList)
                if ((int) entry.Value.Type == groupType)
                    output.Add(entry.Value);

            return output;
        }

        /// <summary>
        /// Zwraca typ grupy o podanym Id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static GroupType? GetGroupType(int groupId)
        {
            Group groupData = GetGroupData(groupId);
            return groupData?.Type;
        }

        /// <summary>
        /// Tworzy nową grupę
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="superLeaderId"></param>
        /// <returns></returns>
        public static Group CreateGroup(string name, int type, int superLeaderId)
        {
            using (Database.Database db = new Database.Database())
            {
                Group newGroup = new Group
                {
                    Code = "",
                    Name = name,
                    ColorR = 255,
                    ColorG = 255,
                    ColorB = 255,
                    Type = (GroupType) type,
                    SpawnX = 0.0,
                    SpawnY = 0.0,
                    SpawnZ = 0.0,
                    Status = 0,
                    SuperLeaderId = 0, // TODO
                    Cash = 0,
                    CreatedAt = Global.GetTimestamp(),
                    Permissions = "",
                    Donation = 0,
                    SpawnDimension = 0,
                    DefaultRank = 0,
                    OrdersType = 0
                };

                db.Groups.Add(newGroup);
                db.SaveChanges();

                // Dodawanie domyślnej rangi
                GroupRank newRank = new GroupRank
                {
                    GroupId = newGroup.Id,
                    Name = "Lider",
                    Level = 0,
                    Permissions = "[\"leader\"]",
                    CreatedAt = Global.GetTimestamp()
                };

                db.GroupRanks.Add(newRank);
                db.SaveChanges();

                newGroup.DefaultRank = newRank.Id;
                newGroup.Save();

                GroupsList.Add(newGroup.Id, newGroup);
                return newGroup;
            }
        }

        /// <summary>
        /// Funkcja uruchamiana wraz z zalogowaniem się gracza
        /// Laduje wszystkie grupy gracza
        /// </summary>
        /// <param name="player"></param>
        public static async void LoadPlayerGroups(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null)
                return;

            using (Database.Database db = new Database.Database())
            {
                var query = await (from member in db.GroupMembers
                    join rRank in db.GroupRanks on member.RankId equals rRank.Id into tempRank
                    from rank in tempRank.DefaultIfEmpty()
                    where member.CharacterId == charData.Id
                    select new
                    {
                        // GroupMembers
                        member.Id,
                        member.GroupId,
                        member.CharacterId,
                        member.RankId,
                        member.CreatedAt,
                        member.Payday,
                        member.DutyTime,
                        member.PaydayTimestamp,
                        member.PaydayAdded,
                        member.PaydayDay,
                        // GroupRanks
                        RankName = rank.Name,
                        RankPermissions = rank.Permissions
                    }).ToListAsync();

                if (query.Count <= 0)
                    return;

                charData.Groups = new List<GroupMember>();
                foreach (var group in query)
                {
                    GroupMember newGroup = new GroupMember
                    {
                        Id = group.Id,
                        GroupId = group.GroupId,
                        CharacterId = group.CharacterId,
                        RankId = group.RankId,
                        CreatedAt = group.CreatedAt,
                        Payday = group.Payday,
                        DutyTime = group.DutyTime,
                        PaydayTimestamp = group.PaydayTimestamp,
                        PaydayAdded = group.PaydayAdded,
                        PaydayDay = group.PaydayDay,
                        RankName = group.RankName,

                        Duty = false,
                        DutyStartTimestamp = 0,
                        RankPermissions = new List<object>(),
                        LastDutyTime = 0
                    };
                    try
                    {
                        newGroup.RankPermissions =
                            JsonConvert.DeserializeObject<List<object>>(group.RankPermissions);
                    }
                    catch (Exception e)
                    {
                        Log.ConsoleLog("GROUPS", $"(USER) {e.Message}", LogType.Error);
                    }

                    charData.Groups.Add(newGroup);
                }
            }

            Log.ConsoleLog("GROUPS",
                $"Załadowano grupy gracza {Player.GetPlayerIcName(player)} ({charData.Groups.Count})",
                LogType.Debug);
        }

        /// <summary>
        /// Zwraca wartość true jeśli grupa posiada wybrane uprawnienie, inaczej false
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="permName"></param>
        /// <returns></returns>
        public static bool DoesGroupHasPerm(int groupId, string permName)
        {
            Group groupData = GetGroupData(groupId);
            if (groupData == null) return false;

            foreach (object entry in groupData.ListedPermissions)
                if (entry.ToString().ToLower().Contains(permName.ToLower()))
                    return true;

            return false;
        }

        /// <summary>
        /// Zwraca wartośc true jeśli gracz posiada wybrane uprawnienie w grupie, inaczej false
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="groupId"></param>
        /// <param name="permName"></param>
        /// <param name="showInfo"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasPerm(Character charData, int groupId, string permName,
            bool showInfo = false)
        {
            if (charData == null) return false;
            GroupMember pGroupData = GetPlayerGroupData(charData.PlayerHandle, groupId);
            if (pGroupData == null) return false;
            foreach (string entry in pGroupData.RankPermissions)
                if (entry.ToLower().Contains(permName.ToLower()) ||
                    entry.ToLower().Contains(Permissions.RankLeader))
                    return true;

            if (showInfo) Ui.ShowError(charData.PlayerHandle, "Nie posiadasz odpowiednich uprawnień.");
            return false;
        }

        /// <summary>
        /// Zwraca wartośc true jeśli gracz posiada wybrane uprawnienie w grupie, inaczej false
        /// </summary>
        /// <param name="player"></param>
        /// <param name="groupId"></param>
        /// <param name="permName"></param>
        /// <param name="showInfo"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasPerm(Client player, int groupId, string permName,
            bool showInfo = false)
        {
            return DoesPlayerHasPerm(Account.GetPlayerData(player), groupId, permName, showInfo);
        }

        /// <summary>
        /// Zwraca obiekt GroupMember określający członkostwo gracza w grupie o podanym Id
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static GroupMember GetPlayerGroupData(Character charData, int groupId)
        {
            if (charData == null) return null;
            if (charData.Groups == null) return null;
            foreach (GroupMember entry in charData.Groups)
                if (entry.GroupId == groupId)
                    return entry;

            return null;
        }

        /// <summary>
        /// Zwraca obiekt GroupMember określający członkostwo gracza w grupie o podanym Id
        /// </summary>
        /// <param name="player"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static GroupMember GetPlayerGroupData(Client player, int groupId)
        {
            return GetPlayerGroupData(Account.GetPlayerData(player), groupId);
        }

        /// <summary>
        /// Zwraca listę graczy należących do grupy o podanym Id
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static List<GroupMember> GetPlayerGroups(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData?.Groups != null && charData.Groups.Count > 0) return charData.Groups;

            return null;
        }

        /// <summary>
        /// Zwraca Id grupy na której gracz duty się znajduje
        /// </summary>
        /// <param name="charData"></param>
        /// <returns></returns>
        public static int GetPlayerGroupDuty(Character charData)
        {
            if (charData?.Groups == null || charData.Groups.Count <= 0) return 0;
            foreach (GroupMember entry in charData.Groups)
                if (entry.Duty)
                    return entry.GroupId;

            return 0;
        }

        /// <summary>
        /// Zwraca Id grupy na której gracz duty się znajduje
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static int GetPlayerGroupDuty(Client player)
        {
            return GetPlayerGroupDuty(Account.GetPlayerData(player));
        }

        /// <summary>
        /// Włącza lub wyłącza duty gracza w grupie o podanym Id
        /// INFO: Można być na duty tylko jednej grupy jednocześnie
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="groupId"></param>
        /// <param name="state"></param>
        public static async void TogglePlayerDuty(Character charData, int groupId, bool state)
        {
            if (charData == null) return;
            if (Bw.Library.DoesPlayerHasBw(charData))
            {
                Ui.ShowError(charData.PlayerHandle, "Nie możesz zmieniać stanu duty w trakcie trwania BW.");
                return;
            }

            if (state)
            {
                GroupMember playerGroupData = GetPlayerGroupData(charData.PlayerHandle, groupId);
                if (playerGroupData == null)
                {
                    Ui.ShowError(charData.PlayerHandle, "Nie posiadasz tej grupy.");
                    return;
                }

                Group groupData = GetGroupData(playerGroupData.GroupId);
                if (groupData == null)
                {
                    Ui.ShowError(charData.PlayerHandle, "Grupa nie istnieje.");
                    return;
                }

                if (GetPlayerGroupDuty(charData) != 0)
                {
                    Ui.ShowError(charData.PlayerHandle, "Najpierw wyłącz duty w innej grupie.");
                    return;
                }

                playerGroupData.Duty = true;
                CountEmergencyGroups();

                PlayerDutyInfo playerDutyInfo = new PlayerDutyInfo
                {
                    GroupTag = groupData.Code,
                    GroupColor = new[] {groupData.ColorR, groupData.ColorG, groupData.ColorB}
                };
                // NAPI.Data.SetEntitySharedData(CharDa, "player.groupDutyInfo",
                //    JsonConvert.SerializeObject(playerDutyInfo, Formatting.None));
                Sync.Library.SetPlayerSyncedData(charData.PlayerHandle, "player.groupDutyInfo",
                    playerDutyInfo);

                Ui.ShowInfo(charData.PlayerHandle,
                    $"Rozpocząłeś służbę w grupie {groupData.Name} (UID: {groupData.Id})");
                Libraries.Log.LogPlayer(charData.PlayerHandle,
                    $"Grupa: {groupData.Name} (UID: {groupData.Id})",
                    Libraries.LogType.StartGroupDuty);

                using (Database.Database db = new Database.Database())
                {
                    await db.GroupDuties.AddAsync(new GroupDuty
                    {
                        GroupId = groupData.Id,
                        CharId = charData.Id,
                        StartTime = Global.GetTimestamp(),
                        EndTime = 0
                    });
                    await db.SaveChangesAsync();
                }
            }
            else
            {
                int playerGroupDuty = GetPlayerGroupDuty(charData);
                if (playerGroupDuty == 0)
                {
                    Ui.ShowWarning(charData.PlayerHandle, "Nie jesteś na duty żadnej grupy.");
                    return;
                }

                if (playerGroupDuty != groupId)
                {
                    Ui.ShowError(charData.PlayerHandle, "Nie jesteś na duty tej grupy.");
                    return;
                }

                GroupMember playerGroupData = GetPlayerGroupData(charData, groupId);
                if (playerGroupData == null)
                {
                    Ui.ShowError(charData.PlayerHandle, "Nie jesteś w tej grupie.");
                    return;
                }

                Group groupData = GetGroupData(groupId);
                if (groupData == null)
                {
                    Ui.ShowError(charData.PlayerHandle, "Grupa na której duty jesteś nie istnieje.");
                    return;
                }

                playerGroupData.Duty = false;
                CountEmergencyGroups();
                //NAPI.Data.ResetEntitySharedData(player, "player.groupDutyInfo");
                Sync.Library.DeletePlayerData(charData.PlayerHandle, "player.groupDutyInfo");
                Ui.ShowInfo(charData.PlayerHandle,
                    $"Zakończyłeś służbę w grupie {groupData.Name} (UID: {groupData.Id})");
                Libraries.Log.LogPlayer(charData, $"Grupa: {groupData.Name} (UID: {groupData.Id})",
                    Libraries.LogType.StopGroupDuty);

                using (Database.Database db = new Database.Database())
                {
                    GroupDuty dutySession = await db.GroupDuties.FirstOrDefaultAsync(t =>
                        t.GroupId == groupData.Id && t.CharId == charData.Id && t.EndTime == 0);
                    if (dutySession == null) return;
                    dutySession.EndTime = Global.GetTimestamp();
                    db.GroupDuties.Update(dutySession);
                    await db.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Włącza lub wyłącza duty gracza w grupie o podanym Id
        /// INFO: Można być na duty tylko jednej grupy jednocześnie
        /// </summary>
        /// <param name="player"></param>
        /// <param name="groupId"></param>
        /// <param name="state"></param>
        public static void TogglePlayerDuty(Client player, int groupId, bool state)
        {
            TogglePlayerDuty(Account.GetPlayerData(player), groupId, state);
        }

        /// <summary>
        /// Zwraca obiekt GroupMember określający członkostwo gracza w grupie o podanym slocie gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="slotId"></param>
        /// <returns></returns>
        public static GroupMember GetPlayerGroupBySlot(Client player, int slotId)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData?.Groups != null && charData.Groups.Count > 0)
                if (slotId > 0)
                    if (charData.Groups.ElementAtOrDefault(slotId - 1) != null)
                        return charData.Groups[slotId - 1];

            return null;
        }

        /// <summary>
        /// Zwraca slot grupy pod którym znajduje się grupa o podanym Id u danego gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static int GetPlayerGroupSlotById(Client player, int groupId)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData?.Groups != null && charData.Groups.Count > 0)
                foreach (GroupMember entry in charData.Groups)
                    if (entry.GroupId == groupId)
                        return charData.Groups.IndexOf(entry) + 1;

            return 0;
        }

        /// <summary>
        /// Zwraca true jeśli podany gracz jest w grupie o podanym Id, inaczej false
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasGroup(Character charData, int groupId)
        {
            if (charData?.Groups == null || charData.Groups.Count == 0) return false;
            foreach (GroupMember entry in charData.Groups)
                if (entry.GroupId == groupId)
                    return true;

            return false;
        }

        public static bool DoesPlayerHasGroup(Client player, int groupId)
        {
            return DoesPlayerHasGroup(Account.GetPlayerData(player), groupId);
        }

        /// <summary>
        /// Zwraca true jeśli podany gracz jest w grupie o podanym typie, inaczej false
        /// </summary>
        /// <param name="player"></param>
        /// <param name="groupType"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasGroupType(Client player, int groupType)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData?.Groups != null && charData.Groups.Count > 0)
                foreach (GroupMember entry in charData.Groups)
                {
                    Group groupData = GetGroupData(entry.GroupId);
                    if (groupData == null) continue;
                    if ((int) groupData.Type == groupType)
                        return true;
                }

            return false;
        }

        /// <summary>
        /// Zwraca listę graczy, będących w grupie o podanym Id. W przypadku, gdy grupa
        /// jest pusta, zwraca null.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="onDuty"></param>
        /// <returns></returns>
        public static List<Character> GetPlayersInGroup(int groupId, bool onDuty = false)
        {
            List<Character> output = new List<Character>();
            foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
            {
                if (!DoesPlayerHasGroup(entry.Value.PlayerHandle, groupId)) continue;
                if (onDuty)
                {
                    if (GetPlayerGroupDuty(entry.Value.PlayerHandle) == groupId)
                        output.Add(entry.Value);
                }
                else
                {
                    output.Add(entry.Value);
                }
            }

            return output;
        }

        /// <summary>
        /// Zwraca listę produktów które są w magazynie grupy
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static async Task<List<GroupProduct>> GetGroupProducts(int groupId)
        {
            using (Database.Database db = new Database.Database())
            {
                List<GroupProduct> groupProducts =
                    await db.GroupProducts.Where(t => t.GroupId == groupId).ToListAsync();
                return groupProducts;
            }
        }

        /// <summary>
        /// Wysyła wiadomośc na czacie IC grupy o podanym Id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="message"></param>
        public static void SendGroupIcMessage(int groupId, string message)
        {
            Group groupData = GetGroupData(groupId);
            if (groupData == null) return;
            List<Character> groupPlayers = GetPlayersInGroup(groupData.Id);
            if (groupPlayers == null) return;
            foreach (Character entry in groupPlayers)
            {
                if (GetPlayerGroupDuty(entry.PlayerHandle) != groupData.Id) continue;
                int groupSlot = GetPlayerGroupSlotById(entry.PlayerHandle, groupId);
                if (groupSlot > 0)
                    entry.PlayerHandle.SendChatMessage(
                        $"!{{{groupData.ColorR}, {groupData.ColorG}, {groupData.ColorB}}}!{groupSlot} " +
                        $"[{groupData.Code}] {message}");
            }
        }

        /// <summary>
        /// Wysyła wiadomośc IC na czacie IC grup o podanym typie
        /// </summary>
        /// <param name="groupType"></param>
        /// <param name="message"></param>
        public static void SendGroupTypeIcMessage(int groupType, string message)
        {
            foreach (KeyValuePair<int, Group> entry in GroupsList)
                if ((int) entry.Value.Type == groupType)
                    SendGroupIcMessage(entry.Value.Id, message);
        }

        /// <summary>
        /// Wysyła wiadomośc na czacie OOC grupy o podanym Id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="message"></param>
        public static void SendGroupOocMessage(int groupId, string message)
        {
            Group groupData = GetGroupData(groupId);
            if (groupData == null) return;
            List<Character> groupPlayers = GetPlayersInGroup(groupData.Id);
            if (groupPlayers == null) return;
            foreach (Character entry in groupPlayers)
            {
                int groupSlot = GetPlayerGroupSlotById(entry.PlayerHandle, groupId);
                if (groupSlot > 0)
                    entry.PlayerHandle.SendChatMessage(
                        $"!{{{groupData.ColorR - 30}, {groupData.ColorG - 30}, {groupData.ColorB - 30}}}@{groupSlot} " +
                        $"[{groupData.Code}] (( {message} ))");
            }
        }

        /// <summary>
        /// Wysyła wiadomośc OOC na czacie OOC grup o podanym typie
        /// </summary>
        /// <param name="groupType"></param>
        /// <param name="message"></param>
        public static void SendGroupTypeOocMessage(int groupType, string message)
        {
            foreach (KeyValuePair<int, Group> entry in GroupsList)
                if ((int) entry.Value.Type == groupType)
                    SendGroupOocMessage(entry.Value.Id, message);
        }

        /// <summary>
        /// Dodaje gracza do grupy o podanym Id. Zwraca enuma AddToGroupState
        /// </summary>
        /// <param name="player"></param>
        /// <param name="groupId"></param>
        /// <param name="leaderRank"></param>
        /// <returns></returns>
        public static async Task<AddToGroupState> AddPlayerToGroup(Client player, int groupId,
            bool leaderRank = false)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null)
                return AddToGroupState.PlayerDoesntExist;

            Group groupData = GetGroupData(groupId);
            if (groupData == null)
                return AddToGroupState.GroupDoesntExist;

            if (DoesPlayerHasGroup(player, groupId))
                return AddToGroupState.AlreadyInGroup;

            // TODO: Licznik grup, maksymalna ilość slotów

            GroupMember newGroup = new GroupMember
            {
                GroupId = groupData.Id,
                CharacterId = charData.Id,
                RankId = groupData.DefaultRank,
                CreatedAt = Global.GetTimestamp(),
                Payday = 0,
                DutyTime = 0,
                PaydayTimestamp = 0,
                PaydayAdded = 0,
                PaydayDay = 0,

                Duty = false,
                DutyStartTimestamp = 0,
                RankName = "",
                RankPermissions = new List<object>(),
                LastDutyTime = 0
            };

            using (Database.Database db = new Database.Database())
            {
                await db.GroupMembers.AddAsync(newGroup);
                await db.SaveChangesAsync();

                if (leaderRank)
                {
                    GroupRank rankInfo =
                        await db.GroupRanks.FirstOrDefaultAsync(t =>
                            t.Permissions.Contains(Permissions.RankLeader));
                    if (rankInfo != null)
                    {
                        newGroup.RankName = rankInfo.Name;
                        try
                        {
                            newGroup.RankPermissions =
                                JsonConvert.DeserializeObject<List<object>>(rankInfo.Permissions);
                        }
                        catch (Exception e)
                        {
                            Log.ConsoleLog("GROUPS", $"(USER-ADD) {e.Message}", LogType.Error);
                        }
                    }
                }
                else
                {
                    GroupRank rankInfo =
                        await db.GroupRanks.FirstOrDefaultAsync(t => t.Id == groupData.DefaultRank);
                    if (rankInfo != null)
                    {
                        newGroup.RankName = rankInfo.Name;
                        try
                        {
                            newGroup.RankPermissions =
                                JsonConvert.DeserializeObject<List<object>>(rankInfo.Permissions);
                        }
                        catch (Exception e)
                        {
                            Log.ConsoleLog("GROUPS", $"(USER-ADD) {e.Message}", LogType.Error);
                        }
                    }
                }


                if (charData.Groups == null) charData.Groups = new List<GroupMember>();

                charData.Groups.Add(newGroup);
                db.GroupMembers.Update(newGroup);
                await db.SaveChangesAsync();
                return AddToGroupState.Ok;
            }
        }

        public static bool IsPlayerInCriminalGroup(Character charData)
        {
            return true;
        }

        /// <summary>
        /// Usuwa gracza z grupy o podanym Id. Zwraca enuma RemoveFromGroupState
        /// </summary>
        /// <param name="player"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static async Task<RemoveFromGroupState> RemovePlayerFromGroup(Client player, int groupId)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null)
                return RemoveFromGroupState.PlayerDoesntExist;

            Group groupData = GetGroupData(groupId);
            if (groupData == null)
                return RemoveFromGroupState.GroupDoesntExist;

            if (!DoesPlayerHasGroup(player, groupId))
                return RemoveFromGroupState.NotInGroup;

            GroupMember playerGroupData = GetPlayerGroupData(player, groupData.Id);
            if (playerGroupData == null)
                return RemoveFromGroupState.NotInGroup;

            // TODO: Wyłączenie duty gracza jeśli na nim jest

            using (Database.Database db = new Database.Database())
            {
                db.GroupMembers.Attach(playerGroupData);
                db.GroupMembers.Remove(playerGroupData);
                await db.SaveChangesAsync();
                charData.Groups.Remove(playerGroupData);
                return RemoveFromGroupState.Ok;
            }
        }

        /// <summary>
        /// Zabiera z konta grupy podaną ilość pieniędzy. Zwraca true jeśli wykonano pomyślnie, inaczej false
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public static async Task<bool> TakeGroupMoney(int groupId, uint value, string reason)
        {
            Group groupData = GetGroupData(groupId);
            if (groupData == null) return false;
            value = Convert.ToUInt32(Math.Abs(value));
            if (groupData.Cash < value) return false;
            groupData.Cash -= (int) value;

            groupData.Save();

            using (Database.Database db = new Database.Database())
            {
                await db.GroupAccountLogs.AddAsync(
                    new GroupAccountLog
                    {
                        GroupId = groupData.Id,
                        Change = (int) -value,
                        Message = reason,
                        NewBalance = groupData.Cash,
                        Timestamp = Global.GetTimestamp()
                    });
                await db.SaveChangesAsync();
            }

            return true;
        }

        /// <summary>
        /// Dodaje do konta grupy podaną ilość pieniędzy. Zwraca true jeśli wykonano pomyślnie, inacezj false
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public static async Task<bool> GiveGroupMoney(int groupId, uint value, string reason)
        {
            Group groupData = GetGroupData(groupId);
            if (groupData == null) return false;
            value = Convert.ToUInt32(Math.Abs(value));
            groupData.Cash += (int) value;

            groupData.Save();

            using (Database.Database db = new Database.Database())
            {
                await db.GroupAccountLogs.AddAsync(
                    new GroupAccountLog
                    {
                        GroupId = groupData.Id,
                        Change = (int) value,
                        Message = reason,
                        NewBalance = groupData.Cash,
                        Timestamp = Global.GetTimestamp()
                    });
                await db.SaveChangesAsync();
            }

            return true;
        }

        /// <summary>
        /// Wysyła wiadomość Weazel News do wszystkich graczy
        /// </summary>
        /// <param name="player"></param>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static void SendRadioMessage(Client player, string type, string message)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string icName = Player.GetPlayerIcName(player);
            foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
                entry.Value.PlayerHandle.TriggerEvent("client.radio.setMessage", icName, type,
                    Global.EscapeHtml(message), !charData.RadioBlock);
        }

        public static void ShowUi(Character charData, UiType uiType, int? groupId = null)
        {
            if (charData == null) return;
            if (uiType == UiType.GroupMenu)
            {
                if (groupId == null) return;
                if (!DoesPlayerHasGroup(charData, (int) groupId)) return;
                Group groupData = GetGroupData((int) groupId);
                if (groupData == null) return;

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("Wartość", 90)
                };

                List<DialogRow> dialogRows = new List<DialogRow>
                {
                    new DialogRow("info", new[] {"Informacje o grupie"}),
                    new DialogRow("duty",
                        new[]
                        {
                            GetPlayerGroupDuty(charData) == (int) groupId
                                ? "Zakończ służbę"
                                : "Rozpocznij służbę"
                        }),
                    new DialogRow("players", new[] {"Gracze online"}),
                    new DialogRow("vehicles", new[] {"Pojazdy grupy"})
                };
                string[] dialogButtons = {"Wybierz", "Anuluj"};

                Account.SetServerData(charData, Account.ServerData.GroupPanelId, groupData.Id);
                Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.PlayerGroupsOptions,
                    $"{groupData.Name} - Zarządzanie", dialogColumns, dialogRows, dialogButtons);
            }
            else if (uiType == UiType.GroupOrders)
            {
                if (groupId == null) return;
                Group groupData = GetGroupData((int) groupId);
                if (groupData == null) return;

                using (Database.Database db = new Database.Database())
                {
                    List<Order> groupOrders = db.Orders.Where(t => t.GroupId == groupData.Id).ToList();
                    if (groupOrders.Count == 0)
                    {
                        Ui.ShowWarning(charData.PlayerHandle,
                            "Grupa nie posiada żadnych dostępnych zamówień.");
                        return;
                    }

                    List<DialogData> dialogData = new List<DialogData>();
                    foreach (Order order in groupOrders)
                        dialogData.Add(new DialogData(
                            string.Format("{0} [{1}][F: {2}] - ${3}", order.Name,
                                ItemsHelper.GetItemTypeName(order.Type), order.Flag ? 'T' : 'N',
                                order.Price),
                            order.Id));

                    Account.SetServerData(charData, Account.ServerData.DialogGroupId, groupData.Id);

                    List<DialogColumn> dialogColumns = new List<DialogColumn>
                    {
                        new DialogColumn("Nazwa", 40),
                        new DialogColumn("Flaga", 20),
                        new DialogColumn("Cena za sztukę", 30)
                    };

                    List<DialogRow> dialogRows = new List<DialogRow>();
                    foreach (Order order in groupOrders)
                        dialogRows.Add(new DialogRow(order.Id,
                            new[] {order.Name, order.Flag ? "Tak" : "Nie", $"${order.Price}"}));

                    string[] dialogButtons = {"Zamów", "Anuluj"};

                    Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.GroupOrdersList,
                        $"{groupData.Name} - Zamówienia", dialogColumns, dialogRows, dialogButtons);

                    // Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.GroupOrdersList, "Menu zamówień",
                    //    "Wybierz przedmiot, który chcesz zamówić do grupy.", dialogData, DialogType.List);
                }
            }
        }

        /// <summary>
        /// Zwraca true jeśli klasą pojazdu jest rower, inaczej false.
        /// </summary>
        /// <param name="vehicleClass"></param>
        /// <returns></returns>
        public static bool IsVehicleClassBicycle(int vehicleClass)
        {
            return Data.NoEngineVehicles.Contains(vehicleClass);
        }

        public static Order GetOrderData(int groupId, int orderId)
        {
            using (Database.Database db = new Database.Database())
            {
                return db.Orders.FirstOrDefault(t => t.GroupId == groupId && t.Id == orderId);
            }
        }

        /// <summary>
        /// Przeładowuje dane grupy z bazy danych.
        /// <returns>
        /// 0 - wszystko gra
        /// 1 - grupa nie znaleziona w bazie danych
        /// </returns>
        /// </summary>
        /// <param name="groupId"></param>
        public static int ReloadGroup(int groupId)
        {
            Group groupData = GetGroupData(groupId);

            using (Database.Database db = new Database.Database())
            {
                Group newGroupData = db.Groups.FirstOrDefault(t => t.Id == groupData.Id);
                if (newGroupData == null) return 1;

                if (groupData != null) GroupsList.Remove(groupData.Id);
                LoadGroup(newGroupData);
                SendGroupOocMessage(newGroupData.Id, "Przeładowano dane grupy przez interfejs WWW.");

                return 0;
            }
        }

        public static bool IsGroupSpawnSet(Group groupData)
        {
            return Math.Abs(groupData.SpawnX) > 0.1 && Math.Abs(groupData.SpawnY) > 0.1;
        }
    }
}