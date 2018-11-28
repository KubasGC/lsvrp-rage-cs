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

// ReSharper disable ConvertIfStatementToSwitchStatement
// ReSharper disable UnusedMember.Global

namespace LSVRP.Features.Groups
{
    // ReSharper disable once UnusedMember.Global
    public class Commands : Script
    {
        [Command("g", GreedyArg = true)]
        public async void Command_G(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            string legend = "/g [l(ista)] | /g [slot] - aby pokazać więcej opcji";
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            string option = arguments[0].ToLower();

            if (option == "lista" || option == "l")
            {
                List<GroupMember> playerGroups = Library.GetPlayerGroups(player);
                if (playerGroups == null)
                {
                    Ui.ShowInfo(player, "Nie posiadasz żadnych grup.");
                    return;
                }

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("Slot", 10),
                    new DialogColumn("Tag", 25),
                    new DialogColumn("Nazwa", 55)
                };

                List<DialogRow> dialogRows = new List<DialogRow>();

                for (int i = 0; i < playerGroups.Count; i++)
                {
                    Group groupData = Library.GetGroupData(playerGroups[i].GroupId);
                    if (groupData == null) continue;

                    dialogRows.Add(new DialogRow(groupData.Id, new[] {$"{i + 1}", groupData.Code, groupData.Name}));
                }

                string[] dialogButtons = {"Opcje", "Anuluj"};

                Dialogs.Library.CreateDialog(player, DialogId.PlayerGroupsList, "Lista grup", dialogColumns, dialogRows,
                    dialogButtons);
            }
            else
            {
                int groupSlot = Command.GetNumberFromString(arguments[0]);
                if (groupSlot <= 0) return;
                GroupMember playerGroupData = Library.GetPlayerGroupBySlot(player, groupSlot);
                if (playerGroupData == null)
                {
                    Ui.ShowError(player, "Nie posiadasz grupy o takim slocie.");
                    return;
                }

                Group groupData = Library.GetGroupData(playerGroupData.GroupId);
                if (groupData == null)
                {
                    Ui.ShowError(player, "Grupa nie istnieje... :/");
                    return;
                }

                legend =
                    "/g [slot] [info, duty (sluzba), zapros, wypros, wplac, wyplac, podaj, opusc, z(gloszenia), " +
                    "s(pawn), ooc, zamow]";
                if (arguments.Length < 2)
                {
                    Ui.ShowUsage(player, legend);
                    return;
                }

                string secondOption = arguments[1].ToLower();
                if (secondOption == "info")
                {
                    List<DialogColumn> headers = new List<DialogColumn>
                    {
                        new DialogColumn("Typ", 30),
                        new DialogColumn("Wartość", 60)
                    };
                    List<DialogRow> rows = new List<DialogRow>
                    {
                        new DialogRow(null, new[] {"UID:", groupData.Id.ToString()}),
                        new DialogRow(null, new[] {"Nazwa gropy:", groupData.Name}),
                        new DialogRow(null, new[] {"Tag:", groupData.Code}),
                        new DialogRow(null, new[] {"Typ:", groupData.Type.ToString()})
                    };
                    string[] dialogBtns = {"Zamknij"};
                    Dialogs.Library.CreateDialog(player, DialogId.None, "Informacje o grupie", headers, rows,
                        dialogBtns);
                }
                else if (secondOption == "duty" || secondOption == "sluzba")
                {
                    Library.TogglePlayerDuty(player, groupData.Id,
                        Library.GetPlayerGroupDuty(player) != groupData.Id);
                }
                else if (secondOption == "zapros")
                {
                    if (!Library.DoesPlayerHasPerm(player, groupData.Id, Permissions.RankInvite))
                    {
                        Ui.ShowError(player, "Nie posiadasz odpowiednich uprawnień do użycia tej komendy");
                        return;
                    }

                    if (arguments.Length < 3)
                    {
                        Ui.ShowUsage(player, "/g [slot] zapros [ID gracza]");
                        return;
                    }

                    int playerId = Command.GetNumberFromString(arguments[2]);
                    if (playerId < 0)
                    {
                        Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                        return;
                    }

                    Character target = Account.GetPlayerDataByServerId(playerId);
                    if (target == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono gracza o podanym ID.");
                        return;
                    }

                    if (Global.GetDistanceBetweenPositions(player.Position, target.PlayerHandle.Position) >
                        Constants.RadiusTalk)
                    {
                        Ui.ShowError(player, "Gracz jest za daleko.");
                        return;
                    }

                    switch (await Library.AddPlayerToGroup(target.PlayerHandle, groupData.Id))
                    {
                        case AddToGroupState.Ok:
                            Ui.ShowInfo(player,
                                $"Dodano użytkownika {Player.GetPlayerIcName(target.PlayerHandle)} do grupy");
                            Ui.ShowInfo(target.PlayerHandle,
                                $"Zostałeś dodany do grupy {groupData.Name} przez gracza {Player.GetPlayerIcName(player)}.");
                            break;
                        case AddToGroupState.PlayerDoesntExist:
                            Ui.ShowError(player, "Gracz nie istnieje.");
                            break;
                        case AddToGroupState.GroupDoesntExist:
                            Ui.ShowError(player, "Grupa nie istnieje.");
                            break;
                        case AddToGroupState.AlreadyInGroup:
                            Ui.ShowError(player, "Gracz jest już w Twojej grupie.");
                            break;
                        case AddToGroupState.DbError:
                            Ui.ShowError(player, "Wystąpił błąd bazy danych.");
                            break;
                        case AddToGroupState.GlobalAlreadyInGroup:
                            Ui.ShowError(player, "Inna postać gracza jest już w grupie.");
                            break;
                        case AddToGroupState.GroupsLimitReached:
                            Ui.ShowError(player, "Gracz osiągnął maksymalny limit grup.");
                            break;
                        default:
                            Ui.ShowError(player, "Wystąpił nieznany błąd.");
                            break;
                    }
                }
                else if (secondOption == "wypros")
                {
                    if (!Library.DoesPlayerHasPerm(player, groupData.Id, Permissions.RankInvite))
                    {
                        Ui.ShowError(player, "Nie posiadasz odpowiednich uprawnień do użycia tej komendy");
                        return;
                    }

                    if (arguments.Length < 3)
                    {
                        Ui.ShowUsage(player, "/g [slot] wypros [ID gracza]");
                        return;
                    }

                    int playerId = Command.GetNumberFromString(arguments[2]);
                    if (playerId < 0)
                    {
                        Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                        return;
                    }

                    Character target = Account.GetPlayerDataByServerId(playerId);
                    if (target == null)
                    {
                        Ui.ShowError(player, "Nie znaleziono gracza o podanym ID.");
                        return;
                    }

                    switch (await Library.RemovePlayerFromGroup(target.PlayerHandle, groupData.Id))
                    {
                        case RemoveFromGroupState.Ok:
                            Ui.ShowInfo(player,
                                $"Wyrzuciłeś gracza {Player.GetPlayerIcName(target.PlayerHandle)} ze swojej grupy.");
                            Ui.ShowInfo(target.PlayerHandle,
                                $"Zostałeś wyrzucony z grupy {groupData.Name} przez {Player.GetPlayerIcName(player)}.");
                            break;
                        case RemoveFromGroupState.PlayerDoesntExist:
                            Ui.ShowError(player, "Gracz nie istnieje.");
                            break;
                        case RemoveFromGroupState.GroupDoesntExist:
                            Ui.ShowError(player, "Grupa nie istnieje.");
                            break;
                        case RemoveFromGroupState.NotInGroup:
                            Ui.ShowError(player, "Gracz nie jest w Twojej grupie.");
                            break;
                        case RemoveFromGroupState.ErrorGettingData:
                            Ui.ShowError(player, "Wystąpił błąd w momencie pobierania danych.");
                            break;
                        default:
                            Ui.ShowError(player, "Wystąpił nieznany błąd.");
                            break;
                    }
                }
                else if (secondOption == "wplac")
                {
                    // TODO sprawdzenie, czy jest się w budynku banku
                    if (!Library.DoesPlayerHasPerm(player, groupData.Id, Permissions.RankLeader))
                    {
                        Ui.ShowError(player, "Nie posiadasz odpowiednich uprawnień do użycia tej komendy");
                        return;
                    }

                    if (arguments.Length < 3)
                    {
                        Ui.ShowUsage(player, "/g [slot] wplac [kwota]");
                        return;
                    }

                    int price = Command.GetNumberFromString(arguments[2]);
                    if (price == Command.InvalidNumber || price < 1)
                    {
                        Ui.ShowError(player, "Wprowadziłeś niepoprawną wartość.");
                        return;
                    }

                    if (charData.Cash < price)
                    {
                        Ui.ShowError(player, "Nie posiadasz takiej kwoty w portfelu.");
                        return;
                    }

                    if (Money.Library.TakePlayerWalletCash(charData, price,
                        $"Wpłata pieniędzy na konto grupy {groupData.Name} ({groupData.Id})"))
                    {
                        groupData.Cash += price;
                        groupData.Save();
                        Library.SendGroupOocMessage(groupData.Id, $"Na konto grupy zostało wpłacone ${price:0,0}.");
                        // TODO logi przepływu hajsu w banku
                    }
                    else
                    {
                        Ui.ShowError(player, "Wystąpił bład w trakcie wpłaty pieniędzy.");
                    }
                }
                else if (secondOption == "wyplac")
                {
                    // TODO sprawdzenie, czy jest się w budynku banku
                    if (!Library.DoesPlayerHasPerm(player, groupData.Id, Permissions.RankLeader))
                    {
                        Ui.ShowError(player, "Nie posiadasz odpowiednich uprawnień do użycia tej komendy");
                        return;
                    }

                    if (arguments.Length < 3)
                    {
                        Ui.ShowUsage(player, "/g [slot] wyplac [kwota]");
                        return;
                    }

                    int price = Command.GetNumberFromString(arguments[2]);
                    if (price == Command.InvalidNumber || price < 1)
                    {
                        Ui.ShowError(player, "Wprowadziłeś niepoprawną wartość.");
                        return;
                    }

                    if (groupData.Cash < price)
                    {
                        Ui.ShowError(player, "Na koncie grupy nie ma takiej kwoty.");
                        return;
                    }

                    groupData.Cash -= price;
                    groupData.Save();
                    // TODO logi przepływu hajsu w banku
                    Library.SendGroupOocMessage(groupData.Id, $"Z konta grupy zostało wypłacone ${price:0,0}.");

                    if (Money.Library.TakePlayerWalletCash(charData, price,
                        $"Wpłata pieniędzy na konto grupy {groupData.Name} ({groupData.Id})"))
                    {
                        groupData.Cash += price;
                        groupData.Save();
                        Library.SendGroupOocMessage(groupData.Id, $"Na konto grupy zostało wpłacone ${price:0,0}.");
                        // TODO logi przepływu hajsu w banku
                    }
                    else
                    {
                        Ui.ShowError(player, "Wystąpił bład w trakcie wpłaty pieniędzy.");
                    }
                }
                else if (secondOption == "podaj")
                {
                    // TODO /g podaj
                }
                else if (secondOption == "opusc")
                {
                    // TODO /g opusc
                }
                else if (secondOption == "z" || secondOption == "zgloszenia")
                {
                    // TODO /g zgloszenia
                }
                else if (secondOption == "s" || secondOption == "spawn")
                {
                    if (!Library.DoesPlayerHasPerm(player, groupData.Id, Permissions.RankLeader))
                    {
                        Ui.ShowError(player, "Nie posiadasz odpowiednich uprawnień do użycia tej komendy");
                        return;
                    }

                    var pos = player.Position;
                    groupData.SpawnX = pos.X;
                    groupData.SpawnY = pos.Y;
                    groupData.SpawnZ = pos.Z;
                    groupData.SpawnDimension = (int) player.Dimension;
                    groupData.Save();
                    Ui.ShowInfo(player, "Miejsce spawnu grupy zostało zmienione");
                }
                else if (secondOption == "ooc")
                {
                    groupData.ChatDisabled = !groupData.ChatDisabled;
                    Library.SendGroupOocMessage(groupData.Id,
                        string.Format("Czat OOC w grupie został {0}.",
                            groupData.ChatDisabled ? "wyłączony" : "włączony"));
                }
                else if (secondOption == "zamow")
                {
                    // TODO permy
                    Library.ShowUi(charData, UiType.GroupOrders, groupData.Id);
                }
                else
                {
                    Ui.ShowUsage(player, legend);
                }
            }
        }

