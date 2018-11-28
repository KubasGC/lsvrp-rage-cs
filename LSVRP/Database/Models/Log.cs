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

namespace LSVRP.Database.Models
{
    [Table("lsvrp_logs")]
    public class Log
    {
        [Key] public int Id { get; set; }

        public string LogType { get; set; }
        public int LogTime { get; set; }
        public int LogOwnerType { get; set; }
        public int LogOwner { get; set; }
        public string LogContent { get; set; }
    }
}