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
using Log = LSVRP.Modules.Log;
using Object = LSVRP.Database.Models.Object;

namespace LSVRP.Features.Objects
{
    public static class Library
    {
        /// <summary>
        /// Słownik zawierający wszystkie obiekty.
        /// </summary>
        private static readonly Dictionary<int, Object> ObjectsList = new Dictionary<int, Object>();

        /// <summary>
        /// Ładuje wszystkie obiekty z bazy danych.
        /// </summary>
        public static void LoadObjects()
        {
            using (Database.Database db = new Database.Database())
            {
                double startTime = Global.GetTimestampMs();
                foreach (Object entry in db.Objects.ToList())
                {
                    entry.Create();
                    ObjectsList.Add(entry.Id, entry);
                }

                Log.ConsoleLog("OBJECTS",
                    $"Załadowano obiekty ({ObjectsList.Count}) | {Global.GetTimestampMs() - startTime}ms");
            }
        }


        /// <summary>
        /// Zwraca dane obiektu o podanym Id.
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public static Object GetObjectData(int objectId)
        {
            return ObjectsList.ContainsKey(objectId) ? ObjectsList[objectId] : null;
        }

        /// <summary>
        /// Zwraca dane obiektu o podanym remoteId.
        /// </summary>
        /// <param name="remoteId"></param>
        /// <returns></returns>
        public static Object GetObjectDataByRemoteId(int remoteId)
        {
            foreach (KeyValuePair<int, Object> entry in ObjectsList)
                if (entry.Value.ObjectHandle != null && NAPI.Entity.DoesEntityExist(entry.Value.ObjectHandle) &&
                    entry.Value.ObjectHandle.Value == remoteId)
                    return entry.Value;

            return null;
        }

        /// <summary>
        /// Tworzy nowy obiekt.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="doors"></param>
        /// <param name="dimension"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static Object CreateObject(int model, int doors, int dimension, Vector3 position, Vector3 rotation,
            int alpha)
        {
            using (Database.Database db = new Database.Database())
            {
                Object newObject = new Object
                {
                    Model = model,
                    DoorId = doors,
                    Dimension = dimension,
                    PosX = position.X,
                    PosY = position.Y,
                    PosZ = position.Z,
                    RotX = rotation.X,
                    RotY = rotation.Y,
                    RotZ = rotation.Z,
                    Alpha = alpha,
                    EditedBy = null
                };

                db.Objects.Add(newObject);
                db.SaveChanges();

                ObjectsList.Add(newObject.Id, newObject);
                newObject.Create();

                return newObject;
            }
        }
    }
}