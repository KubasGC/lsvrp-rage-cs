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

namespace LSVRP.Features.Groups
{
    /// <summary>
    /// Przechowuje informacje o duty gracza
    /// </summary>
    [Serializable]
    public class PlayerDutyInfo
    {
        public string GroupTag { get; set; }
        public int[] GroupColor { get; set; }
    }

    /// <summary>
    /// Przechowuje informacje wiadomości wysłanej na numer alarmowy
    /// </summary>
    public class EmergencyPhoneMessage
    {
        public EmergencyPhoneMessage(int timestamp, string message)
        {
            Timestamp = timestamp;
            Message = message;
        }

        public int Timestamp { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// Przechowuje informacje o numerze alarmowym
    /// </summary>
    public class EmergencyPhone
    {
        public int Id { get; set; }
        public int GroupType { get; set; }
        public int PhoneNumber { get; set; }
        public Vector3 Position { get; set; }
        public List<EmergencyPhoneMessage> Messages { get; set; }
        public int TimeAdded { get; set; }
        public int LastAction { get; set; }
    }

    /// <summary>
    /// Przechowuje informacje o skutej osobie
    /// </summary>
    public class CuffData
    {
        public CuffData(int type, Client player)
        {
            Type = type;
            Player = player;
        }

        public int Type { get; set; }
        public Client Player { get; set; }
    }

    public static class Data
    {
        public static IEnumerable<int> NoEngineVehicles = new List<int> {13};
    }
}