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
    [Table("lsvrp_groups_duty")]
    public class GroupDuty
    {
        [Key] public int Id { get; set; }
        [Column("GroupID")] public int GroupId { get; set; }
        [Column("CharID")] public int CharId { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}