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

//using GTANetworkAPI;
//using LSVRP.Database.Models;
//using LSVRP.Features.Animations;
//using LSVRP.Features.Dialogs;
//using LSVRP.Libraries;
//using LSVRP.Managers;
//using Newtonsoft.Json;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using LSVRP.New.Constants;
//using LSVRP.New.Core.Items;
//using LSVRP.New.Enums;
//using Log = LSVRP.Modules.Log;
//using Vehicle = LSVRP.Database.Models.Vehicle;
//
//namespace LSVRP.Features.Items
//{
//    public static class LibraryOld
//    {
//        /// <summary>
//        /// Słownik zawierający wszystkie przedmioty
//        /// </summary>
//        private static readonly Dictionary<int, Item> ItemsList = new Dictionary<int, Item>();
//
//        /// <summary>
//        /// Funkcja zwracająca słownik z wszystkimi przedmiotami
//        /// </summary>
//        /// <returns></returns>
//        public static Dictionary<int, Item> GetAllItems()
//        {
//            return ItemsList;
//        }
//
//        public static string GetItemTypeName(ItemType itemType)
//        {
//            return ItemsConstants.ItemTypesName.ContainsKey(itemType)
//                ? ItemsConstants.ItemTypesName[itemType]
//                : "Nieznany";
//        }
//
//        /// <summary>
//        /// Funkcja uruchamiana wraz ze startem serwera. Ładuje wszystkie przedmioty do pamięci
//        /// </summary>
//        public static void LoadItems()
//        {
//            double startTime = Global.GetTimestampMs();
//            using (Database.Database db = new Database.Database())
//            {
//                List<Item> items = db.Items.ToList();
//                foreach (Item entry in items)
//                {
//                    ItemsList.Add(entry.Id, entry);
//                    if (entry.OwnerType == OwnerType.Ground)
//                        entry.MakeItemOnGround(new Vector3(entry.X, entry.Y, entry.Z), new Vector3(entry.RotZ, 0, 0),
//                            (uint) entry.Dimension, false);
//                }
//
//                Log.ConsoleLog("ITEMS",
//                    $"Załadowano przedmioty ({ItemsList.Count}) | {Global.GetTimestampMs() - startTime}ms");
//            }
//        }
//
//        /// <summary>
//        /// Funkcja tworząca przedmiot na ziemi
//        /// </summary>
//        /// <param name="item"></param>
//        /// <param name="pos"></param>
//        /// <param name="rot"></param>
//        /// <param name="dim"></param>
//        /// <param name="withSave"></param>
//        private static void MakeItemOnGround(this Item item, Vector3 pos, Vector3 rot, uint dim, bool withSave = true)
//        {
//            if (item.OwnerType != OwnerType.Ground) return;
//
//            item.ObjectHandle = NAPI.Object.CreateObject(Dropable.GetHashFromItem(item.Type, item.Value1), pos,
//                rot, 255, dim);
//
//            item.X = pos.X;
//            item.Y = pos.Y;
//            item.Z = pos.Z;
//
//            if (withSave) item.Save();
//        }
//
//        /// <summary>
//        /// Funkcja tworząca przedmiot na ziemi
//        /// </summary>
//        /// <param name="itemId"></param>
//        public static void MakeItemOnGround(int itemId, Vector3 pos, Vector3 rot, uint dim)
//        {
//            Item itemData = GetItemData(itemId);
//            if (itemData != null)
//                MakeItemOnGround(itemData, pos, rot, dim);
//        }
//
//        /// <summary>
//        /// Funkcja niszcząca przedmiot na ziemi
//        /// </summary>
//        /// <param name="item"></param>
//        private static void DestroyItemOnGround(this Item item)
//        {
//            // TODO DestroyItemOnGround
//            if (item.ObjectHandle != null)
//                item.ObjectHandle.Delete();
//        }
//
//        /// <summary>
//        /// Funkcja niszcząca przedmiot na ziemi
//        /// </summary>
//        /// <param name="itemId"></param>
//        public static void DestroyItemOnGround(int itemId)
//        {
//            Item itemData = GetItemData(itemId);
//            itemData?.DestroyItemOnGround();
//        }
//
//        /// <summary>
//        /// Zwraca informacje o przedmiocie o podanym Id
//        /// </summary>
//        /// <param name="itemId"></param>
//        /// <returns></returns>
//        public static Item GetItemData(int itemId)
//        {
//            return ItemsList.ContainsKey(itemId) ? ItemsList[itemId] : null;
//        }
//
//        /// <summary>
//        /// Zwraca listę przedmiotów należących do podanego właściciela
//        /// </summary>
//        /// <param name="ownerType"></param>
//        /// <param name="owner"></param>
//        /// <returns></returns>
//        public static IEnumerable<Item> GetItemsList(OwnerType ownerType, int? owner = null)
//        {
//            List<Item> output = new List<Item>();
//            foreach (KeyValuePair<int, Item> entry in ItemsList)
//                if (owner == null && entry.Value.OwnerType == ownerType ||
//                    owner != null && entry.Value.OwnerType == ownerType && entry.Value.Owner == owner)
//                    output.Add(entry.Value);
//
//            // Modules.Log.ConsoleLog("ITEMS",
//            //     $"ItemsList [{(int) ownerType}, {owner.ToString()}] " +
//            //     $"{JsonConvert.SerializeObject(output, Formatting.Indented)}", Modules.LogType.Debug);
//            return output;
//        }

        /// <summary>
        /// Zwraca listę przedmiotów danego typu należących do podanego właściciela
        /// </summary>
        /// <param name="ownerType"></param>
        /// <param name="owner"></param>
        /// <param name="type"></param>
        /// <returns></returns>
