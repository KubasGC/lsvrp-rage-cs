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
    [Table("lsvrp_animations")]
    public class Animation
    {
        [Key] public int Id { get; set; }
        public string AnimationDictionary { get; set; }
        public string AnimationName { get; set; }
        public string AnimationCommand { get; set; }
        public bool Loop { get; set; }
        public bool StopOnLastFrame { get; set; }
        public bool OnlyAnimateUpperBody { get; set; }
        public bool AllowPlayerControl { get; set; }
        public bool Cancellable { get; set; }
        [Column("ItemID")] public int ItemId { get; set; }
        public float ItemX { get; set; }
        public float ItemY { get; set; }
        public float ItemZ { get; set; }
        public float ItemRotX { get; set; }
        public float ItemRotY { get; set; }
        public float ItemRotZ { get; set; }
        public string ItemBoneName { get; set; }
    }
}