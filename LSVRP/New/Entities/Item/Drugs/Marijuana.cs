using LSVRP.Database.Models;
using LSVRP.New.Managers;

namespace LSVRP.New.Entities.Item.Drugs
{
    public class Marijuana : ItemEntity
    {
        public Marijuana(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            charData.DrugAddictions.Marijuana += 1;
            charData.DrugAddictions.MarijuanaTime += 900;

            charData.SaveDrugs();

            Features.Chat.Library.SendPlayerMeMessage(charData, "zażywa 1g marihuany.", true);
            Features.Chat.Library.SendPlayerDoMessage(charData, $"{charData.Name} staje się zrelaksowany.", true);

            Features.Sync.Library.SyncPlayerForPlayer(charData.PlayerHandle);

            charData.DoDrugEffects();
            Delete();
            base.UseItem(charData);
        }
    }
}