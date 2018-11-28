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
using LSVRP.Features.Admin;
using LSVRP.Libraries;
using LSVRP.Managers;
using Blip = LSVRP.Database.Models.Blip;

namespace LSVRP.Features.Blips
{
    public class Commands : Script
    {
        [Command("ablip", GreedyArg = true)]
        public void Command_AdminBlip(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (charData.AdminLevel == 0)
            {
                Ui.ShowError(player, "Nie posiadasz odpowiednich uprawnień do użycia tej komendy.");
                return;
            }

            const string legend = "/ablip [uid, stworz, usun]";
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            string option = arguments[0].ToLower();
            if (option == "uid")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.BlipUid, true)) return;

                Blip blipData = Library.GetNearestBlip(player.Position);
                if (blipData == null)
                {
                    Ui.ShowInfo(player, "Nie znaleziono żadnego blipa w pobliżu.");
                    return;
                }

                Player.SendFormattedChatMessage(player, $"Znaleziony blip: {blipData.Name} ({blipData.Id})");
            }
            else if (option == "stworz")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.BlipStworz, true)) return;

                if (arguments.Length - 1 < 6)
                {
                    Ui.ShowUsage(player, "/ablip stworz [spriteId] [colorId] [alpha] [scale (0-100)] [vw] [name]");
                    return;
                }

                int spriteId = Command.GetNumberFromString(arguments[1]);
                int colorId = Command.GetNumberFromString(arguments[2]);
                int alpha = Command.GetNumberFromString(arguments[3]);
                int scale = Command.GetNumberFromString(arguments[4]);
                int dimension = Command.GetNumberFromString(arguments[5]);
                string name = Command.GetConcatString(arguments, 6);

                if (spriteId == Command.InvalidNumber || colorId == Command.InvalidNumber ||
                    alpha == Command.InvalidNumber || scale == Command.InvalidNumber ||
                    dimension == Command.InvalidNumber || name.Length < 3)
                {
                    Ui.ShowUsage(player, "/ablip stworz [spriteId] [colorId] [alpha] [scale (0-100)] [vw] [name]");
                    return;
                }

                Blip newBlip = Library.CreateBlip(name, player.Position, spriteId, colorId, alpha,
                    (float) scale / 100, dimension, charData.Id);

                Ui.ShowInfo(player, "Blip został utworzony.");
            }
            else if (option == "usun")
            {
                if (!Admin.Library.DoesPlayerHasAdminPerm(charData, Permissions.BlipUsun, true)) return;

                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/ablip usun [blipId]");
                    return;
                }

                int blipId = Command.GetNumberFromString(arguments[1]);
                if (blipId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne id blipa.");
                    return;
                }

                if (Library.GetBlipData(blipId) == null)
                {
                    Ui.ShowError(player, "Blip o takim Id nie istnieje");
                    return;
                }

                Library.DestroyBlip(blipId);
            }
        }
    }
}