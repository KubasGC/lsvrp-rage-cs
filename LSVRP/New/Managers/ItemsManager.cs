using System;
using System.Collections.Generic;
using System.Linq;
using LSVRP.Database.Models;
using LSVRP.Features.Items;
using LSVRP.Libraries;
using LSVRP.New.Entities.Item;
using LSVRP.New.Enums;
using LSVRP.New.Factories;

namespace LSVRP.New.Managers
{
    public static class ItemsManager
    {
        public static readonly ICollection<ItemEntity> Items = new List<ItemEntity>();

        public static void Delete(int itemId, Item itemData)
        {
            if (!Items.Any(t => t.Id == itemId)) return;
            using (Database.Database db = new Database.Database())
            {
                db.Items.Remove(itemData);
                db.SaveChanges();
            }

            Items.Remove(Items.First(t => t.Id == itemId));

        }

        public static void Delete(OwnerType ownerType, int owner)
        {
            throw new NotImplementedException();
        }

        public static void Load()
        {
            double startTime = Global.GetTimestampMs();
            ItemFactory itemFactory = new ItemFactory();

            using (Database.Database db = new Database.Database())
            {
                foreach (Item entry in db.Items.ToList())
                {
                    ItemEntity itemEntity = itemFactory.Create(entry);
                    Items.Add(itemEntity);
                }
            }
            Modules.Log.ConsoleLog("ITEMS-NEW",
                $"Załadowano przedmioty ({Items.Count}) | {Global.GetTimestampMs() - startTime}ms");
        }
    }
}