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
using LSVRP.Features.Dialogs;
using LSVRP.Libraries;
using LSVRP.Managers;

namespace LSVRP.Features.Admin.Reports
{
    public static class Library
    {
        /// <summary>
        /// Lista wszystkich raportów
        /// </summary>
        public static readonly Dictionary<int, ReportClass> ReportsList = new Dictionary<int, ReportClass>();

        /// <summary>
        /// Zwraca najmniejszy dostępny indeks
        /// </summary>
        /// <returns></returns>
        public static int GetLowestId()
        {
            int i = 0;
            while (true)
            {
                if (!ReportsList.ContainsKey(i)) return i;
                i++;
            }
        }

        /// <summary>
        /// Pobiera dane danego reportu po jego Id
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public static ReportClass GetReportData(int reportId)
        {
            return ReportsList.ContainsKey(reportId) ? ReportsList[reportId] : null;
        }

        /// <summary>
        /// Dodaje nowy raport do pamięci
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="targetData"></param>
        /// <param name="desc"></param>
        public static void CreateNewReport(Character charData, Character targetData, string desc)
        {
            if (charData == null || targetData == null) return;

            ReportClass newReport = new ReportClass
            {
                Id = GetLowestId(),
                Sender = charData.PlayerHandle,
                Target = targetData.PlayerHandle,
                SenderName = Global.EscapeHtml(Player.GetPlayerOocName(charData)),
                TargetName = Global.EscapeHtml(Player.GetPlayerOocName(targetData)),
                SendTime = Global.GetTimestamp(),
                Description =
                    Global.EscapeHtml(
                        $"{Player.GetPlayerIcName(charData, true)} >> {Player.GetPlayerIcName(targetData, true)}"),
                Content = desc,
                Admin = null
            };
            ReportsList.Add(newReport.Id, newReport);
            Global.SendMessageToAdmins(
                $"!{{15, 224, 213}}[ Gracz {Player.GetPlayerIcName(charData, true)} nadesłał nowy raport. Użyj " +
                "komendy /ar(eport) aby ją przeczytać. ]", true, false);
        }

        /// <summary>
        /// Dodaje nowy raport do pamięci
        /// </summary>
        /// <param name="player"></param>
        /// <param name="target"></param>
        /// <param name="desc"></param>
        public static void CreateNewReport(Client player, Client target, string desc)
        {
            CreateNewReport(Account.GetPlayerData(player), Account.GetPlayerData(target), desc);
        }

        /// <summary>
        /// Usuwa raport podanym Id
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="reportId"></param>
        public static void DestroyReport(Character charData, int reportId)
        {
            ReportClass reportData = GetReportData(reportId);
            if (reportData == null) return;
            if (charData == null)
                Global.SendMessageToAdmins(
                    $"!{{9, 135, 128}}[ Zgłoszenie \"{reportData.Description}\" zostało zamknięte z " +
                    "powodu długiej nieaktywności. ]", true, false);
            else
                Global.SendMessageToAdmins(
                    $"!{{9, 135, 128}}[ Zgłoszenie \"{reportData.Description}\" zostało zamknięte przez " +
                    $"{Player.GetPlayerOocName(charData, false)}. ]", true, false);

            if (ReportsList.ContainsKey(reportData.Id)) ReportsList.Remove(reportData.Id);
        }

        /// <summary>
        /// Usuwa raport o podanym Id
        /// </summary>
        /// <param name="player"></param>
        /// <param name="reportId"></param>
        public static void DestroyReport(Client player, int reportId)
        {
            DestroyReport(Account.GetPlayerData(player), reportId);
        }

