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
using System.Collections.Generic;
using GTANetworkAPI;

namespace LSVRP.Features.Admin
{
    public static class Data
    {
        /// <summary>
        /// Lista pogód
        /// </summary>
        public static readonly List<Weather> Weathers = new List<Weather>
        {
            Weather.EXTRASUNNY,
            Weather.CLEAR,
            Weather.CLOUDS,
            Weather.SMOG,
            Weather.FOGGY,
            Weather.OVERCAST,
            Weather.RAIN,
            Weather.THUNDER,
            Weather.CLEARING,
            Weather.NEUTRAL,
            Weather.SNOW,
            Weather.BLIZZARD,
            Weather.SNOWLIGHT,
            Weather.XMAS
        };
    }

    [Serializable]
    public class RankInfo
    {
        public RankInfo(string name, string color)

        {
            Color = color;
            Name = name;
        }

        public string Color { get; }
        public string Name { get; }
    }
}