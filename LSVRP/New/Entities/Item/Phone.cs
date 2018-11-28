using LSVRP.Database.Models;
using LSVRP.Features.Items;
using LSVRP.New.Enums;

namespace LSVRP.New.Entities.Item
{
    public class Phone : ItemEntity
    {
        public Phone(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            if (ItemData.Used)
            {
                ItemData.Used = false;
                SaveItem();
                charData.SendInfo($"Telefon o numerze {ItemData.Value1} został wyłączony.");
                base.UseItem(charData);
                return;
            }
            else
            {
                if (charData.HasItemTypeUsed(ItemType.Phone))
                {
                    charData.SendError("Używasz już innego telefonu.");
                    base.UseItem(charData);
                    return;
                }

                ItemData.Used = true;
                SaveItem();
                charData.SendInfo($"Telefon o numerze {ItemData.Value1} został włączony.");
                base.UseItem(charData);
                return;
            }
        }
    }
}