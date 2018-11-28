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

namespace LSVRP.Features.Jobs.Courier
{
    [Serializable]
    public class CourierOrder
    {
        public Client Player { get; set; }
        public int OrderId { get; set; }
        public CourierState State { get; set; }
    }
}