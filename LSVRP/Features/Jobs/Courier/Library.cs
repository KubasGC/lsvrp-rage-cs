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
using System.Linq;
using GTANetworkAPI;
using LSVRP.Database.Models;

namespace LSVRP.Features.Jobs.Courier
{
    public static class Library
    {
        private static readonly Dictionary<Client, CourierOrder> CourierOrders = new Dictionary<Client, CourierOrder>();
        private static readonly Vector3 StartPosition = new Vector3(822, -2141, 29);

        /// <summary>
        /// Zwraca true jeśli gracz posiada aktywne zlecenie
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasActiveOrder(Client player)
        {
            return CourierOrders.ContainsKey(player);
        }

        /// <summary>
        /// Zwraca true jeśli zamówienie jest dostarczane przez jakiegoś gracza.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static bool DoesOrderDelivered(int orderId)
        {
            foreach (KeyValuePair<Client, CourierOrder> courierOrder in CourierOrders)
                if (courierOrder.Value.OrderId == orderId)
                {
                    if (courierOrder.Value.Player == null || !NAPI.Entity.DoesEntityExist(courierOrder.Value.Player))
                    {
                        CourierOrders.Remove(courierOrder.Key);
                        return false;
                    }

                    return true;
                }

            return false;
        }

        /// <summary>
        /// Startuje nową sesję kuriera.
        /// </summary>
        /// <param name="player"></param>
        public static void StartCourier(Client player)
        {
            StopCourier(player);
            CourierOrders.Add(player, new CourierOrder
            {
                OrderId = 0,
                Player = player,
                State = CourierState.Start
            });

            NAPI.ClientEvent.TriggerClientEvent(player, "client.markers.createMarker", "courier.blip",
                StartPosition.X, StartPosition.Y, StartPosition.Z, 160, 9, 242, 140, 5, true, 3);
        }

        /// <summary>
        /// Zatrzymuje aktywną sesję kuriera.
        /// </summary>
        /// <param name="player"></param>
        public static void StopCourier(Client player)
        {
            if (CourierOrders.ContainsKey(player)) CourierOrders.Remove(player);
            NAPI.ClientEvent.TriggerClientEvent(player, "client.markers.destroyMarker", "courier.blip");
            NAPI.ClientEvent.TriggerClientEvent(player, "client.markers.destroyMarker", "courier.group");
        }

        /// <summary>
        /// Zwraca dane o aktualnym kurierze.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static CourierOrder GetCourierData(Client player)
        {
            return CourierOrders.ContainsKey(player) ? CourierOrders[player] : null;
        }

        /// <summary>
        /// Zwraca dane o oczekującej ofercie o podanym Id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static OrderPending GetPendingOrder(int orderId)
        {
            using (Database.Database db = new Database.Database())
            {
                return db.OrdersPendings.FirstOrDefault(t => t.Id == orderId);
            }
        }
    }
}