using System;
using LSVRP.Database.Models;
using LSVRP.New.Entities;
using LSVRP.New.Entities.Item;
using LSVRP.New.Entities.Item.Drugs;
using LSVRP.New.Enums;
using LSVRP.New.Managers;
using DrugType = LSVRP.Features.Drugs.DrugType;

namespace LSVRP.New.Factories
{
    public class ItemFactory
    {
        public ItemEntity Create(Item itemData)
        {
            switch (itemData.Type)
            {
                case ItemType.Weapon: return new Weapon(itemData);
                case ItemType.Ammo: return new Ammo(itemData);
                case ItemType.Phone: return new Phone(itemData);
                case ItemType.Megaphone: return new Megaphone(itemData);
                case ItemType.Drink: return new Eatable(itemData);
                case ItemType.Food: return new Eatable(itemData);
                case ItemType.Mask: return new Mask(itemData);
                case ItemType.Skin: return new Skin(itemData);
                case ItemType.Paint: return new Paint(itemData);
                case ItemType.Drugs: return CreateDrug(itemData);
                case ItemType.Cube: return new Cube(itemData);
                case ItemType.Body: return new New.Entities.Item.Body(itemData);
                case ItemType.Armor: return new Armor(itemData);
                case ItemType.Medicine: return new Medicine(itemData);
                case ItemType.Carmod: return new Carmor(itemData);
                case ItemType.Canister: return new Canister(itemData);
                case ItemType.Cigarette: return new Cigarette(itemData);
                case ItemType.Topup: return new Topup(itemData);
                case ItemType.Cruise: return new Cruise(itemData);
                case ItemType.Alcohol: return new Alcohol(itemData);
                case ItemType.PlayingCards: return new PlayingCards(itemData);
                case ItemType.Watch: return new Watch(itemData);
                case ItemType.Mugshot: return new Mugshot(itemData);
                default: throw new ArgumentOutOfRangeException();
            }
        }

        public ItemEntity CreateWithSave(Item itemData)
        {
            
            using (Database.Database db = new Database.Database())
            {
                db.Items.Add(itemData);
                db.SaveChanges();

                ItemEntity newItem = Create(itemData);
                ItemsManager.Items.Add(newItem);
                
                return newItem;
            }
        }
        
        private ItemEntity CreateDrug(Item itemData)
        {
            switch ((DrugType)itemData.Value1)
            {
                case DrugType.Marijuana: return new Marijuana(itemData);
                case DrugType.Cocaine: return new Cocaine(itemData);
                case DrugType.Amphetamine:
                    break;
                case DrugType.MetaAmphetamine:
                    break;
                case DrugType.Heroin:
                    break;
                case DrugType.Opium:
                    break;
                case DrugType.Lsd:
                    break;
                case DrugType.Hash:
                    break;
                default: throw new NotImplementedException();
            }
            throw new NotImplementedException();
        }
    }
}