        /// <summary>
        /// Pokazuje UI dla wybranego gracza
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="uiType"></param>
        /// <param name="reportId"></param>
        public static void ShowUi(Character charData, UiType uiType, int? reportId = null)
        {
            if (charData == null) return;
            if (uiType == UiType.ReportsList)
            {
                if (ReportsList.Count == 0)
                {
                    Ui.ShowInfo(charData.PlayerHandle, "Brak zgłoszeń.");
                    return;
                }

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("Opis", 50),
                    new DialogColumn("Czas", 25),
                    new DialogColumn("Przyjęte", 20)
                };

                List<DialogRow> dialogRows = new List<DialogRow>();
                foreach (KeyValuePair<int, ReportClass> entry in ReportsList)
                    dialogRows.Add(new DialogRow(entry.Value.Id,
                        new[]
                        {
                            entry.Value.Description, Global.GetTimeFromTimestamp(entry.Value.SendTime),
                            entry.Value.Admin != null && NAPI.Entity.DoesEntityExist(entry.Value.Admin)
                                ? "<span style=\"color: green;\">Tak</span>"
                                : "<span style=\"color: red;\">Nie</span>"
                        }));

                string[] dialogButtons = {"Wybierz", "Anuluj"};

                Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.AdminReportList,
                    "Lista zgłoszeń administracyjnych", dialogColumns, dialogRows, dialogButtons);


                /*List<DialogData> dialogData = new List<DialogData>();
                foreach (KeyValuePair<int, ReportClass> entry in ReportsList)
                {
                    string marker = (entry.Value.Admin != null && NAPI.Entity.DoesEntityExist(entry.Value.Admin))
                        ? "<span style=\"font-weight: bold; color: green;\">☑</span>"
                        : "<font style=\"font-weight: bold; color: red;\">☒</font>";
                    dialogData.Add(new DialogData(
                        $"{marker} [{Global.GetTimeFromTimestamp(entry.Value.SendTime)}] {entry.Value.Description}",
                        entry.Value.Id));
                }*/

                // Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.AdminReportList,
                //    "Lista zgłoszeń administracyjnych", "Wybierz zgłoszenie z listy", dialogData, DialogType.List);
            }
            else if (uiType == UiType.ReportInfo)
            {
                if (reportId == null) return;
                if (!charData.HasAdminDuty)
                {
                    Ui.ShowError(charData.PlayerHandle, "Nie jesteś na duty administratora.");
                    return;
                }

                ReportClass reportData = GetReportData((int) reportId);
                if (reportData == null)
                {
                    Ui.ShowError(charData.PlayerHandle, "Nie znaleziono podanego zgłoszenia.");
                    return;
                }

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("", 45),
                    new DialogColumn("", 45)
                };
                List<DialogRow> dialogRows = new List<DialogRow>
                {
                    new DialogRow(null, new[] {"Zgłaszający", reportData.SenderName}),
                    new DialogRow(null, new[] {"Zgłoszony", reportData.TargetName}),
                    new DialogRow(null, new[] {"Godzina zgłoszenia", Global.GetTimeFromTimestamp(reportData.SendTime)}),
                    new DialogRow(null,
                        new[]
                        {
                            "Rozpatrujący",
                            reportData.Admin == null || !NAPI.Entity.DoesEntityExist(reportData.Admin)
                                ? "--"
                                : Player.GetPlayerOocName(reportData.Admin, true)
                        }),
                    new DialogRow(null, new[] {"Treść zgłoszenia", reportData.Content}),
                    new DialogRow(null, new[] {"", ""}),
                    new DialogRow("accept", new[] {"Przyjmij zgłoszenie", ""}),
                    new DialogRow("close", new[] {"Zamknij zgłoszenie", ""}),
                    new DialogRow("back", new[] {"Powrót", ""})
                };

                string[] dialogButtons = {"Wybierz", "Anuluj"};

                Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.AdminReportAction, "Szczegóły zgłoszenia",
                    dialogColumns, dialogRows, dialogButtons);
            }
        }

        /// <summary>
        /// Pokazuje UI dla wybranego gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="uiType"></param>
        /// <param name="reportId"></param>
        public static void ShowUi(Client player, UiType uiType, int? reportId = null)
        {
            ShowUi(Account.GetPlayerData(player), uiType, reportId);
        }
    }
}