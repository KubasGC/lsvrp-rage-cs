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
using LSVRP.Libraries;

namespace LSVRP.Features.Tattoos
{
    public static class Library
    {
        /// <summary>
        /// Zwraca dane męskiego tatuażu o podanym Id.
        /// </summary>
        /// <param name="tattooId"></param>
        /// <returns></returns>
        public static TattooRow GetTattooData(int tattooId)
        {
            return Data.TattoosList.ContainsKey(tattooId) ? Data.TattoosList[tattooId] : null;
        }

        public static TattooInfo GetTattooInfo(int tattooId)
        {
            return Data.TattoosList.ContainsKey(tattooId)
                ? new TattooInfo
                {
                    Id = tattooId,
                    tattoo = Data.TattoosList[tattooId]
                }
                : null;
        }

        public static void RenderClientsideTattooList()
        {
            string output = "";
            foreach (KeyValuePair<int, TattooRow> entry in Data.TattoosList)
                output +=
                    $"TattoosList.set({entry.Key}, {{Collection: \"{entry.Value.Collection}\", Hash: \"{entry.Value.Hash}\"}});\n";

            string dirPath = "lsvrp";
            string filePath = $"{dirPath}/clientside-tattoos.log";
            Log.LoggingFunc(dirPath, filePath, output);
        }
    }
}