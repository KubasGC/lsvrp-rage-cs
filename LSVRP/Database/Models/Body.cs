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
    [Table("lsvrp_bodies")]
    public class Body
    {
        [Key] public int Id { get; set; }
        public int CharId { get; set; }
        public int ItemId { get; set; }
        public string Dna { get; set; }
        public string KillerDna { get; set; }
        public string Description { get; set; }
        public int Timestamp { get; set; }
        public int DeathReason { get; set; }
    }
}