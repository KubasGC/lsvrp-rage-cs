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
    [Table("lsvrp_clothset")]
    public class ClothSet
    {
        [Key] public int Id { get; set; }
        public int CharId { get; set; }
        public string Name { get; set; }
        public int TorsoId { get; set; }
        public int Legs { get; set; }
        public int LegsTexture { get; set; }
        public int Boots { get; set; }
        public int BootsTexture { get; set; }
        public int Accessories { get; set; }
        public int AccessoriesTexture { get; set; }
        public int Undershirt { get; set; }
        public int UndershirtTexture { get; set; }
        public int Tops { get; set; }
        public int TopsTexture { get; set; }
        public int Hat { get; set; }
        public int HatTexture { get; set; }
        public int Glasses { get; set; }
        public int GlassesTexture { get; set; }
        public int Ears { get; set; }
        public int EarsTexture { get; set; }
    }
}