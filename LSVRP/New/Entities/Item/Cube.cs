using LSVRP.Database.Models;
using LSVRP.Libraries;

namespace LSVRP.New.Entities.Item
{
    public class Cube : ItemEntity
    {
        public Cube(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            int cubeScore = Global.GetRandom(1, 6);
            charData.SendActionMessage($"rzucił kostką wyrzucając {cubeScore} oczko(a).", true);
            base.UseItem(charData);
        }
    }
}