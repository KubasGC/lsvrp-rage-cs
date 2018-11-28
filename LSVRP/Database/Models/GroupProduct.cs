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
using LSVRP.Features.Items;
using LSVRP.New.Enums;

namespace LSVRP.Database.Models
{
    [Table("lsvrp_magazines")]
    public class GroupProduct
    {
        [Key] public int Id { get; set; }
        [Column("GroupID")] public int GroupId { get; set; }
        public string ItemName { get; set; }
        public ItemType ItemType { get; set; }
        public int ItemValue1 { get; set; }
        public int ItemValue2 { get; set; }
        public string ItemValue3 { get; set; }
        public int Stock { get; set; }
        public bool FlagType { get; set; }
        public int Price { get; set; }
    }
}