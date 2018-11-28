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
using LSVRP.Libraries;
using Blip = LSVRP.Database.Models.Blip;
using Log = LSVRP.Modules.Log;

namespace LSVRP.Features.Blips
{
    public static class Library
    {
        /// <summary>
        /// Lista blipów
        /// </summary>
        private static readonly Dictionary<int, Blip> BlipsList = new Dictionary<int, Blip>();

        /// <summary>
        /// Ładuje blipy z bazy danych do pamięci
        /// </summary>
        public static void LoadBlips()
        {
            double startTime = Global.GetTimestampMs();
            using (Database.Database db = new Database.Database())
            {
                List<Blip> blipsList = db.Blips.ToList();
                foreach (Blip entry in blipsList)
                {
                    entry.BlipHandle = NAPI.Blip.CreateBlip(entry.SpriteId,
                        new Vector3(entry.X, entry.Y, entry.Z),
                        entry.Scale, (byte) entry.ColorId, entry.Name, (byte) entry.Alpha, 999999.0f, true, 0,
                        (uint) entry.Dimension);
                    BlipsList.Add(entry.Id, entry);
                }
            }

            Log.ConsoleLog("BLIPS",
                $"Załadowano blipy ({BlipsList.Count}) | {Global.GetTimestampMs() - startTime}ms");
        }

        /// <summary>
        /// Tworzy nowego blipa
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="spriteId"></param>
        /// <param name="colorId"></param>
        /// <param name="alpha"></param>
        /// <param name="scale"></param>
        /// <param name="dimension"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public static Blip CreateBlip(string name, Vector3 position, int spriteId, int colorId, int alpha,
            float scale, int dimension, int createdBy)
        {
            Blip newBlip = new Blip
            {
                Name = name,
                X = position.X,
                Y = position.Y,
                Z = position.Z,
                SpriteId = spriteId,
                ColorId = colorId,
                Alpha = alpha,
                Scale = scale,
                Dimension = dimension,
                CreatedBy = createdBy,
                CreatedAt = Global.GetTimestamp()
            };
            using (Database.Database db = new Database.Database())
            {
                db.Blips.Add(newBlip);
                db.SaveChanges();

                newBlip.BlipHandle = NAPI.Blip.CreateBlip(newBlip.SpriteId,
                    new Vector3(newBlip.X, newBlip.Y, newBlip.Z),
                    newBlip.Scale, (byte) newBlip.ColorId, newBlip.Name, (byte) newBlip.Alpha, 999999.0f, true, 0,
                    (uint) newBlip.Dimension);

                BlipsList.Add(newBlip.Id, newBlip);
                return newBlip;
            }
        }

        /// <summary>
        /// Usuwa blipa o podanym Id
        /// </summary>
        /// <param name="blipId"></param>
        public static void DestroyBlip(int blipId)
        {
            Blip blipData = GetBlipData(blipId);
            if (blipData == null) return;

            if (NAPI.Entity.DoesEntityExist(blipData.BlipHandle)) NAPI.Entity.DeleteEntity(blipData.BlipHandle);

            using (Database.Database db = new Database.Database())
            {
                db.Blips.Attach(blipData);
                db.Blips.Remove(blipData);
                db.SaveChanges();
            }

            BlipsList.Remove(blipData.Id);
        }

        /// <summary>
        /// Zwraca dane blipa o danym Id
        /// </summary>
        /// <param name="blipId"></param>
        /// <returns></returns>
        public static Blip GetBlipData(int blipId)
        {
            return !BlipsList.ContainsKey(blipId) ? null : BlipsList[blipId];
        }

        /// <summary>
        /// Zwraca blipa znajdującego się najbliżej podanej pozycji
        /// </summary>
        /// <param name="position"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static Blip GetNearestBlip(Vector3 position, double distance = 10.0)
        {
            double nearestDistance = distance;
            Blip choosedBlip = null;
            foreach (KeyValuePair<int, Blip> entry in BlipsList)
            {
                double dist = Global.GetDistanceBetweenPositions(new Vector3(entry.Value.X, entry.Value.Y, 0),
                    new Vector3(position.X, position.Y, 0));
                if (dist > nearestDistance) continue;

                nearestDistance = dist;
                choosedBlip = entry.Value;
            }

            return choosedBlip;
        }
    }
}