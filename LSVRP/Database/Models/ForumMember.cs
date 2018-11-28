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
    [Table("lsvrpcore_members")]
    public class ForumMember
    {
        [Column("member_id")] [Key] public int MemberId { get; set; }
        [Column("name")] public string Username { get; set; }
        public int AdminLevel { get; set; }
        [Column("vPoints")] public int VisualPoints { get; set; }
        [Column("donateTime")] public int DonateTime { get; set; }
        public string AdminFlags { get; set; }
    }
}