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
using LSVRP.Features.Dialogs;
using LSVRP.Features.Jobs.Courier;
using LSVRP.Libraries;
using LSVRP.Managers;
using Log = LSVRP.Modules.Log;
using LogType = LSVRP.Modules.LogType;

namespace LSVRP.Features.Blips
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.events.OnMarkerEnter")]
        public void Event_OnMarkerEnter(Client player, string markerName)
        {
            Log.ConsoleLog("BLIPS", $"OnMarkerEnter: {markerName}", LogType.Debug);
            if (markerName == "courier.blip")
            {
                using (Database.Database db = new Database.Database())
                {
                    List<OrderPending> activeOrders = new List<OrderPending>();
                    foreach (OrderPending entry in db.OrdersPendings.ToList())
                        if (!Jobs.Courier.Library.DoesOrderDelivered(entry.Id))
                            activeOrders.Add(entry);

                    if (activeOrders.Count == 0)
                    {
                        Ui.ShowError(player, "Nie ma dostępnych żadnych paczek.");
                        Jobs.Courier.Library.StopCourier(player);
                        return;
                    }


                    List<DialogColumn> dialogColumns = new List<DialogColumn>
                    {
                        new DialogColumn("Paczka", 90)
                    };

                    List<DialogRow> dialogRows = new List<DialogRow>();
                    foreach (OrderPending entry in activeOrders)
                        dialogRows.Add(new DialogRow(entry.Id, new[] {entry.Name}));

                    string[] dialogButtons = {"Przyjmij", "Anuluj"};

                    Dialogs.Library.CreateDialog(player, DialogId.CourierAcceptPackage,
                        "Wybierz paczkę do dostarczenia", dialogColumns, dialogRows, dialogButtons);
                }
            }
            else if (markerName == "courier.group")
            {
                CourierOrder courierData = Jobs.Courier.Library.GetCourierData(player);
                if (courierData == null)
                {
                    Jobs.Courier.Library.StopCourier(player);
                    return;
                }

                using (Database.Database db = new Database.Database())
                {
                    OrderPending pendingOrder = db.OrdersPendings.FirstOrDefault(t => t.Id == courierData.OrderId);
                    if (pendingOrder == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono takiego zamówienia.");
                        Jobs.Courier.Library.StopCourier(player);
                        return;
                    }

                    Order orderData = db.Orders.FirstOrDefault(t => t.Id == pendingOrder.OrderId);
                    if (orderData == null)
                    {
                        Ui.ShowError(player, "Nie ma zamówienia odpowiadającemu temu w bazie.");
                        Jobs.Courier.Library.StopCourier(player);
                        return;
                    }

                    GroupProduct magazineItem = db.GroupProducts.FirstOrDefault(t =>
                        t.GroupId == orderData.GroupId && t.ItemName == orderData.Name &&
                        t.ItemType == orderData.Type && t.ItemValue1 == orderData.Value1 &&
                        t.ItemValue2 == orderData.Value2);

                    if (magazineItem == null)
                    {
                        magazineItem = new GroupProduct
                        {
                            GroupId = orderData.GroupId,
                            ItemName = orderData.Name,
                            ItemType = orderData.Type,
                            ItemValue1 = orderData.Value1,
                            ItemValue2 = orderData.Value2,
                            ItemValue3 = orderData.Value3,
                            Stock = pendingOrder.Count,
                            FlagType = orderData.Flag,
                            Price = orderData.Price
                        };
                        db.GroupProducts.Add(magazineItem);
                    }
                    else
                    {
                        magazineItem.Stock += pendingOrder.Count;
                        db.GroupProducts.Update(magazineItem);
                    }

                    int price = pendingOrder.Count * 2;
                    if (price < 20) price = 20;
                    if (price > 100) price = 100;

                    Ui.ShowInfo(player,
                        $"Paczka została dostarczona pomyślnie. Otrzymałeś zapłatę w wysokości ${price}.");
                    Money.Library.GivePlayerWalletCash(player, price, "Zapłata za kurs kuriera.");

                    db.OrdersPendings.Remove(pendingOrder);
                    db.SaveChanges();

                    Jobs.Courier.Library.StopCourier(player);
                }
            }
            else if (markerName == "vehicle.target")
            {
                Character charData = Account.GetPlayerData(player);
                if (charData == null) return;

                Account.RemoveServerData(charData, Account.ServerData.TargetingAtVehicle);
                Ui.ShowInfo(player, "Namierzanie pojazdu zostało wyłączone.");
                NAPI.ClientEvent.TriggerClientEvent(player, "client.markers.destroyMarker", "vehicle.target");
            }
        }
    }
}