using System;
using LSVRP.Database.Models;

namespace LSVRP.New.Entities.Item
{
    public class Ammo : ItemEntity
    {
        public Ammo(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            base.UseItem(charData);
            throw new NotImplementedException();
        }
    }
}