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
using LSVRP.Features.Base;
using LSVRP.Features.Dialogs;
using LSVRP.Managers;
using Library = LSVRP.Features.Groups.Library;

namespace LSVRP.Libraries
{
    public static class Player
    {
        /// <summary>
        /// Pozycja Admin Jaila
        /// </summary>
        private static readonly Vector3 AjPosition = new Vector3(151.96241760253906, -1004.86669921875, -99);

        /// <summary>
        /// Pozycja domyślnego spawnu
        /// </summary>
        public static readonly Vector3 DefaultSpawnPosition = new Vector3(286.99, -1576.25, 30);

        /// <summary>
        /// Zwraca nazwę gracza IC
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="withId"></param>
        /// <returns></returns>
        public static string GetPlayerIcName(Character charData, bool withId = false)
        {
            string output = "[ Niezalogowany ]";
            if (charData == null) return output;
            output = $"{charData.Name} {charData.Lastname}";
            if (charData.HasMask) output = $"Nieznajomy {charData.ShortDna}";

            if (charData.HasAdminDuty) output = $"{charData.GlobalName}";

            // TODO: Custom name

            if (withId) output = $"{output} ({charData.ServerId})";

            return output;
        }

        /// <summary>
        /// Pokazywanie statystyk gracza.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="targetData"></param>
        public static void ShowStats(Character charData, Character targetData)
        {
            if (charData == null || targetData == null) return;

            List<DialogColumn> dialogColumns = new List<DialogColumn>
            {
                new DialogColumn("", 45),
                new DialogColumn("", 45)
            };

            List<DialogRow> dialogRows = new List<DialogRow>
            {
                new DialogRow(null, new[] {"Postać", $"{targetData.Name} {targetData.Lastname} ({targetData.Id})"}),
                new DialogRow(null,
                    new[] {"Konto globalne", $"{GetPlayerOocName(targetData)} ({targetData.MemberId})"}),
                new DialogRow(null, new[] {"Płeć", targetData.Sex == CharSex.Male ? "Mężczyzna" : "Kobieta"}),
                new DialogRow(null, new[] {"Portfel", $"${targetData.Cash:0,0}"}),
                new DialogRow(null, new[] {"Konto bankowe", $"${targetData.AccountBalance:0,0}"}),
                new DialogRow(null, new[] {"Czas online", Global.GetFormattedTime(targetData.OnlineTime)}),
                new DialogRow(null,
                    new[]
                    {
                        "Czas BW", targetData.BwTime == 0 ? "n/d" : Global.GetFormattedTime(targetData.BwTime, true)
                    }),
                new DialogRow(null,
                    new[]
                    {
                        "Czas AJ",
                        targetData.AdminJailTime == 0 ? "n/d" : Global.GetFormattedTime(targetData.AdminJailTime, true)
                    }),
                new DialogRow(null, new[] {"VirtualWorld", targetData.PlayerHandle.Dimension.ToString()}),
                new DialogRow(null, new[] {"DNA", targetData.Dna}),
                new DialogRow(null, new[] {"mDNA", targetData.ShortDna}),
                new DialogRow(null, new[] {"HP", $"{targetData.PlayerHandle.Health}%"}),
                new DialogRow(null, new[] {"Ilość logowań", targetData.LoginCount.ToString()}),
                new DialogRow(null, new[] {"IP", targetData.PlayerHandle.Address}),
                new DialogRow(null, new[] {"", ""}),
                new DialogRow(null, new[] {"Grupy gracza", ""})
            };

            List<GroupMember> playerGroups = Library.GetPlayerGroups(targetData.PlayerHandle);
            if (playerGroups != null)
                foreach (GroupMember entry in playerGroups)
                {
                    Group groupData = Library.GetGroupData(entry.GroupId);
                    if (groupData == null) continue;

                    dialogRows.Add(new DialogRow(null, new[] {$"{groupData.Name} ({groupData.Id})", entry.RankName}));
                }
            else
                dialogRows.Add(new DialogRow(null, new[] {"Brak grup.", "---"}));

            string[] dialogButtons = {"Zamknij"};

            Features.Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.None, "Statystyki gracza",
                dialogColumns, dialogRows, dialogButtons);
        }

