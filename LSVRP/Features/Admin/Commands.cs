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
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Admin.Reports;
using LSVRP.Features.Dialogs;
using LSVRP.Features.Tattoos;
using LSVRP.Libraries;
using LSVRP.Managers;
using Log = LSVRP.Libraries.Log;
using Tattoo = LSVRP.Database.Models.Tattoo;

namespace LSVRP.Features.Admin
{
    public class Commands : Script
    {
        [Command("stats", GreedyArg = true)]
        public void Command_Stats(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel <= 0) return;

            string[] arguments = Command.GetCommandArguments(args);

            if (arguments.Length == 0)
            {
                Player.ShowStats(charData, charData);
            }
            else
            {
                if (charData.AdminLevel == 0)
                {
                    Ui.ShowError(player, "Nie posiadasz odpowiednich uprawnień.");
                    return;
                }

                int serverId = Command.GetNumberFromString(arguments[0]);
                if (serverId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                    return;
                }

                Character targetData = Account.GetPlayerDataByServerId(serverId);
                if (targetData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono gracza o podanym Id.");
                    return;
                }

                Player.ShowStats(charData, targetData);
            }
        }

        [Command("fly")]
        public void Command_Fly(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel <= 0) return;

            // TODO
            // if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.CoreFly, true)) return;

            if (charData.IsFlying)
            {
                charData.IsFlying = false;
                Ui.ShowInfo(player, "Wyłączono latanie.");
                player.TriggerEvent("client.fly.off");
                return;
            }

