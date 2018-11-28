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

namespace LSVRP.Features.Base
{
    [Serializable]
    public class PlayerListData
    {
        public PlayerListData(int id, string name, int gamePoints, int ping)
        {
            Id = id;
            Name = name;
            GamePoints = gamePoints;
            Ping = ping;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int GamePoints { get; set; }
        public int Ping { get; set; }
    }
}