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
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Libraries;
using LSVRP.Managers;
using Newtonsoft.Json;

namespace LSVRP.Features.Penalties
{
    public static class Library
    {
        /// <summary>
        /// Zwraca nazwę kary.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetPenaltyTypeName(PenaltyType type)
        {
            return Data.PenaltyName.ContainsKey((int) type) ? Data.PenaltyName[(int) type] : "Nieznany typ kary";
        }

        /// <summary>
        /// Pokazujre wiadomość informującą o karze dla wszystkich graczy.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="adminData"></param>
        /// <param name="type"></param>
        /// <param name="reason"></param>
        private static void ShowMessage(Character charData, Character adminData, PenaltyType type, string reason)
        {
            var penClass = new
            {
                Type = GetPenaltyTypeName(type),
                Client = $"{charData.Name} {charData.Lastname}",
                Admin = adminData != null ? adminData.GlobalName : "System",
                Reason = reason
            };
            foreach (Client entry in NAPI.Pools.GetAllPlayers())
                NAPI.ClientEvent.TriggerClientEvent(entry, "client.penalty.show",
                    JsonConvert.SerializeObject(penClass, Formatting.None));
        }

        /// <summary>
        /// Kickuje gracza z serwera.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="adminData"></param>
        /// <param name="reason"></param>
        public static void KickPlayer(Character charData, Character adminData, string reason)
        {
            if (charData == null) return;

            Penalty penaltyData = new Penalty
            {
                AdminId = adminData?.MemberId ?? 0,
                TargetId = charData.Id,
                TargetGlobalId = charData.MemberId,
                Type = PenaltyType.Kick,
                Reason = reason,
                Timestamp = Global.GetTimestamp(),
                Expired = 0
            };

            using (Database.Database db = new Database.Database())
            {
                db.Penalties.Add(penaltyData);
                db.SaveChanges();
            }

            ShowMessage(charData, adminData, PenaltyType.Kick, reason);

            if (NAPI.Entity.DoesEntityExist(charData.PlayerHandle)) charData.PlayerHandle.Kick(reason);
        }

        /// <summary>
        /// Nadaje ostrzeżenie graczowi
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="adminData"></param>
        /// <param name="reason"></param>
        public static void WarnPlayer(Character charData, Character adminData, string reason)
        {
            if (charData == null) return;

            reason = Command.UpperFirst(reason);

            Penalty penaltyData = new Penalty
            {
                AdminId = adminData?.MemberId ?? 0,
                TargetId = charData.Id,
                TargetGlobalId = charData.MemberId,
                Type = PenaltyType.Warn,
                Reason = reason,
                Timestamp = Global.GetTimestamp(),
                Expired = 0
            };

            using (Database.Database db = new Database.Database())
            {
                db.Penalties.Add(penaltyData);
                db.SaveChanges();
            }

            Player.SendFormattedChatMessage(charData.PlayerHandle, "Zostało Ci nadane ostrzeżenie",
                Constants.ColorDarkRed);
            Player.SendFormattedChatMessage(charData.PlayerHandle, $"Powód: {reason}", Constants.ColorDarkRed);

            ShowMessage(charData, adminData, PenaltyType.Warn, reason);
        }

        public static void BlockPlayer(Character charData, Character adminData, string reason)
        {
            if (charData == null) return;

            reason = Command.UpperFirst(reason);

            Penalty penaltyData = new Penalty
            {
                AdminId = adminData?.MemberId ?? 0,
                TargetId = charData.Id,
                TargetGlobalId = charData.MemberId,
                Type = PenaltyType.BlockChar,
                Reason = reason,
                Timestamp = Global.GetTimestamp(),
                Expired = 0
            };

            charData.Blocked = true;
            charData.SaveAsync();

            using (Database.Database db = new Database.Database())
            {
                db.Penalties.Add(penaltyData);
                db.SaveChanges();
            }

            Player.SendFormattedChatMessage(charData.PlayerHandle, "Twoja postać została zablokowana.",
                Constants.ColorDarkRed);
            Player.SendFormattedChatMessage(charData.PlayerHandle, $"Powód: {reason}", Constants.ColorDarkRed);

            ShowMessage(charData, adminData, PenaltyType.Ban, reason);

            charData.PlayerHandle.Kick("Twoja postać została zablokowana.");
        }

        public static void BanPlayer(Character charData, Character adminData, int lengthInDays, string reason)
        {
            if (charData == null) return;

            reason = Command.UpperFirst(reason);

            Penalty penaltyData = new Penalty
            {
                AdminId = adminData?.MemberId ?? 0,
                TargetId = charData.Id,
                TargetGlobalId = charData.MemberId,
                Type = PenaltyType.Ban,
                Reason = reason,
                Timestamp = Global.GetTimestamp(),
                Expired = (int) ((DateTimeOffset) DateTime.Now.AddDays(lengthInDays)).ToUnixTimeSeconds()
            };

            Ban newBan = new Ban
            {
                Ip = charData.PlayerHandle.Address,
                SocialClubName = charData.PlayerHandle.SocialClubName,
                MemberId = charData.MemberId,
                Reason = reason,
                Expire = (int) ((DateTimeOffset) DateTime.Now.AddDays(lengthInDays)).ToUnixTimeSeconds(),
                Canceled = false,
                Serial = charData.PlayerHandle.Serial,
                AdminId = adminData?.MemberId ?? 0
            };

            using (Database.Database db = new Database.Database())
            {
                db.Penalties.Add(penaltyData);
                db.Bans.Add(newBan);
                db.SaveChanges();
            }

            Player.SendFormattedChatMessage(charData.PlayerHandle, "Zostałeś zbanowany.", Constants.ColorDarkRed);
            Player.SendFormattedChatMessage(charData.PlayerHandle, $"Powód: {reason}", Constants.ColorDarkRed);

            ShowMessage(charData, adminData, PenaltyType.Ban, reason);

            charData.PlayerHandle.Kick("Zostałeś zbanowany.");
        }
    }
}