//        public static IEnumerable<Item> GetItemsListWithType(OwnerType ownerType, int owner, ItemType type)
//        {
//            List<Item> output = new List<Item>();
//            foreach (KeyValuePair<int, Item> entry in ItemsList)
//                if (entry.Value.OwnerType == ownerType && entry.Value.Owner == owner && entry.Value.Type == type)
//                    output.Add(entry.Value);
//
//            return output;
//        }

        /// <summary>
        /// Zwraca listę przedmiotów znajdujących się na ziemi które znajdują się w zasięgu
        /// </summary>
        /// <param name="position"></param>
        /// <param name="range"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
//        public static IEnumerable<Item> GetItemsList(Vector3 position, double range, int dimension)
//        {
//            List<Item> output = new List<Item>();
//            foreach (KeyValuePair<int, Item> entry in ItemsList)
//            {
//                if (entry.Value.OwnerType != OwnerType.Ground) continue;
//                if (entry.Value.Dimension == dimension &&
//                    Global.GetDistanceBetweenPositions(new Vector3(entry.Value.X, entry.Value.Y, entry.Value.Z),
//                        position) < range)
//                    output.Add(entry.Value);
//            }
//
//            return output;
//        }

        /// <summary>
        /// Zwraca true w przypadku gdy gracz posiada dany typ przedmiotu, inaczej false
        /// </summary>
        /// <param name="player"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
//        public static bool DoesPlayerHasItemType(Client player, ItemType itemType)
//        {
//            return DoesPlayerHasItemType(Account.GetPlayerData(player), itemType);
//        }

        /// <summary>
        /// Zwraca true w przypadku gdy gracz posiada dany typ przedmiotu, inaczej false
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
//        public static bool DoesPlayerHasItemType(Character charData, ItemType itemType)
//        {
//            if (charData == null) return false;
//            IEnumerable<Item> playerItems = GetItemsList(OwnerType.Player, charData.Id);
//            return playerItems != null && playerItems.Any(item => item.Type == itemType);
//        }

        /// <summary>
        /// Tworzy nowy przedmiot. Zwraca klasę nowo stworzonego przedmiotu
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ownerType"></param>
        /// <param name="owner"></param>
        /// <param name="itemType"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="flagType"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
//        public static Item CreateItem(string name, OwnerType ownerType, int owner, ItemType itemType, int value1,
//            int value2, string value3, int flagType = 0, int flag = 0)
//        {
//            Item newItem = new Item
//            {
//                Name = name,
//                OwnerType = ownerType,
//                Owner = owner,
//                Dimension = 0,
//                Flag = flag,
//                FlagType = flagType,
//                X = 0,
//                Y = 0,
//                Z = 0,
//                RotZ = 0,
//                Type = itemType,
//                Value1 = value1,
//                Value2 = value2,
//                Value3 = value3,
//                Used = false
//            };
//            using (Database.Database db = new Database.Database())
//            {
//                db.Items.Add(newItem);
//                db.SaveChanges();
//
//                ItemsList.Add(newItem.Id, newItem);
//                return newItem;
//            }
//        }


        /// <summary>
        /// Usuwa przedmiot o podanym Id
        /// </summary>
        /// <param name="itemId"></param>
