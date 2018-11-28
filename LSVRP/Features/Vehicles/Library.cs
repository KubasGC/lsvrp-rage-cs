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

using System;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Dialogs;
using LSVRP.Features.Groups;
using LSVRP.Libraries;
using LSVRP.Managers;
using LSVRP.New.Entities.Item;
using LSVRP.New.Managers;
using Newtonsoft.Json;
using Log = LSVRP.Modules.Log;
using LogType = LSVRP.Modules.LogType;
using Vehicle = LSVRP.Database.Models.Vehicle;

namespace LSVRP.Features.Vehicles
{
    public static class Library
    {
        /// <summary>
        /// Słownik zawierający informacje o wszystkich załadowanych pojazdach
        /// </summary>
        private static readonly Dictionary<int, Vehicle> VehiclesList =
            new Dictionary<int, Vehicle>();

        private static readonly Dictionary<long, VehConsumption> VehiclesFuel = new Dictionary<long, VehConsumption>();

        /// <summary>
        /// Zwraca słownik zawierający wszystkie pojazdy załadowane do pamięci.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, Vehicle> GetAllVehicles()
        {
            return VehiclesList;
        }


        /// <summary>
        /// Funkcja uruchamiana wraz ze startem serwera. Ładuje wszystkie pojazdy do pamięci
        /// </summary>
        public static void LoadVehicles()
        {
            double startTime = Global.GetTimestampMs();
            using (Database.Database db = new Database.Database())
            {
                List<Vehicle> vehicles = db.Vehicles.ToList();
                foreach (Vehicle entry in vehicles)
                {
                    entry.Spawned = false;
                    entry.MappedExtras = new Dictionary<int, bool>();
                    try
                    {
                        entry.MappedExtras = JsonConvert.DeserializeObject<Dictionary<int, bool>>(entry.Extras);
                    }
                    catch
                    {
                        entry.MappedExtras = new Dictionary<int, bool>();
                    }

                    VehiclesList.Add(entry.Id, entry);
                    if (entry.OwnerType == OwnerType.Group)
                    {
                        Group groupData = Groups.Library.GetGroupData(entry.Owner);
                        if (groupData == null) // Jeśli grupa nie istnieje
                        {
                            DestroyVehicle(entry.Id);
                        }
                        else
                        {
                            if (groupData.Type != GroupType.Family) SpawnVehicle(entry.Id);
                        }
                    }
                }

                foreach (VehicleFuel entry in db.VehiclesFuel.ToList())
                {
                    VehConsumption entryConsumption = new VehConsumption
                    {
                        VehicleHash = NAPI.Util.GetHashKey(entry.VehicleName),
                        Consumption = entry.Consumption,
                        MaxFuel = entry.MaxFuel
                    };
                    VehiclesFuel.Add(entryConsumption.VehicleHash, entryConsumption);
                }

                Log.ConsoleLog("VEHICLES",
                    $"Załadowano pojazdy ({VehiclesList.Count}) | {Global.GetTimestampMs() - startTime}ms");
            }
        }

        /// <summary>
        /// Zwraca dane pojazdu.
        /// </summary>
        /// <param name="veh"></param>
        /// <returns></returns>
        public static Vehicle GetVehicleData(GTANetworkAPI.Vehicle veh)
        {
            return veh.HasData("vehicle.id") ? GetVehicleData((int) veh.GetData("vehicle.id")) : null;
        }

        /// <summary>
        /// Zwraca dane pojazdu.
        /// </summary>
        /// <param name="vehId"></param>
        /// <returns></returns>
        public static Vehicle GetVehicleData(int vehId)
        {
            return VehiclesList.ContainsKey(vehId) ? VehiclesList[vehId] : null;
        }

        /// <summary>
        /// Zwraca listę pojazdów należących do danego właściciela.
        /// </summary>
        /// <param name="ownerTypeType"></param>
        /// <param name="owner"></param>
        /// <param name="spawnedOnly"></param>
        /// <returns></returns>
        public static List<Vehicle> GetVehiclesList(OwnerType ownerTypeType, int owner,
            bool spawnedOnly = false)
        {
            List<Vehicle> output = new List<Vehicle>();
            foreach (KeyValuePair<int, Vehicle> entry in VehiclesList)
            {
                if (entry.Value.OwnerType != ownerTypeType || entry.Value.Owner != owner) continue;


                if (spawnedOnly)
                {
                    if (entry.Value.Spawned) output.Add(entry.Value);
                }
                else
                {
                    output.Add(entry.Value);
                }
            }

            return output;
        }

