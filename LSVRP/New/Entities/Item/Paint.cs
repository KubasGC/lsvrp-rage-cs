using System;
using LSVRP.Database.Models;

namespace LSVRP.New.Entities.Item
{
    public class Paint : ItemEntity
    {
        public Paint(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            base.UseItem(charData);
            throw new NotImplementedException();
        }
    }
}