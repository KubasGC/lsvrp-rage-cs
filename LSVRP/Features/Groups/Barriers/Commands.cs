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
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Libraries;
using LSVRP.Managers;

namespace LSVRP.Features.Groups.Barriers
{
    public class Commands : Script
    {
        [Command("blokada", GreedyArg = true)]
        public void CmdBlokada(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            int groupDuty = Groups.Library.GetPlayerGroupDuty(charData);
            if (groupDuty == 0)
            {
                Ui.ShowError(player, "Nie znajdujesz się na duty żadnej grupy.");
                return;
            }

            Group groupData = Groups.Library.GetGroupData(groupDuty);
            if (groupData == null)
            {
                Ui.ShowError(player, "Grupa na której duty jesteś nie istnieje.");
                return;
            }

            if (!Groups.Library.DoesGroupHasPerm(groupData.Id, Permissions.SharedBarriers))
            {
                Ui.ShowError(player, "Grupa nie posiada uprawnień do stawiania blokad.");
                return;
            }

            if (!Groups.Library.DoesPlayerHasPerm(charData, groupData.Id, Permissions.SharedBarriers))
            {
                Ui.ShowError(player, "Twoja ranga w grupie nie pozwala na stawianie blokad.");
                return;
            }

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/blokada [stworz, usun]");
                return;
            }

            string firstOption = arguments[0].ToLower();


            if (firstOption == "stworz")
            {
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/blokada stworz [pd, strzalka, pacholek, pacholek2]");
                    return;
                }

                string secondOption = arguments[1].ToLower();

                Vector3 tempPos = player.Position;
                Vector3 tempRot = player.Rotation;

                int objectId = 0;

                if (secondOption == "pd")
                {
                    if (groupData.Type != GroupType.Pd)
                    {
                        Ui.ShowError(player, "Grupa nie posiada uprawnień do korzystania z tego typu blokady.");
                        return;
                    }

                    objectId = -143315610;
                    tempPos.Z -= 1.1f;
                }
                else if (secondOption == "strzalka")
                {
                    objectId = 1867879106;
                    tempPos.Z -= 1.0f;
                }
                else if (secondOption == "pacholek")
                {
                    objectId = -175009656;
                    tempPos.Z -= 1.0f;
                    tempRot.Y += -75.0f;
                }
                else if (secondOption == "pacholek2")
                {
                    objectId = -1587301201;
                    tempPos.Z -= 1.0f;
                }
                else
                {
                    Ui.ShowError(player, "Nie znaleziono takiego typu blokady.");
                    return;
                }

                Vector3 pos = Global.GetXyInFrontOfVector(tempPos, player.Rotation, 2.0f);

                Library.CreateBarrier(groupDuty, objectId, pos, tempRot, player.Dimension);
                Ui.ShowInfo(player, "Blokada stworzona.");
            }
            else if (firstOption == "usun")
            {
                Barrier foundBarrier = Library.GetNearestBarrier(player.Position, groupDuty, player.Dimension);
                if (foundBarrier == null)
                {
                    Ui.ShowInfo(player, "Nie znaleziono żadnej blokady w pobliżu.");
                    return;
                }

                Library.DeleteBarrier(foundBarrier);
                Ui.ShowInfo(player, "Blokada usunięta.");
            }
        }
    }
}