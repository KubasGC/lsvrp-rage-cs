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
using Log = LSVRP.Modules.Log;

namespace LSVRP.Features.Interiors
{
    public static class Library
    {
        private static readonly Dictionary<int, Interior> InteriorsList = new Dictionary<int, Interior>();
        private static readonly Dictionary<int, InteriorDoor> InteriorDoorsList = new Dictionary<int, InteriorDoor>();

        /// <summary>
        /// Zwraca słownik zawierający wszystkie załadowane interiory.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, Interior> GetInteriors()
        {
            return InteriorsList;
        }

        /// <summary>
        /// Laduje interiory z bazy danych do pamięci.
        /// </summary>
        public static void LoadInteriors()
        {
            double startTime = Global.GetTimestampMs();
            using (Database.Database db = new Database.Database())
            {
                List<Interior> interiors = db.Interiors.ToList();
                foreach (Interior entry in interiors) InteriorsList.Add(entry.Id, entry);

                Log.ConsoleLog("INTERIORS",
                    $"Załadowano interiory ({InteriorsList.Count}) | {Global.GetTimestampMs() - startTime}ms");
            }
        }

        /// <summary>
        /// Zwraca pierwsze drzwi należące do grupy o danym Id.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static InteriorDoor GetFirstGroupDoor(int groupId)
        {
            foreach (KeyValuePair<int, Interior> interior in InteriorsList)
            {
                if (interior.Value.OwnerType != OwnerType.Group || interior.Value.Owner != groupId) continue;
                foreach (KeyValuePair<int, InteriorDoor> door in InteriorDoorsList)
                {
                    if (door.Value.ParentId != interior.Value.Id) continue;
                    if (door.Value.OutDim == 0) return door.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Laduje drzwi interiorów z bazy danych do pamięci.
        /// </summary>
        public static void LoadInteriorsDoors()
        {
            double startTime = Global.GetTimestampMs();
            using (Database.Database db = new Database.Database())
            {
                List<InteriorDoor> doors = db.InteriorDoors.ToList();
                foreach (InteriorDoor entry in doors)
                {
                    Interior interiorData = GetInteriorData(entry.ParentId);
                    if (interiorData == null)
                    {
                        db.InteriorDoors.Remove(entry);
                        continue;
                    }

                    entry.MarkerOut = NAPI.Marker.CreateMarker(20, new Vector3(entry.OutX, entry.OutY, entry.OutZ + 1),
                        new Vector3(), new Vector3(), 0.5f, new Color(255, 255, 255, 255), true, (uint) entry.OutDim);
                    entry.MarkerOut.Transparency = 255;

                    if ((int) Math.Floor(entry.InX) != 0)
                    {
                        entry.MarkerIn = NAPI.Marker.CreateMarker(20, new Vector3(entry.InX, entry.InY, entry.InZ + 1),
                            new Vector3(), new Vector3(), 0.5f, new Color(255, 255, 255, 255), true,
                            (uint) entry.InDim);
                        entry.MarkerIn.Transparency = 255;
                    }

                    if (entry.Blip > 0)
                        entry.BlipHandle = NAPI.Blip.CreateBlip(entry.Blip,
                            new Vector3(entry.OutX, entry.OutY, entry.OutZ),
                            1.0f, 3, entry.Name, 255, 999999.0f, true, 0,
                            (uint) entry.OutDim);

                    InteriorDoorsList.Add(entry.Id, entry);
                }

                Log.ConsoleLog("INTERIORS-DOORS",
                    $"Załadowano drzwi interiorów ({InteriorDoorsList.Count}) | " +
                    $"{Global.GetTimestampMs() - startTime}ms");
            }
        }

        /// <summary>
        /// Zwraca dane interioru o podanym Id.
        /// </summary>
        /// <param name="interiorId"></param>
        /// <returns></returns>
        public static Interior GetInteriorData(int interiorId)
        {
            return InteriorsList.ContainsKey(interiorId) ? InteriorsList[interiorId] : null;
        }


        /// <summary>
        /// Zwraca dane interioru znajdującego się w podanym wymiarze.
        /// </summary>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static Interior GetInteriorDataByDim(int dimension)
        {
            foreach (KeyValuePair<int, Interior> entry in InteriorsList)
                if (entry.Value.Dimension == dimension)
                    return entry.Value;

            return null;
        }

        /// <summary>
        /// Pobiera pierwszy wolny vw.
        /// </summary>
        /// <returns></returns>
        public static int GetNearestFreeDimension()
        {
            int freeDimension = 1;
            while (true)
            {
                if (InteriorsList.All(t => t.Value.Dimension != freeDimension)) return freeDimension;
                freeDimension++;
            }
        }

        /// <summary>
        /// Pobiera najbliższe drzwi.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static DoorInfo GetNearestDoor(Character charData, double range = 2.5)
        {
            if (charData == null) return null;

            double nearestRange = range;
            DoorInfo nearestDoors = null;

            foreach (KeyValuePair<int, InteriorDoor> entry in InteriorDoorsList)
                if (charData.PlayerHandle.Dimension == entry.Value.OutDim) // Jeśli gracz jest na vw wyjściowym
                {
                    double distance = Global.GetDistanceBetweenPositions(charData.PlayerHandle.Position,
                        new Vector3(entry.Value.OutX, entry.Value.OutY, entry.Value.OutZ));

                    if (distance < nearestRange)
                    {
                        nearestRange = distance;
                        nearestDoors = new DoorInfo {DoorType = DoorType.Out, DoorData = entry.Value};
                    }
                }
                else if (charData.PlayerHandle.Dimension == entry.Value.InDim) // Jeśli gracz jest na vw wejściowym
                {
                    double distance = Global.GetDistanceBetweenPositions(charData.PlayerHandle.Position,
                        new Vector3(entry.Value.InX, entry.Value.InY, entry.Value.InZ));

                    if (distance < nearestRange)
                    {
                        nearestRange = distance;
                        nearestDoors = new DoorInfo {DoorType = DoorType.In, DoorData = entry.Value};
                    }
                }

            return nearestDoors;
        }

        /// <summary>
        /// Zwraca true jeśli gracz ma uprawnienia do użycia interioru, inaczej false.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="interiorData"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasInteriorPerm(Character charData, Interior interiorData)
        {
            if (charData == null || interiorData == null) return false;

            switch (interiorData.OwnerType)
            {
                case OwnerType.Group:
                    return Groups.Library.DoesPlayerHasPerm(charData, interiorData.Owner, Permissions.RankDoor);
                case OwnerType.Player:
                    return charData.Id == interiorData.Owner;
                case OwnerType.None:
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Pobiera najniższe wolne vw.
        /// </summary>
        /// <returns></returns>
        public static int GetFreeDimension()
        {
            int i = 1;
            while (true)
            {
                if (!InteriorsList.Any(t => t.Value.Dimension == i)) return i;
                i++;
            }
        }

        /// <summary>
        /// Tworzy nowy interior.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ownerType"></param>
        /// <param name="owner"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static Interior CreateInterior(string name, OwnerType ownerType, int owner, int dimension)
        {
            using (Database.Database db = new Database.Database())
            {
                Interior newInterior = new Interior
                {
                    Dimension = dimension,
                    OwnerType = ownerType,
                    Created = Global.GetTimestamp(),
                    ForSale = false,
                    Name = name,
                    Owner = owner,
                    SalePrice = 0
                };

                db.Interiors.Add(newInterior);
                db.SaveChanges();

                InteriorsList.Add(newInterior.Id, newInterior);
                return newInterior;
            }
        }

        /// <summary>
        /// Zwraca listę drzwi przypisanych do danego interioru. Jeśli nie znalazło żadnych drzwi zwraca false
        /// </summary>
        /// <param name="interiorData"></param>
        /// <returns></returns>
        public static IEnumerable<InteriorDoor> GetInteriorDoors(Interior interiorData)
        {
            if (interiorData == null) return null;

            List<InteriorDoor> output = new List<InteriorDoor>();
            foreach (KeyValuePair<int, InteriorDoor> entry in InteriorDoorsList)
            {
                if (entry.Value.ParentId == interiorData.Id) output.Add(entry.Value);
            }

            return output.Count == 0 ? null : output;
        }

        /// <summary>
        /// Pokazuje wybrany interfejs graczowi.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="uiType"></param>
        /// <param name="id"></param>
        public static void ShowUi(Character charData, UiType uiType, int id)
        {
            if (charData == null) return;

            if (uiType == UiType.InteriorInfo)
            {
                Interior interiorData = GetInteriorData(id);
                if (interiorData == null) return;

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("", 45),
                    new DialogColumn("", 45)
                };

                List<DialogRow> dialogRows = new List<DialogRow>
                {
                    new DialogRow(null, new []{"ID", interiorData.Id.ToString()}),
                    new DialogRow("name", new []{"Nazwa", interiorData.Name}),
                    new DialogRow("ownertype", new []{"Typ właściciela", ((int)interiorData.OwnerType).ToString()}),
                    new DialogRow("owner", new []{"Właściciel", Global.GetOwnerName((int)interiorData.OwnerType, interiorData.Owner)}),
                    new DialogRow(null, new []{"Virtual World", interiorData.Dimension.ToString()}),
                    new DialogRow(null, new []{"", ""}),
                    new DialogRow("doors", new []{"Lista drzwi", ""})
                };
                string[] dialogButtons = {"Edytuj", "Zamknij"};

                Managers.Account.SetServerData(charData, Account.ServerData.TempDialogData, interiorData.Id);
                Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.InteriorInfo, "Edycja interioru", dialogColumns, dialogRows, dialogButtons);
            }
            else if (uiType == UiType.InteriorDoorsList)
            {
                Interior interiorData = GetInteriorData(id);
                if (interiorData == null) return;

                IEnumerable<InteriorDoor> interiorDoors = GetInteriorDoors(interiorData);
                if (interiorDoors == null)
                {
                    Ui.ShowWarning(charData.PlayerHandle, "Interior nie ma żadnych drzwi.");
                    return;
                }

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("", 90)
                };

                List<DialogRow> dialogRows = interiorDoors.Select(entry => new DialogRow(null, new[] { $"{entry.Name} (ID: {entry.Id})" })).ToList();
                string[] dialogButtons = {"Zamknij"};

                Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.None, $"{interiorData.Name} - drzwi", dialogColumns, dialogRows, dialogButtons);
            }
        }
    }
}