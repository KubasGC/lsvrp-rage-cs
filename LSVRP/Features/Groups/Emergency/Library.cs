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

namespace LSVRP.Features.Groups.Emergency
{
    public static class Library
    {
        public static readonly Dictionary<int, EmergencyPhone> EmergencyPhones = new Dictionary<int, EmergencyPhone>();

        /// <summary>
        /// Zwraca najniższe wolne Id dla rozmowy
        /// </summary>
        /// <returns></returns>
        public static int GetLowestId()
        {
            int index = 0;
            while (true)
            {
                if (!EmergencyPhones.ContainsKey(index)) return index;
                index++;
            }
        }

        /// <summary>
        /// Automatycznie usuwa zalegające zgłoszenia po czasie nieaktywności
        /// </summary>
        public static void AutoRemove()
        {
            int nowTimestamp = Global.GetTimestamp();
            foreach (KeyValuePair<int, EmergencyPhone> entry in EmergencyPhones)
                if (nowTimestamp - entry.Value.LastAction > 1800)
                    EmergencyPhones.Remove(entry.Key);
        }

        /// <summary>
        /// Usuwa zgłoszenie o podanym Id
        /// </summary>
        /// <param name="callId"></param>
        public static void DeleteCall(int callId)
        {
            EmergencyPhones.Remove(callId);
        }

        /// <summary>
        /// Pobiera informacje nt. zgłoszenia o podanym Id
        /// </summary>
        /// <param name="callId"></param>
        /// <returns></returns>
        public static EmergencyPhone GetPhoneCallInfo(int callId)
        {
            return EmergencyPhones.ContainsKey(callId) ? EmergencyPhones[callId] : null;
        }

        /// <summary>
        /// Dodaje nowe zgłoszenie jednocześnie informując o nim grupy
        /// </summary>
        /// <param name="player"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="groupType"></param>
        /// <param name="phoneMessage"></param>
        public static void CreatePhoneCall(Client player, int phoneNumber, int groupType, string phoneMessage)
        {
            int index = GetLowestId();
            EmergencyPhone newClass = new EmergencyPhone
            {
                Id = index,
                GroupType = groupType,
                LastAction = Global.GetTimestamp(),
                Messages = new List<EmergencyPhoneMessage>(),
                PhoneNumber = phoneNumber,
                Position = player.Position,
                TimeAdded = Global.GetTimestamp()
            };
            newClass.Messages.Add(new EmergencyPhoneMessage(Global.GetTimestamp(), phoneMessage));
            Groups.Library.SendGroupTypeOocMessage(groupType, "Nadeszło nowe zgłoszenie. Sprawdź je za pomocą komendy" +
                                                              "/zgłoszenia lub /g [slot] zgłoszenia.");
            EmergencyPhones.Add(newClass.Id, newClass);
        }

        /// <summary>
        /// Pobiera zgłoszenia przypisane do danego typu grupy
        /// </summary>
        /// <param name="groupType"></param>
        /// <returns></returns>
        public static List<EmergencyPhone> GetPhoneCallsByGroupType(int groupType)
        {
            List<EmergencyPhone> output = new List<EmergencyPhone>();
            foreach (KeyValuePair<int, EmergencyPhone> entry in EmergencyPhones)
                if (entry.Value.GroupType == groupType)
                    output.Add(entry.Value);

            return output.Count > 0 ? output : null;
        }

        /// <summary>
        /// Dodaje nową wiadomość do istniejącego zgłoszenia
        /// </summary>
        /// <param name="callId"></param>
        /// <param name="newMessage"></param>
        public static void CreatePhoneCallMessage(int callId, string newMessage)
        {
            EmergencyPhone callInfo = GetPhoneCallInfo(callId);
            if (callInfo == null) return;
            if (callInfo.Messages.Count > 10)
                callInfo.Messages.RemoveAt(1);
            callInfo.Messages.Add(new EmergencyPhoneMessage(Global.GetTimestamp(), newMessage));
        }
    }
}