using LSVRP.Database.Models;
using LSVRP.New.Managers;

namespace LSVRP.New.Entities.Item.Drugs
{
    public class Cocaine : ItemEntity
    {
        public Cocaine(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            charData.DrugAddictions.Cocaine += 10; // 10 punktów uzależnienia
            charData.DrugAddictions.CocaineTime += 1800; // 30 minut

            charData.SaveDrugs();

            Features.Chat.Library.SendPlayerMeMessage(charData, "zażywa 1g kokainy.", true);
            Features.Chat.Library.SendPlayerDoMessage(charData, $"{charData.Name} wyciera nos i staje się nadpobudliwy.",
                true);

            Delete();
            base.UseItem(charData);
        }
    }
}