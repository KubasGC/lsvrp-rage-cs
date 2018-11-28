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
    [Table("lsvrp_bans")]
    public class Ban
    {
        [Key] public int Id { get; set; }
        public string Ip { get; set; }
        public string SocialClubName { get; set; }
        [Column("MemberID")] public int MemberId { get; set; }
        public string Reason { get; set; }
        public int Expire { get; set; }
        public bool Canceled { get; set; }
        public string Serial { get; set; }
        [Column("AdminID")] public int AdminId { get; set; }
    }
}