        /// <summary>
        /// Zwraca nazwę gracza IC
        /// </summary>
        /// <param name="player"></param>
        /// <param name="withId"></param>
        /// <returns></returns>
        public static string GetPlayerIcName(Client player, bool withId = false)
        {
            return GetPlayerIcName(Account.GetPlayerData(player), withId);
        }

        /// <summary>
        /// Zwraca nazwę gracza OOC
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="withId"></param>
        /// <returns></returns>
        public static string GetPlayerOocName(Character charData, bool withId = false)
        {
            string output = "[ Niezalogowany ]";
            if (charData == null) return output;
            output = $"{charData.GlobalName}";

            if (withId) output = $"{output} ({charData.ServerId})";

            return output;
        }

        /// <summary>
        /// Zwraca nazwę gracza OOC
        /// </summary>
        /// <param name="player"></param>
        /// <param name="withId"></param>
        /// <returns></returns>
        public static string GetPlayerOocName(Client player, bool withId = false)
        {
            return GetPlayerOocName(Account.GetPlayerData(player), withId);
        }

        /// <summary>
        /// Buduje twarz podanego gracza.
        /// </summary>
        /// <param name="charData"></param>
        public static void BuildPlayerFaceOld(Character charData)
        {
            if (charData == null) return;

            /*charData.PlayerHandle.HeadBlend = new HeadBlend
            {
                ShapeFirst = (byte) charData.MotherId,
                ShapeSecond = (byte) charData.FatherId,
                ShapeThird = 0,
                SkinFirst = (byte) charData.MotherId,
                SkinSecond = (byte) charData.FatherId,
                SkinThird = 0,
                ShapeMix = charData.ShapeMix,
                SkinMix = charData.SkinMix,
                ThirdMix = 0
            };
            // charData.PlayerHandle.SetClothes(2, charData.HairId, charData.HairColor);

            charData.PlayerHandle.SetHeadOverlay(0, new HeadOverlay
            {
                Index = (byte) charData.Blemishes,
                Opacity = 1.0f,
                Color = 0,
                SecondaryColor = 0
            });
            charData.PlayerHandle.SetHeadOverlay(1, new HeadOverlay
            {
                Index = (byte) charData.FacialHair,
                Opacity = 1.0f,
                Color = (byte) charData.OverlayColor,
                SecondaryColor = 0
            });
            charData.PlayerHandle.SetHeadOverlay(2, new HeadOverlay
            {
                Index = (byte) charData.EyeBrows,
                Opacity = 1.0f,
                Color = (byte) charData.OverlayColor,
                SecondaryColor = 0
            });

            charData.PlayerHandle.SetFaceFeature(0, charData.NoseWidth);
            charData.PlayerHandle.SetFaceFeature(1, charData.NoseHeight);
            charData.PlayerHandle.SetFaceFeature(2, charData.NoseLength);
            charData.PlayerHandle.SetFaceFeature(3, charData.NoseBridge);
            charData.PlayerHandle.SetFaceFeature(4, charData.NoseTip);
            charData.PlayerHandle.SetFaceFeature(5, charData.NoseBridgeShift);*/
        }

        /// <summary>
        /// Zwraca true jeśli gracz posiada skin, inaczej false.
        /// </summary>
        /// <param name="charData"></param>
        /// <returns></returns>
        public static bool DoesPlayerHasSkin(Character charData)
        {
            using (Database.Database db = new Database.Database())
            {
                return db.CharactersLook.Any(t => t.CharId == charData.Id);
            }
        }


