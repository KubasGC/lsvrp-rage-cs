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
    [Table("lsvrp_orders_pending")]
    public class OrderPending
    {
        [Key] public int Id { get; set; }
        public int GroupId { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int CreatedAt { get; set; }
    }
}