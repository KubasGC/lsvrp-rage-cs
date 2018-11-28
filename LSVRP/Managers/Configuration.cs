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
using System.IO;
using LSVRP.Modules;
using Newtonsoft.Json;

// ReSharper disable MemberCanBePrivate.Global

namespace LSVRP.Managers
{
    public class Configuration
    {
        [JsonIgnore] private static Configuration _instance;

        private Configuration()
        {
        }

        public string DatabaseHost { get; set; }
        public string DatabaseUser { get; set; }
        public string DatabasePass { get; set; }
        public string DatabaseDb { get; set; }
        public string DatabasePort { get; set; }
        public bool DebugMode { get; set; }


        public static Configuration Get()
        {
            if (_instance != null) return _instance;

            if (!File.Exists("lsvrp/config.json"))
            {
                FileStream file = File.Create("lsvrp/config.json");
                file.Close();

                _instance = new Configuration
                {
                    DatabaseHost = "host",
                    DatabaseUser = "user",
                    DatabasePass = "pass",
                    DatabaseDb = "db",
                    DatabasePort = "3306",
                    DebugMode = false
                };


                using (StreamWriter textWriter = new StreamWriter("lsvrp/config.json", true))
                {
                    textWriter.Write(JsonConvert.SerializeObject(_instance, Formatting.Indented));
                    textWriter.Close();
                }

                Log.ConsoleLog("WARNING", "Nie znaleziono pliku konfiguracyjnego. Został utworzony nowy.");
                return _instance;
            }

            using (StreamReader file = File.OpenText("lsvrp/config.json"))
            {
                JsonSerializer serialize = new JsonSerializer();
                _instance = (Configuration) serialize.Deserialize(file, typeof(Configuration));
                Log.ConsoleLog("CONFIG", "Załadowano plik konfiguracyjny.");
                return _instance;
            }
        }
    }
}