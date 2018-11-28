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

namespace LSVRP.Features.Groups.Barriers
{
    public class Barrier
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public uint Dimension { get; set; }
        public Object ObjectHandle { get; set; }
    }
}