//        public static async void DestroyItem(int itemId)
//        {
//            Item itemData = GetItemData(itemId);
//            if (itemData == null) return;
//
//            itemData.DestroyItemOnGround();
//            using (Database.Database db = new Database.Database())
//            {
//                db.Items.Remove(itemData);
//                await db.SaveChangesAsync();
//            }
//
//            ItemsList.Remove(itemData.Id);
//        }

        /// <summary>
        /// Używa przedmiot o podanym Id przez gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="itemId"></param>
        /// <param name="inUi"></param>
        /// <param name="itemValue1"></param>
        /*public static void UseItem(Client player, int itemId, bool inUi = false, int itemValue1 = 0)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (charData.BwTime > 0)
            {
                Ui.ShowError(player, "Nie możesz używać przedmiotów podczas trwania BW.");
                return;
            }

            Item itemData = GetItemData(itemId);
            if (itemData == null)
            {
                if (inUi) LoadUi(charData, true, false);
                return;
            }

            if (itemData.OwnerType != OwnerType.Player || itemData.Owner != charData.Id)
            {
                Ui.ShowError(player, "Przedmiot nie należy do Ciebie.");
                if (inUi) LoadUi(charData, true, false);
                return;
            }

            if (itemData.FlagType == 1)
            {
                int groupDuty = Groups.Library.GetPlayerGroupDuty(player);
                if (itemData.Flag != groupDuty)
                {
                    Ui.ShowError(player,
                        "Ten przedmiot jest oflagowany. Aby go użyć musisz być na duty odpowiedniej grupy.");
                    if (inUi) LoadUi(charData, true, false);
                    return;
                }
            }

            Libraries.Log.LogPlayer(player,
                $"[ {itemData.Id} | {itemData.Name} ] [ {itemData.Value1} | {itemData.Value2} | {itemData.Value3} ]",
                LogType.UseItem);

            if (itemData.Type == ItemType.Weapon)
            {
                if (!ItemsConstants.WeaponHashes.ContainsKey(itemData.Value1))
                {
                    Ui.ShowError(player, "Broń posiada niewłaściwą wartość value1.");
                    if (inUi) LoadUi(charData, true, false);
                    return;
                }

                WeaponHash weaponHash = ItemsConstants.WeaponHashes[itemData.Value1];
                if (itemData.Used)
                {
                    player.RemoveAllWeapons();
                    itemData.Used = false;
                    Chat.Library.SendPlayerMeMessage(charData, $"chowa broń \"{itemData.Name}\".", true);
                    itemData.Save();
                    charData.UsedWeapon = null;
                    if (inUi) LoadUi(charData, true, false);
                }
                else
                {
                    if (itemData.Value2 == 0)
                    {
                        Ui.ShowError(player, "Broń nie ma amunicji.");
                        if (inUi) LoadUi(charData, true, false);
                        return;
                    }

                    if (GetPlayerUsedWeaponsCount(charData) > 0)
                    {
                        Ui.ShowError(player, "Nie możesz używać więcej niż jednej broni jednocześnie.");
                        if (inUi) LoadUi(charData, true, false);
                        return;
                    }

                    player.GiveWeapon(weaponHash, itemData.Value2);
                    itemData.Used = true;
                    Chat.Library.SendPlayerMeMessage(charData, $"wyciąga broń \"{itemData.Name}\".", true);
                    itemData.Save();
                    charData.UsedWeapon = itemData;
                    if (inUi) LoadUi(charData, true, false);
                }
            }
            else if (itemData.Type == ItemType.Ammo)
            {
                if (inUi) HideUi(player);

                List<DialogColumn> dialogColumns = new List<DialogColumn>
                {
                    new DialogColumn("UID przedmiotu", 20),
                    new DialogColumn("Nazwa przedmiotu", 50),
                    new DialogColumn("Amunicja", 20)
                };
                List<DialogRow> dialogRows = new List<DialogRow>();
                foreach (Item entry in GetItemsList(OwnerType.Player, charData.Id))
                {
                    if (entry.Type != ItemType.Weapon) continue;
                    if (entry.Value1 != itemData.Value1) continue;

                    dialogRows.Add(new DialogRow(entry.Id,
                        new[] {entry.Id.ToString(), entry.Name, entry.Value2.ToString()}));
                }

                string[] dialogButtons = {"Przeładuj", "Anuluj"};

                Account.SetServerData(charData, Account.ServerData.ItemReloadWeaponAmmoItem, itemData.Id);

                Dialogs.Library.CreateDialog(player, DialogId.ItemReloadWeapon, "Wybierz broń do uzupełnienia",
                    dialogColumns,
                    dialogRows, dialogButtons);
            }
            else if (itemData.Type == ItemType.Phone)
            {
                if (!itemData.Used)
                    if (DoesPlayerHasUsedItemType(charData, ItemType.Phone))
                    {
                        Ui.ShowError(player, "Używasz już innego telefonu.");
                        return;
                    }

                itemData.Used = !itemData.Used;
                itemData.Save();
                string noun = itemData.Used ? "Włączono" : "Wyłączono";
                Ui.ShowInfo(player, $"{noun} telefon o numerze {itemData.Value1}.");
                Chat.Library.SendPlayerMeMessage(charData, "naciska przycisk włącznika na telefonie.", true);
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Megaphone)
            {
                Ui.ShowUsage(player, "/m [tekst]");
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Drink)
            {
                int pHealth = charData.PlayerHandle.Health;
                if (pHealth > 40)
                {
                    pHealth += itemData.Value1;
                    if (pHealth > 100) pHealth = 100;
                    charData.PlayerHandle.Health = pHealth;
                    charData.Health = pHealth;
                    charData.Save();
                }
                else
                {
                    Ui.ShowWarning(charData.PlayerHandle, "Masz zbyt mało punktów życia, aby podnieść jego poziom" +
                                                          "piciem. Musisz zażyć lek.");
                }

                Chat.Library.SendPlayerMeMessage(charData, $"wypił \"{itemData.Name}\".", true);
                DestroyItem(itemData.Id);
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Food)
            {
                int pHealth = charData.PlayerHandle.Health;
                if (pHealth > 40)
                {
                    pHealth += itemData.Value1;
                    if (pHealth > 100) pHealth = 100;
                    charData.PlayerHandle.Health = pHealth;
                    charData.Health = pHealth;
                    charData.Save();
                }
                else
                {
                    Ui.ShowWarning(charData.PlayerHandle, "Masz zbyt mało punktów życia, aby podnieść jego poziom" +
                                                          "jedzeniem. Musisz zażyć lek.");
                }

                Chat.Library.SendPlayerMeMessage(charData, $"zjadł \"{itemData.Name}\".", true);
                DestroyItem(itemData.Id);
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Mask)
            {
                if (itemData.Used)
                {
                    charData.HasMask = false;
                    itemData.Used = false;
                    Chat.Library.SendPlayerMeMessage(charData, "ściąga maskę z twarzy.", true);
                    Sync.Library.SetPlayerSyncedData(charData.PlayerHandle, "player.visibleName",
                        Player.GetPlayerIcName(charData, true));
                }
                else
                {
                    charData.HasMask = true;
                    itemData.Used = true;
                    Chat.Library.SendPlayerMeMessage(charData, "zakłada maskę na twarz.", true);
                    Sync.Library.SetPlayerSyncedData(charData.PlayerHandle, "player.visibleName",
                        Player.GetPlayerIcName(charData, false));
                }

                itemData.Save();
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Skin)
            {
                charData.PlayerHandle.SetSkin(NAPI.Util.GetHashKey(itemData.Value3));
                Chat.Library.SendPlayerMeMessage(charData, "przebrał się.", true);
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Paint)
            {
                // TODO paint
            }
            else if (itemData.Type == ItemType.Drugs)
            {
                if (itemData.Value1 == (int) DrugType.Marijuana)
                {
                    charData.DrugAddictions.Marijuana += 1; // 1 punkt uzależnienia
                    charData.DrugAddictions.MarijuanaTime += 900; // 15 minut

                    charData.SaveDrugs();

                    Chat.Library.SendPlayerMeMessage(charData, "zażywa 1g marihuany.", true);
                    Chat.Library.SendPlayerDoMessage(charData, $"{charData.Name} staje się zrelaksowany.", true);

                    Sync.Library.SyncPlayerForPlayer(charData.PlayerHandle);

                    charData.DoDrugEffects();

                    DestroyItem(itemData.Id);
                }
                else if (itemData.Value1 == (int) DrugType.Cocaine)
                {
                    charData.DrugAddictions.Cocaine += 10; // 10 punktów uzależnienia
                    charData.DrugAddictions.CocaineTime += 1800; // 30 minut

                    charData.SaveDrugs();

                    Chat.Library.SendPlayerMeMessage(charData, "zażywa 1g kokainy.", true);
                    Chat.Library.SendPlayerDoMessage(charData, $"{charData.Name} wyciera nos i staje się nadpobudliwy.",
                        true);

                    charData.DoDrugEffects();

                    DestroyItem(itemData.Id);
                }
                else
                {
                    Ui.ShowError(player, "Nieznany typ narkotyku.");
                }

                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Cube)
            {
                int cubeScore = Global.GetRandom(1, 6);
                Chat.Library.SendPlayerMeMessage(charData, $"rzucił kostką wyrzucając {cubeScore} oczko(a).", true);
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Body)
            {
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Armor)
            {
                if (!itemData.Used)
                {
                    if (DoesPlayerHasUsedItemType(charData, ItemType.Armor))
                    {
                        Ui.ShowError(player, "Używasz już innej kamizelki");
                        if (inUi) LoadUi(charData, true, false);
                        return;
                    }

                    if (itemData.Value1 <= 0)
                    {
                        Ui.ShowError(player, "Kamizelka została zniszczona. Usuwanie przedmiotu...");
                        DestroyItem(itemData.Id);
                        if (inUi) LoadUi(charData, true, false);
                        return;
                    }

                    NAPI.Player.SetPlayerArmor(player, itemData.Value1);
                    Chat.Library.SendPlayerMeMessage(charData, "zakłada kamizelkę kuloodporną.", true);
                }
                else
                {
                    itemData.Value1 = NAPI.Player.GetPlayerArmor(player);
                    itemData.Used = false;

                    NAPI.Player.SetPlayerArmor(player, 0);
                    Chat.Library.SendPlayerMeMessage(charData, "ściąga kamizelkę kuloodporną.", true);
                }

                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Medicine)
            {
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Carmod)
            {
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Canister)
            {
                Vehicle nearestVeh =
                    Vehicles.Library.GetNearestVehicle(player.Position, player.Dimension, 2.5);
                if (nearestVeh == null) return;
                if (nearestVeh.Engine)
                {
                    Ui.ShowError(player, "Silnik pojazdu nie może być uruchomiony");
                    return;
                }

                nearestVeh.Fuel += 10.0;
                if (nearestVeh.Fuel > nearestVeh.MaxFuel)
                    nearestVeh.Fuel = nearestVeh.MaxFuel;

                nearestVeh.Save();
                DestroyItem(itemData.Id);

                Chat.Library.SendPlayerMeMessage(player, "tankuje pojazd paliwem z kanistra.", true);

                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Cigarette)
            {
                Chat.Library.SendPlayerMeMessage(charData, "odpala papierosa.", true);
                NAPI.Player.PlayPlayerAnimation(player,
                    (int) (AnimationFlags.Cancellable | AnimationFlags.Loop | AnimationFlags.AllowPlayerControl),
                    "amb@world_human_smoking@male@male_a@base", "base");
                itemData.Value1--;
                if (itemData.Value1 <= 0)
                    DestroyItem(itemData.Id);
                else
                    itemData.Save();

                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Topup)
            {
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Cruise)
            {
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Alcohol)
            {
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.PlayingCards)
            {
                string[] suits = {"trefl", "karo", "kier", "pik"};
                string[] ranks =
                {
                    "dwójka", "trójka", "czwórka", "piątka", "szóstka", "siódemka", "ósemka", "dziewiątka",
                    "dziesiątka", "walet", "dama", "król", "as"
                };
                int suitId = Global.GetRandom(0, suits.Length - 1);
                int rankId = Global.GetRandom(0, ranks.Length - 1);
                Chat.Library.SendPlayerMeMessage(charData, $"losuje z talii kartę {ranks[rankId]} {suits[suitId]}.",
                    true);
                if (inUi) LoadUi(charData, true, false);
            }
            else if (itemData.Type == ItemType.Mugshot)
            {
                if (inUi) HideUi(player);

                if (itemData.Used)
                {
                    Sync.Library.DeletePlayerData(player, "MugshotTitle");
                    Sync.Library.DeletePlayerData(player, "MugshotTop");
                    Sync.Library.DeletePlayerData(player, "MugshotMiddle");
                    Sync.Library.DeletePlayerData(player, "MugshotBottom");

                    Sync.Library.SyncPlayerForPlayer(player);
                    itemData.Used = false;
                    return;
                }

                if (DoesPlayerHasUsedItemType(charData, ItemType.Mugshot))
                {
                    Ui.ShowError(player, "Używasz już innej tabliczki");
                    if (inUi) LoadUi(charData, true, false);
                    return;
                }

                string[] dialogButtons = {"Następny", "Wyjdź"};
                Dialogs.Library.CreateDialog(player, DialogId.MugshotTitle, "Tytuł tabliczki", "Tytuł", "",
                    dialogButtons);
                itemData.Used = true;
            }
            else
            {
                Ui.ShowError(player, "Nieznany typ przedmiotu.");
                if (inUi) LoadUi(player, true, false);
            }
        }*/

        /// <summary>
        /// Wyświetlanie opisu przedmiotu
        /// </summary>
        /// <param name="player"></param>
        /// <param name="itemId"></param>