        /// <summary>
        /// Spawnuje pojazd.
        /// </summary>
        /// <param name="vehId"></param>
        public static void SpawnVehicle(int vehId)
        {
            Vehicle vehData = GetVehicleData(vehId);
            if (vehData == null) return;
            if (vehData.Spawned) return;
            if (vehData.VehicleHandle != null && NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                NAPI.Entity.DeleteEntity(vehData.VehicleHandle);

            if (vehData.VehicleHash != 0)
            {
                vehData.Spawned = true;
                vehData.VehicleHandle = NAPI.Vehicle.CreateVehicle((uint) vehData.VehicleHash,
                    new Vector3(vehData.X, vehData.Y, vehData.Z), vehData.Rz, vehData.FirstColor, vehData.SecondColor,
                    vehData.NumberPlate, 255, vehData.Closed, vehData.Engine, (uint) vehData.Dimension);
                vehData.VehicleHandle.Rotation = new Vector3(vehData.Rx, vehData.Ry, vehData.Rz);
                vehData.VehicleHandle.Livery = vehData.Livery;
                vehData.VehicleHandle.SetData("vehicle.id", vehData.Id);
                if (vehData.Health < 0) vehData.Health = 100;
                vehData.VehicleHandle.Health = vehData.Health;

                vehData.VehicleHandle.EngineStatus = false;
                vehData.Engine = false;
                vehData.EngineToggle = false;
                vehData.VehicleHandle.Locked = true;
                vehData.Closed = true;
                vehData.TestHandling = new Dictionary<string, double>();

                using (Database.Database db = new Database.Database())
                {
                    List<VehicleMod> vehMods = db.VehicleMods.Where(t => t.VehicleId == vehData.Id).ToList();
                    foreach (VehicleMod entry in vehMods)
                        NAPI.Vehicle.SetVehicleMod(vehData.VehicleHandle, (int) entry.ModId, entry.ModVal);
                }
            }
        }

        /// <summary>
        /// Odspawnowuje pojazd.
        /// </summary>
        /// <param name="vehId"></param>
        public static void UnspawnVehicle(int vehId)
        {
            Vehicle vehData = GetVehicleData(vehId);
            if (vehData == null) return;
            if (!vehData.Spawned) return;

            vehData.Spawned = false;
            vehData.Engine = false;
            if (NAPI.Entity.DoesEntityExist(vehData.VehicleHandle)) NAPI.Entity.DeleteEntity(vehData.VehicleHandle);
        }

        /// <summary>
        /// Zwraca true jeśli gracz posiada uprawnienia ownera pojazdu, inaczej false.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="vehId"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasVehicleOwner(Character charData, int vehId)
        {
            if (charData == null) return false;
            Vehicle vehData = GetVehicleData(vehId);
            if (vehData == null) return false;

            if (charData.AdminLevel > 0 && charData.HasAdminDuty) return true;
            if (vehData.OwnerType == OwnerType.Player)
            {
                if (vehData.Owner == charData.Id) return true;
            }
            else if (vehData.OwnerType == OwnerType.Group)
            {
                // TODO: permy grup
            }

            return false;
        }

        /// <summary>
        /// Zwraca true jeśli gracz posiada uprawnienia ownera pojazdu, inaczej false.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="vehId"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasVehicleOwner(Client player, int vehId)
        {
            return DoesPlayerHasVehicleOwner(Account.GetPlayerData(player), vehId);
        }

        /// <summary>
        /// Zwraca true jeśli gracz posiada uprawnienia do kierowania pojazdem, inaczej false.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="vehId"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasVehiclePerm(Character charData, int vehId)
        {
            if (charData == null) return false;
            Vehicle vehData = GetVehicleData(vehId);
            if (vehData == null) return false;

            if (charData.AdminLevel > 0 && charData.HasAdminDuty) return true;
            if (vehData.OwnerType == OwnerType.Player)
            {
                if (vehData.Owner == charData.Id) return true;
                // TODO: Wypożyczanie
            }
            else if (vehData.OwnerType == OwnerType.Group)
            {
                return Groups.Library.DoesPlayerHasPerm(charData, vehData.Owner, Permissions.RankVehKeys);
            }

            return false;
        }

        /// <summary>
        /// Zwraca domyślne dane nt spalania pojazdu.
        /// </summary>
        /// <param name="vehHash"></param>
        /// <returns></returns>
        public static VehConsumption GetDefaultConsumption(long vehHash)
        {
            return VehiclesFuel.ContainsKey(vehHash)
                ? VehiclesFuel[vehHash]
                : new VehConsumption
                {
                    Consumption = 0.1f,
                    MaxFuel = 45,
                    VehicleHash = vehHash
                };
        }

        /// <summary>
        /// Tworzy nowy pojazd.
        /// </summary>
        /// <param name="vehicleHash"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="colorFirst"></param>
        /// <param name="colorSecond"></param>
        /// <param name="ownerTypeType"></param>
        /// <param name="dimension"></param>
        /// <param name="owner"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public static Vehicle CreateVehicle(long vehicleHash, Vector3 position, Vector3 rotation,
            int colorFirst, int colorSecond, OwnerType ownerTypeType, int dimension, int owner, string name,
            string createdBy = "System")
        {
            VehConsumption vehCon = GetDefaultConsumption(vehicleHash);

            Vehicle veh = new Vehicle
            {
                VehicleHash = vehicleHash,
                Name = name,
                OwnerType = ownerTypeType,
                Owner = owner,
                Dimension = dimension,
                NumberPlate = "BRAK",
                PlateType = 1,
                Spawned = false,
                X = position.X,
                Y = position.Y,
                Z = position.Z,
                Rx = rotation.X,
                Ry = rotation.Y,
                Rz = rotation.Z,
                Closed = true,
                FirstColor = colorFirst,
                SecondColor = colorSecond,
                MaxFuel = vehCon.MaxFuel,
                Fuel = (int) Math.Floor((double) vehCon.MaxFuel / 2),
                Livery = 0,
                Extras = "",
                FuelMultiplier = vehCon.Consumption,
                Health = 1000.0f,
                Blocked = false,
                BlockValue = 0,
                Modifications = "",
                Mileage = 0.0,
                MappedExtras = new Dictionary<int, bool>()
            };

            using (Database.Database db = new Database.Database())
            {
                db.Vehicles.Add(veh);
                db.SaveChanges();
                Log.ConsoleLog("VEHICLE", $"Utworzono pojazd \"{veh.Name}\" (UID: {veh.Id}) [{createdBy}]",
                    LogType.Debug);
                VehiclesList.Add(veh.Id, veh);
                SpawnVehicle(veh.Id);
                return veh;
            }
        }

