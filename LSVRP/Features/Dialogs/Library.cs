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
using System.Text.RegularExpressions;
using System.Timers;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Admin.Reports;
using LSVRP.Features.Items;
using LSVRP.Features.Jobs.Courier;
using LSVRP.Libraries;
using LSVRP.Managers;
using LSVRP.New.Entities.Item;
using LSVRP.New.Enums;
using LSVRP.New.Factories;
using LSVRP.New.Managers;
using Newtonsoft.Json;
using Group = LSVRP.Database.Models.Group;
using Log = LSVRP.Libraries.Log;
using Vehicle = LSVRP.Database.Models.Vehicle;

namespace LSVRP.Features.Dialogs
{
    public static class Library
    {
        public static void CreateDialog(Client player, DialogId dialogId, string title,
            List<DialogColumn> dialogColumns, List<DialogRow> dialogRows, string[] dialogButtons)
        {
            foreach (DialogRow row in dialogRows)
                for (int i = 0; i < row.Text.Length; i++)
                    row.Text[i] = Command.AddSlashes(row.Text[i]);


            NAPI.ClientEvent.TriggerClientEvent(player, "client.dialog.new.create", (int) dialogId,
                Command.AddSlashes(title), JsonConvert.SerializeObject(dialogColumns),
                JsonConvert.SerializeObject(dialogRows), JsonConvert.SerializeObject(dialogButtons));
        }

