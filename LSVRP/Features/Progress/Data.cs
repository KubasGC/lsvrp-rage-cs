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
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Offers;
using LSVRP.Libraries;
using Vehicle = LSVRP.Database.Models.Vehicle;

namespace LSVRP.Features.Progress
{
    public class Progress
    {
        public int Id { get; set; }
        public string ProgressName { get; set; }
        public Character CharData { get; set; }
        public Character TargetData { get; set; }
        public ProgressType Type { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public bool IsBlocked { get; set; }
        public int TimeLength { get; set; }
        public int TimeLeft { get; set; }

        private int Percent => (int) Math.Floor((TimeLength - TimeLeft) / (double) TimeLength * 100D);

        /// <summary>
        /// Uruchomienie interfejsu dla graczy.
        /// </summary>
        public void Start()
        {
            if (CharData != null && CharData.PlayerHandle != null && NAPI.Entity.DoesEntityExist(CharData.PlayerHandle))
                NAPI.ClientEvent.TriggerClientEvent(CharData.PlayerHandle, "client.progress.start", ProgressName);

            if (TargetData != null && TargetData.PlayerHandle != null &&
                NAPI.Entity.DoesEntityExist(TargetData.PlayerHandle))
                NAPI.ClientEvent.TriggerClientEvent(TargetData.PlayerHandle, "client.progress.start", ProgressName);
        }

        /// <summary>
        /// Zaktualizowanie stanu progressu dla graczy.
        /// </summary>
        private void Update()
        {
            if (CharData != null && CharData.PlayerHandle != null &&
                NAPI.Entity.DoesEntityExist(CharData.PlayerHandle))
                NAPI.ClientEvent.TriggerClientEvent(CharData.PlayerHandle, "client.progress.update", Percent);

            if (TargetData != null && TargetData.PlayerHandle != null && TargetData != CharData &&
                NAPI.Entity.DoesEntityExist(TargetData.PlayerHandle))
                NAPI.ClientEvent.TriggerClientEvent(TargetData.PlayerHandle, "client.progress.update", Percent);
        }

        /// <summary>
        /// Schowanie interfejsu dla graczy.
        /// </summary>
        private void Stop()
        {
            if (CharData != null && CharData.PlayerHandle != null && NAPI.Entity.DoesEntityExist(CharData.PlayerHandle))
                NAPI.ClientEvent.TriggerClientEvent(CharData.PlayerHandle, "client.progress.stop");

            if (TargetData != null && TargetData.PlayerHandle != null &&
                NAPI.Entity.DoesEntityExist(TargetData.PlayerHandle))
                NAPI.ClientEvent.TriggerClientEvent(TargetData.PlayerHandle, "client.progress.stop");
        }

        /// <summary>
        /// Schowanie interfejsu dla graczy oraz usunięcie progressu z listy.
        /// </summary>
        public void Destroy()
        {
            Stop();
            Library.ItemsToDestroy.Add(Id);
        }

        /// <summary>
        /// Funkcja wykonująca się za każdym razem uruchomienia timera.
        /// </summary>
        public void OnTimer()
        {
            if (TimeLeft <= 0)
            {
                OnSuccess();
                return;
            }

            if (Type == ProgressType.FixVehicle)
            {
                // Data["veh"] = Database.Models.Vehicle
                // charData - klient
                // targetData - mechanik

                Vehicle vehData = (Vehicle) Data["veh"];
                if (vehData == null)
                {
                    SendMessage("Pojazd nie istnieje.");
                    Destroy();
                    return;
                }

                if (vehData.VehicleHandle == null || !NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                {
                    SendMessage("Pojazd nie jest zespawnowany.");
                    Destroy();
                    return;
                }

                if (TargetData == null || TargetData.PlayerHandle == null ||
                    !NAPI.Entity.DoesEntityExist(TargetData.PlayerHandle))
                {
                    SendMessage("Mechanik wyszedł z gry.");
                    Destroy();
                    return;
                }

                if (vehData.Engine) return;

                if (Global.GetDistanceBetweenPositions(TargetData.PlayerHandle.Position,
                        vehData.VehicleHandle.Position) > 5.0)
                {
                    if (Global.GetDistanceBetweenPositions(TargetData.PlayerHandle.Position,
                            vehData.VehicleHandle.Position) > 20.0 ||
                        TargetData.PlayerHandle.Dimension != vehData.VehicleHandle.Dimension)
                    {
                        SendMessage("Mechanik odszedł zbyt daleko od pojazdu.");
                        Destroy();
                        return;
                    }

                    return;
                }
            }
            else if (Type == ProgressType.TattooCreate)
            {
                if (Global.GetDistanceBetweenPositions(TargetData.PlayerHandle.Position,
                        CharData.PlayerHandle.Position) > 5.0)
                {
                    if (Global.GetDistanceBetweenPositions(TargetData.PlayerHandle.Position,
                            CharData.PlayerHandle.Position) > 20.0 ||
                        TargetData.PlayerHandle.Dimension != CharData.PlayerHandle.Dimension)
                    {
                        SendMessage("Tatuażysta odszedł zbyt daleko od gracza.");
                        Destroy();
                        return;
                    }

                    return;
                }
            }

            TimeLeft--;
            Update();
        }

        /// <summary>
        /// Funkcja wykonywująca się w momencie, gdy TimeLeft osiągnie wartość 0. 
        /// </summary>
        private void OnSuccess()
        {
            // Jeśli jakimś sposobem OnSuccess uruchomi się po raz drugi - niszczymy progress.
            if (IsBlocked)
            {
                Destroy();
                return;
            }

            // Blokujemy progress, aby przypadkiem nie wykonał się drugi raz.
            IsBlocked = true;

            if (Type == ProgressType.FixVehicle)
            {
                Vehicle vehData = (Vehicle) Data["veh"];
                if (vehData == null)
                {
                    SendMessage("Pojazd nie istnieje.");
                    Destroy();
                    return;
                }

                if (vehData.VehicleHandle == null || !NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                {
                    SendMessage("Pojazd nie jest zespawnowany.");
                    Destroy();
                    return;
                }

                if (TargetData == null || TargetData.PlayerHandle == null ||
                    !NAPI.Entity.DoesEntityExist(TargetData.PlayerHandle))
                {
                    SendMessage("Mechanik wyszedł z gry.");
                    Destroy();
                    return;
                }

                if (Offers.Library.PayForOffer(TargetData, CharData, (OfferPayType) Data["type"],
                    (int) (uint) Data["price"]))
                {
                    vehData.Health = 1000.0f;
                    vehData.Save();

                    if (vehData.Spawned && vehData.VehicleHandle != null &&
                        NAPI.Entity.DoesEntityExist(vehData.VehicleHandle))
                        vehData.VehicleHandle.Repair();

                    // ReSharper disable once PossibleInvalidCastException
                    SendMessage($"Pojazd został naprawiony za kwotę ${(uint) Data["price"]}.");
                }
                else
                {
                    SendMessage("Pojazd nie został naprawiony z powodu błędu podczas pobierania opłaty.");
                }

                Destroy();
            }
            else if (Type == ProgressType.TattooCreate)
            {
                if (Offers.Library.PayForOffer(TargetData, CharData, (OfferPayType) Data["type"],
                    (int) (uint) Data["price"]))
                {
                    int tattooId = (int) Data["tattooId"];
                    CharData.SyncedTattoos.Add(tattooId);


                    using (Database.Database db = new Database.Database())
                    {
                        Tattoo newTattoo = new Tattoo
                        {
                            CharId = CharData.Id,
                            TattooId = tattooId
                        };
                        db.Tattoos.Add(newTattoo);
                        db.SaveChanges();
                    }

                    Sync.Library.SyncPlayerForPlayer(CharData.PlayerHandle);

                    // ReSharper disable once PossibleInvalidCastException
                    SendMessage($"Tatuaż został nałożony za kwotę ${(uint) Data["price"]}.");
                }
                else
                {
                    SendMessage("Tatuaż nie został nałożony z powodu błędu podczas pobierania opłaty.");
                }

                Destroy();
            }
        }

        /// <summary>
        /// Funkcja wysyłająca wiadomość do obu stron.
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(string message)
        {
            if (CharData != null && CharData.PlayerHandle != null && NAPI.Entity.DoesEntityExist(CharData.PlayerHandle))
                Player.SendFormattedChatMessage(CharData.PlayerHandle, $"(INFO) {message}", Constants.ColorPictonBlue);

            if (TargetData != null && TargetData.PlayerHandle != null && TargetData != CharData &&
                NAPI.Entity.DoesEntityExist(TargetData.PlayerHandle))
                Player.SendFormattedChatMessage(TargetData.PlayerHandle, $"(INFO) {message}",
                    Constants.ColorPictonBlue);
        }
    }
}