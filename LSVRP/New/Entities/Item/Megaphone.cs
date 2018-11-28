using LSVRP.Database.Models;

namespace LSVRP.New.Entities.Item
{
    public class Megaphone : ItemEntity
    {
        public Megaphone(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            charData.SendUsage("/m [treść wiadomości]");
            base.UseItem(charData);
        }
    }
}