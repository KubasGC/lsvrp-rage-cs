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

namespace LSVRP.Features.Bw
{
    public static class Library
    {
        /// <summary>
        /// Zwraca true jeśli gracz posiada BW, inaczej false.
        /// </summary>
        /// <param name="charData"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasBw(Character charData)
        {
            if (charData == null) return false;
            return charData.BwTime > 0;
        }

        /// <summary>
        /// Wyłącza Bw, jeśli gracz je posiada.
        /// </summary>
        /// <param name="charData"></param>
        public static void EndBw(Character charData)
        {
            if (charData == null) return;

            charData.BwTime = 0;
            charData.Health = 45;
            charData.PlayerHandle.Health = (int) charData.Health;
            charData.Save();

            NAPI.Player.SpawnPlayer(charData.PlayerHandle, new Vector3(charData.LastX, charData.LastY, charData.LastZ));

            Sync.Library.DeletePlayerData(charData.PlayerHandle, "player.bw");
            // TODO: Pewno kilka rzeczy związanych z BW
            NAPI.ClientEvent.TriggerClientEvent(charData.PlayerHandle, "client.bw.toggleUi", false);
        }

        /// <summary>
        /// Ustawia graczowi Bw na wyznaczony czas.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="time"></param>
        /// <param name="fromEvent"></param>
        public static void SetPlayerBw(Character charData, int time, bool fromEvent = false)
        {
            if (charData == null) return;
            if (fromEvent && charData.BwTime > 0) return;
            if (fromEvent)
            {
                Ui.ShowInfo(charData.PlayerHandle, $"Otrzymałeś BW. Ockniesz się za {time} sekund.");
                Player.SendFormattedChatMessage(charData.PlayerHandle,
                    "Aby zablokować swoją postać, użyj komendy /smierc.", Constants.ColorDarkRed);
            }

            if (!fromEvent)
            {
                charData.Health = 0;
                charData.PlayerHandle.Health = 0;
            }

            int playerDuty = Groups.Library.GetPlayerGroupDuty(charData);
            if (playerDuty != 0) Groups.Library.TogglePlayerDuty(charData, playerDuty, false);

            charData.LastX = charData.PlayerHandle.Position.X;
            charData.LastY = charData.PlayerHandle.Position.Y;
            charData.LastZ = charData.PlayerHandle.Position.Z;
            charData.BwTime = time;
            charData.Save();

            Sync.Library.SetPlayerSyncedData(charData.PlayerHandle, "player.bw", true);

            NAPI.ClientEvent.TriggerClientEvent(charData.PlayerHandle, "client.bw.setTime", time);
            NAPI.ClientEvent.TriggerClientEvent(charData.PlayerHandle, "client.bw.toggleUi", true);

            Sync.Library.SyncPlayerForPlayer(charData.PlayerHandle);
        }

        /// <summary>
        /// Ustawia graczowi Bw na wyznaczony czas.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="time"></param>
        /// <param name="fromEvent"></param>
        public static void SetPlayerBw(Client player, int time, bool fromEvent = false)
        {
            SetPlayerBw(Account.GetPlayerData(player), time, fromEvent);
        }
    }
}