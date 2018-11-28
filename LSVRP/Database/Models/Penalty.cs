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
using LSVRP.Features.Penalties;

namespace LSVRP.Database.Models
{
    [Table("lsvrp_penalties")]
    public class Penalty
    {
        [Key] public int Id { get; set; }
        [Column("AdminID")] public int AdminId { get; set; }
        [Column("TargetID")] public int TargetId { get; set; }
        [Column("TargetGlobalID")] public int TargetGlobalId { get; set; }
        public PenaltyType Type { get; set; }
        public string Reason { get; set; }
        [Column("TimeStamp")] public int Timestamp { get; set; }
        public int Expired { get; set; }
    }
}