        /// <summary>
        /// Buduje skina danego gracza.
        /// </summary>
        /// <param name="charData"></param>
        public static bool BuildPlayerSkin(Character charData)
        {
            if (charData == null) return false;

            NAPI.Player.SetPlayerSkin(charData.PlayerHandle,
                charData.Sex == CharSex.Male ? PedHash.FreemodeMale01 : PedHash.FreemodeFemale01);

            if (charData.SkinLook == null)
            {
                if (!DoesPlayerHasSkin(charData))
                {
                    SendFormattedChatMessage(charData.PlayerHandle,
                        "Nie posiadasz jeszcze skonfigurowanego wyglądu Twojej postaci. Przenoszenie do kreatora...",
                        Constants.ColorPictonBlue);

                    NAPI.Player.SpawnPlayer(charData.PlayerHandle,
                        new Vector3(402.9205627441406, -996.6041870117188, -99.00023651123047), 180.0f);
                    NAPI.Entity.SetEntityDimension(charData.PlayerHandle, (uint) Global.GetRandom(20000, 40000));
                    NAPI.ClientEvent.TriggerClientEvent(charData.PlayerHandle, "client.charCreator.toggle", true,
                        charData.Sex == CharSex.Male ? 0 : 1);
                    return false;
                }

                charData.LoadSkin();
            }

            charData.Health = charData.PlayerHandle.Health;


            if (charData.ClothSet != 0)
                using (Database.Database db = new Database.Database())
                {
                    ClothSet clothSet = db.ClothSets.FirstOrDefault(t => t.Id == charData.ClothSet);
                    if (clothSet == null) return false;

                    Dictionary<int, ComponentVariation> componentVariations = new Dictionary<int, ComponentVariation>
                    {
                        {3, new ComponentVariation(clothSet.TorsoId, 0)},
                        {4, new ComponentVariation(clothSet.Legs, clothSet.LegsTexture)},
                        {6, new ComponentVariation(clothSet.Boots, clothSet.BootsTexture)},
                        {7, new ComponentVariation(clothSet.Accessories, clothSet.AccessoriesTexture)},
                        {8, new ComponentVariation(clothSet.Undershirt, clothSet.UndershirtTexture)},
                        {11, new ComponentVariation(clothSet.Tops, clothSet.TopsTexture)}
                    };

                    charData.ComponentVariations = componentVariations;

                    // NAPI.Player.SetPlayerClothes(charData.PlayerHandle, componentVariations);
                }

            Features.Sync.Library.SyncPlayerForPlayer(charData.PlayerHandle);
            NAPI.ClientEvent.TriggerClientEvent(charData.PlayerHandle, "client.cameras.reset");
            return true;
        }

