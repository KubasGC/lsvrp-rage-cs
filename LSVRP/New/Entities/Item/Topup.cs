using System;
using LSVRP.Database.Models;

namespace LSVRP.New.Entities.Item
{
    public class Topup : ItemEntity
    {
        public Topup(Database.Models.Item itemData) : base (itemData){}
        
        public override void UseItem(Character charData)
        {
            base.UseItem(charData);
            throw new NotImplementedException();
        }
    }
}