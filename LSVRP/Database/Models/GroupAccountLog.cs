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
    [Table("lsvrp_groups_account_logs")]
    public class GroupAccountLog
    {
        [Key] public int Id { get; set; }
        [Column("GroupID")] public int GroupId { get; set; }
        public string Message { get; set; }
        public int Timestamp { get; set; }
        public int Change { get; set; }
        public int NewBalance { get; set; }
    }
}