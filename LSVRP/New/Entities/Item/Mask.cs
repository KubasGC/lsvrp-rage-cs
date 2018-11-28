using LSVRP.Database.Models;
using LSVRP.Libraries;

namespace LSVRP.New.Entities.Item
{
    public class Mask : ItemEntity
    {
        public Mask(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            if (ItemData.Used)
            {
                charData.HasMask = false;
                ItemData.Used = false;
                
                Features.Sync.Library.SetPlayerSyncedData(charData.PlayerHandle, "player.visibleName",
                    Player.GetPlayerIcName(charData, true));
            }
            else
            {
                charData.HasMask = true;
                ItemData.Used = true;
                
                Features.Sync.Library.SetPlayerSyncedData(charData.PlayerHandle, "player.visibleName",
                    Player.GetPlayerIcName(charData, false));
            }

            SaveItem();
            base.UseItem(charData);
        }
    }
}