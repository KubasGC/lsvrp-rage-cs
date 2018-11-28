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
using LSVRP.Libraries;
using LSVRP.Managers;

namespace LSVRP.Features.Clothes
{
    public class Commands : Script
    {
        [Command("przebierz")]
        public void Command_Przebierz(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (Bw.Library.DoesPlayerHasBw(charData))
            {
                Ui.ShowError(player, "Nie możesz użyć tej komendy w trakcie trwania BW.");
                return;
            }

            if (charData.PlayerHandle.IsInVehicle)
            {
                Ui.ShowError(player, "Nie możesz użyć tej komendy będąc w pojeździe.");
                return;
            }

            using (Database.Database db = new Database.Database())
            {
                List<ClothSet> playerClothSets = db.ClothSets.Where(t => t.CharId == charData.Id).ToList();
                if (playerClothSets.Count == 0)
                {
                    Ui.ShowError(player, "Nie posiadasz żadnych zestawów ubrań.");
                    return;
                }

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("Zestaw", 90)
                };

                List<DialogRow> dialogRows = new List<DialogRow>();
                foreach (ClothSet clothSet in playerClothSets)
                    dialogRows.Add(new DialogRow(clothSet.Id, new[] {clothSet.Name}));

                string[] dialogButtons = {"Opcje", "Anuluj"};

                Dialogs.Library.CreateDialog(player, DialogId.ClothSetList, "Wybór zestawu ubrania", dialogColumns,
                    dialogRows,
                    dialogButtons);
            }
        }
    }
}