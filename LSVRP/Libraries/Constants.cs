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
namespace LSVRP.Libraries
{
    public static class Constants
    {
        public const double
            RadiusTalk = 14.0, // Odległość, z jakiej słychać normalne mówienie
            RadiusShout = 30.0, // Ogległość, z jakiej słychać krzyk
            RadiusQuiet = 3.0, // Odlgełość, z jakiej słychać szept
            RadiusMegapthone = 60.0; // Odległość, z jakiej słychać megafon

        public const double
            FuelCost = 5.0, // Koszt za litr paliwa
            FuelUsage = 0.003, // Ilość spalanego paliwa na sekundę
            StreamDistance = 500.0; // Odległość streamingu dla danego gracza

        public const string ScriptVersion = "3.0 alpha"; // Wersja skryptu

        public const string
            ColorDarkRed = "#9D2933", // Kolor ciemny czerwony
            ColorDelRio = "#B09E99", // Kolor brązowy-kremowy (?)
            ColorPictonBlue = "#45B1E8"; // Kolor jasno-niebieski (w opór jasny)

        public const int HourlyDonation = 200; // Wysokość dotacji dla nowego gracza (co godzinę);
    }
}