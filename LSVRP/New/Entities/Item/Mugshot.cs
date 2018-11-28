using System;
using LSVRP.Database.Models;
using LSVRP.New.Entities.Item;

namespace LSVRP.New.Entities
{
    public class Mugshot : ItemEntity
    {
        public Mugshot(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            base.UseItem(charData);
            throw new NotImplementedException();
        }
    }
}