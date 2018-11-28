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

namespace LSVRP.Features.Penalties
{
    public static class Data
    {
        public static readonly Dictionary<int, string> PenaltyName = new Dictionary<int, string>
        {
            {1, "Kick"},
            {2, "Blokada postaci"},
            {3, "Ostrzeżenie"},
            {4, "Ban"},
            {5, "Admin Jail"},
            {6, "Character Kill"},
            {7, "Blokada prowadzenia pojazdów"},
            {8, "Blokada czatu OOC"},
            {9, "Virtual Points"},
            {10, "Blokada prędkości"}
        };
    }
}