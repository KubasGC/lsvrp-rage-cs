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
using System.Security.Cryptography;
using System.Text;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Items;
using LSVRP.Managers;
using LSVRP.New.Enums;

namespace LSVRP.Libraries
{
    public static class Global
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Zwraca graczy w danym obszarze
        /// </summary>
        /// <param name="position"></param>
        /// <param name="range"></param>
        /// <param name="dimension"></param>
        /// <param name="exceptPlayer"></param>
        /// <returns></returns>
        public static IEnumerable<Character> GetPlayersInRange(Vector3 position, double range, uint dimension,
            Client exceptPlayer = null)
        {
            List<Character> output = new List<Character>();
            foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
            {
                if (exceptPlayer != null && entry.Value.PlayerHandle == exceptPlayer) continue;
                if (entry.Value.PlayerHandle.Dimension != dimension) continue;

                if (GetDistanceBetweenPositions(position, entry.Value.PlayerHandle.Position) <= range)
                    output.Add(entry.Value);
            }

            return output;
        }

        public static string GetOwnerName(int ownerType, int owner)
        {
            string output = "Nieznany";
            if (ownerType == 1) // GRACZ
            {
                using (Database.Database db = new Database.Database())
                {
                    Character charData = db.Characters.FirstOrDefault(t => t.Id == owner);
                    if (charData != null) output = $"{charData.Name} {charData.Lastname} (UID: {charData.Id})";
                }
            }
            else if (ownerType == 2) // GRUPA
            {
                Group groupData = Features.Groups.Library.GetGroupData(owner);
                if (groupData != null) output = $"{groupData.Name} (UID: {groupData.Id})";
            }

            return output;
        }

        /// <summary>
        /// Generuje losowy ciąg alfanumeryczny o podanej długości.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Zwraca funkcję frontalną przed podanym wektorem
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static Vector3 GetXyInFrontOfVector(Vector3 pos, Vector3 rot, float distance)
        {
            Vector3 newPos = pos;

            newPos.X += (float) Math.Sin(DegreeToRadian(-rot.Z)) * distance;
            newPos.Y += (float) Math.Cos(DegreeToRadian(-rot.Z)) * distance;

            return newPos;
        }

        /// <summary>
        /// Zmienia stopnie na radiany.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        /// <summary>
        /// Zmienia radiany na stopnie.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }


        /// <summary>
        /// Zwraca dystans pomiędzy dwoma wektorami.
        /// </summary>
        /// <param name="posFirst"></param>
        /// <param name="posSecond"></param>
        /// <returns></returns>
        public static double GetDistanceBetweenPositions(Vector3 posFirst, Vector3 posSecond)
        {
            return Math.Sqrt(Math.Pow(posFirst.X - posSecond.X, 2) + Math.Pow(posFirst.Y - posSecond.Y, 2) +
                             Math.Pow(posFirst.Z - posSecond.Z, 2));
        }

        /// <summary>
        /// Zwraca pozycję frontową od pozycji, ustalonego kąta oraz odległości.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="heading"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static Vector3 GetPositionInFrontOf(Vector3 position, float heading, float distance)
        {
            double x = distance * Math.Sin(-(heading * Math.PI / 180));
            double y = distance * Math.Cos(-(heading * Math.PI / 180));
            return new Vector3(position.X + x, position.Y + y, position.Z);
        }

        /// <summary>
        /// Zwraca aktualną datę w unixie
        /// </summary>
        /// <returns></returns>
        public static int GetTimestamp()
        {
            return (int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        /// <summary>
        /// Zwraca aktualna datę w unixie w milisekundach
        /// </summary>
        /// <returns></returns>
        public static double GetTimestampMs()
        {
            TimeSpan diff = DateTime.Now - new DateTime(1970, 1, 1);
            return Math.Floor(diff.TotalMilliseconds);
        }

        /// <summary>
        /// Generuje hash md5
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            foreach (byte t in data) sBuilder.Append(t.ToString("x2"));

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// Zwraca stringa, formatuje datę z timestampa unixowego
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static string GetTimeFromTimestamp(int timestamp)
        {
            DateTime fromUnix = DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
            return $"{fromUnix.Hour:00}:{fromUnix.Minute:00}:{fromUnix.Second:00}";
        }

        /// <summary>
        /// Zwraca losową liczbę z zakresu min:max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandom(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

        /// <summary>
        /// Zwraca wolny numer telefonu
        /// </summary>
        /// <returns></returns>
        public static int GetPhoneNumber()
        {
            using (Database.Database db = new Database.Database())
            {
                while (true)
                {
                    int number = GetRandom(111111, 999999);
                    if (!db.Items.Any(t => t.Type == ItemType.Phone && t.Value1 == number)) return number;
                }
            }
        }

        /// <summary>
        /// Zwraca sformatowany czas z sekund
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="withSeconds"></param>
        /// <param name="withDays"></param>
        /// <returns></returns>
        public static string GetFormattedTime(int seconds, bool withSeconds = false, bool withDays = false)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            if (withSeconds)
            {
                if (withDays)
                    return $"{Math.Floor(time.TotalDays)}d {time.Hours:00}h {time.Minutes:00}m {time.Seconds:00}s";
                return $"{Math.Floor(time.TotalHours)}h {time.Minutes:00}m {time.Seconds:00}s";
            }

            if (withDays) return $"{Math.Floor(time.TotalDays)}d {time.Hours:00}h {time.Minutes:00}m";
            return $"{Math.Floor(time.TotalHours)}h {time.Minutes:00}m";
        }

        /// <summary>
        /// Konwertuje znaki specjalne na znaki HTML
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EscapeHtml(string text)
        {
            return text.Replace("\"", "&#34;").Replace("'", "&#039;").Replace("`", "&#96;");
        }

        /// <summary>
        /// Wysyła wiadomość do administratorów
        /// </summary>
        /// <param name="message"></param>
        /// <param name="onDuty"></param>
        /// <param name="inUi"></param>
        public static void SendMessageToAdmins(string message, bool onDuty, bool inUi)
        {
            foreach (KeyValuePair<int, Character> entry in Account.GetAllPlayers())
            {
                if (entry.Value.AdminLevel <= 0 || onDuty && !entry.Value.HasAdminDuty) continue;
                if (inUi)
                    Ui.ShowInfo(entry.Value.PlayerHandle, message);
                else
                    entry.Value.PlayerHandle.SendChatMessage(message);
            }
        }

        /// <summary>
        /// Zwraca wartość interpolacyjną od value1 do value2 w zależności od amount (zakres 0:1)
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static float Lerp(float value1, float value2, float amount)
        {
            amount = amount < 0 ? 0 : amount;
            amount = amount > 1 ? 1 : amount;
            return value1 + (value2 - value1) * amount;
        }
    }
}