            charData.IsFlying = true;
            Ui.ShowInfo(player, "Włączono latanie.");
            player.TriggerEvent("client.fly.on");
        }

        [Command("atatuaz", GreedyArg = true)]
        public void Command_Atatuaz(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel <= 0) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/atatuaz [id tatuazu]");
                return;
            }

            int tattooId = Command.GetNumberFromString(arguments[0]);
            if (tattooId == Command.InvalidNumber || tattooId < 1)
                Ui.ShowError(player, "Podano niepoprawny numer tatuażu.");

            if (charData.SyncedTattoos.Contains(tattooId))
            {
                charData.SyncedTattoos.Remove(tattooId);
                Sync.Library.SyncPlayerForPlayer(player);
                Ui.ShowInfo(player, "Usunięto tatuaż.");

                using (Database.Database db = new Database.Database())
                {
                    Tattoo tattooData =
                        db.Tattoos.FirstOrDefault(t => t.CharId == charData.Id && t.TattooId == tattooId);
                    if (tattooData == null) return;
                    db.Tattoos.Remove(tattooData);
                    db.SaveChanges();
                }
            }
            else
            {
                TattooRow tattooData = Tattoos.Library.GetTattooData(tattooId);
                if (tattooData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono tatuażu o podanym Id.");
                    return;
                }

                if (tattooData.Sex != charData.Sex)
                {
                    Ui.ShowError(player, "Tatuaż nie zgadza się z płcią Twojej postaci.");
                    return;
                }

                charData.SyncedTattoos.Add(tattooId);
                Sync.Library.SyncPlayerForPlayer(player);
                Ui.ShowInfo(player, "Dodano tatuaż.");

                using (Database.Database db = new Database.Database())
                {
                    Tattoo newTattoo = new Tattoo
                    {
                        CharId = charData.Id,
                        TattooId = tattooId
                    };
                    db.Tattoos.Add(newTattoo);
                    db.SaveChanges();
                }
            }
        }

        [Command("rope")]
        public void CmdRope(Client player)
        {
            player.TriggerEvent("TestRope");
        }

        [Command("to", GreedyArg = true)]
        public void Command_To(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel <= 0) return;

            if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.CoreTeleport, true)) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/to [ID gracza]");
                return;
            }

            int serverId = Command.GetNumberFromString(arguments[0]);
            if (serverId == Command.InvalidNumber)
            {
                Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(serverId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza o podanym Id.");
                return;
            }

            player.WarpOutOfVehicle();
            charData.PlayerHandle.Dimension = targetData.PlayerHandle.Dimension;
            charData.PlayerHandle.Position = targetData.PlayerHandle.Position;
            Log.LogPlayer(charData, $"Teleportowano do gracza {Player.GetPlayerDebugName(targetData)}",
                LogType.Teleport);
        }

        [Command("tm", GreedyArg = true)]
        public void Command_Tm(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel <= 0) return;

            if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.CoreTeleport, true)) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/tm [ID gracza]");
                return;
            }

            int serverId = Command.GetNumberFromString(arguments[0]);
            if (serverId == Command.InvalidNumber)
            {
                Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(serverId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza o podanym Id.");
                return;
            }

            targetData.PlayerHandle.WarpOutOfVehicle();
            targetData.PlayerHandle.Dimension = charData.PlayerHandle.Dimension;
            targetData.PlayerHandle.Position = charData.PlayerHandle.Position;
            Log.LogPlayer(charData, $"Teleportowano gracza {Player.GetPlayerDebugName(targetData)} do siebie",
                LogType.Teleport);
        }

        [Command("topos", GreedyArg = true)]
        public void Command_ToPos(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel <= 0) return;

            if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.CoreTeleport, true)) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 3)
            {
                Ui.ShowUsage(player, "/topos [X] [Y] [Z]");
                return;
            }

            int x = Command.GetNumberFromString(arguments[0]);
            int y = Command.GetNumberFromString(arguments[1]);
            int z = Command.GetNumberFromString(arguments[2]);

            player.Position = new Vector3(x, y, z);
        }

        [Command("aduty")]
        public void Command_Aduty(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            Library.ToggleAdminDuty(charData, !charData.HasAdminDuty);
        }

        [Command("a")]
        public void Command_Admins(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            List<DialogColumn> dialogColumns = new List<DialogColumn>
            {
                new DialogColumn("ID", 15),
                new DialogColumn("Nick", 35),
                new DialogColumn("Ranga", 40)
            };

            List<DialogRow> dialogRows = new List<DialogRow>();

            foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
            {
                if (entry.Value.AdminLevel < 1 || !entry.Value.HasAdminDuty) continue;

                RankInfo rankInfo = Library.GetAdminRankInfo(entry.Value.AdminLevel);

                dialogRows.Add(new DialogRow(null,
                    new[]
                    {
                        entry.Value.ServerId.ToString(),
                        Player.GetPlayerOocName(entry.Value),
                        $"<span style=\"color: #{rankInfo.Color}; font-weight: bold;\">{rankInfo.Name}</span>"
                    }));
            }

            string[] dialogButtons = {"Zamknij"};

            if (dialogRows.Count == 0)
            {
                Ui.ShowInfo(player, "Nie ma żadnego administratora na służbie.");
                return;
            }


            Dialogs.Library.CreateDialog(player, DialogId.None, "Administratorzy online", dialogColumns, dialogRows,
                dialogButtons);
        }

        [Command("aset", GreedyArg = true)]
        public void CmdAset(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel == 0) return;

            const string legend = "/aset [admin, vw, hp, pogoda, czas, nick, pieniadze, pozycja]";
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            string option = arguments[0].ToLower();
            if (option == "admin")
            {
                if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.AsetAdmin, true)) return;
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/aset admin [ID gracza]");
                    return;
                }

                int targetId = Command.GetNumberFromString(arguments[1]);
                if (targetId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne Id gracza.");
                    return;
                }

                Character targetData = Account.GetPlayerDataByServerId(targetId);
                if (targetData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono takiego gracza.");
                    return;
                }

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("Ranga", 90)
                };

                List<DialogRow> dialogRows = new List<DialogRow>
                {
                    new DialogRow(0, new[] {"Brak"}),
                    new DialogRow(1, new[] {"Helper"}),
                    new DialogRow(2, new[] {"Support (1)"}),
                    new DialogRow(3, new[] {"Support (2)"}),
                    new DialogRow(4, new[] {"Support (3)"}),
                    new DialogRow(5, new[] {"Support (4)"}),
                    new DialogRow(6, new[] {"Gamemaster"}),
                    new DialogRow(7, new[] {"Administrator"}),
                    new DialogRow(8, new[] {"Developer"}),
                    new DialogRow(9, new[] {"Moderator serwera"}),
                    new DialogRow(10, new[] {"Senior moderator"})
                };

                string[] dialogButtons = {"Wybierz", "Anuluj"};

                Dictionary<string, object> data = new Dictionary<string, object>
                {
                    {"targetData", targetData}
                };

                Account.SetServerData(charData, Account.ServerData.TempDialogData, data);

                Dialogs.Library.CreateDialog(player, DialogId.ChooseAdminLevel, "Wybierz poziom administratora",
                    dialogColumns, dialogRows, dialogButtons);
            }
            else if (option == "vw")
            {
                if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.AsetVw, true)) return;
                if (arguments.Length - 1 < 2)
                {
                    Ui.ShowUsage(player, "/aset vw [ID gracza] [virtual world]");
                    return;
                }

                int targetId = Command.GetNumberFromString(arguments[1]);
                if (targetId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne Id gracza.");
                    return;
                }

                Character targetData = Account.GetPlayerDataByServerId(targetId);
                if (targetData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono takiego gracza.");
                    return;
                }

                int dimension = Command.GetNumberFromString(arguments[2]);
                if (dimension == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawny virtual world");
                    return;
                }

                targetData.PlayerHandle.Dimension = (uint) dimension;
                Ui.ShowInfo(player,
                    $"Zmieniłeś graczowi {Player.GetPlayerIcName(targetData, true)} vw na {dimension}.");
                Ui.ShowInfo(targetData.PlayerHandle,
                    $"Administrator {Player.GetPlayerOocName(charData)} zmienił Ci vw na {dimension}.");

                Log.LogPlayer(targetData, $"Zmiana vw na {dimension} przez {Player.GetPlayerDebugName(charData)}",
                    LogType.Teleport);
            }
            else if (option == "hp")
            {
                if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.AsetHp, true)) return;
                if (arguments.Length - 1 < 2)
                {
                    Ui.ShowUsage(player, "/aset hp [ID gracza] [ilość hp]");
                    return;
                }

                int targetId = Command.GetNumberFromString(arguments[1]);
                if (targetId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne Id gracza.");
                    return;
                }

                Character targetData = Account.GetPlayerDataByServerId(targetId);
                if (targetData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono takiego gracza.");
                    return;
                }

                int hp = Command.GetNumberFromString(arguments[2]);
                if (hp < 0 || hp > 100)
                {
                    Ui.ShowError(player, "HP musi zawierać się w przedziale [0 - 100].");
                    return;
                }

                targetData.PlayerHandle.Health = hp;
                targetData.Health = hp;

                Ui.ShowInfo(player,
                    $"Zmieniłeś graczowi {Player.GetPlayerIcName(targetData, true)} hp na {hp}.");
                Ui.ShowInfo(targetData.PlayerHandle,
                    $"Administrator {Player.GetPlayerOocName(charData)} zmienił Ci hp na {hp}.");

                Log.LogPlayer(targetData, $"Zmiana hp na {hp} przez {Player.GetPlayerDebugName(charData)}",
                    LogType.ChangeHp);
            }
            else if (option == "pogoda")
            {
                if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.AsetVw, true)) return;
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/aset pogoda [ID pogody]");
                    return;
                }

                int weatherId = Command.GetNumberFromString(arguments[1]);
                if (weatherId < 0 || weatherId > Data.Weathers.Count - 1)
                {
                    Ui.ShowError(player, "ID pogody może zawierać się w przedziale [0 - 13]");
                    return;
                }

                NAPI.World.SetWeather(Data.Weathers[weatherId]);
                Ui.ShowInfo(player,
                    $"Ustawiłeś pogodę na {Enum.GetName(typeof(Weather), Data.Weathers[weatherId]).ToUpper()}.");
            }
            else if (option == "pozycja")
            {
                Player.SendFormattedChatMessage(player,
                    $"Twoja aktualna pozycja: new Vector3({player.Position.X:F2}, {player.Position.Y:F2}, " +
                    $"{player.Position.Z:F2})",
                    Constants.ColorDelRio);
            }
            else if (option == "czas")
            {
                if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.AsetCzas, true)) return;
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/aset czas [godzina]");
                    return;
                }

                int hour = Command.GetNumberFromString(arguments[1]);
                if (hour < 0 || hour > 23)
                {
                    Ui.ShowError(player, "Czas musi zawierać się w granicach [0 - 23]");
                    return;
                }

                NAPI.World.SetTime(hour, 0, 0);
                Ui.ShowInfo(player, $"Ustawiłeś czas serwera na godzinę {hour}.");
            }
            else if (option == "nick")
            {
                if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.AsetNick, true)) return;
                if (arguments.Length - 1 < 2)
                {
                    Ui.ShowUsage(player, "/aset nick [ID gracza] [nowy nick (wpisz usun aby przywrócić standardowy)]");
                    return;
                }

                int targetId = Command.GetNumberFromString(arguments[1]);
                if (targetId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne Id gracza.");
                    return;
                }

                Character targetData = Account.GetPlayerDataByServerId(targetId);
                if (targetData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono takiego gracza.");
                    return;
                }

                string nickname = Command.GetConcatString(arguments, 2);
                if (nickname.ToLower() == "usun")
                {
                    targetData.HasCustomName = false;
                    targetData.CustomName = null;
                    // TODO: refresh nicku

                    Ui.ShowInfo(player,
                        $"Zmieniłeś graczowi {Player.GetPlayerIcName(targetData, true)} nick na domyślny.");
                    Ui.ShowInfo(targetData.PlayerHandle,
                        $"Administrator {Player.GetPlayerOocName(charData)} zmienił Ci nick na donmyślny.");

                    Log.LogPlayer(targetData,
                        $"Zmiana na domyślny przez {Player.GetPlayerDebugName(charData)}",
                        LogType.ChangeNickname);
                }
                else
                {
                    targetData.HasCustomName = true;
                    targetData.CustomName = nickname;
                    // TODO: refresh nicku

                    Ui.ShowInfo(player,
                        $"Zmieniłeś graczowi {Player.GetPlayerIcName(targetData, true)} nick na {nickname}.");
                    Ui.ShowInfo(targetData.PlayerHandle,
                        $"Administrator {Player.GetPlayerOocName(charData)} zmienił Ci nick na {nickname}.");

                    Log.LogPlayer(targetData,
                        $"Zmiana na \"{nickname}\" przez {Player.GetPlayerDebugName(charData)}",
                        LogType.ChangeNickname);
                }
            }
            else if (option == "pieniadze")
            {
                if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.AsetPieniadze, true)) return;
                if (arguments.Length - 1 < 2)
                {
                    Ui.ShowUsage(player,
                        "/aset pieniadze [ID gracza] [ilość pieniędzy do dodania/odjęcia (użyj znaku -)]");
                    return;
                }

                int targetId = Command.GetNumberFromString(arguments[1]);
                if (targetId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne Id gracza.");
                    return;
                }

                Character targetData = Account.GetPlayerDataByServerId(targetId);
                if (targetData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono takiego gracza.");
                    return;
                }

                int money = Command.GetNumberFromString(arguments[2]);
                if (money == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawną kwotę.");
                    return;
                }

                if (money > 0)
                {
                    if (Money.Library.GivePlayerWalletCash(targetData, Math.Abs(money),
                        $"Od administratora {Player.GetPlayerDebugName(charData)}"))
                    {
                        Ui.ShowInfo(player, $"Dodałeś graczowi ${Math.Abs(money)}.");
                        targetData.PlayerHandle.SendChatMessage(
                            $"!{{#026D14}}[ Administrator {Player.GetPlayerOocName(charData)} " +
                            $"dał Ci ${Math.Abs(money)}. ]");
                    }
                }
                else
                {
                    money = Math.Abs(money);
                    if (targetData.Cash < money)
                    {
                        Ui.ShowError(player, "Gracz nie posiada tyle pieniędzy w portfelu.");
                        return;
                    }

                    if (Money.Library.TakePlayerWalletCash(targetData, Math.Abs(money),
                        $"Od administratora {Player.GetPlayerDebugName(charData)}"))
                    {
                        Ui.ShowInfo(player, $"Dodałeś graczowi ${Math.Abs(money)}.");
                        targetData.PlayerHandle.SendChatMessage(
                            $"!{{#026D14}}[ Administrator {Player.GetPlayerOocName(charData)} " +
                            $"zabrał Ci ${Math.Abs(money)}. ]");
                    }
                }
            }
            else
            {
                Ui.ShowUsage(player, legend);
            }
        }

        /*[Command("ee")]
        public void CommandSe(Client player, int effectId)
        {
            Drugs.Library.StartEffectForPlayer(player, effectId);
        }

        [Command("de")]
        public void CommandDe(Client player)
        {
            Drugs.Library.StopAllEffectsForPlayer(player);
        }*/

        [Command("aspawn", GreedyArg = true)]
        public void CmdAspawn(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel <= 0) return;

            if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.CoreCreator, true)) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/aspawn [ID gracza]");
                return;
            }

            int serverId = Command.GetNumberFromString(arguments[0]);
            if (serverId == Command.InvalidNumber)
            {
                Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(serverId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza o podanym Id.");
                return;
            }

            NAPI.Player.SpawnPlayer(targetData.PlayerHandle, Player.DefaultSpawnPosition);
            // Player.SpawnPlayer(targetData.PlayerHandle);
        }

        [Command("ainv")]
        public void Command_Ainv(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel == 0) return;
            if (!charData.HasAdminDuty)
            {
                Ui.ShowError(player, "Nie jesteś na duty administratora.");
                return;
            }

            if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.CoreAinv, true)) return;

            if (charData.HasInvisibleEnabled)
            {
                charData.HasInvisibleEnabled = false;
                Sync.Library.SetPlayerSyncedData(player, "Spectator", false);
                player.Transparency = 255;
                Ui.ShowInfo(player, "Wyłączyłeś niewidzialność.");
            }
            else
            {
                charData.HasInvisibleEnabled = true;
                Sync.Library.SetPlayerSyncedData(player, "Spectator", true);
                player.Transparency = 0;
                Ui.ShowInfo(player, "Włączyłeś niewidzialność.");
            }
        }

        [Command("getpos")]
        public void CmdGetPos(Client player)
        {
            NAPI.Chat.SendChatMessageToPlayer(player, $"{player.Position.X}, {player.Position.Y}, {player.Position.Z}");
        }

        [Command("report", GreedyArg = true, Alias = "raport")]
        public void Command_Report(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/report [ID gracza]");
                return;
            }

            int serverId = Command.GetNumberFromString(arguments[0]);
            if (serverId == Command.InvalidNumber)
            {
                Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(serverId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza o podanym Id.");
                return;
            }

            Account.SetServerData(charData, Account.ServerData.ReportedPlayer, targetData.PlayerHandle);
            Dialogs.Library.CreateDialog(player, DialogId.CreatePlayerReport, "Zgłoszenie gracza",
                "Wprowadź poniżej treść zgłoszenia, które ma trafić do administratorów. Opisz wszystko dokładnie, " +
                "to pozwoli szybko zareagować ekipie", "", new[] {"Wyślij", "Anuluj"});
        }

        [Command("areport", Alias = "ar", GreedyArg = true)]
        public void Command_Areport(Client player)
        {
            Reports.Library.ShowUi(player, UiType.ReportsList);
        }

        [Command("aspec", GreedyArg = true)]
        public void Command_Aspec(Client player, string args = "")
        {
            // TODO: /aspec
        }

        [Command("akick", GreedyArg = true)]
        public void Command_Akick(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel == 0) return;
            if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.PenaltyKick, true)) return;
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/akick [ID gracza]");
                return;
            }

            int targetId = Command.GetNumberFromString(arguments[0]);
            if (targetId == Command.InvalidNumber)
            {
                Ui.ShowError(player, "Podano niepoprawne Id gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(targetId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono takiego gracza.");
                return;
            }

            Account.SetServerData(charData, Account.ServerData.PenaltyPlayerId, targetId);
            Dialogs.Library.CreateDialog(player, DialogId.PenaltyKickText, "Kickowanie gracza",
                "Podaj powód wyrzucenia gracza z serwera.", "", new[] {"Wybierz", "Anuluj"});
        }

        [Command("awarn", GreedyArg = true)]
        public void Command_Awarn(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel == 0) return;
            if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.PenaltyWarn, true)) return;
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/awarn [ID gracza]");
                return;
            }

            int targetId = Command.GetNumberFromString(arguments[0]);
            if (targetId == Command.InvalidNumber)
            {
                Ui.ShowError(player, "Podano niepoprawne Id gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(targetId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono takiego gracza.");
                return;
            }

            Account.SetServerData(charData, Account.ServerData.PenaltyPlayerId, targetId);
            Dialogs.Library.CreateDialog(player, DialogId.PenaltyWarnText, "Warn dla gracza",
                "Podaj powód nadania graczowi ostrzeżenia.", "", new[] {"Wybierz", "Anuluj"});
        }

        [Command("aj", GreedyArg = true)]
        public void Command_Aj(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel == 0) return;
            if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.PenaltyAj, true)) return;
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/aj [ID gracza]");
                return;
            }

            int targetId = Command.GetNumberFromString(arguments[0]);
            if (targetId == Command.InvalidNumber)
            {
                Ui.ShowError(player, "Podano niepoprawne Id gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(targetId);
            if (targetData == null) Ui.ShowError(player, "Nie znaleziono takiego gracza.");

            // TODO: Dialog
        }

        [Command("ablock", GreedyArg = true)]
        public void Command_Ablock(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel == 0) return;
            if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.PenaltyAblock, true)) return;
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 2)
            {
                Ui.ShowUsage(player, "/ablock [ID gracza] [powód]");
                return;
            }

            int targetId = Command.GetNumberFromString(arguments[0]);
            string reason = Command.GetConcatString(arguments, 1);
            if (targetId == Command.InvalidNumber)
            {
                Ui.ShowError(player, "Podano niepoprawne Id gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(targetId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono takiego gracza.");
                return;
            }

            Player.SendFormattedChatMessage(player,
                $"Zablokowałeś postać gracza {Player.GetPlayerDebugName(targetData)}.",
                Constants.ColorDelRio);
            Penalties.Library.BlockPlayer(targetData, charData, reason);
        }

        [Command("aban", GreedyArg = true)]
        public void Command_Aban(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel == 0) return;
            if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.PenaltyKick, true)) return;
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 3)
            {
                Ui.ShowUsage(player, "/aban [ID gracza] [czas w dniach] [powód]");
                return;
            }

            int targetId = Command.GetNumberFromString(arguments[0]);
            int timeInDays = Command.GetNumberFromString(arguments[1]);
            string reason = Command.GetConcatString(arguments, 2);

            if (targetId == Command.InvalidNumber || timeInDays == Command.InvalidNumber || reason.Length < 2)
            {
                Ui.ShowError(player, "Podano niepoprawne dane.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(targetId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono takiego gracza.");
                return;
            }

            if (timeInDays < 1 || timeInDays > 365)
            {
                Ui.ShowError(player, "Długość bana może zawierać się w przedziale [1 - 365]");
                return;
            }

            Player.SendFormattedChatMessage(player, $"Zbanowałeś gracza {Player.GetPlayerDebugName(targetData)}.",
                Constants.ColorDelRio);
            Penalties.Library.BanPlayer(targetData, charData, timeInDays, reason);
        }

        [Command("as", GreedyArg = true)]
        public void Command_As(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (charData.AdminLevel <= 0)
            {
                Ui.ShowError(player, "Nie posiadasz odpowiednich uprawnień do użycia tej komendy.");
                return;
            }


            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/as [treść wiadomości]");
                return;
            }

            RankInfo rankInfo = Library.GetAdminRankInfo(charData.AdminLevel);

            string outputMessage =
                $"!{{#CC925F}}[AS] !{{#FFA490}}(( !{{#{rankInfo.Color}}}{rankInfo.Name} " +
                $"!{{#FFA490}}{Player.GetPlayerOocName(charData, true)}: " +
                $"{Command.UpperFirst(Command.GetConcatString(arguments))}))";

            foreach (KeyValuePair<int, Character> target in Account.GetAllPlayers())
            {
                if (target.Value.AdminLevel == 0) continue; // Tylko dla administratorów

                NAPI.Chat.SendChatMessageToPlayer(target.Value.PlayerHandle, outputMessage);
            }

            // TODO: logi
        }

        [Command("ado", GreedyArg = true)]
        public void Command_Ado(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            // TODO: ado
        }

        [Command("glob", GreedyArg = true)]
        public void Command_Glob(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (!Library.DoesPlayerHasAdminPerm(charData, Permissions.CoreGlob))
            {
                Ui.ShowError(player, "Nie posiadasz odpowiednich uprawnień do użycia tej komendy.");
                return;
            }

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/glob [treść wiadomości]");
                return;
            }

            RankInfo rankInfo = Library.GetAdminRankInfo(charData.AdminLevel);

            string outputMessage =
                $"!{{#FFFFFF}}(( !{{#{rankInfo.Color}}}{rankInfo.Name} " +
                $"!{{#FFFFFF}}{Player.GetPlayerOocName(charData, true)}: " +
                $"{Command.UpperFirst(Command.GetConcatString(arguments))}))";

            foreach (KeyValuePair<int, Character> target in Account.GetAllPlayers())
                NAPI.Chat.SendChatMessageToPlayer(target.Value.PlayerHandle, outputMessage);

            // TODO: logi
        }
    }
}