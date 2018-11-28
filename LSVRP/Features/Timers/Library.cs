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
using System.Threading;
using System.Timers;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Drugs;
using LSVRP.Features.Interiors;
using LSVRP.Features.Offers;
using LSVRP.Libraries;
using LSVRP.Managers;
using Log = LSVRP.Modules.Log;
using Vehicle = LSVRP.Database.Models.Vehicle;
using Timer = System.Timers.Timer;

namespace LSVRP.Features.Timers
{
    public static class Library
    {
        private static Timer _globalTimer;
        public static bool TimersOffline;

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static int[] _serverTime = {0, 0};

        /// <summary>
        /// Uruchamia timer.
        /// </summary>
        public static void StartTimer()
        {
            // ReSharper disable once RedundantCheckBeforeAssignment
            if (_globalTimer != null) _globalTimer = null;

            _globalTimer = new Timer(1000);
            _globalTimer.Elapsed += OnTimerElapsed;
            _globalTimer.AutoReset = true;
            _globalTimer.Enabled = true;
            Log.ConsoleLog("TIMER", "Timer został uruchomiony.");
        }

        /// <summary>
        /// Zatrzymuje utworzony timer.
        /// </summary>
        public static void StopTimer()
        {
            _globalTimer.Enabled = false;
        }

        private static void OnTimerElapsed(object sender, ElapsedEventArgs args)
        {
            if (TimersOffline) return;
            PlayersTimer(); // Timer wykonujący obliczenia dla graczy
            VehiclesTimer(); // Timer wykonujący obliczenia dla pojazdów
            OfferTimer(); // Timer wykonujący obliczenia dla ofert
            WorldTimer(); // Timer wykonujący obliczenia dla świata

            Progress.Library.ExecuteProgress();
        }

