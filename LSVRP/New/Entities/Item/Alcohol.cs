using System;
using LSVRP.Database.Models;
using LSVRP.New.Entities.Item;

namespace LSVRP.New.Entities
{
    public class Alcohol : ItemEntity
    {
        public Alcohol(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            base.UseItem(charData);
            throw new NotImplementedException();
        }
    }
}