//        public static void ShowItemInfo(Client player, int itemId)
//        {
//            var charData = Account.GetPlayerData(player);
//            if (charData == null) return;
//            var itemData = GetItemData(itemId);
//            if (itemData == null) return;
//
//            if (itemData.Owner != charData.Id || itemData.OwnerType != OwnerType.Player)
//            {
//                Ui.ShowError(player, "Nie posiadasz tego przedmiotu.");
//                return;
//            }
//
//            string desc = "Nie rozpoznano typu przedmiotu.";
//
//            #region Opisy przedmiotów
//
//            switch (itemData.Type)
//            {
//                case ItemType.Alcohol:
//                    desc =
//                        "Alkohol może wprowadzić Twoją postać w stan upojenia. Po spożyciu nadmiernej ilośći, prowadzenie pojazdów oraz poruszanie się może być utrudnione.";
//                    break;
//
//                case ItemType.Ammo:
//                    desc = "Amunicja jest niezbędna aby oddać strzał z broni.";
//                    break;
//
//                case ItemType.Armor:
//                    desc =
//                        "Kamizelka kuloodporna może uratować Ci życie. Załóż ją aby ochronić się przed bronią palną.";
//                    break;
//
//                case ItemType.Body:
//                    desc = "Ciało jednego z mieszkańców. Niech spoczywa w pokoju.";
//                    break;
//
//                case ItemType.Canister:
//                    desc = "Kanister przyda Ci się gdy zabraknie paliwa, a do stacji kawał drogi.";
//                    break;
//
//                case ItemType.Carmod:
//                    desc = "Część modyfikacji pojazdu. Ten przedmiot pozwoli Ci podrasować brykę.";
//                    break;
//
//                case ItemType.Cigarette:
//                    desc =
//                        "Papierosy pozwolą Twojej postaci zabić stres, ale prędzej czy później mogą zupełnie zlikwidować jego odczuwanie.";
//                    break;
//
//                case ItemType.Cruise:
//                    desc =
//                        "Tempomat zamontowany w pojeździe pozwoli Ci na utrzymywanie stałej prędkośći bez męczenia nogi.";
//                    break;
//
//                case ItemType.Cube:
//                    desc = "Kostka do gry pozwoli Ci spędzić czas rywalizując ze znajomymi. Kto trafi 6 oczek?";
//                    break;
//
//                case ItemType.Drink:
//                    desc = "Pragnienie dopada nawet najlepszych sportowców. Pamiętaj o nawodnieniu organizmu.";
//                    break;
//
//                case ItemType.Drugs:
//                    desc =
//                        "Narkotyki mogą uczynić Cię silniejszym, zrelaksowanym lub agresywnym. Mogą też wpakować Cię do paki, ale kto by o tym myślał?";
//                    break;
//
//                case ItemType.Food:
//                    desc = "Jedzenie pomoże Ci zregenerować punkty zdrowia i ruszyć dalej w pełni sił.";
//                    break;
//
//                case ItemType.Mask:
//                    desc = "Nie ważne co jest powodem do ukrycia twarzy, maska załatwi je wszystkie.";
//                    break;
//
//                case ItemType.Medicine:
//                    desc = "Lek pomoże Ci pozbyć się bólu głowy po utracie przytomności.";
//                    break;
//
//                case ItemType.Megaphone:
//                    desc = "Impreza, pościg czy protest? Dzięki megafonowi Twój głos usłyszą wszyscy.";
//                    break;
//
//                case ItemType.Paint:
//                    desc =
//                        "Lakier umożliwi Ci przemalowanie swojego pojazdu na dowolny, wybrany przez siebie kolor. Oczywiście nie bez pomocy mechanika.";
//                    break;
//
//                case ItemType.Phone:
//                    desc = "Wykręć numer i dzwoń! No, ewentualnie wyśli SMSa jeśli brakuje Ci odwagi.";
//                    break;
//
//                case ItemType.PlayingCards:
//                    desc = "Karty do gry są jeszcze 'TODO' więc nie wiemy co Ci o nich powiedzieć.";
//                    break;
//
//                case ItemType.Skin:
//                    desc =
//                        "Nie szata zdobi człowieka. Chyba że mieszkasz w Los Santos. Tutaj warto zadbać o wygląd! Nowe ciuszki na pewno dodadzą prestiżu.";
//                    break;
//
//                case ItemType.Topup:
//                    desc =
//                        "Doładowanie do telefonu to coś o czym warto pamiętać. Chyba że lubisz wracać z buta po dobrej imprezie bez mozliwości wezwania taksówki lub znajomego.";
//                    break;
//
//                case ItemType.Watch:
//                    desc = "Czas to pieniądz, a za pieniądze kupiłeś ten zegarek. Pilnuj go, każda minuta jest cenna.";
//                    break;
//
//                case ItemType.Weapon:
//                    desc = "Broń... zyskana legalnie czy nie, potrafi wyrządzić krzywdę. Używaj jej rozważnie.";
//                    break;
//            }
//
//            #endregion
//
//            string[] dialogButtons = {"Ok"};
//
//            Dialogs.Library.CreateDialog(player, DialogId.ItemInfo, "Opis przedmiotu", desc, dialogButtons);
//        }


        /// <summary>
        /// Wyrzuca przedmiot o podanym Id przez gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="itemId"></param>
        /// <param name="inUi"></param>
