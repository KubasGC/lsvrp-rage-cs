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
using System.Drawing;
using Colorful;
using LSVRP.Managers;
using Console = Colorful.Console;

namespace LSVRP.Modules
{
    public enum LogType
    {
        Info,
        Warning,
        Error,
        Debug
    }

    public static class Log
    {
        /// <summary>
        /// Loguje informacje do konsoli
        /// </summary>
        /// <param name="moduleName">Nazwa modułu</param>
        /// <param name="output">Wyjście</param>
        /// <param name="logType">Typ logu</param>
        public static void ConsoleLog(string moduleName, string output, LogType logType = LogType.Info)
        {
            if (logType == LogType.Debug && !Configuration.Get().DebugMode) return;

            DateTime dateNow = DateTime.Now;

            string formattedOutput =
                $"{dateNow.Hour:D2}:{dateNow.Minute:D2}:{dateNow.Second:D2}:{dateNow.Millisecond:D3} | ";

            string logTypeName;
            Color logTypeColor;
            switch (logType)
            {
                default:
                    logTypeName = "NONE";
                    logTypeColor = Color.White;
                    break;

                case LogType.Debug:
                    logTypeName = "DEBUG";
                    logTypeColor = Color.DarkViolet;
                    break;


                case LogType.Info:
                    logTypeName = "INFO";
                    logTypeColor = Color.ForestGreen;
                    break;

                case LogType.Warning:
                    logTypeName = "WARNING";
                    logTypeColor = Color.Yellow;
                    break;

                case LogType.Error:
                    logTypeName = "ERROR";
                    logTypeColor = Color.White;
                    break;
            }

            // formattedOutput += $"[{moduleName}] {output}";
            formattedOutput += "[{0}][{1}] {2}";
            Formatter[] outputFormat =
            {
                new Formatter(logTypeName, logTypeColor),
                new Formatter(moduleName, Color.Aqua),
                new Formatter(output, Color.White)
            };

            Console.WriteLineFormatted(formattedOutput, Color.White, outputFormat);
        }
    }
}