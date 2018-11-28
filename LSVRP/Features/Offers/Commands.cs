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
using LSVRP.Features.Groups;
using LSVRP.Features.Items;
using LSVRP.Features.Tattoos;
using LSVRP.Libraries;
using LSVRP.Managers;
using LSVRP.New.Entities.Item;
using LSVRP.New.Managers;
using Vehicle = LSVRP.Database.Models.Vehicle;

namespace LSVRP.Features.Offers
{
    public class Commands : Script
    {
        [Command("o", Alias = "oferuj", GreedyArg = true)]
        public void Command_Oferuj(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            const string legend =
                "/o(feruj) [przedmiot, pojazd, leczenie, naprawe, lakierowanie, montaz, mandat, rp, tatuaz]";
            string[] arguments = Command.GetCommandArguments(args);

            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            if (Library.DoesPlayerHasActiveOffer(player))
            {
                Ui.ShowError(player, "Posiadasz już aktywną inną ofertę.");
                return;
            }

            string offerType = arguments[0].ToLower();

            if (offerType == "przedmiot")
            {
                if (arguments.Length - 1 < 3)
                {
                    Ui.ShowUsage(player, "/o(feruj) przedmiot [ID przedmiotu] [ID gracza] [cena]");
                    return;
                }

                int itemId = Command.GetNumberFromString(arguments[1]);
                int playerId = Command.GetNumberFromString(arguments[2]);
                int price = Command.GetNumberFromString(arguments[3]);

                if (itemId == Command.InvalidNumber || playerId == Command.InvalidNumber ||
                    price == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne parametry komendy.");
                    return;
                }

                if (price < 0)
                {
                    Ui.ShowWarning(player, "Kwota oferty musi być większa lub równa 0.");
                    return;
                }

                Character target = Account.GetPlayerDataByServerId(playerId);
                if (target == null)
                {
                    Ui.ShowError(player, "Nie znaleziono gracza o podanym ID.");
                    return;
                }

                if (Library.DoesPlayerHasActiveOffer(target.PlayerHandle))
                {
                    Ui.ShowError(player, "Gracz posiada już inną aktywną ofertę.");
                    return;
                }

                if (Global.GetDistanceBetweenPositions(player.Position, target.PlayerHandle.Position) > 3.0 ||
                    player.Dimension != target.PlayerHandle.Dimension)
                {
                    Ui.ShowError(player, "Gracz jest za daleko.");
                    return;
                }

                ItemEntity itemData = ItemsManager.Items.FirstOrDefault(t => t.Id == itemId);
                if (itemData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono przedmiotu o podanym Id.");
                    return;
                }

               if (!itemData.CheckOwner(charData))
                {
                    Ui.ShowError(player, "Przedmiot nie należy do Ciebie.");
                    return;
                }

                if (itemData.Used)
                {
                    Ui.ShowError(player, "Przedmiot nie może być używany.");
                    return;
                }

                Dictionary<string, object> offerData = new Dictionary<string, object>
                {
                    {"Id", itemData.Id}
                };

                Library.CreateOffer(player, target.PlayerHandle, OfferType.SellItem, (uint) price, offerData,
                    $"sprzedaż przedmiotu {itemData.Name}");
            }
            else if (offerType == "pojazd")
            {
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe, aby uzyć tej komendy.");
                    return;
                }

                if (arguments.Length - 1 < 2)
                {
                    Ui.ShowUsage(player, "/o(feruj) pojazd [ID gracza] [cena]");
                    return;
                }

                int playerId = Command.GetNumberFromString(arguments[1]);
                int price = Command.GetNumberFromString(arguments[2]);

                if (playerId == Command.InvalidNumber || price == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne parametry komendy.");
                    return;
                }

                if (price < 0)
                {
                    Ui.ShowWarning(player, "Kwota oferty musi być większa lub równa 0.");
                    return;
                }

                Character target = Account.GetPlayerDataByServerId(playerId);
                if (target == null)
                {
                    Ui.ShowError(player, "Nie znaleziono gracza o podanym ID.");
                    return;
                }

                if (Library.DoesPlayerHasActiveOffer(target.PlayerHandle))
                {
                    Ui.ShowError(player, "Gracz posiada już inną aktywną ofertę.");
                    return;
                }

                if (Global.GetDistanceBetweenPositions(player.Position, target.PlayerHandle.Position) > 3.0 ||
                    player.Dimension != target.PlayerHandle.Dimension)
                {
                    Ui.ShowError(player, "Gracz jest za daleko.");
                    return;
                }

                Vehicle vehData = Vehicles.Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd nie istnieje.");
                    return;
                }

                if (vehData.OwnerType != Vehicles.OwnerType.Player || vehData.Owner != charData.Id)
                {
                    Ui.ShowError(player, "Pojazd nie należy do Ciebie.");
                    return;
                }

                Dictionary<string, object> offerData = new Dictionary<string, object>
                {
                    {"Id", vehData.Id}
                };