        public static void CreateDialog(Client player, DialogId dialogId, string title, string desc, string startVal,
            string[] dialogButtons)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "client.dialog.new.text.create", (int) dialogId, title, desc,
                startVal, JsonConvert.SerializeObject(dialogButtons));
        }

        public static void CreateDialog(Client player, DialogId dialogId, string title, string desc,
            string[] dialogButtons)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "client.dialog.new.info.create", (int) dialogId, title, desc,
                JsonConvert.SerializeObject(dialogButtons));
        }

        /// <summary>
        /// Wykonuje się po wywołaniu akcji w dialogu po stronie klienta
        /// </summary>
        /// <param name="player"></param>
        /// <param name="dialogId"></param>
        /// <param name="dialogType"></param>
        /// <param name="data"></param>
        /// <param name="clickedButton"></param>
        public static void OnModalGotData(Client player, DialogId dialogId, DialogType dialogType, object data,
            DialogButton clickedButton)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData != null)
            {
                if (dialogId == DialogId.None)
                {
                }
                // ReSharper disable once ConvertIfStatementToSwitchStatement
                else if (dialogId == DialogId.AdminReportList)
                {
                    if (clickedButton != DialogButton.Accept) return;

                    Account.SetServerData(charData, Account.ServerData.AdminReportId,
                        Command.GetNumberFromString(data.ToString()));
                    Admin.Reports.Library.ShowUi(charData, UiType.ReportInfo,
                        Command.GetNumberFromString(data.ToString()));
                }
                else if (dialogId == DialogId.AdminReportAction)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    if (!charData.HasAdminDuty) return;
                    object reportId = Account.GetServerData(charData, Account.ServerData.AdminReportId);
                    if (reportId == null) return;
                    ReportClass reportData = Admin.Reports.Library.GetReportData((int) reportId);
                    if (reportData == null) return;
                    if (data.ToString() == "accept")
                    {
                        if (reportData.Admin == null || !NAPI.Entity.DoesEntityExist(reportData.Admin))
                        {
                            reportData.Admin = player;
                            Ui.ShowInfo(player, "Przyjąłeś zgłoszenie.");
                            Global.SendMessageToAdmins(
                                $"!{{18, 170, 162}}[ Administrator {Player.GetPlayerOocName(charData, true)} przyjął" +
                                $" zgłoszenie \"{reportData.Description}\". ]",
                                true, false);
                            if (NAPI.Entity.DoesEntityExist(reportData.Sender))
                                reportData.Sender.SendChatMessage(
                                    $"!{{165, 158, 11}}[ ⚠ Administrator {Player.GetPlayerOocName(charData, true)}" +
                                    " przyjął Twoje zgłoszenie. ]");
                        }
                        else
                        {
                            Ui.ShowWarning(charData.PlayerHandle, "Zgłoszenie zostało już przyjęte przez kogoś innego");
                        }

                        Admin.Reports.Library.ShowUi(charData, UiType.ReportInfo, (int) reportId);
                    }
                    else if (data.ToString() == "close")
                    {
                        Ui.ShowInfo(charData.PlayerHandle, "Zamknąłeś zgłoszenie.");
                        Admin.Reports.Library.DestroyReport(charData, (int) reportId);
                        Admin.Reports.Library.ShowUi(charData, UiType.ReportsList);
                    }
                    else if (data.ToString() == "back")
                    {
                        Admin.Reports.Library.ShowUi(charData, UiType.ReportsList);
                    }
                }
                else if (dialogId == DialogId.PlayerGroupsList)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    Groups.Library.ShowUi(charData, Groups.UiType.GroupMenu,
                        Command.GetNumberFromString(data.ToString()));
                }
                else if (dialogId == DialogId.ItemInfo)
                {
                    if (clickedButton != DialogButton.Accept) return;
                }
                else if (dialogId == DialogId.PlayerGroupsOptions)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    object groupId = Account.GetServerData(charData, Account.ServerData.GroupPanelId);
                    if (groupId == null) return;
                    GroupMember pGroupData = Groups.Library.GetPlayerGroupData(charData, (int) groupId);
                    if (pGroupData == null) return;
                    Group groupData = Groups.Library.GetGroupData((int) groupId);
                    if (groupData == null) return;

                    if (data.ToString() == "info")
                    {
                        List<DialogColumn> dialogColumns = new List<DialogColumn>
                        {
                            new DialogColumn("Opcja", 40),
                            new DialogColumn("Wartość", 55)
                        };

                        List<DialogRow> dialogRows = new List<DialogRow>
                        {
                            new DialogRow(null,
                                new[] {"Nazwa", $"{groupData.Name} (UID: {groupData.Id})"}),
                            new DialogRow(null,
                                new[] {"Tag", groupData.Code}),
                            new DialogRow(null,
                                new[] {"Typ", $"{groupData.Type}"}),
                            new DialogRow(null,
                                new[] {"Dotacja", $"${groupData.Donation}"}),
                            new DialogRow(null,
                                new[] {"Stan konta", $"${groupData.Cash}"})
                        };

                        string[] dialogButtons = {"Zamknij"};

                        CreateDialog(player, DialogId.None, $"{groupData.Name} - Informacje", dialogColumns,
                            dialogRows, dialogButtons);
                    }
                    else if (data.ToString() == "duty")
                    {
                        Groups.Library.TogglePlayerDuty(charData, groupData.Id,
                            Groups.Library.GetPlayerGroupDuty(charData) != groupData.Id);
                        Groups.Library.ShowUi(charData, Groups.UiType.GroupMenu, groupData.Id);
                    }
                    else if (data.ToString() == "players")
                    {
                        List<Character> playersOnline = Groups.Library.GetPlayersInGroup(groupData.Id);
                        List<DialogColumn> dialogColumns = new List<DialogColumn>
                        {
                            new DialogColumn("ID gracza", 10),
                            new DialogColumn("Nick gracza", 40),
                            new DialogColumn("Ranga gracza", 45)
                        };

                        List<DialogRow> dialogRows = new List<DialogRow>();
                        foreach (Character entry in playersOnline)
                        {
                            GroupMember eGroupData = Groups.Library.GetPlayerGroupData(charData, groupData.Id);
                            if (eGroupData == null) continue;

                            dialogRows.Add(new DialogRow(null,
                                new[] {entry.ServerId.ToString(), Player.GetPlayerIcName(entry), eGroupData.RankName}));
                        }

                        string[] dialogButtons = {"Sprawdź uprawnienia", "Anuluj"};

                        CreateDialog(player, DialogId.None, $"{groupData.Name} - Gracze Online", dialogColumns,
                            dialogRows, dialogButtons);
                    }
                    else if (data.ToString() == "vehicles")
                    {
                        // TODO: Pokazywanie pojazdów grupy
                    }
                }
                else if (dialogId == DialogId.CreatePlayerReport)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    Client targetClient = (Client) Account.GetServerData(charData, Account.ServerData.ReportedPlayer);
                    if (targetClient == null || !NAPI.Entity.DoesEntityExist(targetClient))
                    {
                        Ui.ShowError(charData.PlayerHandle, "Gracz nie jest już na serwerze.");
                        Account.RemoveServerData(charData, Account.ServerData.ReportedPlayer);
                        return;
                    }

                    Admin.Reports.Library.CreateNewReport(charData, Account.GetPlayerData(targetClient),
                        data.ToString());
                    Ui.ShowInfo(player, "Zgłoszenie zostało wysłane pomyślnie.");
                }
                else if (dialogId == DialogId.VehicleList)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    int vehId = Command.GetNumberFromString(data.ToString());
                    if (vehId == Command.InvalidNumber)
                    {
                        Ui.ShowError(player, "Wybór był niepoprawny. Spróbuj ponownie.");
                        return;
                    }

                    Vehicles.Library.ShowUi(charData, Vehicles.UiType.VehicleOptions, vehId);
                }
                else if (dialogId == DialogId.VehicleOptions)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    object vehId = Account.GetServerData(charData, Account.ServerData.DialogVehicleId);
                    if (vehId == null)
                    {
                        Ui.ShowError(player, "Wybór był niepoprawny. Spróbuj ponownie.");
                        return;
                    }

                    Vehicle vehData = Vehicles.Library.GetVehicleData((int) vehId);
                    if (vehData == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono takiego pojazdu.");
                        return;
                    }

                    if (data.ToString() == "info")
                    {
                        Vehicles.Library.ShowUi(charData, Vehicles.UiType.VehicleInfo, vehData.Id);
                    }
                    else if (data.ToString() == "spawn")
                    {
                        if (!vehData.Spawned)
                        {
                            if (Vehicles.Library.GetPlayerSpawnedVehiclesCount(charData) > 0)
                            {
                                Ui.ShowWarning(charData.PlayerHandle,
                                    "Możesz mieć zespawnowany tylko jeden pojazd. Donatorzy mogą mieć " +
                                    "zespwanowane do 3 pojazdów na raz.");
                                return;
                            }

                            // TODO: Sprawdzanie zajętej pozycji
                            Vehicles.Library.SpawnVehicle(vehData.Id);
                            Ui.ShowInfo(charData.PlayerHandle,
                                $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został zespawnowany.");
                        }
                        else
                        {
                            if (vehData.VehicleHandle != null && NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                            {
                                if (vehData.VehicleHandle.Occupants.Count > 0)
                                {
                                    Ui.ShowError(charData.PlayerHandle,
                                        "Nie możesz odspawnować auta, gdy znajdują się w nim gracze.");
                                    return;
                                }

                                Vehicles.Library.UnspawnVehicle(vehData.Id);
                                Ui.ShowInfo(charData.PlayerHandle,
                                    $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został odspawnowany.");
                            }
                        }
                    }
                    else if (data.ToString() == "locate")
                    {
                        object target = Account.GetServerData(charData, Account.ServerData.TargetingAtVehicle);
                        if (target == null || (int) target != vehData.Id)
                        {
                            if (!vehData.Spawned || vehData.VehicleHandle == null ||
                                !NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                            {
                                Ui.ShowError(player, "Pojazd nie jest zespawnowany.");
                                return;
                            }

                            Account.SetServerData(charData, Account.ServerData.TargetingAtVehicle, vehData.Id);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client.markers.createMarker", "vehicle.target",
                                vehData.VehicleHandle.Position.X, vehData.VehicleHandle.Position.Y,
                                vehData.VehicleHandle.Position.Z - 1.0f, 20, 196, 255, 100, 6, true, 3);
                            Ui.ShowInfo(player, "Pojazd został zaznaczony na mapie.");
                        }
                        else
                        {
                            Account.RemoveServerData(charData, Account.ServerData.TargetingAtVehicle);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client.markers.destroyMarker",
                                "vehicle.target");
                            Ui.ShowInfo(player, "Namierzanie pojazdu zostało wyłączone.");
                        }
                    }
                    else if (data.ToString() == "rent")
                    {
                        Ui.ShowError(player, "Wypożyczanie nie zostało jeszcze przepisane.");
                        // todo
                    }
                    else if (data.ToString() == "back")
                    {
                        Vehicles.Library.ShowUi(charData, Vehicles.UiType.VehiclesList, 0);
                    }
                    else if (data.ToString() == "delete")
                    {
                        if (!charData.HasAdminDuty) return;

                        Ui.ShowInfo(player, "Pojazd został usunięty.");
                        Vehicles.Library.DestroyVehicle(vehData.Id);
                        Vehicles.Library.ShowUi(charData, Vehicles.UiType.VehiclesList, 0);
                    }
                }
                else if (dialogId == DialogId.VehicleEditAdmin)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    object vehId = Account.GetServerData(charData, Account.ServerData.DialogVehicleId);
                    if (vehId == null)
                    {
                        Ui.ShowError(player, "Wybór był niepoprawny. Spróbuj ponownie.");
                        return;
                    }

                    Vehicle vehData = Vehicles.Library.GetVehicleData((int) vehId);
                    if (vehData == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono takiego pojazdu.");
                        return;
                    }

                    if (data.ToString() == "editName")
                    {
                        Account.SetServerData(charData, Account.ServerData.DialogVehicleAdminEdit, "editName");
                        CreateDialog(player, DialogId.VehicleEditAdminOption, "Zmiana nazwy pojazdu",
                            "Użyj pola poniżej, aby ustawić nową nazwę dla pojazdu.", vehData.Name,
                            new[] {"Zapisz", "Anuluj"});
                    }
                    else if (data.ToString() == "editColor1")
                    {
                        Account.SetServerData(charData, Account.ServerData.DialogVehicleAdminEdit, "editColor1");
                        CreateDialog(player, DialogId.VehicleEditAdminOption, "Zmiana koloru pojazdu",
                            "Użyj pola poniżej, aby ustawić nową wartość pierwszego koloru pojazdu.",
                            vehData.FirstColor.ToString(), new[] {"Zapisz", "Anuluj"});
                    }
                    else if (data.ToString() == "editColor2")
                    {
                        Account.SetServerData(charData, Account.ServerData.DialogVehicleAdminEdit, "editColor2");
                        CreateDialog(player, DialogId.VehicleEditAdminOption, "Zmiana koloru pojazdu",
                            "Użyj pola poniżej, aby ustawić nową wartość drugiego koloru pojazdu.",
                            vehData.SecondColor.ToString(), new[] {"Zapisz", "Anuluj"});
                    }
                }
                else if (dialogId == DialogId.VehicleEditAdminOption)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    object vehId = Account.GetServerData(charData, Account.ServerData.DialogVehicleId);
                    if (vehId == null)
                    {
                        Ui.ShowError(player, "Wybór był niepoprawny. Spróbuj ponownie.");
                        return;
                    }

                    Vehicle vehData = Vehicles.Library.GetVehicleData((int) vehId);
                    if (vehData == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono takiego pojazdu.");
                        return;
                    }


                    object editType = Account.GetServerData(charData, Account.ServerData.DialogVehicleAdminEdit);
                    if (editType == null)
                    {
                        Ui.ShowError(player, "Wybrano niepoprawną opcję.");
                        Vehicles.Library.ShowUi(charData, Vehicles.UiType.VehicleEditAdmin, vehData.Id);
                        return;
                    }

                    int colorId;
                    switch ((string) editType)
                    {
                        case "editName":
                            if (data.ToString().Length < 3)
                            {
                                Ui.ShowError(player, "Nazwa musi mieć przynajmniej 3 znaki.");
                                Vehicles.Library.ShowUi(charData, Vehicles.UiType.VehicleEditAdmin, vehData.Id);
                                return;
                            }

                            vehData.Name = data.ToString();

                            Player.SendFormattedChatMessage(player,
                                $"Zmieniono nazwę pojazdu (UID: {vehData.Id}) na \"{vehData.Name}\".",
                                Constants.ColorDelRio);
                            break;

                        case "editColor1":
                            colorId = Command.GetNumberFromString(data.ToString());
                            if (colorId == Command.InvalidNumber || colorId < 0)
                            {
                                Ui.ShowError(player, "Podano nieprawidłową wartość koloru.");
                                Vehicles.Library.ShowUi(charData, Vehicles.UiType.VehicleEditAdmin, vehData.Id);
                                return;
                            }

                            vehData.FirstColor = colorId;
                            if (vehData.Spawned && vehData.VehicleHandle != null &&
                                NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                                vehData.VehicleHandle.PrimaryColor = vehData.FirstColor;

                            Player.SendFormattedChatMessage(player,
                                $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został przemalowany.",
                                Constants.ColorDelRio);
                            break;

                        case "editColor2":
                            colorId = Command.GetNumberFromString(data.ToString());
                            if (colorId == Command.InvalidNumber || colorId < 0)
                            {
                                Ui.ShowError(player, "Podano nieprawidłową wartość koloru.");
                                Vehicles.Library.ShowUi(charData, Vehicles.UiType.VehicleEditAdmin, vehData.Id);
                                return;
                            }

                            vehData.SecondColor = colorId;
                            if (vehData.Spawned && vehData.VehicleHandle != null &&
                                NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                                vehData.VehicleHandle.SecondaryColor = vehData.SecondColor;

                            Player.SendFormattedChatMessage(player,
                                $"Pojazd \"{vehData.Name}\" (UID: {vehData.Id}) został przemalowany.",
                                Constants.ColorDelRio);
                            break;
                    }

                    vehData.Save();
                    Account.RemoveServerData(charData, Account.ServerData.DialogVehicleAdminEdit);
                    Vehicles.Library.ShowUi(charData, Vehicles.UiType.VehicleEditAdmin, vehData.Id);
                }
                else if (dialogId == DialogId.ClothSetList)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    int setId = Command.GetNumberFromString(data.ToString());
                    if (setId == Command.InvalidNumber)
                    {
                        Ui.ShowError(player, "Nie znaleziono podanego zestawu ubrań.");
                        return;
                    }

                    using (Database.Database db = new Database.Database())
                    {
                        ClothSet clothSetData =
                            db.ClothSets.FirstOrDefault(t => t.CharId == charData.Id && t.Id == setId);
                        if (clothSetData == null)
                        {
                            Ui.ShowError(player, "Nie znaleziono podanego zestawu ubrań.");
                            return;
                        }

                        Account.SetServerData(charData, Account.ServerData.ChoosedClothSet, setId);

                        List<DialogColumn> dialogColumns = new List<DialogColumn>
                        {
                            new DialogColumn("Akcja", 90)
                        };
                        List<DialogRow> dialogRows = new List<DialogRow>
                        {
                            new DialogRow("use", new[] {"Użyj zestawu"}),
                            new DialogRow("edit", new[] {"Zmień nazwę zestawu"}),
                            new DialogRow("delete", new[] {"Usuń zestaw"})
                        };
                        string[] dialogButtons = {"Wybierz", "Anuluj"};

                        CreateDialog(player, DialogId.ClothSetAction, $"Zestaw \"{clothSetData.Name}\"", dialogColumns,
                            dialogRows, dialogButtons);
                    }
                }
                else if (dialogId == DialogId.ClothSetAction)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    object clothSet = Account.GetServerData(charData, Account.ServerData.ChoosedClothSet);
                    if (clothSet == null) return;

                    string option = data.ToString().ToLower();
                    if (option == "use")
                    {
                        int hp = player.Health;
                        charData.ClothSet = (int) clothSet;
                        Player.BuildPlayerSkin(charData);
                        // Chat.Library.SendPlayerMeMessage(charData, "przebiera się.", true);
                        Account.RemoveServerData(charData, Account.ServerData.ChoosedClothSet);
                        player.Health = hp;
                        Sync.Library.SyncPlayerForPlayer(charData.PlayerHandle);
                        charData.Save();
                    }
                    else if (option == "edit")
                    {
                        CreateDialog(player, DialogId.ClothSetEdit, "Zmian nazwy zestawu",
                            "Wprowadź poniżej nową nazwę zestawu.", "", new[] {"Zapisz", "Anuluj"});
                    }
                    else if (option == "delete")
                    {
                        List<DialogColumn> dialogColumns = new List<DialogColumn>
                        {
                            new DialogColumn("Akcja", 90)
                        };
                        List<DialogRow> dialogRows = new List<DialogRow>
                        {
                            new DialogRow("not-clickable", new[] {"Czy na pewno chcesz usunąć wybrany zestaw?"}),
                            new DialogRow("not-clickable", new[] {""}),
                            new DialogRow("delete", new[] {"Usuń zestaw"})
                        };
                        string[] dialogButtons = {"Wybierz", "Anuluj"};

                        CreateDialog(player, DialogId.ClothSetDelete, "Potwierdzenie usunięcia zestawu", dialogColumns,
                            dialogRows, dialogButtons);
                    }
                }
                else if (dialogId == DialogId.ClothSetDelete)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    object clothSet = Account.GetServerData(charData, Account.ServerData.ChoosedClothSet);
                    if (clothSet == null) return;

                    using (Database.Database db = new Database.Database())
                    {
                        ClothSet clothSetObject = db.ClothSets.FirstOrDefault(t => t.Id == (int) clothSet);
                        if (clothSetObject == null)
                        {
                            Ui.ShowError(player, "Nie znaleziono takiego zestawu ubrań w bazie danych.");
                            return;
                        }

                        db.ClothSets.Remove(clothSetObject);
                        db.SaveChanges();
                        Ui.ShowError(player, "Wybrany zestaw ubrań został usunięty.");
                        Account.RemoveServerData(charData, Account.ServerData.ChoosedClothSet);
                    }
                }
                else if (dialogId == DialogId.ClothSetEdit)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    object clothSet = Account.GetServerData(charData, Account.ServerData.ChoosedClothSet);
                    if (clothSet == null) return;

                    string clothSetName = data.ToString();
                    if (clothSetName.Length < 3)
                    {
                        Ui.ShowError(player, "Nazwa zestawu musi zawierać przynajmniej 3 znaki.");
                        CreateDialog(player, DialogId.ClothSetEdit, "Zmian nazwy zestawu",
                            "Wprowadź poniżej nową nazwę zestawu.", "", new[] {"Zapisz", "Anuluj"});
                        return;
                    }

                    using (Database.Database db = new Database.Database())
                    {
                        ClothSet clothSetObject = db.ClothSets.FirstOrDefault(t => t.Id == (int) clothSet);
                        if (clothSetObject == null)
                        {
                            Ui.ShowError(player, "Nie znaleziono takiego zestawu ubrań w bazie danych.");
                            return;
                        }

                        clothSetObject.Name = clothSetName;

                        db.ClothSets.Update(clothSetObject);
                        db.SaveChanges();
                    }
                }
                else if (dialogId == DialogId.GroupOrdersList)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    object groupId = Account.GetServerData(charData, Account.ServerData.DialogGroupId);
                    if (groupId == null) return;

                    Group groupData = Groups.Library.GetGroupData((int) groupId);
                    if (groupData == null) return;

                    int orderId = Command.GetNumberFromString(data.ToString());
                    if (orderId == Command.InvalidNumber) return;

                    Order orderData = Groups.Library.GetOrderData(groupData.Id, orderId);
                    if (orderData == null) return;

                    Account.SetServerData(charData, Account.ServerData.DialogGroupOrderId, orderData.Id);

                    CreateDialog(player, DialogId.GroupOrdersEnterQuantity, "Kreator zamówienia grupy",
                        $"Poniżej wprowadź ilość sztuk przedmiotu \"{orderData.Name}\", którego chcesz zamówić.", "",
                        new[] {"Zamów", "Anuluj"});
                }
                else if (dialogId == DialogId.GroupOrdersEnterQuantity)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    if (dialogType != DialogType.EnterText) return;

                    object groupId = Account.GetServerData(charData, Account.ServerData.DialogGroupId);
                    if (groupId == null) return;

                    Group groupData = Groups.Library.GetGroupData((int) groupId);
                    if (groupData == null) return;

                    object orderId = Account.GetServerData(charData, Account.ServerData.DialogGroupOrderId);
                    if (orderId == null) return;

                    Order orderData = Groups.Library.GetOrderData(groupData.Id, (int) orderId);
                    if (orderData == null) return;

                    int orderQuantity = Command.GetNumberFromString(data.ToString());
                    if (orderQuantity == Command.InvalidNumber || orderQuantity < 1 || orderQuantity > 100)
                    {
                        Ui.ShowWarning(player,
                            "Możesz zamówić minimalnie jeden a maksymalnie 100 przedmiotów w jednej paczce.");
                        CreateDialog(player, DialogId.GroupOrdersEnterQuantity, "Kreator zamówienia grupy",
                            $"Poniżej wprowadź ilość sztuk przedmiotu \"{orderData.Name}\", którego chcesz zamówić.",
                            "",
                            new[] {"Zamów", "Anuluj"});
                        return;
                    }

                    Account.SetServerData(charData, Account.ServerData.DialogGroupOrderQuantity, orderQuantity);
                    int sumPrice = orderData.Price * orderQuantity;

                    List<DialogData> dialogData = new List<DialogData>
                    {
                        new DialogData("<strong>PODSUMOWANIE</strong>", "not-clickable"),
                        new DialogData($"{orderData.Name}", "not-clickable"),
                        new DialogData($"Ilość sztuk: {orderQuantity:0,0}", "not-clickable"),
                        new DialogData($"Cena za sztukę: ${orderData.Price:0,0}", "not-clickable"),
                        new DialogData($"Całkowity koszt: ${sumPrice:0,0}", "not-clickable"),
                        new DialogData($"Stan konta grupy: {groupData.Cash:0,0}", "not-clickable"),
                        new DialogData("<span style=\"color: green;\">Potwierdź zakup</span>", "accept"),
                        new DialogData("<span style=\"color: red;\">Odrzuć zakup</span>", "decline")
                    };

                    List<DialogColumn> dialogColumns = new List<DialogColumn>
                    {
                        new DialogColumn("", 45),
                        new DialogColumn("", 45)
                    };

                    List<DialogRow> dialogRows = new List<DialogRow>
                    {
                        new DialogRow(null, new[] {"Nazwa zamówienia", orderData.Name}),
                        new DialogRow(null, new[] {"Ilość sztuk", $"{orderQuantity:0,0}"}),
                        new DialogRow(null, new[] {"Cena za sztukę", $"${orderData.Price:0,0}"}),
                        new DialogRow(null, new[] {"Całkowity koszt", $"${sumPrice:0,0}"}),
                        new DialogRow(null, new[] {"Stan konta grupy", $"${groupData.Cash:0,0}"}),
                        new DialogRow(null, new[] {"", ""}),
                        new DialogRow("accept", new[] {"Potwierdź zakup", ""}),
                        new DialogRow("decline", new[] {"Odrzuć zakup", ""})
                    };
                    string[] dialogButtons = {"Wybierz", "Anuluj"};

                    CreateDialog(player, DialogId.GroupOrdersSummary, "Potwierdzenie zakupu", dialogColumns, dialogRows,
                        dialogButtons);
                }
                else if (dialogId == DialogId.GroupOrdersSummary)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    object groupId = Account.GetServerData(charData, Account.ServerData.DialogGroupId);
                    if (groupId == null) return;

                    Group groupData = Groups.Library.GetGroupData((int) groupId);
                    if (groupData == null) return;

                    object orderId = Account.GetServerData(charData, Account.ServerData.DialogGroupOrderId);
                    if (orderId == null) return;

                    Order orderData = Groups.Library.GetOrderData(groupData.Id, (int) orderId);
                    if (orderData == null) return;

                    object orderQuantity = Account.GetServerData(charData, Account.ServerData.DialogGroupOrderQuantity);
                    if (orderQuantity == null) return;

                    int sumPrice = orderData.Price * (int) orderQuantity;

                    if (data.ToString() == "accept")
                    {
                        if (groupData.Cash < sumPrice)
                        {
                            Ui.ShowError(player, "Grupa nie posiada tyle pieniędzy na koncie.");
                            return;
                        }

                        groupData.Cash -= sumPrice;
                        // TODO logi konta grupowego
                        groupData.Save();

                        OrderPending newOrderPending = new OrderPending
                        {
                            GroupId = groupData.Id,
                            OrderId = orderData.Id,
                            Name = $"Paczka {groupData.Name} | {Global.GetTimeFromTimestamp(Global.GetTimestamp())}",
                            Count = (int) orderQuantity,
                            CreatedAt = Global.GetTimestamp()
                        };

                        using (Database.Database db = new Database.Database())
                        {
                            db.OrdersPendings.Add(newOrderPending);
                            db.SaveChanges();

                            Ui.ShowInfo(player, "Zamówiono paczkę.");
                            Groups.Library.SendGroupOocMessage(groupData.Id,
                                $"Grupa złożyła zamówienie na kwotę ${sumPrice:0,0}.");
                        }
                    }

                    Account.RemoveServerData(charData, Account.ServerData.DialogGroupId);
                    Account.RemoveServerData(charData, Account.ServerData.DialogGroupOrderId);
                    Account.RemoveServerData(charData, Account.ServerData.DialogGroupOrderQuantity);
                }
                else if (dialogId == DialogId.PlayerWalkingStyleChoose)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    int styleId = Command.GetNumberFromString(data.ToString());
                    if (styleId == Command.InvalidNumber) return;

                    using (Database.Database db = new Database.Database())
                    {
                        WalkingStyle walkingStyle = db.WalkingStyles.FirstOrDefault(t => t.Id == styleId);
                        if (walkingStyle == null) return;

                        charData.WalkingStyle = walkingStyle.Id;
                        charData.WalkingStyleAnim = walkingStyle.AnimName;
                        if (charData.WalkingStyleAnim.Length < 2) charData.WalkingStyleAnim = null;
                        charData.Save();
                        Sync.Library.SyncPlayerForPlayer(charData.PlayerHandle);
                        Ui.ShowInfo(charData.PlayerHandle, "Pomyślnie zmieniono styl chodzenia.");
                    }
                }
                else if (dialogId == DialogId.ShopListItem)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    int productId = Command.GetNumberFromString(data.ToString());
                    if (productId == Command.InvalidNumber)
                    {
                        Ui.ShowError(player, "Podano niepoprawne ID produktu");
                        return;
                    }

                    ShopProduct productData = Shops.Library.GetProductData(productId);
                    if (productData == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono takiego produktu.");
                        return;
                    }

                    if (charData.Cash < productData.Price)
                    {
                        Ui.ShowError(player, "Nie posiadasz wystarczającej ilości gotówki przy sobie.");
                        return;
                    }

                    if (Money.Library.TakePlayerWalletCash(charData, productData.Price,
                        $"Zapłata za przedmiot {productData.Name} w sklepie {productData.ShopId}."))
                    {
                        int v1 = productData.Value1;
                        int v2 = productData.Value2;
                        string v3 = productData.Value3;

                        if (v3.Contains("phone-generate"))
                        {
                            v3 = "";
                            v1 = Global.GetPhoneNumber();
                        }

                        ItemFactory itemFactory = new ItemFactory();

                        itemFactory.CreateWithSave(new Item
                        {
                            Name = productData.Name,
                            OwnerType = OwnerType.Player,
                            Owner = charData.Id,
                            Type = productData.Type,
                            Value1 = v1,
                            Value2 = v2,
                            Value3 = v3,
                            Used = false
                        });

                        // Items.Library.CreateItem(productData.Name, OwnerType.Player, charData.Id, productData.Type, v1,
                        //    v2, v3);

                        Ui.ShowInfo(player, "Przedmiot został zakupiony pomyślnie.");
                        Chat.Library.SendPlayerMeMessage(charData, $"kupił przedmiot \"{productData.Name}\".", true);
                    }
                }
                else if (dialogId == DialogId.CourierAcceptPackage)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    int orderId = Command.GetNumberFromString(data.ToString());
                    if (orderId == Command.InvalidNumber) return;

                    CourierOrder courierData = Jobs.Courier.Library.GetCourierData(player);
                    if (courierData == null) return;
                    if (courierData.State != CourierState.Start) return;

                    OrderPending orderData = Jobs.Courier.Library.GetPendingOrder(orderId);
                    if (orderData == null)
                    {
                        Ui.ShowError(player, "Zamówienie nie istnieje.");
                        return;
                    }

                    if (Jobs.Courier.Library.DoesOrderDelivered(orderData.Id))
                    {
                        Ui.ShowError(player, "Zamówienie jest dostarczane przez innego kuriera.");
                        return;
                    }

                    InteriorDoor firstDoor = Interiors.Library.GetFirstGroupDoor(orderData.GroupId);
                    if (firstDoor == null)
                    {
                        Ui.ShowError(player,
                            "Grupa nie posiada żadnych drzwi dostępnych na vw 0 do których można dostarczyć przesyłkę.");
                        return;
                    }

                    courierData.State = CourierState.Deliver;
                    courierData.OrderId = orderData.Id;
                    NAPI.ClientEvent.TriggerClientEvent(player, "client.markers.destroyMarker", "courier.blip");
                    NAPI.ClientEvent.TriggerClientEvent(player, "client.markers.createMarker", "courier.group",
                        firstDoor.OutX, firstDoor.OutY, firstDoor.OutZ, 160, 9, 242, 140, 5, true, 3);

                    Ui.ShowInfo(player, "Na mapie zaznaczono punkt, do którego musisz dowieźć paczkę.");
                }
                else if (dialogId == DialogId.ItemReloadWeapon)
                {
                    /*if (clickedButton != DialogButton.Accept) return;
                    Item itemData = Items.Library.GetItemData((int)data);
                    if (itemData == null) return;

                    object ammoId = Account.GetServerData(charData, Account.ServerData.ItemReloadWeaponAmmoItem);
                    if (ammoId == null) return;

                    Item ammoData = Items.Library.GetItemData((int)ammoId);
                    if (ammoData == null) return;

                    if (ammoData.OwnerType != OwnerType.Player || ammoData.Owner != charData.Id ||
                        itemData.OwnerType != OwnerType.Player || itemData.Owner != charData.Id) return;

                    if (itemData.Used)
                    {
                        Ui.ShowError(player, "Broń nie może być używana.");
                        return;
                    }

                    itemData.Value2 += ammoData.Value2;

                    Chat.Library.SendPlayerMeMessage(charData, $"przeładowuje magazynek w broni \"{itemData.Name}\".",
                        true);
                    Items.Library.DestroyItem(ammoData.Id);*/
                    Account.RemoveServerData(charData, Account.ServerData.ItemReloadWeaponAmmoItem);
                    throw new NotImplementedException();
                }
                else if (dialogId == DialogId.CornerDrugPrice)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    int.TryParse((string) data, out int price);
                    int maxPrice = (int) Account.GetServerData(charData, Account.ServerData.CornerMaxPrice);
                    int cornerId = (int) Account.GetServerData(charData, Account.ServerData.CornerId);
                    Item selectedDrug = (Item) Account.GetServerData(charData, Account.ServerData.CornerItem);
                    int count = (int) Account.GetServerData(charData, Account.ServerData.CornerItemCount);
                    if (price < 1 || maxPrice < 1 || count < 1 || selectedDrug == null || selectedDrug.Value2 < count)
                    {
                        Ui.ShowError(player, "Wystapił błąd podczas przetwarzania informacji. Handel zakończony");
                        Corners.Library.StopCornerSell(charData);
                        return;
                    }

                    var corner = Corners.Library.GetPlayerCorner(player);
                    if (corner == null)
                    {
                        Ui.ShowError(player, "Nie nzjajdujesz się na cornerze. Handel zakończony");
                        Corners.Library.StopCornerSell(charData);
                        return;
                    }

                    if (selectedDrug.Owner != charData.Id)
                    {
                        Ui.ShowError(player, "Nie posiadasz tego przedmiotu");
                        Corners.Library.StopCornerSell(charData);
                        return;
                    }

                    if (price > maxPrice)
                    {
                        Ui.ShowError(player, "Cena była zbyt wysoka. Klient zrezygnował z zakupu");
                        Chat.Library.SendPlayerDoMessage(player,
                            $"Nieco zdenerwowany klient odchodzi od {Player.GetPlayerIcName(charData, false)}", true);
                    }
                    else
                    {
                        Log.LogPlayer(charData,
                            $"Sold {count} drug {selectedDrug.Name}[{selectedDrug.Id}] on corner {corner.Id} for ${price}");

                        selectedDrug.Value2 -= count;
                        if (selectedDrug.Value2 <= 0)
                        {
                        }
                        // Items.Library.DestroyItem(selectedDrug.Id);
                        // TODO ItemsManager.Delete(selectedDrug.Id, selectedDrug);
                        else
                        {
                            selectedDrug.Save();
                        }

                        Money.Library.GivePlayerWalletCash(player, price, "Sprzedaż narkotyków");
                        player.SendChatMessage($"Otrzymujesz ${price} ze sprzedaży narkotyków.");
                        Ui.ShowInfo(player, "Sprzedaż zakończona sukcesem. Oczekuj na następnych klientów.");
                        Chat.Library.SendPlayerMeMessage(player,
                            "wymienia się czymś z klientem, ten po chwili odchodzi.", true);
                    }

                    corner.DrugsSold += 1;
                    player.TriggerEvent("client.corners.togglecornerUI");
                    int time = Corners.Library.GetNextCornerSellTime(corner);
                    if (time > 0)
                    {
                        Timer timer = new Timer(time) {AutoReset = false};
                        timer.Elapsed += (sender, e) => Corners.Library.SellDrugs(player.Handle.Value, corner.Id);
                        timer.Start();
                    }
                }
                else if (dialogId == DialogId.SelectSpawn)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    string option = data.ToString();
                    Regex regexGroup = new Regex(@"^g-([0-9]+)$");
                    if (option == "centrum")
                    {
                        charData.SpawnType = 0;
                    }
                    else if (regexGroup.IsMatch(option))
                    {
                        int group = Command.GetNumberFromString(regexGroup.Match(option).Groups[1].Value);
                        charData.SpawnType = 1;
                        charData.SpawnInfo = group;
                    }

                    //todo spawn hotel i dom
                    Ui.ShowInfo(player, "Miejsce spawnu zostało zmienione");
                    charData.Save();
                }
                else if (dialogId == DialogId.BwEnterDescription)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    string description = data.ToString();
                    if (description.Length < 10 || description.Length > 255)
                    {
                        Ui.ShowError(player,
                            "Opis śmierci musi zawierać co najmniej 10 znaków i maksymalnie 255 znaków.");
                        return;
                    }
                    // TODO

                    /*Item bodyItem = Items.Library.CreateItem("Zwłoki", OwnerType.Ground, 0, ItemType.Body, charData.Id,
                        1, "1");
                    Items.Library.MakeItemOnGround(bodyItem.Id, player.Position, new Vector3(0, 0, 0),
                        player.Dimension);

                    Body bodyRow = new Body
                    {
                        CharId = charData.Id,
                        DeathReason = 0,
                        Description = description,
                        Dna = charData.Dna,
                        ItemId = bodyItem.Id,
                        KillerDna = "BRAK",
                        Timestamp = Global.GetTimestamp()
                    };

                    using (Database.Database db = new Database.Database())
                    {
                        db.Bodies.Add(bodyRow);
                        db.SaveChanges();
                    }*/

                    Ui.ShowInfo(player, "Postać została uśmiercona.");
                    charData.Blocked = true;
                    charData.Save();
                    player.Kick("Character Kill");
                }
                else if (dialogId == DialogId.PenaltyKickText)
                {
                    if (clickedButton != DialogButton.Accept) return;

                    string penaltyReason = data.ToString();
                    if (penaltyReason.Length < 5)
                    {
                        Ui.ShowError(player, "Powód musi zawierać przynajmniej 5 znaków.");
                        return;
                    }

                    Account.SetServerData(charData, Account.ServerData.PenaltyReason, penaltyReason);

                    CreateDialog(player, DialogId.PenaltyKickConfirm, "Potwierdzenie kary",
                        "Czy na pewno chcesz wyrzucić tego gracza?", new[] {"Tak", "Nie"});
                }
                else if (dialogId == DialogId.PenaltyKickConfirm)
                {
                    if (clickedButton == DialogButton.Accept)
                    {
                        Character targetData =
                            Account.GetPlayerDataByServerId((int) Account.GetServerData(charData,
                                Account.ServerData.PenaltyPlayerId));

                        if (targetData == null)
                        {
                            Ui.ShowError(player, "Gracz nie jest na serwerze.");
                            return;
                        }

                        Penalties.Library.KickPlayer(targetData, charData,
                            (string) Account.GetServerData(charData, Account.ServerData.PenaltyReason));
                        Ui.ShowInfo(player, "Wyrzuciłeś gracza z serwera.");
                    }
                    else
                    {
                        Ui.ShowInfo(player, "Gracz nie został wyrzucony.");
                    }
                }
                else if (dialogId == DialogId.PenaltyWarnText)
                {
                    if (clickedButton != DialogButton.Accept) return;

                    string penaltyReason = data.ToString();
                    if (penaltyReason.Length < 5)
                    {
                        Ui.ShowError(player, "Powód musi zawierać przynajmniej 5 znaków.");
                        return;
                    }

                    Account.SetServerData(charData, Account.ServerData.PenaltyReason, penaltyReason);

                    CreateDialog(player, DialogId.PenaltyWarnConfirm, "Potwierdzenie kary",
                        "Czy na pewno chcesz dać ostrzeżenie temu graczowi?", new[] {"Tak", "Nie"});
                }
                else if (dialogId == DialogId.PenaltyWarnConfirm)
                {
                    if (clickedButton == DialogButton.Accept)
                    {
                        Character targetData =
                            Account.GetPlayerDataByServerId((int) Account.GetServerData(charData,
                                Account.ServerData.PenaltyPlayerId));

                        if (targetData == null)
                        {
                            Ui.ShowError(player, "Gracz nie jest na serwerze.");
                            return;
                        }

                        Penalties.Library.WarnPlayer(targetData, charData,
                            (string) Account.GetServerData(charData, Account.ServerData.PenaltyReason));
                        Ui.ShowInfo(player, "Dałeś ostrzeżenie graczowi.");
                    }
                    else
                    {
                        Ui.ShowInfo(player, "Gracz nie dostał ostrzeżenia.");
                    }
                }
                else if (dialogId == DialogId.AdminGroupRemove)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    int groupId = Command.GetNumberFromString(data.ToString());
                    if (groupId == Command.InvalidNumber) return;

                    Group groupData = Groups.Library.GetGroupData(groupId);
                    if (groupData == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono grupy o podanym Id.");
                        return;
                    }

                    var tempClass = new
                    {
                        GroupId = groupData.Id
                    };
                    Account.SetServerData(charData, Account.ServerData.DialogGroupAdminData, tempClass);
                    CreateDialog(player, DialogId.AdminGroupRemoveConfirm, "Potwierdzenie usunięcia",
                        $"Czy na pewno chcesz usunąć grupę {groupData.Name}?", new[] {"Tak", "Nie"});
                }
                else if (dialogId == DialogId.AdminGroupRemoveConfirm)
                {
                    if (clickedButton != DialogButton.Accept) return;
                    dynamic tempClass = Account.GetServerData(charData, Account.ServerData.DialogGroupAdminData);
                    if (tempClass == null) return;

                    Group groupData = Groups.Library.GetGroupData((int) tempClass.GroupId);
                    Account.RemoveServerData(charData, Account.ServerData.DialogGroupAdminData);

                    if (groupData == null) return;

                    Ui.ShowInfo(player, "TODO");
                    // TODO Groups.Library.DestroyGroup()
                }
                else if (dialogId == DialogId.ItemPickDialog)
                {
                    if (clickedButton != DialogButton.Accept) return;

                    int itemId = Command.GetNumberFromString(data.ToString());
                    if (itemId == Command.InvalidNumber) return;

                    ItemEntity itemEntity =
                        ItemsManager.Items.FirstOrDefault(t => t.Id == itemId);
                    if (itemEntity.Equals(null)) return;

                    itemEntity.PickItem(charData);

                    // Items.Library.PickItem(player, itemId, true);
                }
                else if (dialogId == DialogId.ChooseAdminLevel)
                {
                    Dictionary<string, object> tempData =
                        (Dictionary<string, object>) Account.GetServerData(charData, Account.ServerData.TempDialogData);

                    Character targetData = (Character) tempData["targetData"];
                    if (targetData == null) return;

                    int oldAdminLevel = targetData.AdminLevel;
                    targetData.AdminLevel = Command.GetNumberFromString(data.ToString());
                    using (Database.Database db = new Database.Database())
                    {
                        ForumMember member =
                            db.ForumMembers.FirstOrDefault(t => t.MemberId == targetData.MemberId);
                        if (member != null)
                        {
                            member.AdminLevel = targetData.AdminLevel;
                            db.ForumMembers.Update(member);

                            db.SaveChanges();

                            Ui.ShowInfo(player,
                                "Ustawiłeś poziom administratora użytkownikowi " +
                                $"{Player.GetPlayerOocName(targetData, true)} na {targetData.AdminLevel}.");
                            Ui.ShowInfo(targetData.PlayerHandle,
                                $"Administrator {Player.GetPlayerOocName(charData, true)} ustawił Ci poziom " +
                                $"administratora na {targetData.AdminLevel}.");

                            Log.LogPlayer(targetData,
                                $"stary poziom: {oldAdminLevel}, nowy poziom: {targetData.AdminLevel}",
                                LogType.ChangeAdminLevel);
                        }
                    }

                    Account.RemoveServerData(charData, Account.ServerData.TempDialogData);
                }
                else if (dialogId == DialogId.MugshotTitle && clickedButton == DialogButton.Accept)
                {
                    Sync.Library.SetPlayerSyncedData(player, "MugshotTitle", data);
                    CreateDialog(player, DialogId.MugshotTop, "Góra tabliczki", "Góra", "",
                        new[] {"Następny", "Zamknij"});
                }
                else if (dialogId == DialogId.MugshotTop && clickedButton == DialogButton.Accept)
                {
                    Sync.Library.SetPlayerSyncedData(player, "MugshotTop", data);
                    CreateDialog(player, DialogId.MugshotMiddle, "Środek tabliczki", "Środek", "",
                        new[] {"Następny", "Zamknij"});
                }
                else if (dialogId == DialogId.MugshotMiddle && clickedButton == DialogButton.Accept)
                {
                    Sync.Library.SetPlayerSyncedData(player, "MugshotMiddle", data);
                    CreateDialog(player, DialogId.MugshotBottom, "Dół tabliczki", "Dół", "",
                        new[] {"Gotowe", "Zamknij"});
                }
                else if (dialogId == DialogId.MugshotBottom && clickedButton == DialogButton.Accept)
                {
                    Sync.Library.SetPlayerSyncedData(player, "MugshotBottom", data);
                    Sync.Library.SyncPlayerForPlayer(player);
                }
                else if (dialogId == DialogId.InteriorsList)
                {
                    if (clickedButton == DialogButton.Accept)
                    {
                        int intId = Command.GetNumberFromString(data.ToString());
                        Interiors.Library.ShowUi(charData, Interiors.UiType.InteriorInfo, intId);
                    }
                }
                else if (dialogId == DialogId.InteriorInfo)
                {
                    int intId = (int) Account.GetServerData(charData, Account.ServerData.TempDialogData);
                    if (data.ToString() == "doors")
                    {
                        Interiors.Library.ShowUi(charData, Interiors.UiType.InteriorDoorsList, intId);
                    }
                    else
                    {
                        Account.SetServerData(charData, Account.ServerData.TempDialogData,
                            new Dictionary<string, object>
                            {
                                {"intId", intId},
                                {"edit", data.ToString()}
                            });

                        CreateDialog(player, DialogId.InteriorEdit, "Edycja wartości interioru",
                            "Wprowadź poniżej nową wartość", "", new[] {"Zapisz", "Anuluj"});
                    }
                }
                else if (dialogId == DialogId.InteriorEdit)
                {
                    Dictionary<string, object> dData =
                        (Dictionary<string, object>) Account.GetServerData(charData, Account.ServerData.TempDialogData);

                    Interior interiorData = Interiors.Library.GetInteriorData((int) dData["intId"]);
                    if (interiorData == null) return;

                    switch (dData["edit"])
                    {
                        case "name":
                            interiorData.Name = data.ToString();
                            interiorData.Save();
                            Ui.ShowInfo(player, "Nazwa interioru została zmieniona.");
                            Interiors.Library.ShowUi(charData, Interiors.UiType.InteriorInfo,
                                interiorData.Id);
                            break;

                        case "ownertype":
                            int ownerType = Command.GetNumberFromString(data.ToString());
                            if (ownerType < 0 || ownerType > 2)
                            {
                                Ui.ShowError(player, "Podano nieprawidłową wartość.");
                            }

                            interiorData.OwnerType = (Interiors.OwnerType) ownerType;
                            interiorData.Save();
                            Ui.ShowInfo(player, "Typ właściciela interioru został zmieniony.");
                            Interiors.Library.ShowUi(charData, Interiors.UiType.InteriorInfo,
                                interiorData.Id);
                            break;

                        case "owner":
                            int owner = Command.GetNumberFromString(data.ToString());
                            if (owner == Command.InvalidNumber)
                            {
                                Ui.ShowError(player, "Podano nieprawidłową wartość.");
                            }

                            interiorData.Owner = owner;
                            interiorData.Save();
                            Ui.ShowInfo(player, "Właściciel interioru został zmieniony.");
                            Interiors.Library.ShowUi(charData, Interiors.UiType.InteriorInfo,
                                interiorData.Id);
                            break;
                        default: break;
                    }
                }
                else
                {
                    Ui.ShowError(player,
                        $"Wystąpił błąd. Zgłoś go administratorowi: DialogError: {(int) dialogId}");
                }
            }
        }
    }
}