//        public static void DropItem(Client player, int itemId, bool inUi = false)
//        {
//            var charData = Account.GetPlayerData(player);
//            if (charData == null) return;
//            var itemData = GetItemData(itemId);
//            if (itemData == null) return;
//            if (Bw.Library.DoesPlayerHasBw(charData))
//            {
//                Ui.ShowError(player, "Nie możesz odkładać przedmiotów podczas BW.");
//                return;
//            }
//
//            if (itemData.Used)
//            {
//                Ui.ShowError(player, "Przedmiot nie może byc używany.");
//                return;
//            }
//
//            if (itemData.Owner != charData.Id || itemData.OwnerType != OwnerType.Player)
//            {
//                Ui.ShowError(player, "Nie posiadasz tego przedmiotu.");
//                return;
//            }
//
//            if (charData.PlayerHandle.Vehicle != null)
//            {
//                var vehData = Vehicles.Library.GetVehicleData(charData.PlayerHandle.Vehicle);
//                if (vehData == null) return;
//                itemData.OwnerType = OwnerType.Vehicle;
//                itemData.Owner = vehData.Id;
//                itemData.X = itemData.Y = itemData.Z = itemData.RotZ = 0.0;
//                itemData.Dimension = 0;
//                itemData.Save();
//                Chat.Library.SendPlayerMeMessage(player, "odkłada przedmiot w pojeździe.", true);
//                Libraries.Log.LogPlayer(charData,
//                    $"Dropped item {itemData.Id} ({itemData.Name}) in vehicle {vehData.Id} ({vehData.Name}");
//                if (inUi) LoadUi(player, true, false);
//            }
//            else
//            {
//                itemData.Owner = 0;
//                itemData.OwnerType = 0;
//                itemData.X = player.Position.X;
//                itemData.Y = player.Position.Y;
//                itemData.Z = player.Position.Z;
//                itemData.Dimension = (int) player.Dimension;
//                itemData.RotZ = player.Heading;
//
//
//                MakeItemOnGround(itemData, new Vector3(player.Position.X, player.Position.Y, player.Position.Z - 0.98),
//                    player.Rotation, player.Dimension);
//
//                itemData.Save();
//                Chat.Library.SendPlayerMeMessage(player, "odkłada przedmiot na ziemi.", true);
//                Libraries.Log.LogPlayer(charData, $"Dropped item {itemData.Id} ({itemData.Name}) on the ground");
//                if (inUi) LoadUi(player, true, false);
//            }
//        }

        /// <summary>
        /// Podnosi przedmiot o podanym Id przez gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="itemId"></param>
        /// <param name="inUi"></param>
