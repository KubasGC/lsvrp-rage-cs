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
using LSVRP.Database.Models;
using LSVRP.Features.Dialogs;
using LSVRP.Features.Items;
using LSVRP.Libraries;
using LSVRP.Managers;
using LSVRP.New.Entities.Item;
using LSVRP.New.Enums;
using Newtonsoft.Json;
using Log = LSVRP.Modules.Log;

namespace LSVRP.Features.Corners
{
    public static class Library
    {
        public const double CornerRadius = 3.0;
        private static readonly Dictionary<int, Corner> CornerList = new Dictionary<int, Corner>();

        public static Dictionary<int, Corner> GetCorners()
        {
            return CornerList;
        }

        public static void LoadCorners()
        {
            double startTime = Global.GetTimestampMs();
            using (Database.Database db = new Database.Database())
            {
                List<Corner> loaded = db.Corners.ToList();
                foreach (var entry in loaded) CornerList.Add(entry.Id, entry);

                Log.ConsoleLog("CORNERS",
                    $"Załadowano cornery ({CornerList.Count}) | {Global.GetTimestampMs() - startTime}ms");
            }
        }

        public static Corner GetCornerData(int cornerId)
        {
            return CornerList.ContainsKey(cornerId) ? CornerList[cornerId] : null;
        }

        public static Corner CreateCorner(string name, double x, double y, double z, int dimenssion,
            bool highRisk = false)
        {
            using (var db = new Database.Database())
            {
                Corner c = new Corner
                {
                    Name = name,
                    X = x,
                    Y = y,
                    Z = z,
                    Dimension = dimenssion,
                    HighRisk = highRisk
                };
                db.Corners.Add(c);
                db.SaveChanges();

                CornerList.Add(c.Id, c);
                return c;
            }
        }

        public static void DeleteCorner(Corner c)
        {
            using (var db = new Database.Database())
            {
                db.Corners.Remove(c);
                db.SaveChanges();
                CornerList.Remove(c.Id);
            }
        }

        public static Corner GetPlayerCorner(Client player)
        {
            foreach (var c in CornerList)
                if (Global.GetDistanceBetweenPositions(player.Position, c.Value.GetPosition()) < CornerRadius)
                    return c.Value;

            return null;
        }

        public static void StopCornerSell(Character charData)
        {
            Client player = charData.PlayerHandle;
            var timerId = Account.GetServerData(charData, Account.ServerData.CornerId);
            if (timerId != null)
            {
                //clearTimeout(player.customData.cornerTimer);
            }

            Account.RemoveServerData(charData, Account.ServerData.CornerId);
            Account.RemoveServerData(charData, Account.ServerData.CornerItem);
            Account.RemoveServerData(charData, Account.ServerData.CornerItemCount);
            Account.RemoveServerData(charData, Account.ServerData.CornerMaxPrice);
            object[] opt = {false};
            player.TriggerEvent("client.corners.togglecornerUI", opt);
        }

        public static void SellDrugs(int playerId, int cornerId)
        {
            Character charData = Account.GetPlayerDataByServerId(playerId);

            if (charData == null || Account.GetServerData(charData, Account.ServerData.CornerId) == null)
                return;

            int playerCornerId = (int) Account.GetServerData(charData, Account.ServerData.CornerId);
            if (cornerId != playerCornerId)
                return;

            Corner cornerData = GetCornerData(cornerId);
            if (cornerData == null)
                return;

            if (!IsTimeOkToSellDrugs())
            {
                StopCornerSell(charData);
                Ui.ShowError(charData.PlayerHandle, "Handel na cornerze możliwy jest w godzinach 18-2");
                return;
            }

            if (!cornerData.Equals(GetPlayerCorner(charData.PlayerHandle)))
            {
                StopCornerSell(charData);
                Ui.ShowError(charData.PlayerHandle, "Nie znajdujesz się na cornerze. Sprzedaż anulowana");
                return;
            }


            List<ItemEntity> playerDrugs = New.Managers.ItemsManager.Items
                .Where(t => t.CheckOwner(charData) && t.Type == ItemType.Drugs).ToList();

           

            ItemEntity selectedDrug = playerDrugs[Global.GetRandom(0, playerDrugs.Count - 1)];
            int max = selectedDrug.Value2 < 5 ? selectedDrug.Value2 : 4;
            int drugCount = Global.GetRandom(1, max);
            int itemMaxPrice = Items.Drugs.GetDrugMaxPrice((DrugType) selectedDrug.Value1);
            if (cornerData.HighRisk)
                itemMaxPrice = (int) (itemMaxPrice * 1.5);

            Account.SetServerData(charData, Account.ServerData.CornerItem, selectedDrug);
            Account.SetServerData(charData, Account.ServerData.CornerItemCount, drugCount);
            Account.SetServerData(charData, Account.ServerData.CornerMaxPrice,
                Global.GetRandom((int) 0.6 * itemMaxPrice, itemMaxPrice));
            string[] dialogButtons = {"Wybierz", "Anuluj"};

            string title = $"Klient chce kupić {drugCount} sztuk {selectedDrug.Name}";
            Dialogs.Library.CreateDialog(charData.PlayerHandle, DialogId.CornerDrugPrice,
                title, "Jaką cenę chcesz mu zaproponować?", "", dialogButtons);
        }

        public static string GetAllCornersSerialized()
        {
            return JsonConvert.SerializeObject(CornerList);
        }

        public static bool IsTimeOkToSellDrugs()
        {
            return true;
//            int hour = new DateTime().Hour;
//            return !(hour > 1 && hour < 18);
        }

        public static int GetNextCornerSellTime(Corner corner)
        {
            if (corner.HighRisk)
                return (Global.GetRandom(60, 120) + corner.DrugsSold * 2) * 1000;
            return 5000;
        }
    }
}