using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Libraries;
using LSVRP.Managers;

namespace LSVRP.Features.Items
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.items.useItem")]
        public void Event_UseItem(Client player, int itemId)
        {
            Library.UseItem(player, itemId, true);
        }

        [RemoteEvent("server.items.dropItem")]
        public void Event_DropItem(Client player, int itemId)
        {
            Library.DropItem(player, itemId, true);
        }

        [RemoteEvent("server.items.pickItem")]
        public void Event_PickItem(Client player, int itemId)
        {
            Library.PickItem(player, itemId, true);
        }

        [RemoteEvent("server.items.showUi")]
        public void Event_ShowUi(Client player)
        {
            Library.ShowUi(player);
        }

        [RemoteEvent("server.items.shotWeapon")]
        public void Event_ShotWeapon(Client player, string weaponHash, int ammo)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (charData.UsedWeapon == null)
            {
                player.RemoveAllWeapons();
                return;
            }

            WeaponHash wHash = Data.WeaponHashes[charData.UsedWeapon.Value1];
            if ((long) Command.GetDoubleFromString(weaponHash) != (long) wHash && ammo > 0)
            {
                Ui.ShowError(player, "Broń nie zgadza się z używaną.");
                player.RemoveAllWeapons();
                charData.UsedWeapon.Used = false;
                charData.UsedWeapon.Save();
                charData.UsedWeapon = null;
                return;
            }

            charData.UsedWeapon.Value2--;
            if (charData.UsedWeapon.Value2 <= 0)
            {
                Ui.ShowInfo(player, "W broni skończyła się amunicja.");
                player.RemoveAllWeapons();
                charData.UsedWeapon.Used = false;
                charData.UsedWeapon.Value2 = 0;
                charData.UsedWeapon.Save();
                charData.UsedWeapon = null;
                return;
            }
            
            // Player.SendFormattedChatMessage(player, $"Broń: {weaponHash}, ammo: {ammo}", Constants.ColorPictonBlue);
        }
    }
}