        /// <summary>
        /// Usuwa istniejący pojazd.
        /// </summary>
        /// <param name="vehId"></param>
        public static void DestroyVehicle(int vehId)
        {
            Vehicle vehData = GetVehicleData(vehId);
            if (vehData == null) return;

            List<ItemEntity> items = ItemsManager.Items
                .Where(t => t.OwnerType == New.Enums.OwnerType.Vehicle && t.Owner == vehData.Id)
                .ToList();

            for (int i = items.Count - 1; i > -1; i--)
            {
                items[1].Delete();
            }

            if (vehData.Spawned && vehData.VehicleHandle != null && NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                NAPI.Entity.DeleteEntity(vehData.VehicleHandle);


            using (Database.Database db = new Database.Database())
            {
                int vehicleId = vehData.Id;
                db.Vehicles.Attach(vehData);
                db.Vehicles.Remove(vehData);
                db.SaveChanges();

                VehiclesList.Remove(vehicleId);
            }
        }

        /// <summary>
        /// Zwraca liczbę zespawnowanych pojazdów przez gracza.
        /// </summary>
        /// <param name="charData"></param>
        /// <returns></returns>
        public static int GetPlayerSpawnedVehiclesCount(Character charData)
        {
            return charData == null ? 0 : GetVehiclesList(OwnerType.Player, charData.Id, true).Count;
        }

        /// <summary>
        /// Zwraca pojazd znajdujący się najbliżej danej pozycji na danym vw i danej odległości.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="dimension"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static Vehicle GetNearestVehicle(Vector3 position, uint dimension, double range = 5.0)
        {
            double nearestRange = range;
            Vehicle nearestVehicle = null;

            foreach (KeyValuePair<int, Vehicle> entry in VehiclesList)
            {
                if (!entry.Value.Spawned || entry.Value.VehicleHandle == null ||
                    !NAPI.Entity.DoesEntityExist(entry.Value.VehicleHandle)) continue;
                if (entry.Value.VehicleHandle.Dimension != dimension) continue;

                double mathDistance = Global.GetDistanceBetweenPositions(position, entry.Value.VehicleHandle.Position);
                if (mathDistance < nearestRange)
                {
                    nearestRange = mathDistance;
                    nearestVehicle = entry.Value;
                }
            }

            return nearestVehicle;
        }

        /// <summary>
        /// Zwraca nazwę typu właściciela pojazdu.
        /// </summary>
        /// <param name="ownerType"></param>
        /// <returns></returns>
        public static string GetVehicleOwnerTypeName(OwnerType ownerType)
        {
            switch (ownerType)
            {
                default: return "Nieznany";
                case OwnerType.None: return "Nieznany";
                case OwnerType.Player: return "Gracz";
                case OwnerType.Group: return "Grupa";
            }
        }

        /// <summary>
        /// Zwraca nazwę właściciela pojazdu.
        /// </summary>
        /// <param name="vehData"></param>
        /// <returns></returns>
        public static string GetVehicleOwnerName(Vehicle vehData)
        {
            string output = "Nieznany";
            if (vehData == null) return output;

            if (vehData.OwnerType == OwnerType.Player)
            {
                using (Database.Database db = new Database.Database())
                {
                    Character charData = db.Characters.FirstOrDefault(t => t.Id == vehData.Owner);
                    if (charData != null) output = $"{charData.Name} {charData.Lastname} (UID: {charData.Id})";
                }
            }
            else if (vehData.OwnerType == OwnerType.Group)
            {
                Group groupData = Groups.Library.GetGroupData(vehData.Owner);
                if (groupData != null) output = $"{groupData.Name} (UID: {groupData.Id})";
            }

            return output;
        }

        /// <summary>
        /// Pokazuje interfejs dla gracza.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="uiType"></param>
        /// <param name="vehId"></param>
        public static void ShowUi(Character charData, UiType uiType, int vehId)
        {
            if (charData == null) return;
            Account.RemoveServerData(charData, Account.ServerData.DialogVehicleAdminEdit);
            if (uiType == UiType.VehicleInfo)
            {
                Vehicle vehData = GetVehicleData(vehId);
                if (vehData == null) return;

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("", 40),
                    new DialogColumn("", 50)
                };

                List<DialogRow> dialogRows = new List<DialogRow>
                {
                    new DialogRow(null, new[] {"UID pojazdu", vehData.Id.ToString()}),
                    new DialogRow(null, new[] {"Nazwa pojazdu", vehData.Name}),
                    new DialogRow(null, new[] {"Pozycja", $"{vehData.X:F1}, {vehData.Y:F1}, {vehData.Z:F1}"}),
                    new DialogRow(null, new[] {"Zamknięty", vehData.Closed ? "Tak" : "Nie"}),
                    new DialogRow(null, new[] {"Kolor pojazdu", $"[{vehData.FirstColor}] [{vehData.SecondColor}]"}),
                    new DialogRow(null, new[] {"Paliwo", $"{vehData.Fuel:F1}/{vehData.MaxFuel:F1}L"}),
                    new DialogRow(null, new[] {"Wytrzymałość", $"{vehData.Health:F1} HP"}),
                    new DialogRow(null, new[] {"Typ właściciela", GetVehicleOwnerTypeName(vehData.OwnerType)}),
                    new DialogRow(null, new[] {"Nazwa właściciela", GetVehicleOwnerName(vehData)})
                };

                string[] dialogButtons = {"Zamknij"};

                Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.None, "Informacje o pojeździe",
                    dialogColumns, dialogRows, dialogButtons);
            }
            else if (uiType == UiType.VehiclesList)
            {
                List<Vehicle> playerVehicles = GetVehiclesList(OwnerType.Player, charData.Id);
                if (playerVehicles.Count == 0)
                {
                    Ui.ShowWarning(charData.PlayerHandle, "Nie posiadasz żadnych pojazdów.");
                    return;
                }

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("UID", 20),
                    new DialogColumn("Nazwa", 50),
                    new DialogColumn("Zespawnowany", 20)
                };

