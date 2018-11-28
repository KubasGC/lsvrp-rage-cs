using LSVRP.Database.Models;
using LSVRP.New.Managers;

namespace LSVRP.New.Entities.Item
{
    public class Eatable : ItemEntity
    {
        public Eatable(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            int playerHealth = charData.PlayerHandle.Health;
            if (playerHealth > 40)
            {
                playerHealth += ItemData.Value1;
                if (playerHealth > 100) playerHealth = 100;

                charData.PlayerHandle.Health = playerHealth;
                charData.Health = playerHealth;
                charData.Save();
                Delete();
                charData.SendInfo($"Spożyłeś \"{ItemData.Name}\".");
                base.UseItem(charData);
            }
            else
            {
                charData.SendError("Masz zbyt mało punktów życia, aby móc go uzupełnić piciem bądź jedzeniem. Zażyj lek.");
                base.UseItem(charData);
            }
        }
    }
}