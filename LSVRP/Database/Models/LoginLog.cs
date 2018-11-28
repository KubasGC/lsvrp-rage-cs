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
    [Table("lsvrp_login_logs")]
    public class LoginLog
    {
        [Key] public int Id { get; set; }
        [Column("memberID")] public int MemberId { get; set; }
        [Column("time")] public int Time { get; set; }
        [Column("ip")] public string Ip { get; set; }
        [Column("serial")] public string Serial { get; set; }
        [Column("success")] public bool Success { get; set; }
    }
}