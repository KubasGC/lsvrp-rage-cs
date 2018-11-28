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
using LSVRP.Features.Items;
using LSVRP.Features.Progress;
using LSVRP.Libraries;
using LSVRP.Managers;
using LSVRP.New.Entities.Item;
using LSVRP.New.Enums;
using LSVRP.New.Helpers;
using LSVRP.New.Managers;
using Log = LSVRP.Modules.Log;
using LogType = LSVRP.Modules.LogType;
using Vehicle = LSVRP.Database.Models.Vehicle;

namespace LSVRP.Features.Offers
{
    public static class Library
    {
        /// <summary>
        /// Lista ofert.
        /// </summary>
        private static readonly Dictionary<int, Offer> OffersList = new Dictionary<int, Offer>();

        /// <summary>
        /// Zwraca listę aktywnych ofert.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, Offer> GetAllOffers()
        {
            return OffersList;
        }

        /// <summary>
        /// Zwraca dane oferty o podanym Id.
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns></returns>
        public static Offer GetOfferData(int offerId)
        {
            return OffersList.ContainsKey(offerId) ? OffersList[offerId] : null;
        }

        /// <summary>
        /// Zwraca najmniejsze dostępne Id dla oferty.
        /// </summary>
        /// <returns></returns>
        private static int GetFreeOfferIndex()
        {
            int i = 0;
            while (true)
            {
                if (GetOfferData(i) == null) return i;
                i++;
            }
        }

        /// <summary>
        /// Zwraca true jeśli gracz posiada aktywną ofertę, inaczej false.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasActiveOffer(Client player)
        {
            return OffersList.Any(t => t.Value.Player == player || t.Value.Target == player);
        }

        /// <summary>
        /// Zwraca dane oferty dotyczącej podanego gracza.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static Offer GetOfferData(Client player)
        {
            foreach (KeyValuePair<int, Offer> offer in OffersList)
                if (offer.Value.Player == player || offer.Value.Target == player)
                    return offer.Value;

            return null;
        }

        /// <summary>
        /// Tworzy nową ofertę.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="target"></param>
        /// <param name="type"></param>
        /// <param name="price"></param>
        /// <param name="data"></param>
        /// <param name="name"></param>
        /// <param name="system"></param>
        public static void CreateOffer(Client player, Client target, OfferType type, uint price,
            Dictionary<string, object> data, string name, bool system = false)
        {
            Offer newOffer = new Offer
            {
                Id = GetFreeOfferIndex(),
                Player = player,
                Target = target,
                Type = type,
                Price = price,
                Data = data,
                StartedAt = Global.GetTimestamp(),
                SystemOffer = system
            };

            OffersList.Add(newOffer.Id, newOffer);
            if (player != null) Ui.ShowInfo(player, "Oferta została złożona.");

            // TODO: logi

            string pName = player == null ? "System" : Player.GetPlayerIcName(player);

            NAPI.ClientEvent.TriggerClientEvent(target, "client.offers.showOffer",
                $"{pName} ofertuje {name}", price);
            Log.ConsoleLog("OFFERS", $"Oferta o Id {newOffer.Id} zostala utworzona.", LogType.Debug);
        }

        /// <summary>
        /// Usuwa istniejącą ofertę.
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="withMessage"></param>
        /// <param name="reason"></param>
        /// <param name="cancelOffer"></param>
        public static void DestroyOffer(int offerId, bool withMessage = true,
            string reason = "Wystąpił problem w trakcie realizowania oferty.", bool cancelOffer = false)
        {
            Offer offerData = GetOfferData(offerId);
            if (offerData == null) return;

            if (withMessage)
            {
                if (!offerData.SystemOffer && offerData.Player != null && NAPI.Entity.DoesEntityExist(offerData.Player))
                {
                    NAPI.ClientEvent.TriggerClientEvent(offerData.Player, "client.offers.hideOffer");

                    if (cancelOffer)
                        Ui.ShowInfo(offerData.Player, reason);
                    else
                        Ui.ShowError(offerData.Player, reason);
                }

                if (NAPI.Entity.DoesEntityExist(offerData.Target))
                {
                    NAPI.ClientEvent.TriggerClientEvent(offerData.Target, "client.offers.hideOffer");

                    if (cancelOffer)
                        Ui.ShowInfo(offerData.Target, reason);
                    else
                        Ui.ShowError(offerData.Target, reason);
                }
            }


            Log.ConsoleLog("OFFERS", $"Oferta o Id {offerData.Id} zostala usunieta.", LogType.Debug);
            OffersList.Remove(offerData.Id);
        }

        /// <summary>
        /// Akceptuje ofertę z wybranym typem płatności.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="payType"></param>
        public static void AcceptOffer(Character charData, OfferPayType payType)
        {
            if (charData == null) return;
            Offer offerData = GetOfferData(charData.PlayerHandle);
            if (offerData == null) return;

            if (offerData.Player == charData.PlayerHandle && !offerData.SystemOffer &&
                offerData.Target != offerData.Player)
            {
                Ui.ShowError(charData.PlayerHandle, "Nie możesz zaakceptować oferty za drugiego gracza.");
                return;
            }

            OnOfferAccept(offerData.Id, payType);
        }

