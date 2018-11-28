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
using System.Threading.Tasks;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Libraries;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LSVRP.Features.Login
{
    public static class Library
    {
        /// <summary>
        /// Pokazuje okno UI wyboru postaci
        /// </summary>
        /// <param name="player"></param>
        /// <param name="userId"></param>
        public static async void ShowPlayerCharacters(Client player, int userId)
        {
            using (Database.Database db = new Database.Database())
            {
                List<Character> playerCharacters =
                    await db.Characters.Where(t => !t.Blocked && t.MemberId == userId).ToListAsync();
                if (playerCharacters.Count == 0)
                {
                    Ui.ShowError(player, "Nie posiadasz żadnych postaci :<");
                    player.Kick();
                    return;
                }

                ForumMember forumMember = db.ForumMembers.FirstOrDefault(t => t.MemberId == userId);

                List<LoginScreenCharacter> serializableCharacters = new List<LoginScreenCharacter>();
                foreach (Character entry in playerCharacters)
                    serializableCharacters.Add(new LoginScreenCharacter
                    {
                        Id = entry.Id,
                        Name = $"{entry.Name} {entry.Lastname}",
                        Online = Global.GetFormattedTime(entry.OnlineTime)
                    });

                NAPI.ClientEvent.TriggerClientEvent(player, "client.choosechar.show",
                    JsonConvert.SerializeObject(serializableCharacters),
                    forumMember != null ? forumMember.Username : "--"
                );

                // player.TriggerEvent("client.choosechar.show",
                //    JsonConvert.SerializeObject(serializableCharacters, Formatting.None), rankName,
                //    player.GetData("player.vPoints"), Account.GetAllPlayers().Count, 0 /* TODO */);
                // player.TriggerEvent("client.login.LoginSuccess");
                player.TriggerEvent("client.ui.loader", false);
            }
        }

        /// <summary>
        /// Zwraca true jeśli gracz posiada bana na IP lub SocialCluba, w innym wypadku false
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static async Task<bool> DoesClientHasBan(Client player)
        {
            using (Database.Database db = new Database.Database())
            {
                int timestampNow = Global.GetTimestamp();
                int banCount = await db.Bans.Where(t =>
                        !t.Canceled && t.Expire < timestampNow &&
                        (t.SocialClubName == player.SocialClubName || t.Ip == player.Address ||
                         t.Serial == player.Serial))
                    .CountAsync();
                return banCount != 0;
            }
        }
    }
}