//        public static void PickItem(Client player, int itemId, bool inUi = false)
//        {
//            var charData = Account.GetPlayerData(player);
//            if (charData == null) return;
//            var itemData = GetItemData(itemId);
//            if (itemData == null) return;
//            if (itemData.OwnerType != OwnerType.Ground ||
//                Global.GetDistanceBetweenPositions(player.Position, new Vector3(itemData.X, itemData.Y, itemData.Z)) >
//                5.0 || itemData.Dimension != player.Dimension)
//            {
//                Ui.ShowError(player, "Przedmiot nie znajduje się obok Ciebie");
//                return;
//            }
//
//            itemData.Owner = charData.Id;
//            itemData.OwnerType = OwnerType.Player;
//            itemData.X = itemData.Y = itemData.Z = 0.0;
//            DestroyItemOnGround(itemData);
//            string msg = player.Vehicle != null ? "podnosi coś z pojazdu" : "podnosi coś z ziemi";
//            Chat.Library.SendPlayerMeMessage(charData, msg, true);
//            itemData.Save();
//            if (inUi) LoadUi(player, true, false);
//        }

        /// <summary>
        /// Laduje UI przedmiotów
        /// </summary>
        /// <param name="player"></param>
        /// <param name="refreshOnly"></param>
        /// <param name="withMessage"></param>
