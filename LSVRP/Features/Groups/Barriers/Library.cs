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
using LSVRP.Libraries;

namespace LSVRP.Features.Groups.Barriers
{
    public static class Library
    {
        private static readonly IDictionary<int, Barrier> BarriersList = new Dictionary<int, Barrier>();

        /// <summary>
        /// Tworzy nową barierkę.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="objectId"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="dimension"></param>
        public static Barrier CreateBarrier(int groupId, int objectId, Vector3 position, Vector3 rotation,
            uint dimension)
        {
            Barrier newBarrier = new Barrier
            {
                Id = GetNearestId(),
                GroupId = groupId,
                Dimension = dimension,
                ObjectHandle = NAPI.Object.CreateObject(objectId, position, rotation, 255, dimension)
            };

            BarriersList.Add(newBarrier.Id, newBarrier);
            return newBarrier;
        }

        /// <summary>
        /// Pobiera najmniejsze Id.
        /// </summary>
        /// <returns></returns>
        public static int GetNearestId()
        {
            int i = 0;
            while (true)
            {
                if (!BarriersList.ContainsKey(i)) return i;
                i++;
            }
        }

        /// <summary>
        /// Usuwa barierkę.
        /// </summary>
        /// <param name="barrier"></param>
        public static void DeleteBarrier(Barrier barrier)
        {
            if (NAPI.Entity.DoesEntityExist(barrier.ObjectHandle)) barrier.ObjectHandle.Delete();
            if (BarriersList.ContainsKey(barrier.Id)) BarriersList.Remove(barrier.Id);
        }


        /// <summary>
        /// Pobiera najbliższą barierkę.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="groupId"></param>
        /// <param name="dim"></param>
        /// <returns></returns>
        public static Barrier GetNearestBarrier(Vector3 pos, int groupId, uint dim)
        {
            double dist = 5.0;
            Barrier output = null;

            foreach (KeyValuePair<int, Barrier> entry in BarriersList)
            {
                if (entry.Value.GroupId != groupId) continue;
                if (entry.Value.Dimension != dim) continue;
                if (!NAPI.Entity.DoesEntityExist(entry.Value.ObjectHandle)) continue;

                double calcDist = Global.GetDistanceBetweenPositions(pos, entry.Value.ObjectHandle.Position);
                if (calcDist < dist)
                {
                    dist = calcDist;
                    output = entry.Value;
                }
            }

            return output;
        }
    }
}