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
using Log = LSVRP.Modules.Log;
using LogType = LSVRP.Modules.LogType;

namespace LSVRP.Features.Socket
{
    public static class Library
    {
        private const string SocketIp = "127.0.0.1";
        private const int SocketPort = 22020;

        private static LsvrpSocket _lsvrpSocket;

        public static void StartSocket()
        {
            _lsvrpSocket = new LsvrpSocket();
            _lsvrpSocket.Server(SocketIp, SocketPort);
            Log.ConsoleLog("SOCKET", $"Socket UDP został uruchomiony na adresie {SocketIp}:{SocketPort}");
        }

        public static void OnSocketGotData(string receivedData)
        {
            try
            {
                SocketData sData = NAPI.Util.FromJson<SocketData>(receivedData);
                Functions choosedFunction = (Functions) Command.GetNumberFromString(sData.Func);
                if (choosedFunction == Functions.ReloadGroup)
                {
                    int errno = Groups.Library.ReloadGroup(Command.GetNumberFromString(sData.Data));
                    if (errno == 0)
                        Log.ConsoleLog("SOCKET", $"Przeladowano zdalnie grupe o Id {sData.Data}.");
                    else
                        Log.ConsoleLog("SOCKET",
                            $"Wystąpił blad w trakcie przeladowywania danych grupy o Id {sData.Data} (errno: {errno}).",
                            LogType.Error);
                }
                else if (choosedFunction == Functions.KickPlayer)
                {
                    int charId = Command.GetNumberFromString(sData.Data);
                    if (charId == Command.InvalidNumber) return;

                    Character charData = Account.GetPlayerData(charId);
                    if (charData == null) return;

                    // TODO kick.
                    Log.ConsoleLog("SOCKET",
                        $"Wyrzucono gracza {Player.GetPlayerDebugName(charData)} z serwera.");
                }
            }
            catch (Exception e)
            {
                Log.ConsoleLog("SOCKET",
                    $"Wystapil problem w momencie konwersji stringa do jsona. Dane: |{receivedData}| Error: {e.Message}",
                    LogType.Error);
            }
        }
    }
}