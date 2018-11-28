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

namespace LSVRP.Features.Tattoos
{
    public class Commands : Script
    {
        [Command("tatuaz")]
        public void Command_Tatuaz(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (charData.SyncedTattoos.Count == 0)
            {
                Ui.ShowInfo(player, "Twoja postać nie posiada żadnych tatuaży.");
                return;
            }

            List<DialogColumn> dialogColumns = new List<DialogColumn>
            {
                new DialogColumn("Nazwa", 45),
                new DialogColumn("Część ciała", 45)
            };

            List<DialogRow> dialogRows = new List<DialogRow>();
            foreach (int entry in charData.SyncedTattoos)
            {
                TattooInfo tattooData = Library.GetTattooInfo(entry);
                if (tattooData == null) continue;

                dialogRows.Add(new DialogRow(null,
                    new[] {$"{tattooData.tattoo.Name} ({tattooData.Id})", tattooData.tattoo.BodyPart.ToString()}));
            }

            string[] dialogButtons = {"Wybierz", "Anuluj"};
            Dialogs.Library.CreateDialog(player, DialogId.None, "Lista Twoich tatuaży", dialogColumns, dialogRows,
                dialogButtons);
        }
    }
}