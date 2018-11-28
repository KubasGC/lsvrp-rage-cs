using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Items;
using LSVRP.New.Constants;

namespace LSVRP.New.Entities.Item
{
    public class Weapon : ItemEntity
    {
        private WeaponHash? WeaponHash
        {
            get
            {
                if (ItemsConstants.WeaponHashes.ContainsKey(ItemData.Value1))
                {
                    return ItemsConstants.WeaponHashes[ItemData.Value1];
                }

                return null;
            }
        }

        private int WeaponAmmo => ItemData.Value2;
        private string WeaponName => ItemData.Name;


        public Weapon(Database.Models.Item itemData) : base(itemData)
        {
        }

        public override void UseItem(Character charData)
        {
            if (WeaponHash == null)
            {
                charData.SendError("Broń jest utworzona niepoprawnie.");
                base.UseItem(charData);
                return;
            }

            if (ItemData.Used)
            {
                charData.PlayerHandle.RemoveAllWeapons();
                charData.SendActionMessage($"chowa broń \"{WeaponName}\".");
                charData.UsedWeapon = null;
                ItemData.Used = false;
                SaveItem();
            }
            else
            {
                if (WeaponAmmo <= 0)
                {
                    charData.SendError("Broń nie ma amunicji.");
                    base.UseItem(charData);
                    return;
                }

                if (charData.GetUsedGuns() > 0)
                {
                    charData.SendError("Możesz używać jednocześnie tylko jednej broni.");
                    base.UseItem(charData);
                    return;
                }

                ItemData.Used = true;
                charData.PlayerHandle.GiveWeapon((WeaponHash) WeaponHash, WeaponAmmo);
                charData.SendActionMessage($"wyciąga broń \"{WeaponName}\".");
                charData.UsedWeapon = ItemData;
                SaveItem();
                base.UseItem(charData);
            }

            base.UseItem(charData);
        }
    }
}