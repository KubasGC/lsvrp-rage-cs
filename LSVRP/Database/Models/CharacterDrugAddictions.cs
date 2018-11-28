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
    [Table("lsvrp_characters_drugs")]
    public class CharacterDrugAddictions
    {
        [Key] public int Id { get; set; }
        public int CharId { get; set; }
        public int Marijuana { get; set; }
        public int Cocaine { get; set; }
        public int Amphetamine { get; set; }
        public int MetaAmphetamine { get; set; }
        public int Heroin { get; set; }
        public int Opium { get; set; }
        public int Lsd { get; set; }
        public int Hash { get; set; }

        public int MarijuanaTime { get; set; }
        public int CocaineTime { get; set; }
        public int AmphetamineTime { get; set; }
        public int MetaAmphetamineTime { get; set; }
        public int HeroinTime { get; set; }
        public int OpiumTime { get; set; }
        public int LsdTime { get; set; }
        public int HashTime { get; set; }
    }
}