        /// <summary>
        /// Odrzuca ofertę danego gracza.
        /// </summary>
        /// <param name="charData"></param>
        public static void DiscardOffer(Character charData)
        {
            if (charData == null) return;
            Offer offerData = GetOfferData(charData.PlayerHandle);
            if (offerData == null) return;

            if (offerData.Target == charData.PlayerHandle)
            {
                Ui.ShowError(charData.PlayerHandle, "Nie możesz odrzucić oferty za drugiego gracza.");
                return;
            }

            DestroyOffer(offerData.Id, true, "Oferta została odrzucona.", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charData">Sprzedający</param>
        /// <param name="targetData">Kupujący</param>
        /// <param name="payType"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static bool PayForOffer(Character charData, Character targetData, OfferPayType payType, int price)
        {
            if (targetData == null) return false;

            if (charData != null)
            {
                if (payType == OfferPayType.Cash)
                {
                    if (!Money.Library.TakePlayerWalletCash(targetData, price,
                        $"Zapłata za ofertę dla gracza {Player.GetPlayerDebugName(charData)}")) return false;
                    if (!Money.Library.GivePlayerWalletCash(charData, price,
                        $"Zapłata za ofertę od gracza {Player.GetPlayerDebugName(targetData)}"))
                    {
                        Money.Library.GivePlayerWalletCash(targetData, price, "Zwrot kwoty po nieudanej próbie oferty");
                        return false;
                    }

                    return true;
                }

                if (payType == OfferPayType.Card)
                {
                    if (!Money.Library.TakePlayerBankCash(targetData, price,
                        $"Zapłata za ofertę dla gracza {Player.GetPlayerDebugName(charData)}")) return false;
                    if (!Money.Library.GivePlayerBankCash(charData, price,
                        $"Zapłata za ofertę od gracza {Player.GetPlayerDebugName(targetData)}"))
                    {
                        Money.Library.GivePlayerBankCash(targetData, price, "Zwrot kwoty po nieudanej próbie oferty");
                        return false;
                    }

                    return true;
                }
            }
            else
            {
                if (payType == OfferPayType.Cash)
                {
                    if (!Money.Library.TakePlayerWalletCash(targetData, price,
                        "Zapłata za ofertę dla systemu")) return false;
                    return true;
                }

                if (payType == OfferPayType.Card)
                {
                    if (!Money.Library.TakePlayerBankCash(targetData, price,
                        "Zapłata za ofertę dla systemu")) return false;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Wykonuje się w momencie zaakceptowania oferty.
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="payType"></param>
        private static void OnOfferAccept(int offerId, OfferPayType payType)
        {
            Offer offerData = GetOfferData(offerId);
            if (offerData == null) return;

            if (!offerData.SystemOffer && !NAPI.Entity.DoesEntityExist(offerData.Player) ||
                !NAPI.Entity.DoesEntityExist(offerData.Target))
            {
                offerData.Destroy("Jeden z graczy nie jest zalogowany.");
                return;
            }

            Character charData = Account.GetPlayerData(offerData.Player);
            Character targetData = Account.GetPlayerData(offerData.Target);

            if (!offerData.SystemOffer && charData == null || targetData == null)
            {
                offerData.Destroy("Jeden z graczy nie jest zalogowany.");
                return;
            }

            if (payType == OfferPayType.Cash && targetData.Cash < offerData.Price)
            {
                offerData.Destroy("Kupujący nie ma odpowiedniej ilości gotówki przy sobie.");
                return;
            }

            if (payType == OfferPayType.Card && targetData.AccountBalance < offerData.Price)
            {
                offerData.Destroy("Kupujący nie ma na koncie bankowym odpowiedniej ilości gotówki.");
                return;
            }

            // Akcje ofert

            if (offerData.Type == OfferType.SellItem)
            {
                if (Global.GetDistanceBetweenPositions(offerData.Player.Position, offerData.Target.Position) > 3.0 ||
                    offerData.Player.Dimension != offerData.Target.Dimension)
                {
                    offerData.Destroy("Zbyt daleko od celu.");
                    return;
                }

                ItemEntity itemData = ItemsManager.Items.FirstOrDefault(t => t.Id == (int) offerData.Data["Id"]);
                
                if (itemData == null)
                {
                    offerData.Destroy("Przedmiot nie został znaleziony.");
                    return;
                }

                if (itemData.Used)
                {
                    offerData.Destroy("Przedmiot nie może być używany.");
                    return;
                }

                if (offerData.Price == 0 || PayForOffer(charData, targetData, payType, (int) offerData.Price))
                {
                    
                    itemData.SetOwner(OwnerType.Player, targetData.Id);

                    Chat.Library.SendPlayerMeMessage(charData,
                        $"podaje przedmiot \"{itemData.Name}\" graczowi {Player.GetPlayerIcName(targetData)}", true);
                    offerData.Success();
                    return;
                }
            }
            else if (offerData.Type == OfferType.Rp)
            {
                if (offerData.Price == 0 || PayForOffer(charData, targetData, payType, (int) offerData.Price))
                {
                    offerData.Success();
                    return;
                }
            }
            else if (offerData.Type == OfferType.RegisterVehicle)
            {
                Vehicle vehData = Vehicles.Library.GetVehicleData((int) offerData.Data["Id"]);
                if (vehData == null)
                {
                    offerData.Destroy("Wystąpił błąd w trakcie pobierania danych pojazdu.");
                    return;
                }

                if (offerData.Price == 0 || PayForOffer(charData, targetData, payType, (int) offerData.Price))
                {
                    vehData.NumberPlate = Vehicles.Library.GeneratePlate();
                    vehData.Save();
                    if (vehData.Spawned && NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                        vehData.VehicleHandle.NumberPlate = vehData.NumberPlate;
                    // TODO: akcje z botem

                    offerData.Success();
                    return;
                }
            }
            else if (offerData.Type == OfferType.SellCar)
            {
                Vehicle vehData = Vehicles.Library.GetVehicleData((int) offerData.Data["Id"]);
                if (vehData == null)
                {
                    offerData.Destroy("Pojazd nie został odnaleziony.");
                    return;
                }

                if (offerData.Price == 0 || PayForOffer(charData, targetData, payType, (int) offerData.Price))
                {
                    vehData.OwnerType = Vehicles.OwnerType.Player;
                    vehData.Owner = targetData.Id;
                    vehData.Save();
                    Chat.Library.SendPlayerMeMessage(charData,
                        $"podaje klucze do pojazdu graczowi {Player.GetPlayerIcName(targetData)}.", true);

                    offerData.Success();
                    return;
                }
            }
            else if (offerData.Type == OfferType.Heal)
            {
                if (offerData.Price == 0 || PayForOffer(charData, targetData, payType, (int) offerData.Price))
                {
                    targetData.Health = 100;
                    targetData.PlayerHandle.Health = 100;

                    offerData.Success();
                    return;
                }
            }
            else if (offerData.Type == OfferType.PdFine)
            {
                // todo
            }
            else if (offerData.Type == OfferType.Fuel)
            {
                // todo
            }
            else if (offerData.Type == OfferType.GroupGive)
            {
                using (Database.Database db = new Database.Database())
                {
                    // todo
                }
            }
            else if (offerData.Type == OfferType.BincoCloth)
            {
                if (offerData.Price == 0 || PayForOffer(null, targetData, payType, (int) offerData.Price))
                    using (Database.Database db = new Database.Database())
                    {
                        db.ClothSets.Add((ClothSet) offerData.Data["clothSet"]);
                        db.SaveChanges();

                        Player.SendFormattedChatMessage(targetData.PlayerHandle,
                            "Ubranie zostało zapisane. Możesz je zmienić używając komendy /przebierz.",
                            Constants.ColorPictonBlue);

                        offerData.Success();
                    }
            }
            else if (offerData.Type == OfferType.GasStation)
            {
                Vehicle vehData = Vehicles.Library.GetVehicleData((GTANetworkAPI.Vehicle) offerData.Data["vehicle"]);
                if (vehData != null)
                    if (offerData.Price == 0 || PayForOffer(null, targetData, payType, (int) offerData.Price))
                    {
                        vehData.Fuel += Command.GetNumberFromString(offerData.Data["fuel"].ToString());
                        vehData.Save();

                        Chat.Library.SendPlayerMeMessage(targetData,
                            $"wkłada wąż do baku i tankuje auto \"{vehData.Name}\".", true);

                        offerData.Success();
                    }
            }
            else if (offerData.Type == OfferType.Repair)
            {
                Vehicle vehData = (Vehicle) offerData.Data["vehData"];
                if (vehData != null)
                {
                    if (charData != null && Progress.Library.DoesPlayerHasActiveProgress(charData) ||
                        targetData != null && Progress.Library.DoesPlayerHasActiveProgress(targetData))
                    {
                        offerData.Destroy("Jeden z graczy posiada już aktywne zadanie.");
                        return;
                    }

                    Dictionary<string, object> data = new Dictionary<string, object>
                    {
                        {"veh", vehData},
                        {"price", offerData.Price},
                        {"type", payType}
                    };
                    Progress.Library.CreateProgress("Naprawa pojazdu", targetData, charData, ProgressType.FixVehicle,
                        60, data);
                    offerData.Success(true);
                }
            }
            else if (offerData.Type == OfferType.TattooCreate)
            {
                if (charData != null && Progress.Library.DoesPlayerHasActiveProgress(charData) ||
                    targetData != null && Progress.Library.DoesPlayerHasActiveProgress(targetData))
                {
                    offerData.Destroy("Jeden z graczy posiada już aktywne zadanie.");
                    return;
                }

                Dictionary<string, object> data = new Dictionary<string, object>
                {
                    {"tattooId", (int) offerData.Data["tattooId"]},
                    {"price", offerData.Price},
                    {"type", payType}
                };
                Progress.Library.CreateProgress("Nakładanie tatuażu", targetData, charData, ProgressType.TattooCreate,
                    20, data);
                offerData.Success(true);
            }

            offerData.Destroy();
        }
    }
}