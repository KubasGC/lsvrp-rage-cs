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

namespace LSVRP.Features.Animations
{
    public class Commands : Script
    {
        [Command("anim", Alias = "anims")]
        public void Command_Anim(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (Bw.Library.DoesPlayerHasBw(charData))
            {
                Ui.ShowError(player, "Nie możesz używać animacji w trakcie trwania BW.");
                return;
            }

            List<DialogColumn> dialogColumns = new List<DialogColumn>
            {
                new DialogColumn("Animacja", 90)
            };
            List<DialogRow> dialogRows = new List<DialogRow>();

            foreach (KeyValuePair<string, Animation> entry in Library.GetAnimationsList())
                dialogRows.Add(new DialogRow(entry.Value.AnimationCommand, new[] {entry.Value.AnimationCommand}));

            string[] dialogButtons = {"Użyj", "Anuluj"};
            Dialogs.Library.CreateDialog(player, DialogId.AnimationsList, "Lista animacji", dialogColumns, dialogRows,
                dialogButtons);
        }
    }
}