        [Command("ag", GreedyArg = true)]
        public async void CommandAg(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (charData.AdminLevel == 0) return;
            const string legend =
                "/ag [lista, stworz, usun, wejdz]";
            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, legend);
                return;
            }

            string option = arguments[0].ToLower();
            if (option == "stworz")
            {
            }
            else if (option == "lista")
            {
                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("Id", 30),
                    new DialogColumn("Nazwa", 60)
                };

                List<DialogRow> dialogRows = new List<DialogRow>();
                foreach (KeyValuePair<int, Group> entry in Library.GetGroups())
                    dialogRows.Add(new DialogRow(entry.Value.Id, new[] {entry.Value.Id.ToString(), entry.Value.Name}));

                string[] dialogButtons = {"Zamknij"};

                Dialogs.Library.CreateDialog(player, DialogId.None, "Lista grup",
                    dialogColumns, dialogRows, dialogButtons);
            }
            else if (option == "usun")
            {
                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("Id", 30),
                    new DialogColumn("Nazwa", 60)
                };

                List<DialogRow> dialogRows = new List<DialogRow>();
                foreach (KeyValuePair<int, Group> entry in Library.GetGroups())
                    dialogRows.Add(new DialogRow(entry.Value.Id, new[] {entry.Value.Id.ToString(), entry.Value.Name}));

                string[] dialogButtons = {"Wybierz", "Anuluj"};

                Dialogs.Library.CreateDialog(player, DialogId.AdminGroupRemove, "Wybierz grupę do usunięcia",
                    dialogColumns, dialogRows, dialogButtons);
            }
            else if (option == "wejdz")
            {
                if (arguments.Length - 1 < 1)
                {
                    Ui.ShowUsage(player, "/ag wejdz [ID grupy]");
                    return;
                }

                int groupId = Command.GetNumberFromString(arguments[1]);
                if (groupId == Command.InvalidNumber)
                {
                    Ui.ShowError(player, "Podano niepoprawne ID grupy.");
                    return;
                }

                Group groupData = Library.GetGroupData(groupId);
                if (groupData == null)
                {
                    Ui.ShowError(player, "Nie znaleziono grupy.");
                    return;
                }

                if (Library.DoesPlayerHasGroup(charData, groupData.Id))
                {
                    Ui.ShowError(player, "Jesteś już w tej grupie.");
                    return;
                }

                switch (await Library.AddPlayerToGroup(charData.PlayerHandle, groupData.Id))
                {
                    case AddToGroupState.Ok:
                        Player.SendFormattedChatMessage(player, $"Dodano do grupy \"{groupData.Name}\".",
                            Constants.ColorPictonBlue);
                        break;
                    case AddToGroupState.PlayerDoesntExist:
                        Ui.ShowError(player, "Gracz nie istnieje.");
                        break;
                    case AddToGroupState.GroupDoesntExist:
                        Ui.ShowError(player, "Grupa nie istnieje.");
                        break;
                    case AddToGroupState.AlreadyInGroup:
                        Ui.ShowError(player, "Gracz jest już w Twojej grupie.");
                        break;
                    case AddToGroupState.DbError:
                        Ui.ShowError(player, "Wystąpił błąd bazy danych.");
                        break;
                    case AddToGroupState.GlobalAlreadyInGroup:
                        Ui.ShowError(player, "Inna postać gracza jest już w grupie.");
                        break;
                    case AddToGroupState.GroupsLimitReached:
                        Ui.ShowError(player, "Gracz osiągnął maksymalny limit grup.");
                        break;
                    default:
                        Ui.ShowError(player, "Wystąpił nieznany błąd.");
                        break;
                }
            }
        }

        [Command("zgloszenia")]
        public void Command_Zgloszenia(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            int playerGroupDuty = Library.GetPlayerGroupDuty(player);
            if (playerGroupDuty == 0)
            {
                Ui.ShowError(player, "Nie jesteś na duty żadnej grupy.");
                return;
            }

            Group groupData = Library.GetGroupData(playerGroupDuty);
            if (groupData == null) Ui.ShowError(player, "Grupa nie istnieje.");

            // TODO
        }

        [Command("reanimuj", GreedyArg = true)]
        public void Command_Reanimuj(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/reanimuj [ID gracza]");
                return;
            }

            int playerDuty = Library.GetPlayerGroupDuty(player);
            if (playerDuty == 0)
            {
                Ui.ShowError(player, "Musisz być na duty grupy z odpowiednimi uprawnieniami.");
                return;
            }

            if (!Library.DoesPlayerHasPerm(charData, playerDuty, Permissions.SharedMedHeal, true)) return;

            int playerId = Command.GetNumberFromString(arguments[0]);
            if (playerId < 0)
            {
                Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(playerId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza.");
                return;
            }

            if (Global.GetDistanceBetweenPositions(player.Position, targetData.PlayerHandle.Position) >
                Constants.RadiusTalk)
            {
                Ui.ShowError(player, "Gracz jest zbyt daleko.");
                return;
            }

            if (!Bw.Library.DoesPlayerHasBw(targetData))
            {
                Ui.ShowError(player, "Gracz nie posiada BW.");
                return;
            }

            Bw.Library.EndBw(targetData);
            Ui.ShowInfo(targetData.PlayerHandle, $"{Player.GetPlayerIcName(charData)} ocucił Cię.");
            Ui.ShowInfo(player, $"Ocuciłeś gracza {Player.GetPlayerIcName(targetData)}.");
        }

        [Command("przeszukaj", GreedyArg = true)]
        public void Command_Przeszukaj(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/przeszukaj [ID gracza]");
                return;
            }

            int playerDuty = Library.GetPlayerGroupDuty(player);
            if (playerDuty == 0)
            {
                Ui.ShowError(player, "Musisz być na duty grupy z odpowiednimi uprawnieniami.");
                return;
            }

            if (!Library.DoesPlayerHasPerm(charData, playerDuty, Permissions.SharedSearchPlayer, true)) return;

            int playerId = Command.GetNumberFromString(arguments[0]);
            if (playerId < 0)
            {
                Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(playerId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza.");
                return;
            }

            if (Global.GetDistanceBetweenPositions(player.Position, targetData.PlayerHandle.Position) >
                Constants.RadiusTalk)
                Ui.ShowError(player, "Gracz jest zbyt daleko.");

            // TODO: Przeszukiwanie
        }

        [Command("przetrzymaj", GreedyArg = true)]
        public void Command_Przetrzymaj(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/przetrzymaj [ID gracza]");
                return;
            }

            int playerDuty = Library.GetPlayerGroupDuty(player);
            if (playerDuty == 0)
            {
                Ui.ShowError(player, "Musisz być na duty grupy z odpowiednimi uprawnieniami.");
                return;
            }

            if (!Library.DoesPlayerHasPerm(charData, playerDuty, Permissions.SharedDetention, true)) return;
            // TODO: Sprawdzanie interioru

            int playerId = Command.GetNumberFromString(arguments[0]);
            if (playerId < 0)
            {
                Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(playerId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza.");
                return;
            }

            if (Global.GetDistanceBetweenPositions(player.Position, targetData.PlayerHandle.Position) >
                Constants.RadiusTalk)
            {
                Ui.ShowError(player, "Gracz jest zbyt daleko.");
            }

            // TODO: Przetrzymywanie
        }

        [Command("skuj", GreedyArg = true)]
        public void Command_Skuj(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/skuj [ID gracza]");
                return;
            }

            int playerDuty = Library.GetPlayerGroupDuty(player);
            if (playerDuty == 0)
            {
                Ui.ShowError(player, "Musisz być na duty grupy z odpowiednimi uprawnieniami.");
                return;
            }

            if (!Library.DoesPlayerHasPerm(charData, playerDuty, Permissions.SharedPoliceCuff, true)) return;

            int playerId = Command.GetNumberFromString(arguments[0]);
            if (playerId < 0)
            {
                Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(playerId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza.");
                return;
            }

            if (targetData.PlayerHandle == player)
            {
                Ui.ShowError(player, "Nie możesz skuć samego siebie.");
                return;
            }

            if (Global.GetDistanceBetweenPositions(player.Position, targetData.PlayerHandle.Position) >
                Constants.RadiusTalk)
            {
                Ui.ShowError(player, "Gracz jest zbyt daleko.");
                return;
            }

            if (charData.Cuff != null && charData.Cuff.Type != 0 && NAPI.Entity.DoesEntityExist(charData.Cuff.Player))
            {
                Ui.ShowError(player, "Nie możesz teraz tego zrobić.");
                return;
            }

            if (targetData.Cuff != null && targetData.Cuff.Type != 0 &&
                NAPI.Entity.DoesEntityExist(targetData.Cuff.Player))
            {
                Ui.ShowError(player, "Nie możesz teraz tego zrobić.");
                return;
            }

            charData.Cuff = new CuffData(1, targetData.PlayerHandle);
            targetData.Cuff = new CuffData(2, charData.PlayerHandle);

            Ui.ShowInfo(player, $"Skułeś gracza {Player.GetPlayerIcName(targetData.PlayerHandle)}.");
            Ui.ShowInfo(targetData.PlayerHandle, $"Zostałeś skuty przez gracza {Player.GetPlayerIcName(player)}.");
            Chat.Library.SendPlayerMeMessage(charData, $"skuł gracza {Player.GetPlayerIcName(targetData)}.", true);
        }

        [Command("rozkuj", GreedyArg = true)]
        public void Command_Rozkuj(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/rozkuj [ID gracza]");
                return;
            }

            int playerDuty = Library.GetPlayerGroupDuty(player);
            if (playerDuty == 0)
            {
                Ui.ShowError(player, "Musisz być na duty grupy z odpowiednimi uprawnieniami.");
                return;
            }

            if (!Library.DoesPlayerHasPerm(charData, playerDuty, Permissions.SharedPoliceCuff, true)) return;
            int playerId = Command.GetNumberFromString(arguments[0]);
            if (playerId < 0)
            {
                Ui.ShowError(player, "Podano niepoprawne ID gracza.");
                return;
            }

            Character targetData = Account.GetPlayerDataByServerId(playerId);
            if (targetData == null)
            {
                Ui.ShowError(player, "Nie znaleziono gracza.");
                return;
            }

            if (targetData.PlayerHandle == player)
            {
                Ui.ShowError(player, "Nie możesz rozkuć samego siebie.");
                return;
            }

            if (Global.GetDistanceBetweenPositions(player.Position, targetData.PlayerHandle.Position) >
                Constants.RadiusTalk)
            {
                Ui.ShowError(player, "Gracz jest zbyt daleko.");
                return;
            }

            if (targetData.Cuff == null || targetData.Cuff.Type == 0 ||
                !NAPI.Entity.DoesEntityExist(targetData.Cuff.Player))
            {
                Ui.ShowError(player, "Gracz nie jest skuty.");
                return;
            }

            if (targetData.Cuff.Player != player)
            {
                Ui.ShowError(player, "Gracz nie jest skuty przez Ciebie.");
                return;
            }

            charData.Cuff = null;
            targetData.Cuff = null;

            Ui.ShowInfo(player, $"Rozkułeś gracza {Player.GetPlayerIcName(targetData.PlayerHandle)}.");
            Ui.ShowInfo(targetData.PlayerHandle, $"Zostałeś rozkuty przez gracza {Player.GetPlayerIcName(player)}.");
            Chat.Library.SendPlayerMeMessage(charData, $"rozkuł gracza {Player.GetPlayerIcName(targetData)}.", true);
        }

        [Command("blokuj", GreedyArg = true)]
        public void Command_Blokuj(Client player, string args = "")
        {
            // TODO /blokuj
        }

        [Command("news", GreedyArg = true)]
        public void Command_News(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/news [treść]");
                return;
            }

            int playerDuty = Library.GetPlayerGroupDuty(player);
            if (playerDuty == 0)
            {
                Ui.ShowError(player, "Musisz być na duty grupy z odpowiednimi uprawnieniami.");
                return;
            }

            if (!Library.DoesPlayerHasPerm(charData, playerDuty, Permissions.SharedRadioNews, true)) return;

            string message = Command.GetConcatString(arguments);

            // TODO: Radio
        }

        [Command("d", GreedyArg = true)]
        public void Command_D(Client player, string args = "")
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            int groupDuty = Library.GetPlayerGroupDuty(charData);
            if (groupDuty == 0)
            {
                Ui.ShowError(player, "Nie jesteś na duty żadnej grupy.");
                return;
            }

            Group groupData = Library.GetGroupData(groupDuty);
            if (groupData == null)
            {
                Ui.ShowError(player, "Grupa nie istnieje.");
                return;
            }

            if (!Library.DoesGroupHasPerm(groupData.Id, Permissions.SharedChatDepo))
            {
                Ui.ShowWarning(player, "Grupa nie posiada uprawnień do używania czatu departamentowego.");
                return;
            }

            if (!Library.DoesPlayerHasPerm(charData, groupData.Id, Permissions.SharedChatDepo, false))
            {
                Ui.ShowWarning(player, "Nie posiadasz odpowiednich uprawnień do używania czatu departamentowego.");
                return;
            }

            string[] arguments = Command.GetCommandArguments(args);
            if (arguments.Length < 1)
            {
                Ui.ShowUsage(player, "/d [treść wiadomości]");
                return;
            }

            string message = Command.UpperFirst(Command.GetConcatString(arguments));
            message = $"!{{255, 130, 130}}[{groupData.Code}] {Player.GetPlayerIcName(charData)}: {message}";
            foreach (KeyValuePair<int, Group> group in Library.GetGroups())
            {
                if (!Library.DoesGroupHasPerm(group.Value.Id, Permissions.SharedChatDepo)) continue;
                foreach (Character target in Library.GetPlayersInGroup(group.Value.Id, true))
                    NAPI.Chat.SendChatMessageToPlayer(target.PlayerHandle, message);
            }

            Chat.Library.SendPlayerLocalMessage(charData, Command.UpperFirst(Command.GetConcatString(arguments)),
                "mówi (radio)", charData.PlayerHandle);
        }
    }
}