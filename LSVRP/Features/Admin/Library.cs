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
using LSVRP.Features.Sync;
using LSVRP.Libraries;
using LSVRP.Managers;
using Microsoft.EntityFrameworkCore;

namespace LSVRP.Features.Admin
{
    public static class Library
    {
        /// <summary>
        /// Zwraca Klasę RankInfo, która zawiera nazwę rangi administratora, kolor HEX oraz klasę w CEF
        /// </summary>
        /// <param name="rankNumber">Poziom administratora</param>
        /// <returns></returns>
        public static RankInfo GetAdminRankInfo(int rankNumber)
        {
            switch (rankNumber)
            {
                default: return new RankInfo("Nieznana ranga", "FFFFFF");
                case 1: return new RankInfo("Helper", "0085DD");
                case 2: return new RankInfo("Support (1)", "0085DD");
                case 3: return new RankInfo("Support (2)", "0085DD");
                case 4: return new RankInfo("Support (3)", "0085DD");
                case 5: return new RankInfo("Support (4)", "0085DD");
                case 6: return new RankInfo("Gamemaster", "18C91F");
                case 7: return new RankInfo("Administrator", "FF0000");
                case 8: return new RankInfo("Developer", "FF7C52");
                case 9: return new RankInfo("Moderator serwera", "B366FF");
                case 10: return new RankInfo("Senior moderator", "901AFF");
            }
        }

        /// <summary>
        /// Zwraca informację czy gracz ma określony perm administratora
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="permName"></param>
        /// <param name="withMessage"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasAdminPerm(Character charData, string permName, bool withMessage = false)
        {
            if (charData == null) return false;
            if (withMessage)
            {
                if (charData.AdminLevel == 0 || !charData.AdminPerm.Contains(permName))
                {
                    Ui.ShowError(charData.PlayerHandle, $"Nie posiadasz uprawnienia \"{permName}\" pozwalającego na " +
                                                        "użycie tej komendy");
                    return false;
                }

                return true;
            }

            return charData.AdminLevel > 0 && charData.AdminPerm.Contains(permName);
        }

        /// <summary>
        /// Zwraca informację czy gracz ma określony perm administratora
        /// </summary>
        /// <param name="player"></param>
        /// <param name="permName"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasAdminPerm(Client player, string permName, bool withMessage = false)
        {
            return DoesPlayerHasAdminPerm(Account.GetPlayerData(player), permName, withMessage);
        }

        /// <summary>
        /// Włącza lub wyłącza duty administratora
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="state"></param>
        public static async void ToggleAdminDuty(Character charData, bool state)
        {
            if (charData == null) return;

            if (state)
            {
                charData.HasAdminDuty = true;
                Ui.ShowInfo(charData.PlayerHandle, "Rozpocząłeś służbę administratora. Od tej pory pojawiać będą Ci" +
                                                   " się powiadomienia o raportach.");
                Sync.Library.SetPlayerSyncedData(charData.PlayerHandle, new List<PlayerData>
                {
                    new PlayerData("player.visibleName", Player.GetPlayerIcName(charData, true)),
                    new PlayerData("player.adminDuty", true)
                });
                using (Database.Database db = new Database.Database())
                {
                    List<AdminDuty> adminDuties = await db.AdminDuties.Where(t =>
                            t.AdminGlobalId == charData.MemberId && t.AdminCharId == charData.Id && t.EndTime == 0)
                        .ToListAsync();
                    db.AdminDuties.RemoveRange(adminDuties);
                    await db.AdminDuties.AddAsync(new AdminDuty
                    {
                        AdminGlobalId = charData.MemberId,
                        AdminCharId = charData.Id,
                        StartTime = Global.GetTimestamp(),
                        EndTime = 0
                    });
                    await db.SaveChangesAsync();
                }
            }
            else
            {
                charData.HasAdminDuty = false;
                Ui.ShowInfo(charData.PlayerHandle, "Zakończyłeś służbę administratora.");
                Sync.Library.SetPlayerSyncedData(charData.PlayerHandle, "player.visibleName",
                    Player.GetPlayerIcName(charData, true));
                Sync.Library.DeletePlayerData(charData.PlayerHandle, "player.adminDuty");
                using (Database.Database db = new Database.Database())
                {
                    AdminDuty adminDuty = await db.AdminDuties.FirstOrDefaultAsync(t =>
                        t.AdminGlobalId == charData.MemberId && t.AdminCharId == charData.Id && t.EndTime == 0);
                    if (adminDuty == null) return;
                    adminDuty.EndTime = Global.GetTimestamp();
                    db.AdminDuties.Update(adminDuty);
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}