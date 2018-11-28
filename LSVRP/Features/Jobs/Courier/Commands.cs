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
using LSVRP.Database.Models;
using LSVRP.Libraries;
using LSVRP.Managers;

namespace LSVRP.Features.Jobs.Courier
{
    public class Commands : Script
    {
        [Command("kurier")]
        public void Command_Kurier(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (charData.JobId != JobType.Courier)
            {
                Ui.ShowError(player, "Nie jesteś kurierem.");
                return;
            }

            if (Library.DoesPlayerHasActiveOrder(player))
            {
                Library.StopCourier(player);
                Ui.ShowInfo(player, "Zakończyłeś sesję kuriera.");
            }
            else
            {
                Library.StartCourier(player);
                Ui.ShowInfo(player,
                    "Rozpocząłeś sesję kuriera. Udaj się do wyznaczonego punktu, aby odebrać zgłoszenie.");
            }
        }
    }
}