                Library.CreateOffer(player, target.PlayerHandle, OfferType.SellCar, (uint) price, offerData,
                    $"sprzedaż pojazdu {vehData.Name}");
            }
            else if (offerType == "leczenie")
            {
                int groupDuty = Groups.Library.GetPlayerGroupDuty(charData);
                if (groupDuty == 0)
                {
                    Ui.ShowError(player, "Nie jesteś na duty żadnej grupy.");
                    return;
                }

                if (!Groups.Library.DoesGroupHasPerm(groupDuty, Permissions.SharedMedHeal))
                {
                    Ui.ShowError(player, "Grupa nie posiada uprawnień do leczenia.");
                    return;
                }

                if (!Groups.Library.DoesPlayerHasPerm(charData, groupDuty, Permissions.SharedMedHeal))
                {
                    Ui.ShowError(player, "Twoja ranga w grupie nie posiada upranień do leczenia.");
                    return;
                }

                if (arguments.Length - 1 < 2)
                {
                    Ui.ShowUsage(player, "/o(feruj) leczenie [ID gracza] [cena]");
                    return;
                }

                int playerId = Command.GetNumberFromString(arguments[1]);
                int price = Command.GetNumberFromString(arguments[2]);

                if (playerId == Command.InvalidNumber || price == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne parametry komendy.");
                    return;
                }

                if (price < 0)
                {
                    Ui.ShowWarning(player, "Kwota oferty musi być większa lub równa 0.");
                    return;
                }

                Character target = Account.GetPlayerDataByServerId(playerId);
                if (target == null)
                {
                    Ui.ShowError(player, "Nie znaleziono gracza o podanym ID.");
                    return;
                }

                if (Library.DoesPlayerHasActiveOffer(target.PlayerHandle))
                {
                    Ui.ShowError(player, "Gracz posiada już inną aktywną ofertę.");
                    return;
                }

                if (Global.GetDistanceBetweenPositions(player.Position, target.PlayerHandle.Position) > 3.0 ||
                    player.Dimension != target.PlayerHandle.Dimension)
                {
                    Ui.ShowError(player, "Gracz jest za daleko.");
                    return;
                }

                Library.CreateOffer(player, target.PlayerHandle, OfferType.Heal, (uint) price, null, "Leczenie");
            }
            else if (offerType == "naprawe")
            {
                if (arguments.Length - 1 < 2)
                {
                    Ui.ShowUsage(player, "/o(feruj) naprawe [ID gracza] [cena]");
                    return;
                }

                int playerId = Command.GetNumberFromString(arguments[1]);
                int price = Command.GetNumberFromString(arguments[2]);

                if (playerId == Command.InvalidNumber || price == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne parametry komendy.");
                    return;
                }

                if (price < 0)
                {
                    Ui.ShowWarning(player, "Kwota oferty musi być większa lub równa 0.");
                    return;
                }

                Character target = Account.GetPlayerDataByServerId(playerId);
                if (target == null)
                {
                    Ui.ShowError(player, "Nie znaleziono gracza o podanym ID.");
                    return;
                }

                if (Library.DoesPlayerHasActiveOffer(target.PlayerHandle))
                {
                    Ui.ShowError(player, "Gracz posiada już inną aktywną ofertę.");
                    return;
                }

                if (Global.GetDistanceBetweenPositions(player.Position, target.PlayerHandle.Position) > 3.0 ||
                    player.Dimension != target.PlayerHandle.Dimension)
                {
                    Ui.ShowError(player, "Gracz jest za daleko.");
                    return;
                }

                if (!target.PlayerHandle.IsInVehicle)
                {
                    Ui.ShowError(player, "Gracz nie jest w pojeździe.");
                    return;
                }

                Vehicle vehData = Vehicles.Library.GetVehicleData(target.PlayerHandle.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd nie jest prawidłowy.");
                    return;
                }

                Dictionary<string, object> data = new Dictionary<string, object>
                {
                    {"vehData", vehData}
                };

                Library.CreateOffer(player, target.PlayerHandle, OfferType.Repair, (uint) price, data,
                    "Naprawa pojazdu");
            }
            else if (offerType == "tatuaz")
            {
                if (arguments.Length - 1 < 3)
                {
                    Ui.ShowUsage(player, "/o(feruj) tatuaz [ID gracza] [ID tatuazu] [cena]");
                    return;
                }

                int playerId = Command.GetNumberFromString(arguments[1]);
                int tattooId = Command.GetNumberFromString(arguments[2]);
                int price = Command.GetNumberFromString(arguments[3]);

                if (playerId == Command.InvalidNumber || price == Command.InvalidNumber ||
                    tattooId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne parametry komendy.");
                    return;
                }

                if (price < 0)
                {
                    Ui.ShowWarning(player, "Kwota oferty musi być większa lub równa 0.");
                    return;
                }

                Character target = Account.GetPlayerDataByServerId(playerId);
                if (target == null)
                {
                    Ui.ShowError(player, "Nie znaleziono gracza o podanym ID.");
                    return;
                }

                if (Library.DoesPlayerHasActiveOffer(target.PlayerHandle))
                {
                    Ui.ShowError(player, "Gracz posiada już inną aktywną ofertę.");
                    return;
                }

                if (Global.GetDistanceBetweenPositions(player.Position, target.PlayerHandle.Position) > 3.0 ||
                    player.Dimension != target.PlayerHandle.Dimension)
                {
                    Ui.ShowError(player, "Gracz jest za daleko.");
                    return;
                }

                TattooRow tattooInfo = Tattoos.Library.GetTattooData(tattooId);
                if (tattooInfo == null)
                {
                    Ui.ShowError(player, "Podano niepoprawne Id tatuażu.");
                    return;
                }

                if (tattooInfo.Sex != target.Sex)
                {
                    Ui.ShowError(player,
                        $"Tatuaż nie zgadza się z płcią postaci dla której chcesz go zrobić. ({(int) target.Sex})");
                    return;
                }

                if (target.SyncedTattoos.Contains(tattooId))
                {
                    Ui.ShowError(player, "Gracz posiada już taki tatuaż.");
                    return;
                }

                Dictionary<string, object> data = new Dictionary<string, object>
                {
                    {"tattooId", tattooId}
                };

                Library.CreateOffer(player, target.PlayerHandle, OfferType.TattooCreate, (uint) price, data,
                    $"Nałożenie tatuażu [ID: {tattooId}]");
            }
        }
    }
}