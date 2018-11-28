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

namespace LSVRP.Features.Interiors
{
    public class Commands : Script
    {
        [Command("ad", GreedyArg = true)]
        public void CmdAdminDrzwi(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            // TODO uprawnienia

            string[] arguments = Command.GetCommandArguments(args);
            const string legend = "/ad [lista, stworz]";

            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            string firstOption = arguments[0].ToLower();

            if (firstOption == "stworz")
            {
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/ad stworz [interior, drzwi]");
                    return;
                }

                string secondOption = arguments[1].ToLower();
                if (secondOption == "interior")
                {
                    Interior createdInterior = Library.CreateInterior("Nowy interior", OwnerType.Player, charData.Id,
                        Library.GetNearestFreeDimension());
                    createdInterior.Name = $"Nowy interior {createdInterior.Id}";
                    createdInterior.Save();

                    Ui.ShowInfo(player, "Utworzono interior.");
                    Library.ShowUi(charData, UiType.InteriorInfo, createdInterior.Id);
                }
                else if (secondOption == "drzwi")
                {

                }
                else
                {
                    Ui.ShowError(player, "Podano niepoprawny typ.");
                }
            }
            else if (firstOption == "lista")
            {
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/ad lista [interior, drzwi]");
                    return;
                }

                string secondOption = arguments[1].ToLower();
                if (secondOption == "interior")
                {
                    List<DialogColumn> dialogColumns = new List<DialogColumn>
                    {
                        new DialogColumn("Nazwa interioru", 90)
                    };
                    List<DialogRow> dialogRows = new List<DialogRow>();
                    if (Library.GetInteriors().Count == 0)
                    {
                        Ui.ShowWarning(player, "Nie utworzono żadnych interiorów.");
                        return;
                    }

                    foreach (KeyValuePair<int, Interior> entry in Library.GetInteriors())
                    {
                        dialogRows.Add(new DialogRow(entry.Value.Id, new []{$"{entry.Value.Name} ({entry.Value.Id})"}));
                    }

                    string[] dialogButtons = {"Informacje", "Zamknij"};

                    Dialogs.Library.CreateDialog(player, DialogId.InteriorsList, "Lista wszystkich interiorów", dialogColumns, dialogRows, dialogButtons);
                }
            }
        }

        [Command("drzwi", GreedyArg = true)]
        public void CmdDrzwi(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            const string legend = "/drzwi [zamknij]";

            DoorInfo doorData = Library.GetNearestDoor(charData);
            if (doorData == null)
            {
                Ui.ShowError(player, "Nie stoisz przy żadnych drzwiach.");
                return;
            }

            Interior interiorData = Library.GetInteriorData(doorData.DoorData.ParentId);
            if (interiorData == null)
            {
                Ui.ShowError(player, "Nie znaleziono interioru do którego przypisane są drzwi.");
                return;
            }

            if (!Library.DoesPlayerHasInteriorPerm(charData, interiorData))
                Ui.ShowError(player, "Nie posiadasz odpowiednich uprawnień.");

            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            string fOption = arguments[0].ToLower();
            if (fOption == "zamknij")
            {
                if (doorData.DoorData.Locked)
                {
                    Ui.ShowInfo(player, "Drzwi zostały otwarte.");
                    Chat.Library.SendPlayerMeMessage(charData, "otwiera drzwi.", true);
                    doorData.DoorData.Locked = false;
                }
                else
                {
                    Ui.ShowInfo(player, "Drzwi zostały zamknięte.");
                    Chat.Library.SendPlayerMeMessage(charData, "zamyka drzwi.", true);
                    doorData.DoorData.Locked = true;
                }

                doorData.DoorData.Save();
            }
            else
            {
                Ui.ShowUsage(player, legend);
            }
        }
    }
}