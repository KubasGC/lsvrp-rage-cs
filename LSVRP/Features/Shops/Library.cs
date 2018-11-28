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
using LSVRP.Features.Clothes;
using LSVRP.Libraries;
using Log = LSVRP.Modules.Log;

namespace LSVRP.Features.Shops
{
    public static class Library
    {
        /// <summary>
        /// Słownik przechowujący dane sklepów.
        /// </summary>
        private static readonly Dictionary<int, Shop> ShopsList = new Dictionary<int, Shop>();

        /// <summary>
        /// Ładuje sklepy z bazy danych.
        /// </summary>
        public static void LoadShops()
        {
            double startTime = Global.GetTimestampMs();
            using (Database.Database db = new Database.Database())
            {
                foreach (Shop entry in db.Shops.ToList())
                {
                    entry.ShopMarker = NAPI.Marker.CreateMarker(1, new Vector3(entry.X, entry.Y, entry.Z),
                        new Vector3(), new Vector3(), 0.5f, 255, 255, 255, false, 0);

                    /*entry.ShopBlip =
                        NAPI.Blip.CreateBlip(500, new Vector3(), 1.0f, 4, entry.Name, 255, 50.0f, true, 0, 0);*/

                    ShopsList.Add(entry.Id, entry);
                }

                Log.ConsoleLog("SHOPS",
                    $"Załadowano sklepy ({ShopsList.Count}) | {Global.GetTimestampMs() - startTime}ms");
            }
        }

        /// <summary>
        /// Tworzy nowy sklep.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="shopType"></param>
        /// <returns></returns>
        public static Shop CreateShop(string name, Vector3 position, ShopTypes shopType)
        {
            using (Database.Database db = new Database.Database())
            {
                Shop newShop = new Shop
                {
                    Name = name,
                    X = position.X,
                    Y = position.Y,
                    Z = position.Z,
                    ShopType = shopType
                };

                newShop.ShopMarker = NAPI.Marker.CreateMarker(1, newShop.Position,
                    new Vector3(), new Vector3(), 0.5f, 255, 255, 255, false, 0);

                db.Shops.Add(newShop);
                db.SaveChanges();
                ShopsList.Add(newShop.Id, newShop);

                return newShop;
            }
        }

        /// <summary>
        /// Pobiera dane sklepu.
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static Shop GetShopData(int shopId)
        {
            return ShopsList.ContainsKey(shopId) ? ShopsList[shopId] : null;
        }

        /// <summary>
        /// Pobiera dane najbliższego sklepu znajdującego się w danej lokalizacji.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="distance"></param>
        /// <param name="shopType"></param>
        /// <returns></returns>
        public static Shop GetNearestShop(Vector3 position, double distance = 5.0, ShopTypes? shopType = null)
        {
            Shop nearestShop = null;
            double nearestDistance = distance;
            foreach (KeyValuePair<int, Shop> entry in ShopsList)
            {
                if (shopType != null && (ShopTypes) shopType != entry.Value.ShopType) continue;

                double dist = Global.GetDistanceBetweenPositions(position,
                    new Vector3(entry.Value.X, entry.Value.Y, entry.Value.Z));

                if (dist < nearestDistance)
                {
                    nearestDistance = dist;
                    nearestShop = entry.Value;
                }
            }

            return nearestShop;
        }

        public static void DestroyShop(Shop shop)
        {
            if (NAPI.Entity.DoesEntityExist(shop.ShopMarker)) shop.ShopMarker.Delete();
            using (Database.Database db = new Database.Database())
            {
                db.Shops.Remove(shop);
                db.SaveChanges();
            }

            if (ShopsList.ContainsKey(shop.Id)) ShopsList.Remove(shop.Id);
            shop = null;
        }

        /// <summary>
        /// Zwraca listę produktów przypisanych do danego sklepu.
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static List<ShopProduct> GetShopProducts(int shopId)
        {
            using (Database.Database db = new Database.Database())
            {
                return db.ShopProducts.Where(t => t.ShopId == shopId).ToList();
            }
        }

        /// <summary>
        /// Zwraca dane produktu o podanym Id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static ShopProduct GetProductData(int productId)
        {
            using (Database.Database db = new Database.Database())
            {
                return db.ShopProducts.FirstOrDefault(t => t.Id == productId);
            }
        }
    }
}