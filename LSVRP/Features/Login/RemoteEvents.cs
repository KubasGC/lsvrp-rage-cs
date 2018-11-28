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
using System.Security.Cryptography;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Admin;
using LSVRP.Features.Sync;
using LSVRP.Libraries;
using LSVRP.Managers;
using Microsoft.EntityFrameworkCore;

// ReSharper disable UnusedMember.Global

namespace LSVRP.Features.Login
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.login.OnPlayerTriedToLogin")]
        public async void Event_OnPlayerTriedToLogin(Client player, string username, string password)
        {
            player.TriggerEvent("client.ui.loader", true);
            Character charData = Account.GetPlayerData(player);
            if (charData != null)
            {
                Ui.ShowError(player, "Jesteś już zalogowany.");
                return;
            }

            using (Database.Database db = new Database.Database())
            {
                ForumMember globalMember = await db.ForumMembers.FirstOrDefaultAsync(t => t.Username == username);
                if (globalMember != null)
                {
                    if (Auth.AuthUser(username, password))
                    {
                        Ui.ShowInfo(player,
                            $"Witaj, {globalMember.Username}! Zalogowałeś się pomyślnie. Laduję Twoje postacie...");
                        player.TriggerEvent("client.ui.loader", true);


                        player.SetData("player.globalId", globalMember.MemberId);
                        player.SetData("player.globalName", globalMember.Username);
                        player.SetData("player.adminLevel", globalMember.AdminLevel);
                        player.SetData("player.vPoints", globalMember.VisualPoints);
                        player.SetData("player.donateTime", globalMember.DonateTime);
                        player.SetData("player.adminFlags", globalMember.AdminFlags);

                        await db.LoginLogs.AddAsync(new LoginLog
                        {
                            MemberId = globalMember.MemberId,
                            Ip = player.Address,
                            Serial = player.Serial,
                            Success = true,
                            Time = Global.GetTimestamp()
                        });
                        await db.SaveChangesAsync();

                        Library.ShowPlayerCharacters(player, globalMember.MemberId);
                    }
                    else
                    {
                        Ui.ShowError(player, "Podano niepoprawne dane logowania.");
                        player.TriggerEvent("client.login.BadLogin");
                        player.TriggerEvent("client.ui.loader", false);
                        await db.LoginLogs.AddAsync(new LoginLog
                        {
                            MemberId = globalMember.MemberId,
                            Ip = player.Address,
                            Success = false,
                            Serial = player.Serial,
                            Time = Global.GetTimestamp()
                        });
                        await db.SaveChangesAsync();
                    }
                }
                else
                {
                    Ui.ShowError(player, "Podano niepoprawne dane logowania.");
                    player.TriggerEvent("client.login.BadLogin");
                    player.TriggerEvent("client.ui.loader", false);
                }
            }
        }

        [RemoteEvent("server.login.OnClientChooseCharacter")]
        public async void Event_OnClientChooseCharacter(Client player, int charId)
        {
            player.TriggerEvent("client.ui.loader", true);
            using (Database.Database db = new Database.Database())
            {
                Character characterData = await db.Characters.FirstOrDefaultAsync(t => t.Id == charId);
                if (characterData == null) return;

                if (characterData.Blocked)
                {
                    player.Kick("Ta postać jest zablokowana!");
                    return;
                }

                if (characterData.MemberId != player.GetData("player.globalId"))
                {
                    player.Kick("Ta postać nie należy do Ciebie!");
                    return;
                }

                Character charData = await Account.LoadPlayerData(player, characterData.Id);
                if (charData == null)
                {
                    player.Kick("Wystąpił błąd w momencie ładowania danych.");
                    return;
                }

                charData.MemberId = player.GetData("player.globalId");
                charData.GlobalName = player.GetData("player.globalName");
                charData.AdminLevel = player.GetData("player.adminLevel");
                charData.VisualPoints = player.GetData("player.vPoints");
                charData.DonateTime = player.GetData("player.donateTime");

                player.ResetData("player.globalId");
                player.ResetData("player.globalName");
                player.ResetData("player.adminLevel");
                player.ResetData("player.vPoints");
                player.ResetData("player.donateTime");
                player.ResetData("player.adminFlags");

                // TODO: Generotwanie numeru konta bankowego jeśli go nie ma

                if (charData.ShortDna == null || charData.ShortDna.Length < 4)
                {
                    charData.ShortDna = Player.GenerateDna();
                    charData.Dna = Global.GetMd5Hash(MD5.Create(), charData.ShortDna);
                }

                player.SendChatMessage(
                    $"!{{#FFFFFF}}Witaj, !{{#CF3A24}}{charData.GlobalName} !{{#BDC3C7}}(GID: {charData.MemberId})!{{#FFFFFF}}. Wybrałeś postać !{{#89C4F4}}{charData.Name} {charData.Lastname} !{{#BDC3C7}}(UID: {charData.Id}, SID: {charData.ServerId})!{{#FFFFFF}}");
                player.SendChatMessage("Miłej gry życzy ekipa !{#407A52}LSVRP!{#FFFFFF}!");

                if (charData.DonateTime > Global.GetTimestamp())
                    player.SendChatMessage(
                        "!{#4286f4}[ Jesteś aktywnym donatorem! Subsrkybcja kończy się za " +
                        $"{Global.GetFormattedTime(charData.DonateTime - Global.GetTimestamp(), false, true)}. ]");

                if (charData.AdminLevel > 0)
                {
                    RankInfo adminRankInfo = Admin.Library.GetAdminRankInfo(charData.AdminLevel);
                    player.SendChatMessage(
                        $"!{{#9D2933}}[ Na serwerze posiadasz uprawnienia: !{{#{adminRankInfo.Color}}}{adminRankInfo.Name}!{{#9D2933}}. ]");
                }

                Sync.Library.SetPlayerSyncedData(player, new List<PlayerData>
                {
                    new PlayerData("player.isLogged", true),
                    new PlayerData("player.visibleName", Player.GetPlayerIcName(player, true)),
                    new PlayerData("player.adminLevel", charData.AdminLevel),
                    new PlayerData("player.isInCriminalGroup", false /* TODO */)
                });

                // Ładowanie grup gracza
                Groups.Library.LoadPlayerGroups(player);

                player.TriggerEvent("client.ui.login");
                player.TriggerEvent("client.cameras.toggleblur", false, 1000);
                player.TriggerEvent("client.ui.loader", false);
                player.TriggerEvent("client.choosechar.hideDashboard");

                // Spawn gracza
                Player.SpawnPlayer(player);

                charData.LoginCount++;
                charData.InGame = true;
                charData.LastLogin = Global.GetTimestamp();
                charData.LastX = player.Position.X;
                charData.LastY = player.Position.Y;
                charData.LastZ = player.Position.Z;
                charData.Dimension = (int) player.Dimension;
                charData.Save();

                Sync.Library.SyncPlayerForPlayer(player, player);

                // player.TriggerEvent("client.cameras.reset");

                // TODO: SetPalyerDoorsLabels
                // TODO: SetPlayerBusesLabels

                charData.DoDrugEffects();

                Groups.Library.BuildEmergencyGroups(charData.PlayerHandle);

                if (Groups.Library.IsPlayerInCriminalGroup(charData))
                    player.TriggerEvent("client.corners.load", Corners.Library.GetAllCornersSerialized());
            }
        }
    }
}