//        public static void LoadUi(Client player, bool refreshOnly = false, bool withMessage = true)
//        {
//            LoadUi(Account.GetPlayerData(player), refreshOnly, withMessage);
//        }
//
//        public static void ShowUi(Client player)
//        {
//            LoadUi(Account.GetPlayerData(player));
//        }
//
//        public static void HideUi(Client player)
//        {
//            NAPI.ClientEvent.TriggerClientEvent(player, "client.items.hideItems");
//        }


        /// <summary>
        /// Laduje UI przedmiotów
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="refreshOnly"></param>
        /// <param name="withMessage"></param>
//        public static void LoadUi(Character charData, bool refreshOnly = false, bool withMessage = true)
//        {
//            if (charData == null) return;
//            IEnumerable<Item> playerItems = GetItemsList(OwnerType.Player, charData.Id);
//            List<ClientItem> pItems = playerItems.Select(t => new ClientItem(t.Id, t.Name, t.Used)).ToList();
//            charData.PlayerHandle.TriggerEvent(refreshOnly ? "client.items.refreshItems" : "client.items.showItems",
//                JsonConvert.SerializeObject(pItems, Formatting.None));
//        }

        /// <summary>
        /// Zwraca liczbę używanych broni przez gracza
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
//        public static int GetPlayerUsedWeaponsCount(Client player)
//        {
//            return GetPlayerUsedWeaponsCount(Account.GetPlayerData(player));
//        }

        /// <summary>
        /// Zwraca liczbę używanych broni przez gracza
        /// </summary>
        /// <param name="charData"></param>
        /// <returns></returns>
