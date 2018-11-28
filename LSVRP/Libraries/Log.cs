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
using System.IO;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Managers;

namespace LSVRP.Libraries
{
    public enum LogType
    {
        Info,
        ChatIc,
        ChatOoc,
        StartGroupDuty,
        StopGroupDuty,
        SpawnPlayer,
        UseItem,
        ActionIc,
        Teleport,
        ChangeAdminLevel,
        ChangeHp,
        ChangeNickname,
        MoneyAdded,
        MoneyTook,
        PwSend
    }

    public static class Log
    {
        /// <summary>
        /// Loguje wszystko do plików
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        public static async void LoggingFunc(string dirPath, string filePath, string content)
        {
            DateTime now = DateTime.Now;
            content = $"[{now:HH:mm:ss}] | {content}";
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);

            if (!File.Exists(filePath))
            {
                FileStream file = File.Create(filePath);
                file.Close();
            }

            using (StreamWriter textWriter = new StreamWriter(filePath, true))
            {
                await textWriter.WriteLineAsync(content);
                textWriter.Close();
            }
        }

        /// <summary>
        /// Pobiera nazwę akcji po typie logu
        /// </summary>
        /// <param name="logType"></param>
        /// <returns></returns>
        private static string GetLogTypeName(LogType logType)
        {
            switch (logType)
            {
                default: return "Nieznany moduł";
                case LogType.Info: return "Info";
                case LogType.ChatIc: return "Czat IC";
                case LogType.ChatOoc: return "Czat OOC";
                case LogType.StartGroupDuty: return "Wejście na służbę grupy";
                case LogType.StopGroupDuty: return "Zejście ze służby grupy";
                case LogType.SpawnPlayer: return "Spawn gracza";
                case LogType.UseItem: return "Użycie przedmiotu";
                case LogType.ActionIc: return "Akcja IC";
                case LogType.Teleport: return "Teleportacja";
                case LogType.ChangeAdminLevel: return "Zmiana poziomu administratora";
                case LogType.ChangeHp: return "Zmiana hitpoints";
                case LogType.ChangeNickname: return "Zmiana nicku";
                case LogType.MoneyAdded: return "Dodanie pieniędzy";
                case LogType.MoneyTook: return "Zabranie pieniędzy";
                case LogType.PwSend: return "Prywatna wiadomość";
            }
        }

        /// <summary>
        /// Zapisuje log gracza w pliku
        /// </summary>
        /// <param name="player"></param>
        /// <param name="content"></param>
        /// <param name="logType"></param>
        public static void LogPlayer(Client player, string content, LogType logType = LogType.Info)
        {
            LogPlayer(Account.GetPlayerData(player), content, logType);
        }

        /// <summary>
        /// Zapisuje log gracza w pliku
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="content"></param>
        /// <param name="logType"></param>
        public static void LogPlayer(Character charData, string content, LogType logType = LogType.Info)
        {
            if (charData == null) return;
            content = $"[{GetLogTypeName(logType)}] {content}";
            DateTime now = DateTime.Now;
            string dirPath = $"lsvrp/game-logs/{charData.Id}";
            string filePath = $"{dirPath}/{now:dd-MM-yyyy}.log";
            LoggingFunc(dirPath, filePath, content);
        }
    }
}