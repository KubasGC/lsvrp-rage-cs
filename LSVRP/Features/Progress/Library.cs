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
using System.Threading;
using LSVRP.Database.Models;

namespace LSVRP.Features.Progress
{
    public static class Library
    {
        /// <summary>
        /// Lista aktualnych progresów.
        /// </summary>
        public static readonly IDictionary<int, Progress> ProgressesList = new Dictionary<int, Progress>();

        /// <summary>
        /// Lista rzeczy do usunięcia.
        /// </summary>
        public static readonly List<int> ItemsToDestroy = new List<int>();


        /// <summary>
        /// Podaje najniższe dostępne id.
        /// </summary>
        /// <returns></returns>
        public static int GetNearestId()
        {
            int i = 0;
            while (true)
            {
                if (!ProgressesList.ContainsKey(i)) return i;
                i++;
            }
        }

        /// <summary>
        /// Zwraca true jeśli gracz posiada aktywny progress, inaczej false.
        /// </summary>
        /// <param name="charData"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasActiveProgress(Character charData)
        {
            return ProgressesList.Any(t => t.Value.CharData == charData || t.Value.TargetData == charData);
        }

        /// <summary>
        /// Tworzy nowy progress.
        /// </summary>
        /// <param name="progressName"></param>
        /// <param name="charData"></param>
        /// <param name="targetData"></param>
        /// <param name="progressType"></param>
        /// <param name="time"></param>
        /// <param name="data"></param>
        public static Progress CreateProgress(string progressName, Character charData, Character targetData,
            ProgressType progressType, int time, Dictionary<string, object> data)
        {
            Progress newProgress = new Progress
            {
                ProgressName = progressName,
                CharData = charData,
                TargetData = targetData,
                Id = GetNearestId(),
                Type = progressType,
                TimeLength = time,
                TimeLeft = time,
                Data = data,
                IsBlocked = false
            };
            ProgressesList.Add(newProgress.Id, newProgress);
            newProgress.Start();
            return newProgress;
        }

        public static void ExecuteProgress()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (KeyValuePair<int, Progress> entry in ProgressesList) entry.Value.OnTimer();

                for (int i = ItemsToDestroy.Count - 1; i > -1; i--)
                {
                    if (ProgressesList.ContainsKey(ItemsToDestroy[i])) ProgressesList.Remove(ItemsToDestroy[i]);

                    ItemsToDestroy.Remove(ItemsToDestroy[i]);
                }
            });
            /*new Thread(() =>
            {
                foreach (KeyValuePair<int, Progress> entry in ProgressesList) entry.Value.OnTimer();

                for (int i = ItemsToDestroy.Count - 1; i > -1; i--)
                {
                    if (ProgressesList.ContainsKey(ItemsToDestroy[i])) ProgressesList.Remove(ItemsToDestroy[i]);

                    ItemsToDestroy.Remove(ItemsToDestroy[i]);
                }
            }).Start();*/
        }
    }
}