        /// <summary>
        /// Spawnuje danego gracza
        /// </summary>
        /// <param name="player"></param>
        public static void SpawnPlayer(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;
            if (!BuildPlayerSkin(charData)) return;
            // BuildPlayerFace(charData);
            // TODO: GeneratePlayerDescriptions

            player.TriggerEvent("client.money.update", charData.Cash);


            if (charData.AdminJailTime > 0)
            {
                NAPI.Player.SpawnPlayer(player, AjPosition);
                player.Dimension = (uint) new Random().Next(25000, 35000);

                Log.LogPlayer(player, $"Spawn w AJ. Pozostały czas: {charData.AdminJailTime} s.", LogType.SpawnPlayer);
            }
            else if (charData.BwTime > 0)
            {
                NAPI.Player.SpawnPlayer(player, new Vector3(charData.LastX, charData.LastY, charData.LastZ));
                player.Dimension = (uint) charData.Dimension;
                Features.Bw.Library.SetPlayerBw(charData, charData.BwTime);
                Log.LogPlayer(player, $"Spawn z BW na ostatniej pozycji. Pozostały czas: {charData.BwTime} s.",
                    LogType.SpawnPlayer);
            }
            else
            {
                if (charData.DetentionDoorId != 0)
                {
                    // TODO: przetrzymanie
                }
                else
                {
                    if (Global.GetTimestamp() - charData.LastLogin < 600)
                    {
                        NAPI.Player.SpawnPlayer(player, new Vector3(charData.LastX, charData.LastY, charData.LastZ));
                        player.Dimension = (uint) charData.Dimension;
                        Log.LogPlayer(player, "Spawn na ostatniej pozycji.", LogType.SpawnPlayer);
                    }
                    else
                    {
                        if (charData.SpawnType == 0) // Spawn domyślny
                        {
                            NAPI.Player.SpawnPlayer(player, DefaultSpawnPosition);
                            player.Dimension = 0;
                            Log.LogPlayer(player, "Spawn na domyślnej pozycji.", LogType.SpawnPlayer);
                        }
                        else if (charData.SpawnType == 1) // Spawn grupy
                        {
                            Group groupData = Library.GetGroupData(charData.SpawnInfo);
                            if (groupData != null)
                            {
                                if (Math.Floor(groupData.SpawnX) > 0 || Math.Floor(groupData.SpawnX) < 0)
                                {
                                    Log.LogPlayer(player,
                                        $"Spawn na pozycji grupowej {groupData.Name} (UID: {groupData.Id}).",
                                        LogType.SpawnPlayer);

                                    NAPI.Player.SpawnPlayer(player,
                                        new Vector3(groupData.SpawnX, groupData.SpawnY, groupData.SpawnZ));
                                    player.Dimension = (uint) groupData.SpawnDimension;
                                }
                                else
                                {
                                    charData.SpawnType = 0;
                                    charData.SpawnInfo = 0;
                                    // ReSharper disable once TailRecursiveCall
                                    SpawnPlayer(player);
                                }
                            }
                            else
                            {
                                charData.SpawnType = 0;
                                charData.SpawnInfo = 0;
                                // ReSharper disable once TailRecursiveCall
                                SpawnPlayer(player);
                            }
                        }
                        else if (charData.SpawnType == 2) // Spawn w domu
                        {
                            SendFormattedChatMessage(charData.PlayerHandle, "Spawn w domu nie jest zakodzony. :c",
                                Constants.ColorPictonBlue);
                            // TODO Spawn w domu
                        }
                        else if (charData.SpawnType == 3) // Spawn w hotelu
                        {
                            SendFormattedChatMessage(charData.PlayerHandle, "Spawn w hotelu nie jest zakodzony. :c",
                                Constants.ColorPictonBlue);
                            // TODO Spawn w hotelu
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Zwraca nazwę gracza do debugowania
        /// </summary>
        /// <param name="charData"></param>
        /// <returns></returns>
        public static string GetPlayerDebugName(Character charData)
        {
            if (charData == null) return "[ Nie znaleziono gracza ]";
            return
                $"[ UID: {charData.Id}, GID: {charData.MemberId}, SID: {charData.ServerId}, " +
                $"IC: {charData.Name} {charData.Lastname}, OOC: {charData.GlobalName} ]";
        }

        /// <summary>
        /// Zwraca nazwę gracza do debugowania
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static string GetPlayerDebugName(Client player)
        {
            return GetPlayerDebugName(Account.GetPlayerData(player));
        }

        /// <summary>
        /// Generuje unikalne DNA.
        /// </summary>
        /// <returns></returns>
        public static string GenerateDna()
        {
            using (Database.Database db = new Database.Database())
            {
                while (true)
                {
                    string generatedDna = Global.GenerateRandomString(4);
                    if (!db.Characters.Any(t => t.ShortDna == generatedDna)) return generatedDna;
                }
            }
        }

        /// <summary>
        /// Wypisuje na czacie dla gracza wiadomość w eleganckim formatowaniu w nawiasach [ ]. 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void SendFormattedChatMessage(Client player, string message, string color = "#FFFFFF")
        {
            player.SendChatMessage($"!{{{color}}}[ {message} ]");
        }
    }
}