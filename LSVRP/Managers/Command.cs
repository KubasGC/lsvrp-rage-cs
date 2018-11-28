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
using System.Text;
using System.Text.RegularExpressions;

namespace LSVRP.Managers
{
    public static class Command
    {
        public const int InvalidNumber = -65535;

        /// <summary>
        /// Zwraca stringa z połączonych argumentów
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="startAt"></param>
        /// <returns></returns>
        public static string GetConcatString(string[] arguments, int startAt = 0)
        {
            if (startAt > arguments.Length - 1) return null;
            StringBuilder result = new StringBuilder();
            for (int i = startAt; i < arguments.Length; i++)
            {
                result.Append(arguments[i]);
                if (i != arguments.Length - 1) result.Append(" ");
            }

            string output = result.ToString().Replace("!{", "");
            return output;
        }

        /// <summary>
        /// Zwraca liczbę przekonwertowaną ze stringa, jeśli niepoprawna - zwraca InvalidNumber
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int GetNumberFromString(string text)
        {
            return int.TryParse(text, out int result) ? result : InvalidNumber;
        }

        public static double GetDoubleFromString(string text)
        {
            return double.TryParse(text, out double result) ? result : InvalidNumber;
        }

        /// <summary>
        /// Zwraca stringa ze sformatowanym czasem liczonym w sekundach
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="withSeconds"></param>
        /// <returns></returns>
        public static string GetFormattedOnlineTime(int seconds, bool withSeconds = false)
        {
            decimal hour = Math.Floor(seconds / (decimal) 3600);
            decimal minute = Math.Floor((decimal) seconds / 60) - hour * 60;

            if (withSeconds)
            {
                decimal second = seconds - minute * 60 - hour * 3600;
                return $"{hour:00} h {minute:00} m {second:00} s";
            }

            return $"{hour:00} h {minute:00} m";
        }

        /// <summary>
        /// Zwraca tablicę stringów zawierającą całą komendę
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string[] GetCommandArguments(string text)
        {
            if (text == null) return new string[0];
            return text.Length < 1 ? new string[0] : text.Split(' ');
        }

        /// <summary>
        /// Zwraca stringa z dodaną kropką na końcu
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EndDot(string text)
        {
            if (!(text.EndsWith(".") || text.EndsWith("!") || text.EndsWith("?")))
                text += ".";

            return text;
        }

        /// <summary>
        /// Zwraca stringa który może mieć pierwszą wielką literę i kropkę na końcu w zależności od ustawień
        /// </summary>
        /// <param name="text"></param>
        /// <param name="withDot"></param>
        /// <param name="withUpper"></param>
        /// <returns></returns>
        public static string UpperFirst(string text, bool withDot = true, bool withUpper = true)
        {
            string output = text;

            if (withDot && !(text.EndsWith(".") || text.EndsWith("!") || text.EndsWith("?")))
                output += ".";

            if (withUpper) output = char.ToUpper(output[0]) + (output.Length > 1 ? output.Substring(1) : string.Empty);

            return output;
        }

        /// <summary>
        /// Returns a string with backslashes before characters that need to be quoted
        /// </summary>
        /// <param name="inputTxt">Text string need to be escape with slashes</param>
        public static string AddSlashes(string inputTxt)
        {
            // List of characters handled:
            // \000 null
            // \010 backspace
            // \011 horizontal tab
            // \012 new line
            // \015 carriage return
            // \032 substitute
            // \042 double quote
            // \047 single quote
            // \134 backslash
            // \140 grave accent

            string result = inputTxt;

            try
            {
                result = Regex.Replace(inputTxt,
                    @"[\000\010\011\012\015\032\042\047\134\140]", "\\$0");
            }
            catch (Exception ex)
            {
                // handle any exception here
                Console.WriteLine(ex.Message);
            }

            result = result.Replace("'", "\\'");

            return result;
        }
    }
}