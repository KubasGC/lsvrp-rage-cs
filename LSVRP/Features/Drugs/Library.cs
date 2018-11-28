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
using System.Linq;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Libraries;
using Log = LSVRP.Modules.Log;

namespace LSVRP.Features.Drugs
{
    public static class Library
    {
        public static readonly Dictionary<int, DrugEffect> DrugEffects = new Dictionary<int, DrugEffect>();

        /// <summary>
        /// Ładuje dane narkotyków z bazy danych.
        /// </summary>
        public static void Load()
        {
            using (Database.Database db = new Database.Database())
            {
                double startTime = Global.GetTimestampMs();

                foreach (DrugEffect entry in db.DrugEffects.ToList()) DrugEffects.Add(entry.Id, entry);

                Log.ConsoleLog("DRUGS",
                    $"Załadowano efekty narkotykow ({DrugEffects.Count}) | {Global.GetTimestampMs() - startTime}ms");
            }
        }

        /// <summary>
        /// Zwraca dane efektu, null jeśli taki efekt nie istnieje.
        /// </summary>
        /// <param name="effectId"></param>
        /// <returns></returns>
        public static DrugEffect GetDrugEffect(int effectId)
        {
            return DrugEffects.ContainsKey(effectId) ? DrugEffects[effectId] : null;
        }

        /// <summary>
        /// Uruchamia efekt narkotyków dla podanego gracza.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="effectId"></param>
        public static void StartEffectForPlayer(Client player, int effectId)
        {
            DrugEffect effectData = GetDrugEffect(effectId);
            if (effectData == null) return;
            NAPI.ClientEvent.TriggerClientEvent(player, "client.drugs.startEffect", effectData.EffectName);
        }

        /// <summary>
        /// Zatrzymuje efekt narkotyków dla podanego gracza.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="effectId"></param>
        public static void StopEffectForPlayer(Client player, int effectId)
        {
            DrugEffect effectData = GetDrugEffect(effectId);
            if (effectData == null) return;
            NAPI.ClientEvent.TriggerClientEvent(player, "client.drugs.stopEffect", effectData.EffectName);
        }

        /// <summary>
        /// Zatrzymuje wszystkie efekty.
        /// </summary>
        /// <param name="player"></param>
        public static void StopAllEffectsForPlayer(Client player)
        {
            foreach (KeyValuePair<int, DrugEffect> entry in DrugEffects)
                NAPI.ClientEvent.TriggerClientEvent(player, "client.drugs.stopEffect", entry.Value.EffectName);
        }

        /// <summary>
        /// Zwraca losową wiadomość.
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string GetRandomMessage(string[] messages, string prefix = "")
        {
            int random = Global.GetRandom(0, messages.Length - 1);
            return $"{prefix}{messages[random]}";
        }
    }
}