        /// <summary>
        /// Timer wykonujący obliczenia dla graczy.
        /// </summary>
        private static void PlayersTimer()
        {
            DateTime nowTime = DateTime.Now;

            foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
            {
                if (entry.Value.PlayerHandle == null || !NAPI.Entity.DoesEntityExist(entry.Value.PlayerHandle))
                {
                    Account.RemovePlayerData(entry.Value);
                    continue;
                }

                #region Zwiększenie licznika czasu gry

                entry.Value.OnlineTime++;
                if (entry.Value.OnlineTime != 0 && entry.Value.OnlineTime % 3600 == 0) // Godzina gry na serwerze
                    if (entry.Value.OnlineTime < 36000) // Dotacja dla gracza <10h
                    {
                        Money.Library.GivePlayerBankCash(entry.Value, Constants.HourlyDonation,
                            "Dotacja dla nowego gracza.");

                        Player.SendFormattedChatMessage(entry.Value.PlayerHandle,
                            "Dostałeś dotację dla nowego gracza w wysokości $200.", Constants.ColorPictonBlue);
                    }

                #endregion

                #region Sprawdzanie Bw

                if (entry.Value.BwTime > 0)
                {
                    entry.Value.BwTime--; // Zmniejszanie licznika czasu Bw
                    if (entry.Value.BwTime % 5 == 0)
                        NAPI.ClientEvent.TriggerClientEvent(entry.Value.PlayerHandle, "client.bw.setTime",
                            entry.Value.BwTime);

                    if (entry.Value.BwTime == 0) Bw.Library.EndBw(entry.Value); // Wyłączanie jeśli czas to 0
                }

                #endregion

                #region Skuwanie

                if (entry.Value.Cuff != null && entry.Value.Cuff.Type == 2)
                {
                    if (entry.Value.Cuff.Player != null && NAPI.Entity.DoesEntityExist(entry.Value.Cuff.Player))
                    {
                        if (entry.Value.Cuff.Player.Dimension != entry.Value.PlayerHandle.Dimension)
                            entry.Value.PlayerHandle.Dimension = entry.Value.Cuff.Player.Dimension;

                        if (Global.GetDistanceBetweenPositions(entry.Value.PlayerHandle.Position,
                                entry.Value.Cuff.Player.Position) > 4.0)
                            entry.Value.PlayerHandle.Position =
                                Global.GetPositionInFrontOf(entry.Value.Cuff.Player.Position,
                                    entry.Value.Cuff.Player.Heading, -2.0f);
                    }
                    else
                    {
                        entry.Value.Cuff = null;
                        Ui.ShowWarning(entry.Value.PlayerHandle, "Gracz, który Cię skuł opuścił serwer. Rozkuto.");
                    }
                }

                #endregion

                #region Naliczanie czasu duty w grupie

                int playerGroupDuty = Groups.Library.GetPlayerGroupDuty(entry.Value);
                if (playerGroupDuty != 0)
                {
                    GroupMember pGroupData = Groups.Library.GetPlayerGroupData(entry.Value, playerGroupDuty);
                    if (pGroupData != null) pGroupData.DutyTime++; // Zwiększanie licznika czasu duty.
                }

                #endregion

                #region Sprawdzanie Admin Jaila

                if (entry.Value.AdminJailTime > 0)
                {
                    entry.Value.AdminJailTime--;
                    if (entry.Value.AdminJailTime == 0)
                    {
                        Player.SendFormattedChatMessage(entry.Value.PlayerHandle,
                            "Czas Twojej odsiadki w Admin Jailu dobiegł końca. Postaraj się wyciągnąć wnioski, " +
                            "aby nigdy więcej tutaj nie trafić!", Constants.ColorPictonBlue);
                        Player.SpawnPlayer(entry.Value.PlayerHandle);
                    }
                }

                #endregion

                #region Narkotyki

                // Co 30 minut.
                if (nowTime.Minute % 30 == 0 && nowTime.Second == 0)
                {
                    #region marihuana

                    if (entry.Value.DrugAddictions.Marijuana >= 30 && entry.Value.DrugAddictions.Marijuana < 50)
                        Chat.Library.SendPlayerDoMessage(entry.Value,
                            Drugs.Library.GetRandomMessage(Data.MarihuannaDoActions),
                            true);

                    if (entry.Value.DrugAddictions.Marijuana >= 50)
                        if (Global.GetRandom(1, 2) == 1 && !entry.Value.PlayerHandle.IsInVehicle)
                        {
                            Animation anim = Animations.Library.GetAnimation("nacpany");
                            if (anim != null)
                            {
                                Animations.Library.PlayAnimation(entry.Value, anim);
                                Chat.Library.SendPlayerDoMessage(entry.Value,
                                    $"{entry.Value.Name} wpatruje się przed siebie, nie kontaktując ze światem.",
                                    true);
                            }
                        }

                    #endregion
                }

                // Co 15 minut.
                if (nowTime.Minute % 15 == 0 && nowTime.Second == 0)
                {
                    #region marihuana

                    if (entry.Value.DrugAddictions.Marijuana >= 50 && entry.Value.DrugAddictions.Marijuana < 75)
                        Chat.Library.SendPlayerDoMessage(entry.Value,
                            Drugs.Library.GetRandomMessage(Data.MarihuannaDoActions),
                            true);

                    #endregion
                }

                // Co 10 minut.
                if (nowTime.Minute % 10 == 0 && nowTime.Second == 0)
                {
                    #region marihuana

                    if (entry.Value.DrugAddictions.Marijuana >= 75)
                        Chat.Library.SendPlayerDoMessage(entry.Value,
                            Drugs.Library.GetRandomMessage(Data.MarihuannaDoActions),
                            true);

                    #endregion
                }


                if (entry.Value.DrugAddictions.MarijuanaTime > 0)
                {
                    if (nowTime.Minute % 3 == 0 && nowTime.Second == 0)
                        if (Global.GetRandom(1, 2) == 1)
                        {
                            int rand = Global.GetRandom(1, 2);
                            if (rand == 1)
                            {
                                switch (Global.GetRandom(1, 2))
                                {
                                    case 1:
                                        Chat.Library.SendPlayerMeMessage(entry.Value, "śmieje się.", true);
                                        break;
                                    case 2:
                                        Chat.Library.SendPlayerDoMessage(entry.Value,
                                            Drugs.Library.GetRandomMessage(Data.MarihuannaDoActions1),
                                            true);
                                        break;
                                }
                            }
                            else
                            {
                                if (!entry.Value.PlayerHandle.IsInVehicle)
                                {
                                    Animation anim = Animations.Library.GetAnimation("nacpany");
                                    if (anim != null)
                                    {
                                        Animations.Library.PlayAnimation(entry.Value, anim);
                                        Chat.Library.SendPlayerDoMessage(entry.Value,
                                            $"{entry.Value.Name} wpatruje się przed siebie, nie kontaktując ze światem.",
                                            true);
                                    }
                                }
                            }
                        }

                    entry.Value.DrugAddictions.MarijuanaTime--;

                    if (entry.Value.DrugAddictions.MarijuanaTime == 0)
                    {
                        Drugs.Library.StopEffectForPlayer(entry.Value.PlayerHandle, 20);
                        Drugs.Library.StopEffectForPlayer(entry.Value.PlayerHandle, 15);
                        Sync.Library.SyncPlayerForPlayer(entry.Value.PlayerHandle);
                        entry.Value.SaveDrugs();
                    }
                }

                if (entry.Value.DrugAddictions.CocaineTime > 0)
                {
                    if (nowTime.Minute % 3 == 0 && nowTime.Second == 0)
                        if (Global.GetRandom(1, 2) == 1)
                        {
                            int anotherRandom = Global.GetRandom(1, 3);

                            if (anotherRandom == 1)
                            {
                                switch (Global.GetRandom(1, 8))
                                {
                                    case 1:
                                        Chat.Library.SendPlayerDoMessage(entry.Value,
                                            $"{entry.Value.Name} ma wyraźny katar, od czasu do czasu pociąga nosem.",
                                            true);
                                        break;

                                    case 2:
                                        Chat.Library.SendPlayerDoMessage(entry.Value,
                                            $"{entry.Value.Name} odczuwa niepokój i lekki lęk.",
                                            true);
                                        break;

                                    case 3:
                                        Chat.Library.SendPlayerDoMessage(entry.Value,
                                            $"{entry.Value.Name} ma bardzo rozszerzone źrenice, które ewidentnie słabo reagują na światło.",
                                            true);
                                        break;

                                    case 4:
                                        Chat.Library.SendPlayerDoMessage(entry.Value, "Nos gracza jest zaczerwieniony.",
                                            true);
                                        break;

                                    case 5:
                                        Chat.Library.SendPlayerDoMessage(entry.Value,
                                            $"{entry.Value.Name} odczuwa pobudzenie i napięcie.", true);
                                        break;

                                    case 6:
                                        Chat.Library.SendPlayerDoMessage(entry.Value,
                                            $"{entry.Value.Name} ma rozszerzone źrenice.",
                                            true);
                                        break;

                                    case 7:
                                        Chat.Library.SendPlayerDoMessage(entry.Value,
                                            $"{entry.Value.Name} ma przyspieszony oddech.",
                                            true);
                                        break;

                                    case 8:
                                        Animation anim = Animations.Library.GetAnimation("doping2");
                                        if (anim != null)
                                        {
                                            Animations.Library.PlayAnimation(entry.Value, anim);
                                            Chat.Library.SendPlayerMeMessage(entry.Value,
                                                "zaczyna skakać z radości, śmiejąc się na głos i klaszcze w dłonie.",
                                                true);
                                        }

                                        break;
                                }
                            }
                            else if (anotherRandom == 2)
                            {
                            }
                        }

                    entry.Value.DrugAddictions.CocaineTime--;

                    if (entry.Value.DrugAddictions.CocaineTime == 0)
                    {
                        Drugs.Library.StopEffectForPlayer(entry.Value.PlayerHandle, 25);
                        Drugs.Library.StopEffectForPlayer(entry.Value.PlayerHandle, 4);
                        Sync.Library.SyncPlayerForPlayer(entry.Value.PlayerHandle);
                        entry.Value.SaveDrugs();
                    }
                }

                if (entry.Value.DrugAddictions.AmphetamineTime > 0)
                {
                    entry.Value.DrugAddictions.AmphetamineTime--;

                    if (entry.Value.DrugAddictions.AmphetamineTime == 0)
                    {
                        // TODO wyłączenie efektu amfetaminy.
                    }
                }

                if (entry.Value.DrugAddictions.MetaAmphetamineTime > 0)
                {
                    entry.Value.DrugAddictions.MetaAmphetamineTime--;

                    if (entry.Value.DrugAddictions.MetaAmphetamineTime == 0)
                    {
                        // TODO wyłączenie efektu metaamfetaminy.
                    }
                }

                if (entry.Value.DrugAddictions.HeroinTime > 0)
                {
                    entry.Value.DrugAddictions.HeroinTime--;

                    if (entry.Value.DrugAddictions.HeroinTime == 0)
                    {
                        // TODO wyłączenie efektu heroiny.
                    }
                }

                if (entry.Value.DrugAddictions.OpiumTime > 0)
                {
                    entry.Value.DrugAddictions.OpiumTime--;

                    if (entry.Value.DrugAddictions.OpiumTime == 0)
                    {
                        // TODO wyłączenie efektu opium.
                    }
                }

                if (entry.Value.DrugAddictions.LsdTime > 0)
                {
                    entry.Value.DrugAddictions.LsdTime--;

                    if (entry.Value.DrugAddictions.LsdTime == 0)
                    {
                        // TODO wyłączenie efektu lsd.
                    }
                }

                if (entry.Value.DrugAddictions.HashTime > 0)
                {
                    entry.Value.DrugAddictions.HashTime--;

                    if (entry.Value.DrugAddictions.HashTime == 0)
                    {
                        // TODO wyłączenie efektu hashu.
                    }
                }

                #endregion
            }
        }

