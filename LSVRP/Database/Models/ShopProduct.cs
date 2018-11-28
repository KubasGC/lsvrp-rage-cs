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
    [Table("lsvrp_247_products")]
    public class ShopProduct
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string Value3 { get; set; }
        public int Price { get; set; }
        [Column("ShopID")] public int ShopId { get; set; }
    }
}