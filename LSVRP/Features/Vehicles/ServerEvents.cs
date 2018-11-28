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
using Vehicle = GTANetworkAPI.Vehicle;

namespace LSVRP.Features.Vehicles
{
    public class ServerEvents : Script
    {
        [ServerEvent(Event.PlayerEnterVehicleAttempt)]
        public void Event_EnterVehicleAttempt(Client player, Vehicle veh, sbyte seatId)
        {
            Database.Models.Vehicle vehData = Library.GetVehicleData(veh);
            if (vehData == null) return;
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            foreach (Client entry in NAPI.Pools.GetAllPlayers())
                NAPI.ClientEvent.TriggerClientEvent(entry, "client.vehicle.engine", vehData.VehicleHandle.Value,
                    vehData.Engine);
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void Event_EnterVehicle(Client player, Vehicle veh, sbyte seatId)
        {
            Database.Models.Vehicle vehData = Library.GetVehicleData(veh);
            if (vehData == null) return;

            if (seatId == -1)
            {
                Character charData = Account.GetPlayerData(player);
                if (charData == null)
                {
                    player.Kick("No login.");
                    return;
                }

                if (!Library.DoesPlayerHasVehiclePerm(charData, vehData.Id))
                {
                    Ui.ShowWarning(player, "Nie posiadasz uprawnień do prowadzenia tego pojazdu.");
                    return;
                }

                // TODO: penalty
                NAPI.ClientEvent.TriggerClientEvent(player, "client.vehicle.mileage.add", (float)vehData.Mileage);
                NAPI.ClientEvent.TriggerClientEvent(player, "client.vehicle-speedometer.toggle", true);
                charData.VehicleTimer = new System.Timers.Timer(500);
                charData.VehicleTimer.Elapsed += (sender, args) =>
                {
                    NAPI.ClientEvent.TriggerClientEvent(player, "client.vehicle-speedometer.refresh",
                        (float)(vehData.Fuel / vehData.MaxFuel) * 100);
                };
                charData.VehicleTimer.Start();
                // TODO: log
            }
        }

        [ServerEvent(Event.PlayerExitVehicleAttempt)]
        public void Event_ExitVehicleAttempt(Client player, Vehicle veh)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "client.vegicle.mileage.forceRequest");
            NAPI.ClientEvent.TriggerClientEvent(player, "client.vehicle-speedometer.toggle", false);
            NAPI.ClientEvent.TriggerClientEvent(player, "client.vehicle-speedometer.toggle", false);
            NAPI.ClientEvent.TriggerClientEvent(player, "client.vehicle.mileage.remove");
            Character charData = Account.GetPlayerData(player);
            charData.VehicleTimer.Dispose();
        }

        [ServerEvent(Event.VehicleDamage)]
        public void EventVehicleDamage(Vehicle veh, float bodyHealthLoss, float engineHealthLoss)
        {
            Database.Models.Vehicle vehData = Library.GetVehicleData(veh);
            if (vehData == null) return;

            vehData.Health = veh.Health;

            Character driver = Library.GetDriver(veh);
            if (driver != null)
                Player.SendFormattedChatMessage(driver.PlayerHandle,
                    $"Uszkodziłeś pojazd (body: {bodyHealthLoss:F2} engine: {engineHealthLoss:F2})");
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        public void Event_ExitVehicle(Client player, Vehicle veh)
        {
            Database.Models.Vehicle vehData = Library.GetVehicleData(veh);
            if (vehData == null) return;

            foreach (Client entry in NAPI.Pools.GetAllPlayers())
                NAPI.ClientEvent.TriggerClientEvent(entry, "client.vehicle.engine", vehData.VehicleHandle.Value,
                    vehData.Engine);

            vehData.Health = vehData.VehicleHandle.Health;
            vehData.Save();

            // TODO: Log
        }
    }
}