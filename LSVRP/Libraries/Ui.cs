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
using GTANetworkAPI;

namespace LSVRP.Libraries
{
    public static class Ui
    {
        /// <summary>
        /// Wyświetla informację dla gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="content"></param>
        public static void ShowInfo(Client player, string content)
        {
            player.TriggerEvent("client.ui.showNotification", content, 1);
        }

        /// <summary>
        /// Wyświetla ostrzeżenie dla gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="content"></param>
        public static void ShowWarning(Client player, string content)
        {
            player.TriggerEvent("client.ui.showNotification", content, 2);
        }

        /// <summary>
        /// Wyświetla błąd dla gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="content"></param>
        public static void ShowError(Client player, string content)
        {
            player.TriggerEvent("client.ui.showNotification", content, 3);
        }

        /// <summary>
        /// Wyświetla użycie dla gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="content"></param>
        public static void ShowUsage(Client player, string content)
        {
            player.TriggerEvent("client.ui.showNotification", content, 4);
        }

        public static class Content
        {
            public const string
                NoPermission = "Nie posiadasz wystarczających uprawnień do użycia tej komendy.";
        }
    }
}