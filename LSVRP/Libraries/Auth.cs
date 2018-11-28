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
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace LSVRP.Libraries
{
    public static class Auth
    {
        private static string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream ?? throw new InvalidOperationException(),
                        Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream ?? throw new InvalidOperationException(),
                        Encoding.GetEncoding("utf-8"));
                    string errorText = reader.ReadToEnd();
                    return errorText;
                }
            }
        }

        public static bool AuthUser(string username, string password)
        {
            string text =
                Get(
                    $"https://lsvrp.pl/index.php?app=lsvrp&module=api&controller=main&do=authUser&username={username}&password={password}");
            if (text.Contains("Nie znaleziono uzytkownika.")) return false;
            JObject parse = JObject.Parse(text);
            return parse["status"].ToString().Contains("ok");
        }
    }
}