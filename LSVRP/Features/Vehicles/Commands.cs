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
using LSVRP.Features.Admin;
using LSVRP.Features.Dialogs;
using LSVRP.Libraries;
using LSVRP.Managers;
using Vehicle = LSVRP.Database.Models.Vehicle;

namespace LSVRP.Features.Vehicles
{
    public class Commands : Script
    {
        [Command("v", Alias = "vehicle,pojazd", GreedyArg = true)]
        public void Command_Vehicle(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            const string legend = "/v [l(ista), z(amknij), (za)parkuj, maska, bagaznik]";
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            string option = arguments[0].ToLower();
            if (option == "lista" || option == "l")
            {
                Library.ShowUi(charData, UiType.VehiclesList, 0);
            }
            else if (option == "zamknij" || option == "z")
            {
                Vehicle vehData = Library.GetNearestVehicle(player.Position, player.Dimension);
                if (vehData == null)
                {
                    Ui.ShowWarning(player, "Nie znaleziono żadnego pojazdu obok Ciebie.");
                    return;
                }

                if (!Library.DoesPlayerHasVehiclePerm(charData, vehData.Id))
                {
                    Ui.ShowError(player, "Nie posiadasz kluczy do tego pojazdu.");
                    return;
                }

                if (vehData.Closed)
                {
                    vehData.Closed = false;
                    vehData.VehicleHandle.Locked = false;
                    Chat.Library.SendPlayerMeMessage(charData, $"otwiera drzwi pojazdu \"{vehData.Name}\".", true);
                }
                else
                {
                    vehData.Closed = true;
                    vehData.VehicleHandle.Locked = true;
                    Chat.Library.SendPlayerMeMessage(charData, $"zamyka drzwi pojazdu \"{vehData.Name}\".", true);
                }
            }
            else if (option == "zaparkuj" || option == "parkuj")
            {
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz być w pojeździe.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono tego pojazdu.");
                    return;
                }

                if (!Library.DoesPlayerHasVehicleOwner(charData, vehData.Id))
                {
                    Ui.ShowError(player, "Nie posiadasz odpowiednich uprawnień.");
                    return;
                }

                vehData.X = vehData.VehicleHandle.Position.X;
                vehData.Y = vehData.VehicleHandle.Position.Y;
                vehData.Z = vehData.VehicleHandle.Position.Z;

                vehData.Rx = vehData.VehicleHandle.Rotation.X;
                vehData.Ry = vehData.VehicleHandle.Rotation.Y;
                vehData.Rz = vehData.VehicleHandle.Rotation.Z;

                vehData.Dimension = (int) vehData.VehicleHandle.Dimension;

                vehData.Save();

                Ui.ShowInfo(player, "Pojazd został zaparkowany pomyślnie.");
            }
            else if (option == "maska")
            {
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                if (player.VehicleSeat != -1)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe jako kierowca.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Niewłaściwy pojazd.");
                    return;
                }

                vehData.Hood = !vehData.Hood;
                foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
                    NAPI.ClientEvent.TriggerClientEvent(entry.Value.PlayerHandle, "client.vehicle.sync.hood",
                        vehData.VehicleHandle.Value, vehData.Hood);
            }
            else if (option == "bagaznik")
            {
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                if (player.VehicleSeat != -1)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe jako kierowca.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Niewłaściwy pojazd.");
                    return;
                }

