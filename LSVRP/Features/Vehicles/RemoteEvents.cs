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
using System.Collections.Generic;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Offers;
using LSVRP.Managers;
using LSVRP.Modules;
using Vehicle = LSVRP.Database.Models.Vehicle;

namespace LSVRP.Features.Vehicles
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.vehicle.mileage")]
        public void Event_VehicleMileage(Client player, double mileageToAppend)
        {
            if (!player.IsInVehicle) return;

            Vehicle vehData = Library.GetVehicleData(player.Vehicle);
            vehData.Mileage += mileageToAppend; // it's always positive number of km to append
        }
             
        [RemoteEvent("server.events.vehicleEngine")]
        public void Event_VehicleEngine(Client player)
        {
            if (!player.IsInVehicle) return;
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            Vehicle vehData = Library.GetVehicleData(player.Vehicle);
            if (vehData == null) return;

            if (Bw.Library.DoesPlayerHasBw(charData)) return;
            Library.ToggleVehicleEngine(charData, vehData, !vehData.Engine);
        }

        [RemoteEvent("server.vehicle.sync")]
        public void Event_VehicleSync(Client player, int remoteId)
        {
            Library.SyncVehicleForPlayer(player, remoteId);
        }

        [RemoteEvent("server.vehicle.bind.key")]
        public void Event_VehicleBindKey(Client player, string type)
        {
            if (!player.IsInVehicle) return;
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            Vehicle vehData = Library.GetVehicleData(player.Vehicle);
            if (vehData == null) return;
            if (!vehData.Spawned) return;

            switch (type)
            {
                case "left-indicator":
                    vehData.LeftIndicator = !vehData.LeftIndicator;
                    foreach (Client entry in NAPI.Pools.GetAllPlayers())
                        NAPI.ClientEvent.TriggerClientEvent(entry, "client.vehicle.sync.indicator",
                            vehData.VehicleHandle.Value, vehData.LeftIndicator, vehData.RightIndicator);
                    break;

                case "right-indicator":
                    vehData.RightIndicator = !vehData.RightIndicator;
                    foreach (Client entry in NAPI.Pools.GetAllPlayers())
                        NAPI.ClientEvent.TriggerClientEvent(entry, "client.vehicle.sync.indicator",
                            vehData.VehicleHandle.Value, vehData.LeftIndicator, vehData.RightIndicator);
                    break;

                case "siren":
                    vehData.SirenSound = !vehData.SirenSound;
                    foreach (Client entry in NAPI.Pools.GetAllPlayers())
                        NAPI.ClientEvent.TriggerClientEvent(entry, "client.vehicle.sync.siren",
                            vehData.VehicleHandle.Value, vehData.SirenSound);
                    break;
            }
        }

        [RemoteEvent("server.gas.offer")]
        public void Event_GasStationOffer(Client player, int fuel, int cash)
        {
            if (!player.IsInVehicle) return;
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            Vehicle vehData = Library.GetVehicleData(player.Vehicle);
            if (vehData == null) return;
            if (!vehData.Spawned) return;

            Dictionary<string, object> offerData = new Dictionary<string, object>
            {
                {"vehicle", player.Vehicle},
                {"fuel", fuel}
            };

            Offers.Library.CreateOffer(null, charData.PlayerHandle, OfferType.GasStation, (uint) cash, offerData,
                "Tankowanie pojazdu", true);
        }
    }
}