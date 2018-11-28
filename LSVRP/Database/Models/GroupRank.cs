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
    [Table("lsvrp_groups_ranks")]
    public class GroupRank
    {
        [Key] public int Id { get; set; }

        [Column("GroupID")] public int GroupId { get; set; }

        public string Name { get; set; }
        public int Level { get; set; }
        public string Permissions { get; set; }
        public int CreatedAt { get; set; }
    }
}