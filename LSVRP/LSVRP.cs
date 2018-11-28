/*
*  Art. 74 Ustawy o prawie autorskim:
*  1. Programy komputerowe podlegają ochronie jak utwory literackie, o ile przepisy niniejszego rozdziału nie stanowią inaczej.
*	2. Ochrona przyznana programowi komputerowemu obejmuje wszystkie formy jego wyrażenia. Idee i zasady będące podstawą jakiegokolwiek elementu programu komputerowego, w tym podstawą łączy, nie podlegają ochronie.
*	3. Prawa majątkowe do programu komputerowego stworzonego przez pracownika w wyniku wykonywania obowiązków ze stosunku pracy przysługują pracodawcy, o ile umowa nie stanowi inaczej.
*	4. Autorskie prawa majątkowe do programu komputerowego, z zastrzeżeniem przepisów art. 75 ust. 2 i 3, obejmują prawo do:
*		1) trwałego lub czasowego zwielokrotnienia programu komputerowego w całości lub w części jakimikolwiek środkami i w jakiejkolwiek formie; w zakresie, w którym dla wprowadzania, wyświetlania, stosowania, przekazywania i przechowywania programu komputerowego niezbędne jest jego zwielokrotnienie, czynności te wymagają zgody uprawnionego;
*		2) tłumaczenia, przystosowywania, zmiany układu lub jakichkolwiek innych zmian w programie komputerowym, z zachowaniem praw osoby, która tych zmian dokonała;
*		3) rozpowszechniania, w tym użyczenia lub najmu, programu komputerowego lub jego kopii.
*
*
* LSVRP C# Engine
* Script dedicated for Role-play server in Grand Theft Auto V game based on the external Multiplayer called Rage Multiplayer
* @Author: Kubas
* @StartDate: Jun 2018
*
*
* @urls:
* 		@RAGE-MP  	    https://rage.mp
* 		@LSVRP:			https://lsvrp.pl
*
* All Rights Reserved
* Copyright prohibited
*
*/

using System;
using System.Linq;
using System.Text;
using GTANetworkAPI;
using LSVRP.Features.Groups;
using LSVRP.Libraries;
using LSVRP.Managers;
using Color = System.Drawing.Color;
using Console = Colorful.Console;
using Log = LSVRP.Modules.Log;
using LogType = LSVRP.Modules.LogType;

namespace LSVRP
{
    public class Lsvrp : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void ServerStart()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs args)
            {
                Log.ConsoleLog("SHUTDOWN", "Wyłączanie serwera...");
                args.Cancel = true;
            };

            double startTime = Global.GetTimestampMs();
            Log.ConsoleLog("MAIN", "Inicjalizacja skryptu Los Santos V Role-Play...");
            NAPI.Server.SetGlobalServerChat(false); // Wyłączenie globalnego domyślnego czatu
            NAPI.Server.SetAutoSpawnOnConnect(false); // Wyłączenie automatycznego spawnu gracza po dołączeniu
            NAPI.Server.SetAutoRespawnAfterDeath(false); // Wyłączenie automatycznego respawnu po śmierci
            NAPI.Server.SetGlobalDefaultCommandMessages(false); // Wyłączenie domyślnych odpowiedzi do komend
            // NAPI.Server.SetDefaultSpawnLocation(); TODO

            // Ładowanie systemów
            Library.LoadGroups(); // Ładowanie grup
            Features.Vehicles.Library.LoadVehicles(); // Ładowanie pojazdów
            New.Managers.ItemsManager.Load(); // [NEW] Ładowanie przedmiotów
            // Features.Items.Library.LoadItems(); // Ładowanie przedmiotów
            Features.Blips.Library.LoadBlips(); // Ładowanie blipów
            Features.Animations.Library.LoadAnimations(); // Ładowanie animacji
            Features.Interiors.Library.LoadInteriors(); // Ładowanie interiorów
            Features.Interiors.Library.LoadInteriorsDoors(); // Ładowanie drzwi interiorów
            Features.Corners.Library.LoadCorners();
            Features.Shops.Library.LoadShops(); // Ładowanie sklepów
            Features.Timers.Library.StartTimer(); // Włączanie timera
            Features.Socket.Library.StartSocket(); // Włączanie serwera socket
            Features.Drugs.Library.Load(); // Ładowanie narkotyków
            Features.Objects.Library.LoadObjects(); // Ładowanie obiektów
            Features.Houses.Library.LoadHouses(); // Ładowanie mieszkań

            // Features.Tattoos.Library.RenderClientsideTattooList(); // Tworzenie tatuaży dla clientside

            using (Database.Database db = new Database.Database())
            {
                db.Characters.ToList().ForEach(t => t.InGame = false);
                db.SaveChanges();
                Log.ConsoleLog("INGAME", "Zresetowano licznik graczy online.");
            }

            Log.ConsoleLog("MAIN", $"Zakończono ładowanie modułów. | {Global.GetTimestampMs() - startTime}ms");

            Console.WriteAscii($"LSVRP {Constants.ScriptVersion}", Color.White);

            if (Configuration.Get().DebugMode) Log.ConsoleLog("MAIN", "DebugMode jest WŁĄCZONY.", LogType.Warning);

             // Features.Timers.Library.CountPayday(); // tylko do testów
        }
    }
}