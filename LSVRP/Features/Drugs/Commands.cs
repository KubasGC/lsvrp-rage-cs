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
using LSVRP.Managers;

namespace LSVRP.Features.Drugs
{
    public class Commands : Script
    {
        [Command("narkotyki")]
        public void CommandNarkotyki(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            List<DialogColumn> dialogColumns = new List<DialogColumn>
            {
                new DialogColumn("Narkotyk", 40),
                new DialogColumn("Uzależnienie", 25),
                new DialogColumn("Czas", 25)
            };

            List<DialogRow> dialogRows = new List<DialogRow>
            {
                new DialogRow(null,
                    new[]
                    {
                        "Marihuana", $"{charData.DrugAddictions.Marijuana}%",
                        $"{charData.DrugAddictions.MarijuanaTime}s"
                    }),
                new DialogRow(null,
                    new[]
                    {
                        "Kokaina", $"{charData.DrugAddictions.Cocaine}%",
                        $"{charData.DrugAddictions.CocaineTime}s"
                    })
            };

            string[] dialogButtons = {"Wybierz", "Anuluj"};
            Dialogs.Library.CreateDialog(player, DialogId.None, "Uzależnienie narkotykowe", dialogColumns, dialogRows,
                dialogButtons);
        }
    }
}