                List<DialogRow> dialogRows = new List<DialogRow>();
                foreach (Vehicle entry in playerVehicles)
                    dialogRows.Add(new DialogRow(entry.Id,
                        new[]
                        {
                            entry.Id.ToString(),
                            entry.Spawned ? $"<span style=\"color: green;\">{entry.Name}</span>" : entry.Name,
                            entry.Spawned ? "Tak" : "Nie"
                        }));

                string[] dialogButtons = {"Opcje", "Zamknij"};

                /*List<DialogData> dialogData = new List<DialogData>();
                foreach (Database.Models.Vehicle entry in playerVehicles)
                {
                    if (entry.Spawned)
                    {
                        dialogData.Add(new DialogData(
                            $"<span style=\"color: green; font-weight: bold;\">{Global.EscapeHtml(entry.Name)} " +
                            $"({entry.Id})</span>", entry.Id));
                    }
                    else
                    {
                        dialogData.Add(new DialogData($"{Global.EscapeHtml(entry.Name)} ({entry.Id})", entry.Id));
                    }
                }*/

                Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.VehicleList, "Lista posiadanych pojazdów",
                    dialogColumns, dialogRows, dialogButtons);

                // Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.VehicleList, "Twoje pojazdy",
                //    "Wybierz opcję", dialogData, DialogType.List);
            }
            else if (uiType == UiType.VehicleOptions)
            {
                Vehicle vehData = GetVehicleData(vehId);
                if (vehData == null) return;

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("", 90)
                };

                List<DialogRow> dialogRows = new List<DialogRow>
                {
                    new DialogRow("info", new[] {"Informacje o pojeździe"}),
                    new DialogRow("spawn", new[] {"(Un)spawn pojazdu"}),
                    new DialogRow("locate", new[] {"Namierz pojazd"}),
                    new DialogRow("rent", new[] {"Wypożycz pojazd"}),
                    new DialogRow("platetype", new[] {"Wygląd tablicy rejestracyjnej"})
                };

                if (charData.HasAdminDuty) dialogRows.Add(new DialogRow("delete", new[] {"Usuń pojazd"}));

                dialogRows.Add(new DialogRow("back", new[] {"Powrót do listy pojazdów"}));

                string[] dialogButtons = {"Wybierz", "Anuluj"};

                Account.SetServerData(charData, Account.ServerData.DialogVehicleId, vehData.Id);
                Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.VehicleOptions,
                    "Opcje zarządzania pojazdem", dialogColumns, dialogRows, dialogButtons);
            }
            else if (uiType == UiType.VehicleEditAdmin)
            {
                Vehicle vehData = GetVehicleData(vehId);
                if (vehData == null) return;

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("", 45),
                    new DialogColumn("", 45)
                };

                List<DialogRow> dialogRows = new List<DialogRow>
                {
                    new DialogRow(null, new[] {"UID", vehData.Id.ToString()}),
                    new DialogRow("editName", new[] {"Nazwa", vehData.Name}),
                    new DialogRow("editColor1", new[] {"Kolor 1", vehData.FirstColor.ToString()}),
                    new DialogRow("editColor2", new[] {"Kolor 2", vehData.SecondColor.ToString()})
                };
                string[] dialogButtons = {"Wybierz", "Anuluj"};
                Account.SetServerData(charData, Account.ServerData.DialogVehicleId, vehData.Id);
                Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.VehicleEditAdmin, "Edycja pojazdu",
                    dialogColumns, dialogRows, dialogButtons);
            }
        }

        /// <summary>
        /// Zmiana stanu silnika (odpalanie, gaszenie).
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="vehData"></param>
        /// <param name="state"></param>
        public static void ToggleVehicleEngine(Character charData, Vehicle vehData, bool state)
        {
            if (charData == null || vehData == null) return;
            if (vehData.EngineToggle) return;
            if (!charData.PlayerHandle.IsInVehicle || charData.PlayerHandle.Vehicle != vehData.VehicleHandle ||
                charData.PlayerHandle.VehicleSeat != -1) return;

            if (!DoesPlayerHasVehiclePerm(charData, vehData.Id))
            {
                Ui.ShowError(charData.PlayerHandle, "Nie posiadasz kluczy do tego pojazdu.");
                return;
            }

            // TODO: Jeśli pojazd jest w naprawie zablokuj odpalanie auta
            if (state)
            {
                if (vehData.Engine) return;
                if (vehData.Health < 100)
                {
                    Ui.ShowError(charData.PlayerHandle, "Pojazd jest zniszczony. Musisz wezwać pomoc drogową.");
                    return;
                }

                if (vehData.Blocked)
                {
                    Ui.ShowError(charData.PlayerHandle,
                        $"Pojazd ma założoną blokadę na koło. Kwota odblokowania: ${vehData.BlockValue}");
                    return;
                }

                if (vehData.Fuel <= 0)
                {
                    Ui.ShowError(charData.PlayerHandle, "W baku nie ma już paliwa.");
                    return;
                }

                Chat.Library.SendPlayerMeMessage(charData, "przekręca kluczyk w stacyjce i próbuje uruchomić silnik",
                    true);
                vehData.EngineToggle = true;
                NAPI.Task.Run(() =>
                {
                    vehData.EngineToggle = false;
                    vehData.Engine = true;
                    vehData.VehicleHandle.EngineStatus = true;
                    foreach (Client entry in NAPI.Pools.GetAllPlayers())
                        NAPI.ClientEvent.TriggerClientEvent(entry, "client.vehicle.engine", vehData.VehicleHandle.Value,
                            true);

                    Chat.Library.SendPlayerDoMessage(charData, "Silnik odpalił.", true);
                }, 2000);
            }
            else
            {
                if (!vehData.Engine) return;

                vehData.Engine = false;
                vehData.VehicleHandle.EngineStatus = false;
                foreach (Client entry in NAPI.Pools.GetAllPlayers())
                    NAPI.ClientEvent.TriggerClientEvent(entry, "client.vehicle.engine", vehData.VehicleHandle.Value,
                        false);
            }
        }

        /// <summary>
        /// Zwraca nazwę pojazdu.
        /// </summary>
        /// <param name="vehData"></param>
        /// <returns></returns>
        public static string GetVehicleFormattedName(Vehicle vehData)
        {
            return vehData == null ? "Nieznany pojazd" : $"\"{vehData.Name}\" (UID: {vehData.Id})";
        }


        /// <summary>
        /// Synchronizuje wszystkie informacje o pojeździe dla gracza (lub wszystkich, jeśli player == null).
        /// </summary>
        /// <param name="player"></param>
        /// <param name="remoteId"></param>
        public static void SyncVehicleForPlayer(Client player, int remoteId)
        {
            // if (player != null)
            // {
            //     Log.ConsoleLog("VEHICLE", $"Sync vehicle {remoteId} for player {player.SocialClubName}", LogType.Debug);
            // }
            // else
            // {
            //     Log.ConsoleLog("VEHICLE", $"Sync vehicle {remoteId} for all playes.", LogType.Debug);
            // }

            GTANetworkAPI.Vehicle remoteVehicle = NAPI.Pools.GetAllVehicles().Find(t => t.Value == remoteId);
            if (remoteVehicle == default(GTANetworkAPI.Vehicle)) return;

            Vehicle vehData = GetVehicleData(remoteVehicle);
            if (vehData == null) return;

            if (player == null)
                foreach (Client entry in NAPI.Pools.GetAllPlayers())
                    NAPI.ClientEvent.TriggerClientEvent(entry, "client.vehicle.sync", vehData.VehicleHandle.Value,
                        !vehData.SirenSound, vehData.LeftIndicator, vehData.RightIndicator, vehData.Hood, vehData.Trunk,
                        vehData.Health, vehData.Livery, vehData.FirstColor, vehData.SecondColor,
                        vehData.VehicleHandle.Siren, JsonConvert.SerializeObject(vehData.MappedExtras),
                        JsonConvert.SerializeObject(vehData.TestHandling), vehData.VehicleDescription);
            else
                NAPI.ClientEvent.TriggerClientEvent(player, "client.vehicle.sync", vehData.VehicleHandle.Value,
                    !vehData.SirenSound, vehData.LeftIndicator, vehData.RightIndicator, vehData.Hood, vehData.Trunk,
                    vehData.Health, vehData.Livery, vehData.FirstColor, vehData.SecondColor,
                    vehData.VehicleHandle.Siren, JsonConvert.SerializeObject(vehData.MappedExtras),
                    JsonConvert.SerializeObject(vehData.TestHandling), vehData.VehicleDescription);
        }

        /// <summary>
        /// Synchronizuje jedną informację o pojeździe dla gracza (lub wszystkich, jeśli player == null).
        /// </summary>
        /// <param name="player"></param>
        /// <param name="remoteId"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SyncVehicleForPlayer(Client player, int remoteId, string name, object value)
        {
            GTANetworkAPI.Vehicle remoteVehicle = NAPI.Pools.GetAllVehicles().Find(t => t.Value == remoteId);
            if (remoteVehicle == default(GTANetworkAPI.Vehicle)) return;

            Vehicle vehData = GetVehicleData(remoteVehicle);
            if (vehData == null) return;

            if (player == null)
                foreach (Client entry in NAPI.Pools.GetAllPlayers())
                    NAPI.ClientEvent.TriggerClientEvent(entry, "client.vehicle.sync.option", remoteId, name, value);
            else
                NAPI.ClientEvent.TriggerClientEvent(player, "client.vehicle.sync.option", remoteId, name, value);
        }

        /// <summary>
        /// Zwraca hash pojazdu po jego nazwie.
        /// </summary>
        /// <param name="vehName"></param>
        /// <returns></returns>
        public static uint? GetVehicleHashByName(string vehName)
        {
            return Data.VehiclesHashes.ContainsKey(vehName.ToLower()) ? (uint?) Data.VehiclesHashes[vehName] : null;
        }

        /// <summary>
        /// Przeładowuje dodatki pojazdu.
        /// </summary>
        /// <param name="vehData"></param>
        public static void ReloadVehicleExtra(Vehicle vehData)
        {
            if (vehData == null) return;
            if (!vehData.Spawned || vehData.VehicleHandle == null ||
                !NAPI.Entity.DoesEntityExist(vehData.VehicleHandle)) return;

            if (vehData.MappedExtras == null) vehData.MappedExtras = new Dictionary<int, bool>();

            foreach (Client entry in NAPI.Pools.GetAllPlayers())
                NAPI.ClientEvent.TriggerClientEvent(entry, "client.vehicle.sync.option", vehData.VehicleHandle.Value,
                    "extra", JsonConvert.SerializeObject(vehData.MappedExtras, Formatting.None));
        }

        /// <summary>
        /// Zwraca true jeśli miejsce parkingowe jest wolne, inaczej false.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static bool DoesParkPlaceFree(Vector3 position, int dimension)
        {
            foreach (KeyValuePair<int, Vehicle> entry in VehiclesList)
                if (entry.Value.Dimension == dimension && Global.GetDistanceBetweenPositions(position,
                        new Vector3(entry.Value.X, entry.Value.Y, entry.Value.Z)) < 3.0)
                    return false;

            return true;
        }

        /// <summary>
        /// Parkuje pojazd na podanych koordynatach.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="vehData"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="dimension"></param>
        public static void ParkVehicle(Client player, Vehicle vehData, Vector3 position,
            Vector3 rotation, int dimension)
        {
            if (vehData == null) return;
            if (!DoesParkPlaceFree(position, dimension))
            {
                if (player != null) Ui.ShowWarning(player, "To miejsce parkingowe jest już zajęte.");
                return;
            }

            vehData.Dimension = dimension;
            vehData.X = position.X;
            vehData.Y = position.Y;
            vehData.Z = position.Z;
            vehData.Rx = rotation.X;
            vehData.Ry = rotation.Y;
            vehData.Rz = rotation.Z;
            vehData.Save();

            if (player != null) Ui.ShowInfo(player, $"Pojazd {GetVehicleFormattedName(vehData)} został zaparkowany.");
        }

        /// <summary>
        /// Generuje unikalną tablicę dla pojazdu.
        /// </summary>
        /// <returns></returns>
        public static string GeneratePlate()
        {
            while (true)
            {
                string output = Global.GenerateRandomString(6);
                using (Database.Database db = new Database.Database())
                {
                    if (!db.Vehicles.Any(t => t.NumberPlate == output)) return output;
                }
            }
        }

        public static Character GetDriver(GTANetworkAPI.Vehicle veh)
        {
            foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
                if (entry.Value.PlayerHandle.IsInVehicle && entry.Value.PlayerHandle.Vehicle == veh)
                    return entry.Value;

            return null;
        }
    }
}