        /// <summary>
        /// Timer wykonujący obliczenia dla pojazdów.
        /// </summary>
        private static void VehiclesTimer()
        {
            foreach (KeyValuePair<int, Vehicle> entry in Vehicles.Library.GetAllVehicles())
            {
                if (!entry.Value.Spawned || entry.Value.VehicleHandle == null ||
                    !NAPI.Entity.DoesEntityExist(entry.Value.VehicleHandle)) continue;

                if (entry.Value.Engine)
                {
                    // Sprawdzenie, czy pojazd nie jest rowerem
                    if (!Groups.Library.IsVehicleClassBicycle(
                        NAPI.Vehicle.GetVehicleClass((VehicleHash) entry.Value.VehicleHash)))
                    {
                        entry.Value.Fuel -= Constants.FuelUsage; // Zmniejszenie licznika paliwa;
                        if (entry.Value.Fuel <= 0) // Jeśli w zbiorniku skończyło się paliwo
                        {
                            entry.Value.Fuel = 0;
                            entry.Value.Engine = false;
                            entry.Value.Save();

                            entry.Value.VehicleHandle.EngineStatus = false;
                        }
                    }
                }
                else
                {
                    if (entry.Value.VehicleHandle.EngineStatus) entry.Value.VehicleHandle.EngineStatus = false;
                }
            }
        }

