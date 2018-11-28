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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LSVRP.Features.Vehicles;

namespace LSVRP.Database.Models
{
    [Table("lsvrp_vehicle_mods")]
    public class VehicleMod
    {
        [Key] public int Id { get; set; }
        public int VehicleId { get; set; }
        public ModType ModId { get; set; }
        public int ModVal { get; set; }
    }
}