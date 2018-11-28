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
    [Table("lsvrp_blips")]
    public class Blip
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        [Column("SpriteID")] public int SpriteId { get; set; }
        [Column("ColorID")] public int ColorId { get; set; }
        public int Alpha { get; set; }
        public float Scale { get; set; }
        public int Dimension { get; set; }
        public int CreatedBy { get; set; }
        public int CreatedAt { get; set; }

        [NotMapped] public GTANetworkAPI.Blip BlipHandle { get; set; }
    }
}