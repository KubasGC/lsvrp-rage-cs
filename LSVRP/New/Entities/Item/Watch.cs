using System;
using LSVRP.Database.Models;
using LSVRP.Libraries;

namespace LSVRP.New.Entities.Item
{
    public class Watch : ItemEntity
    {
        public Watch(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            charData.SendActionMessage("spogląda na zegarek", true);
            Player.SendFormattedChatMessage(charData.PlayerHandle,
                $"Aktualna godzina: {DateTime.Now.Hour:00}:{DateTime.Now.Minute:00}:{DateTime.Now.Second:00}",
                Libraries.Constants.ColorPictonBlue);
            base.UseItem(charData);
        }
    }
}