        /// <summary>
        /// Timer wykonujący obliczenia dla świata.
        /// </summary>
        private static void WorldTimer()
        {
            DateTime nowTime = DateTime.Now;
            if (_serverTime[0] != nowTime.Hour || _serverTime[1] != nowTime.Minute)
            {
                _serverTime[0] = nowTime.Hour;
                _serverTime[1] = nowTime.Minute;

                NAPI.World.SetTime(nowTime.Hour, nowTime.Minute, nowTime.Second);
            }

            if (nowTime.Hour == 4 && nowTime.Minute == 0 && !TimersOffline)
            {
                TimersOffline = true;
                SaveAll();
            }
        }

        /// <summary>
        /// Timer wykonujący obliczenia dla ofert.
        /// </summary>
        private static void OfferTimer()
        {
            int timestamp = Global.GetTimestamp();
            foreach (KeyValuePair<int, Offer> offer in Offers.Library.GetAllOffers())
                if (timestamp - offer.Value.StartedAt > 14)
                    offer.Value.Destroy("Po 15 sekundach nieaktywności oferta została anulowana.", true);
        }

        /// <summary>
        /// Zapisuje wszystkie potrzebne dane i restartuje serwer.
        /// </summary>
        private static void SaveAll()
        {
            Log.ConsoleLog("RESTART", "Wyrzucanie graczy z serwera...");
            List<Client> allPlayers = NAPI.Pools.GetAllPlayers();
            foreach (Client player in allPlayers) player.Kick("Następuje restart serwera, wróć za chwilę...");

            Log.ConsoleLog("RESTART", $"Wyrzucono {allPlayers.Count} graczy.");
            using (Database.Database db = new Database.Database())
            {
                foreach (CharacterDrugAddictions entry in db.CharactersDrugAddictions.ToList())
                {
                    db.CharactersDrugAddictions.Attach(entry);

                    entry.Amphetamine -= 5;
                    if (entry.Amphetamine < 0) entry.Amphetamine = 0;
                    entry.Cocaine -= 5;
                    if (entry.Cocaine < 0) entry.Cocaine = 0;
                    entry.Hash -= 5;
                    if (entry.Hash < 0) entry.Hash = 0;
                    entry.Heroin -= 5;
                    if (entry.Heroin < 0) entry.Heroin = 0;
                    entry.Lsd -= 5;
                    if (entry.Lsd < 0) entry.Lsd = 0;
                    entry.Marijuana -= 5;
                    if (entry.Marijuana < 0) entry.Marijuana = 0;
                    entry.MetaAmphetamine -= 5;
                    if (entry.MetaAmphetamine < 0) entry.MetaAmphetamine = 0;
                    entry.Opium -= 5;
                    if (entry.Opium < 0) entry.Opium = 0;
                }

                db.SaveChanges();
                Log.ConsoleLog("RESTART", "Zmniejszono uzaleznienie od narkotykow graczy...");


                List<Character> allCharacters = db.Characters.ToList();

                foreach (Character entry in allCharacters)
                {
                    if (entry.Blocked) continue;

                    db.Characters.Attach(entry);

                    entry.Strength -= 1;
                    if (entry.Strength < 1000) entry.Strength = 1000;
                    // Log.ConsoleLog("RESTART", $"Postac {i} ({entry.Name} {entry.Lastname})", LogType.Debug);
                }

                db.SaveChanges();
                Log.ConsoleLog("RESTART", "Zakonczono obliczenia na graczach.");

                int timestamp = Global.GetTimestamp();
                foreach (House entry in db.Houses.ToList())
                {
                    entry.LoadInteriorData();
                    if (entry.InteriorData == null) continue;
                    if (entry.InteriorData.OwnerType != OwnerType.Player) continue;

                    Character charData = Account.GetPlayerDataOnly(entry.InteriorData.Owner);
                    if (charData == null) continue;

                    // Usuwanie po 30 dniach.
                    if (timestamp - charData.LastLogin > 2592000)
                    {
                        entry.InteriorData.OwnerType = OwnerType.None;
                        entry.InteriorData.Owner = 0;
                        entry.InteriorData.Save();
                    }
                }

                CountPayday();

                while (true)
                {
                    DateTime nowTime = DateTime.Now;
                    if (nowTime.Minute != 0) break;

                    Thread.Sleep(1000);
                }

                Log.ConsoleLog("RESTART", "Zapis zakonczony. Wylaczanie serwera...");
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Liczy i wypłaca wypłatę za przepracowane godziny.
        /// </summary>
        public static void CountPayday()
        {
            Log.ConsoleLog("PAYDAY", "Rozpoczynam dzialanie.");
            using (Database.Database db = new Database.Database())
            {
                // Usunięcie duty które EndTime mają na 0.
                IQueryable<GroupDuty> endTime = db.GroupDuties.Where(t => t.EndTime == 0);
                int endTimeCount = endTime.Count();
                db.GroupDuties.RemoveRange(endTime);
                db.SaveChanges();
                Log.ConsoleLog("PAYDAY", $"Usunieto {endTimeCount} rekordow zawierajacych EndTime 0.");

                long yesterdayTimestamp = ((DateTimeOffset) DateTime.Now.AddHours(-24)).ToUnixTimeSeconds();
                Log.ConsoleLog("PAYDAY",
                    $"Szukam payday w bazie od czasu  {yesterdayTimestamp} rekordow zawierajacych EndTime 0.");

                foreach (Character character in db.Characters.Where(t => !t.Blocked))
                {
                    int payday = 0;
                    foreach (GroupMember group in db.GroupMembers.Where(t => t.CharacterId == character.Id))
                    {
                        if (group.Payday <= 0) continue;
                        Group groupData = db.Groups.FirstOrDefault(t => t.Id == group.GroupId);
                        if (groupData == null) continue;
                        int dutyTime = 0;

                        foreach (GroupDuty dutySession in db.GroupDuties.Where(t =>
                            t.CharId == character.Id && t.GroupId == group.GroupId &&
                            t.StartTime >= yesterdayTimestamp))
                        {
                            if (dutySession.EndTime < dutySession.StartTime) continue;

                            dutyTime += dutySession.EndTime - dutySession.StartTime;
                        }

                        payday += CountPaydayForGroup(character, groupData, group.Payday, dutyTime);
                    }

                    if (payday > 0)
                    {
                        Log.ConsoleLog("PAYDAY",
                            $"Wyplacono wyplate dla gracza {Player.GetPlayerIcName(character)} (${payday})");

                        character.AccountBalance += payday;
                        db.Characters.Update(character);
                    }
                }

                db.SaveChanges();

                Log.ConsoleLog("PAYDAY", "Zakonczono wyplacanie...");
            }
        }

        private static int CountPaydayForGroup(Character charData, Group groupData, int payday, int dutyTime)
        {
            if (dutyTime < 1200) return 0;
            if (charData == null || groupData == null) return 0;

            int output = 0;

            if (groupData.Donation < payday) payday = groupData.Donation;

            if (dutyTime >= 1200) output += payday;
            if (dutyTime >= 2400) output += payday;
            if (dutyTime >= 3600) output += payday;

            return output;
        }
    }
}