                vehData.Trunk = !vehData.Trunk;
                foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
                    NAPI.ClientEvent.TriggerClientEvent(entry.Value.PlayerHandle, "client.vehicle.sync.trunk",
                        vehData.VehicleHandle.Value, vehData.Trunk);
            }
            else if (option == "opis")
            {
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                if (player.VehicleSeat != -1)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe jako kierowca.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Niewłaściwy pojazd.");
                    return;
                }

                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/v opis [tresc opisu] | Aby usunac opis wpisz /v opis usun");
                    return;
                }

                if (arguments[1].ToLower() == "usun")
                {
                    Library.SyncVehicleForPlayer(null, player.Vehicle.Value, "descdel", 0);
                    Ui.ShowInfo(player, "Opis pojazdu usunięty.");
                    vehData.VehicleDescription = null;
                    return;
                }

                vehData.VehicleDescription = Command.GetConcatString(arguments, 1);
                Library.SyncVehicleForPlayer(null, player.Vehicle.Value, "desc", vehData.VehicleDescription);
                Ui.ShowInfo(player, "Opis pojazdu został ustawiony.");
            }
        }

        [Command("av", GreedyArg = true)]
        public void Command_AdminVehicle(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel == 0) return;
            const string legend =
                "/av [uid, stworz, edytuj, usun, tm, to, spawn, napraw, kolor1, kolor2, pj, przypisz, przeszukaj, " +
                "respawn, parkuj, mods, info, paliwo]";
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            string option = arguments[0].ToLower();
            if (option == "uid")
            {
                Vehicle vehicleFound = Library.GetNearestVehicle(player.Position, player.Dimension);
                if (vehicleFound == null)
                {
                    Ui.ShowError(player, "Nie znaleziono żadnego pojazdu obok Ciebie.");
                    return;
                }

                Player.SendFormattedChatMessage(player,
                    $"Znaleziony pojazd: (UID: {vehicleFound.Id}) {vehicleFound.Name}", Constants.ColorDelRio);
            }
            else if (option == "info")
            {
                if (player.IsInVehicle)
                {
                    Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                    if (vehData == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono takiego pojazdu.");
                        return;
                    }

                    Library.ShowUi(charData, UiType.VehicleInfo, vehData.Id);
                }
                else
                {
                    if (arguments.Length - 1 < 1)
                    {
                        Ui.ShowUsage(player, "/av info [ID pojazdu]");
                        return;
                    }

                    int vehId = Command.GetNumberFromString(arguments[1]);
                    if (vehId == Command.InvalidNumber)
                    {
                        Ui.ShowError(player, "Podano błędne dane.");
                        return;
                    }

                    Vehicle vehData = Library.GetVehicleData(vehId);
                    if (vehData == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono takiego pojazdu.");
                        return;
                    }

                    Library.ShowUi(charData, UiType.VehicleInfo, vehData.Id);
                }
            }
            else if (option == "paliwo")
            {
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd w którym siedzisz jest nieprawidłowym pojazdem.");
                    return;
                }

                vehData.Fuel = vehData.MaxFuel;
                vehData.Save();

                Ui.ShowInfo(player, "Pojazd został napełniony.");
            }
            else if (option == "handling")
            {
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd w którym siedzisz jest nieprawidłowym pojazdem.");
                    return;
                }

                if (arguments.Length - 1 < 2) Ui.ShowUsage(player, "/av handling [typ] [wartość]");

                string type = arguments[1].ToUpper();
                double value = Command.GetDoubleFromString(arguments[2]);

                if (vehData.TestHandling.ContainsKey(type)) vehData.TestHandling.Remove(type);

                vehData.TestHandling.Add(type, value);
                Library.SyncVehicleForPlayer(null, vehData.VehicleHandle.Value);
                Ui.ShowInfo(player, $"Zmieniono wartość \"{type}\" na \"{value}\".");
            }
            else if (option == "mods")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesColor, true)) return;
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd w którym siedzisz jest nieprawidłowym pojazdem.");
                    return;
                }

                using (Database.Database db = new Database.Database())
                {
                    List<VehicleMod> mods = db.VehicleMods.Where(t => t.VehicleId == vehData.Id).ToList();
                    if (mods.Count == 0)
                    {
                        Ui.ShowInfo(player, "Pojazd nie posiada żadnych modyfikacji.");
                        return;
                    }

                    List<DialogColumn> dialogColumns = new List<DialogColumn>
                    {
                        new DialogColumn("ID Modyfikacji", 40),
                        new DialogColumn("Wartość modyfikacji", 40)
                    };

                    List<DialogRow> dialogRows = new List<DialogRow>();
                    foreach (VehicleMod entry in mods)
                        dialogRows.Add(new DialogRow(null, new[] {entry.ModId.ToString(), entry.ModVal.ToString()}));

                    string[] dialogButtons = {"Wybierz", "Zamknij"};

                    Dialogs.Library.CreateDialog(player, DialogId.None, "Zainstalowane modyfikacje", dialogColumns,
                        dialogRows, dialogButtons);
                }
            }
            else if (option == "rmods")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesColor, true)) return;
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd w którym siedzisz jest nieprawidłowym pojazdem.");
                    return;
                }

                for (int i = 0; i < 76; i++) NAPI.Vehicle.SetVehicleMod(vehData.VehicleHandle, i, -1);

                using (Database.Database db = new Database.Database())
                {
                    List<VehicleMod> vehMods = db.VehicleMods.Where(t => t.VehicleId == vehData.Id).ToList();
                    foreach (VehicleMod entry in vehMods)
                        NAPI.Vehicle.SetVehicleMod(vehData.VehicleHandle, (int) entry.ModId, entry.ModVal);
                }
            }
            else if (option == "stworz")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehicleCreate, true)) return;
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/av stworz [nazwa pojazdu]");
                    return;
                }

                uint? vehicleHash = Library.GetVehicleHashByName(arguments[1].ToLower());
                if (vehicleHash == null)
                {
                    Ui.ShowError(player, "Nie znaleziono takiego pojazdu.");
                    return;
                }

                Vector3 posInFrontOf = Global.GetPositionInFrontOf(player.Position, player.Heading, 5.0f);
                Vehicle vehicle = Library.CreateVehicle((long) vehicleHash, posInFrontOf,
                    new Vector3(0, 0, player.Heading + 90), 0, 0, OwnerType.Player, (int) player.Dimension, charData.Id,
                    Command.UpperFirst(arguments[1], false), Player.GetPlayerDebugName(charData));

                Player.SendFormattedChatMessage(player, $"Utworzono pojazd \"{vehicle.Name}\" (UID: {vehicle.Id})",
                    Constants.ColorDarkRed);
            }
            else if (option == "edytuj")
            {
                Vehicle vehData;
                if (player.IsInVehicle)
                {
                    vehData = Library.GetVehicleData(player.Vehicle);
                    if (vehData == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono pojazdu o podanym ID.");
                        return;
                    }

                    Library.ShowUi(charData, UiType.VehicleEditAdmin, vehData.Id);
                    return;
                }

                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehicleCreate, true)) return;
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/av edytuj [id pojazdu]");
                    return;
                }

                int vehId = Command.GetNumberFromString(arguments[1]);
                if (vehId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne UID pojazdu.");
                    return;
                }

                vehData = Library.GetVehicleData(vehId);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono pojazdu o podanym ID.");
                    return;
                }

                Library.ShowUi(charData, UiType.VehicleEditAdmin, vehData.Id);
            }
            else if (option == "usun")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehicleDelete, true)) return;
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/av usun [id pojazdu]");
                    return;
                }

                int vehId = Command.GetNumberFromString(arguments[1]);
                if (vehId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne UID pojazdu");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(vehId);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd o takim UID nie istnieje.");
                    return;
                }

                Player.SendFormattedChatMessage(player,
                    $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został usunięty.", Constants.ColorDarkRed);
                Library.DestroyVehicle(vehData.Id);
            }
            else if (option == "to")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesTeleport, true)) return;
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/av to [id pojazdu]");
                    return;
                }

                int vehId = Command.GetNumberFromString(arguments[1]);
                if (vehId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne UID pojazdu.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(vehId);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono pojazdu o podanym ID.");
                    return;
                }

                if (!vehData.Spawned || vehData.VehicleHandle == null ||
                    !NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                {
                    Ui.ShowError(player, "Pojazd nie jest zespawnowany.");
                    return;
                }

                player.Position = new Vector3(vehData.VehicleHandle.Position.X - 2.5,
                    vehData.VehicleHandle.Position.Y - 2.5, vehData.VehicleHandle.Position.Z);
                player.Dimension = vehData.VehicleHandle.Dimension;

                Player.SendFormattedChatMessage(player,
                    $"Teleportowałeś się do pojazdu \"{vehData.Name}\" (UID: {vehData.Id}).", Constants.ColorDelRio);
            }
            else if (option == "tm")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesTeleport, true)) return;
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/av tm [id pojazdu]");
                    return;
                }

                int vehId = Command.GetNumberFromString(arguments[1]);
                if (vehId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne UID pojazdu.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(vehId);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono pojazdu o podanym ID.");
                    return;
                }

                if (!vehData.Spawned || vehData.VehicleHandle == null ||
                    !NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                {
                    Ui.ShowError(player, "Pojazd nie jest zespawnowany.");
                    return;
                }

                Vector3 newPosition = Global.GetPositionInFrontOf(player.Position, player.Heading, 5.0f);
                vehData.VehicleHandle.Position = newPosition;
                vehData.VehicleHandle.Rotation = new Vector3(0, 0, player.Heading + 90.0f);
                vehData.VehicleHandle.Dimension = player.Dimension;

                Player.SendFormattedChatMessage(player,
                    $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został przeteleportowany do Ciebie.",
                    Constants.ColorDelRio);
            }
            else if (option == "spawn")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesSpawn, true)) return;
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/av spawn [id pojazdu]");
                    return;
                }

                int vehId = Command.GetNumberFromString(arguments[1]);
                if (vehId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne UID pojazdu.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(vehId);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono pojazdu o podanym ID.");
                    return;
                }

                if (!vehData.Spawned || vehData.VehicleHandle == null ||
                    !NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                {
                    Library.SpawnVehicle(vehData.Id);
                    Player.SendFormattedChatMessage(player,
                        $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został zespawnowany.", Constants.ColorDelRio);
                }
                else
                {
                    Library.UnspawnVehicle(vehData.Id);
                    Player.SendFormattedChatMessage(player,
                        $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został odspawnowany.", Constants.ColorDelRio);
                }
            }
            else if (option == "parkuj")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesPark, true)) return;
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd w którym siedzisz jest nieprawidłowym pojazdem.");
                    return;
                }

                Library.ParkVehicle(charData.PlayerHandle, vehData, player.Vehicle.Position, player.Vehicle.Rotation,
                    (int) player.Dimension);
            }
            else if (option == "napraw")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesFix, true)) return;
                if (player.IsInVehicle)
                {
                    Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                    if (vehData == null)
                    {
                        Ui.ShowError(player, "Pojazd w którym siedzisz jest nieprawidłowym pojazdem.");
                        return;
                    }

                    vehData.Health = 1000.0f;
                    vehData.Save();

                    if (vehData.Spawned && vehData.VehicleHandle != null &&
                        NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                        vehData.VehicleHandle.Repair();

                    Player.SendFormattedChatMessage(player,
                        $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został naprawiony.", Constants.ColorDelRio);
                }
                else
                {
                    if (arguments.Length - 1 < 1)
                    {
                        Ui.ShowUsage(player, "/av napraw [id pojazdu]");
                        return;
                    }

                    int vehId = Command.GetNumberFromString(arguments[1]);
                    if (vehId == Command.InvalidNumber)
                    {
                        Ui.ShowError(player, "Podano niepoprawne UID pojazdu.");
                        return;
                    }

                    Vehicle vehData = Library.GetVehicleData(vehId);
                    if (vehData == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono pojazdu o podanym ID.");
                        return;
                    }

                    vehData.Health = 1000.0f;
                    vehData.Save();

                    if (vehData.Spawned && vehData.VehicleHandle != null &&
                        NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                        vehData.VehicleHandle.Repair();

                    Player.SendFormattedChatMessage(player,
                        $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został naprawiony.", Constants.ColorDelRio);
                }
            }
            else if (option == "kolor1")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesColor, true)) return;
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd w którym siedzisz jest nieprawidłowym pojazdem.");
                    return;
                }

                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/av kolor1 [id koloru]");
                    return;
                }

                int colorId = Command.GetNumberFromString(arguments[1]);
                if (colorId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano nieprawidłowy kolor pojazdu.");
                    return;
                }

                vehData.FirstColor = colorId;

                if (vehData.Spawned && vehData.VehicleHandle != null &&
                    NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                    vehData.VehicleHandle.PrimaryColor = vehData.FirstColor;

                Player.SendFormattedChatMessage(player,
                    $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został przemalowany.", Constants.ColorDelRio);
            }
            else if (option == "kolor2")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesColor, true)) return;
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd w którym siedzisz jest nieprawidłowym pojazdem.");
                    return;
                }

                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/av kolor2 [id koloru]");
                    return;
                }

                int colorId = Command.GetNumberFromString(arguments[1]);
                if (colorId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano nieprawidłowy kolor pojazdu.");
                    return;
                }

                vehData.SecondColor = colorId;

                if (vehData.Spawned && vehData.VehicleHandle != null &&
                    NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                    vehData.VehicleHandle.SecondaryColor = vehData.SecondColor;

                Player.SendFormattedChatMessage(player,
                    $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został przemalowany.", Constants.ColorDelRio);
            }
            else if (option == "pj")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesPj, true)) return;
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd w którym siedzisz jest nieprawidłowym pojazdem.");
                    return;
                }

                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/av pj [id paintjobu]");
                    return;
                }

                int liveryId = Command.GetNumberFromString(arguments[1]);
                if (liveryId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano nieprawidłowe id paintjobu.");
                    return;
                }

                vehData.Livery = liveryId;
                vehData.Save();

                if (vehData.Spawned && vehData.VehicleHandle != null &&
                    NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                {
                    vehData.VehicleHandle.Livery = vehData.Livery;
                    Library.SyncVehicleForPlayer(null, vehData.VehicleHandle.Value, "livery", vehData.Livery);
                }

                Player.SendFormattedChatMessage(player,
                    $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został przemalowany.", Constants.ColorDelRio);
            }
            else if (option == "przypisz")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesAssign, true)) return;
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd w którym siedzisz jest nieprawidłowym pojazdem.");
                    return;
                }

                if (arguments.Length - 1 < 2)
                {
                    Ui.ShowUsage(player, "/av przypisz [gracz, grupa] [Id właściciela]");
                    return;
                }

                int ownerId = Command.GetNumberFromString(arguments[2]);
                if (ownerId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne Id właściciela");
                    return;
                }

                string subOption = arguments[1].ToLower();
                if (subOption == "gracz")
                {
                    Character targetData = Account.GetPlayerDataByServerId(ownerId);
                    if (targetData == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono gracza o podanym Id.");
                        return;
                    }

                    vehData.OwnerType = OwnerType.Player;
                    vehData.Owner = targetData.Id;
                    vehData.Save();

                    Player.SendFormattedChatMessage(targetData.PlayerHandle,
                        $"Administrator przypisał Ci pojazd {Library.GetVehicleFormattedName(vehData)}.",
                        Constants.ColorPictonBlue);
                    Player.SendFormattedChatMessage(player,
                        $"Pojazd {Library.GetVehicleFormattedName(vehData)} został przypisany graczowi " +
                        $"{Player.GetPlayerIcName(targetData, true)}.", Constants.ColorDarkRed);
                }
                else if (subOption == "grupa")
                {
                    Group groupData = Groups.Library.GetGroupData(ownerId);
                    if (groupData == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono grupy o podanym Id.");
                        return;
                    }

                    vehData.OwnerType = OwnerType.Group;
                    vehData.Owner = groupData.Id;
                    vehData.Save();

                    Player.SendFormattedChatMessage(player,
                        $"Pojazd {Library.GetVehicleFormattedName(vehData)} został przypisany grupie " +
                        $"{groupData.Name} (UID: {groupData.Id})", Constants.ColorDarkRed);
                }
                else
                {
                    Ui.ShowUsage(player, "/av przypisz [gracz, grupa] [Id właściciela]");
                }
            }
            else if (option == "extra")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.VehiclesPj, true)) return;
                if (!player.IsInVehicle)
                {
                    Ui.ShowError(player, "Musisz siedzieć w pojeździe.");
                    return;
                }

                Vehicle vehData = Library.GetVehicleData(player.Vehicle);
                if (vehData == null)
                {
                    Ui.ShowError(player, "Pojazd w którym siedzisz jest nieprawidłowym pojazdem.");
                    return;
                }

                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/av extra [id extrasu]");
                    return;
                }

                int extrasId = Command.GetNumberFromString(arguments[1]);
                if (extrasId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano nieprawidłowe id extrasu.");
                    return;
                }

                if (vehData.MappedExtras == null) vehData.MappedExtras = new Dictionary<int, bool>();

                if (vehData.MappedExtras.ContainsKey(extrasId))
                {
                    vehData.MappedExtras[extrasId] = !vehData.MappedExtras[extrasId];
                    Ui.ShowInfo(player, $"Zmieniono stan extrasu na {vehData.MappedExtras[extrasId].ToString()}.");
                }
                else
                {
                    vehData.MappedExtras.Add(extrasId, !vehData.VehicleHandle.GetExtra(extrasId));
                    Ui.ShowInfo(player, $"Zmieniono stan extrasu na {vehData.MappedExtras[extrasId].ToString()}.");
                }

                vehData.Save();
                vehData.RebuildExtras();
            }
        }

        [Command("silnik")]
        public void CmdSilnik(Client player)
        {
            if (!player.IsInVehicle) return;
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            Vehicle vehData = Library.GetVehicleData(player.Vehicle);
            if (vehData == null) return;

            if (Bw.Library.DoesPlayerHasBw(charData)) return;
            Library.ToggleVehicleEngine(charData, vehData, !vehData.Engine);
        }

        [Command("tankuj")]
        public void CmdTankuj(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (!player.IsInVehicle)
            {
                Ui.ShowError(player, "Nie jesteś w pojeździe.");
                return;
            }

            Vehicle vehData = Library.GetVehicleData(player.Vehicle);
            if (vehData == null)
            {
                Ui.ShowError(player, "Nie jesteś w pojeździe.");
                return;
            }

            // NAPI.ClientEvent.TriggerClientEvent(player, "client.gassstations.cmd", vehData.MaxFuel - vehData.Fuel);
            player.TriggerEvent("clgascommand", (vehData.MaxFuel - vehData.Fuel).ToString());
        }
    }
}