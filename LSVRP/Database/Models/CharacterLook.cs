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
    [Table("lsvrp_characters_look")]
    public class CharacterLook
    {
        [Key] public int Id { get; set; }
        public int CharId { get; set; }
        public int Father { get; set; }
        public int Mother { get; set; }
        public float SkinMix { get; set; }
        public float ColorMix { get; set; }
        public int Beard { get; set; }
        public int BeardColor { get; set; }
        public int Hair { get; set; }
        public int HairColor { get; set; }
        public int Eyebrows { get; set; }
        public int EyebrowsColor { get; set; }
        public int Scars { get; set; }
        public int Aging { get; set; }
        public int Makeup { get; set; }
        public int Blush { get; set; }
        public int BlushColor { get; set; }
        public int Complexion { get; set; }
        public int Burns { get; set; }
        public int Lipstick { get; set; }
        public int LipstickColor { get; set; }
        public int Freckles { get; set; }
        public int Chesthair { get; set; }
        public int ChesthairColor { get; set; }
        public float NoseWidth { get; set; }
        public float NoseHeight { get; set; }
        public float NoseLength { get; set; }
        public float NoseBridge { get; set; }
        public float NoseEnd { get; set; }
        public float NoseShift { get; set; }
        public float EyebrowsHeight { get; set; }
        public float EyebrowsWidth { get; set; }
        public float BoneHeight { get; set; }
        public float BoneWidth { get; set; }
        public float CheeksWidth { get; set; }
        public float EyesWidth { get; set; }
        public float LipsWidth { get; set; }
        public float JawWidth { get; set; }
        public float JawHeight { get; set; }
        public float ChinLength { get; set; }
        public float ChinPosition { get; set; }
        public float ChinWidth { get; set; }
        public float ChinShape { get; set; }
        public float NeckLength { get; set; }
    }
}