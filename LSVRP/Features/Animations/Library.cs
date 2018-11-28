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

namespace LSVRP.Features.Animations
{
    public static class Library
    {
        /// <summary>
        /// Przechowuje dane o animacjach załadowane z bazy danych.
        /// </summary>
        private static readonly Dictionary<string, Animation> AnimationsList = new Dictionary<string, Animation>();

        /// <summary>
        /// Zwraca wartość słownika przechowującego dane o animacjach załadowynch z bazy danych.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Animation> GetAnimationsList()
        {
            return AnimationsList;
        }

        /// <summary>
        /// Zwraca dane animacji o konkretnej komendzie.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static Animation GetAnimation(string command)
        {
            return AnimationsList.ContainsKey(command) ? AnimationsList[command] : null;
        }

        /// <summary>
        /// Ładuje wszystkie animacje z bazy danych.
        /// </summary>
        public static void LoadAnimations()
        {
            double startTime = Global.GetTimestampMs();
            using (Database.Database db = new Database.Database())
            {
                List<Animation> animations = db.Animations.ToList();
                foreach (Animation entry in animations) AnimationsList.Add(entry.AnimationCommand, entry);

                Log.ConsoleLog("ANIMATIONS",
                    $"Załadowano animacje ({AnimationsList.Count}) | {Global.GetTimestampMs() - startTime}ms");
            }
        }

        /// <summary>
        /// Zwraca odpowiednią flagę animacji.
        /// </summary>
        /// <param name="animData"></param>
        /// <returns></returns>
        public static int BuildAnimationFlags(Animation animData)
        {
            AnimationFlags output = AnimationFlags.None;
            if (animData.Loop) output = output | AnimationFlags.Loop;
            if (animData.StopOnLastFrame) output = output | AnimationFlags.StopOnLastFrame;
            if (animData.OnlyAnimateUpperBody) output = output | AnimationFlags.OnlyAnimateUpperBody;
            if (animData.AllowPlayerControl) output = output | AnimationFlags.AllowPlayerControl;
            if (animData.Cancellable) output = output | AnimationFlags.Cancellable;
            return (int) output;
        }

        /// <summary>
        /// Odtwarza animację danego gracza.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="animData"></param>
        public static void PlayAnimation(Character charData, Animation animData)
        {
            if (animData.AnimationName == "stopani")
            {
                NAPI.Player.StopPlayerAnimation(charData.PlayerHandle);
                NAPI.ClientEvent.TriggerClientEvent(charData.PlayerHandle, "client.animation.hideInfo");
                charData.AnimPlayer = null;
                Sync.Library.SyncPlayerForPlayer(charData.PlayerHandle);
            }
            else
            {
                if (animData.ItemId != 0)
                    charData.AnimPlayer = new AnimPlayer
                    {
                        ObjectId = animData.ItemId,
                        BoneName = animData.ItemBoneName,
                        Position = new Vector3(animData.ItemX, animData.ItemY, animData.ItemZ),
                        Rotation = new Vector3(animData.ItemRotX, animData.ItemRotY, animData.ItemRotZ)
                    };

                NAPI.ClientEvent.TriggerClientEvent(charData.PlayerHandle, "client.animation.showInfo");
                // TODO: Jakieś lepsze synchronizowanie
                int animFlags = BuildAnimationFlags(animData);
                foreach (Client entry in NAPI.Pools.GetAllPlayers())
                    NAPI.ClientEvent.TriggerClientEvent(entry, "client.animation.sync", charData.PlayerHandle.Value,
                        animData.AnimationDictionary, animData.AnimationName, animFlags);

                Sync.Library.SyncPlayerForPlayer(charData.PlayerHandle);
            }
        }
    }
}