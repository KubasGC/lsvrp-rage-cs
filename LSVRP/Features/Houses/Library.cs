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
using LSVRP.Database.Models;
using LSVRP.Features.Interiors;
using LSVRP.Libraries;
using Log = LSVRP.Modules.Log;

namespace LSVRP.Features.Houses
{
    public static class Library
    {
        /// <summary>
        /// Słownik zawierający listę wszystkich mieszkań.
        /// </summary>
        private static readonly Dictionary<int, House> HousesList = new Dictionary<int, House>();


        /// <summary>
        /// Ładuje mieszkania z bazy danych.
        /// </summary>
        public static void LoadHouses()
        {
            double startTime = Global.GetTimestampMs();
            using (Database.Database db = new Database.Database())
            {
                foreach (House entry in db.Houses.ToList())
                {
                    entry.LoadInteriorData();
                    HousesList.Add(entry.Id, entry);
                }
            }

            Log.ConsoleLog("HOUSES",
                $"Załadowano mieszkania ({HousesList.Count}) | {Global.GetTimestampMs() - startTime}ms");
        }

        public static House GetHouseByDim(int dimension)
        {
            foreach (KeyValuePair<int, House> entry in HousesList)
                if (entry.Value.Dimension == dimension)
                    return entry.Value;

            return null;
        }


        /// <summary>
        /// Sprawdza uprawnienia ownera do danego mieszkania.
        /// </summary>
        /// <param name="houseData"></param>
        /// <param name="ownerType"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static bool CheckPerms(House houseData, OwnerType ownerType, int owner)
        {
            if (houseData?.InteriorData == null) return false;

            return houseData.InteriorData.OwnerType == ownerType && houseData.InteriorData.Owner == owner;
        }
    }
}