//        public static int GetPlayerUsedWeaponsCount(Character charData)
//        {
//            if (charData == null) return 0;
//            int weaponsCount = 0;
//            foreach (KeyValuePair<int, Item> entry in ItemsList)
//            {
//                if (entry.Value.OwnerType != OwnerType.Player || entry.Value.Owner != charData.Id) continue;
//                if (entry.Value.Type == ItemType.Weapon && entry.Value.Used) weaponsCount++;
//            }
//
//            return weaponsCount;
//        }

        /// <summary>
        /// Sprawdza, czy gracz posiada użyty przynajmniej jeden przedmiot o podanym typie.
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
//        public static bool DoesPlayerHasUsedItemType(Character charData, ItemType itemType)
//        {
//            if (charData == null) return false;
//
//            IEnumerable<Item> pItems = GetItemsList(OwnerType.Player, charData.Id);
//            return pItems.Any(t => t.Type == itemType && t.Used);
//        }


        /// <summary>
        /// Rozbrajanie gracza (przy wychodzeniu z serwera czy dostaniu BW).
        /// </summary>
        /// <param name="charData"></param>
//        public static void DisarmPlayer(Character charData)
//        {
//            if (charData == null) return;
//
//            foreach (Item entry in GetItemsList(OwnerType.Player, charData.Id))
//            {
//                if (!entry.Used) continue;
//
//                if (entry.Type == ItemType.Weapon)
//                {
//                    entry.Used = false;
//                    entry.Save();
//
//                    charData.PlayerHandle.RemoveAllWeapons();
//                }
//                else if (entry.Type == ItemType.Armor)
//                {
//                    entry.Value1 = NAPI.Player.GetPlayerArmor(charData.PlayerHandle);
//                    entry.Used = false;
//                }
//            }
//        }

//        /// <summary>
//        /// Kasuje przedmioty należące do podanego właściciela.
//        /// </summary>
//        /// <param name="ownerType"></param>
//        /// <param name="owner"></param>
//        public static void RemoveItemsByOwner(OwnerType ownerType, int owner)
//        {
//            ThreadPool.QueueUserWorkItem(delegate
//            {
//                foreach (Item entry in GetItemsList(ownerType, owner)) DestroyItem(entry.Id);
//            });
//            /*new Thread(() =>
//            {
//                foreach (Item entry in GetItemsList(ownerType, owner)) DestroyItem(entry.Id);
//            }).Start();*/GetPlayerUsedWeaponsCount
////        }
//    }
//}