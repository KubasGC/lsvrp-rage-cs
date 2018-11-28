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
using Object = LSVRP.Database.Models.Object;

namespace LSVRP.Features.Objects
{
    public class Commands : Script
    {
        [Command("ao", GreedyArg = true)]
        public void CmdAo(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            const string legend = "/ao [stworz, edytuj, usun]";
            string[] arguments = Command.GetCommandArguments(args);

            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            string firstOption = arguments[0].ToLower();

            if (firstOption == "stworz")
            {
                Vector3 frontPos = Global.GetPositionInFrontOf(player.Position, player.Heading, 5.0f);

                Object createdObject = Library.CreateObject(
                    (int) NAPI.Util.GetHashKey("prop_dress_disp_03"), 0, (int) player.Dimension, frontPos,
                    new Vector3(0, 0, player.Heading), 255);

                Ui.ShowInfo(player, $"Utworzono obiekt o identyfikatorze {createdObject.Id}");
            }
            else if (firstOption == "edytuj")
            {
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/ao edytuj [ID obiektu]");
                    return;
                }

                int objectId = Command.GetNumberFromString(arguments[1]);
                if (objectId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne ID obiektu.");
                    return;
                }

                Object objectData = Library.GetObjectData(objectId);
                if (objectData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono obiektu o podanym ID.");
                    return;
                }

                if (objectData.EditedBy != null && objectData.EditedBy.Value != player.Value &&
                    NAPI.Entity.DoesEntityExist(objectData.EditedBy))
                {
                    Ui.ShowError(player, "Obiekt jest już edytowany przez kogoś innego.");
                    return;
                }

                objectData.EditedBy = player;

                Ui.ShowInfo(player, $"Edytujesz obiekt o ID {objectData.Id}.");
                NAPI.ClientEvent.TriggerClientEvent(player, "client.objects.edit", objectData.ObjectHandle.Value);
            }
        }
    }
}