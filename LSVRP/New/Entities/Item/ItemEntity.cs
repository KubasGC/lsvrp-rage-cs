using System;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Items;
using LSVRP.New.Enums;
using LSVRP.New.Extensions;
using LSVRP.New.Managers;

namespace LSVRP.New.Entities.Item
{
    public class ItemEntity
    {
        public int Id => ItemData.Id;
        public string Name => ItemData.Name;
        public ItemType Type => ItemData.Type;
        public int Value1 => ItemData.Value1;
        public int Value2 => ItemData.Value2;
        public bool Used => ItemData.Used;
        public OwnerType OwnerType => ItemData.OwnerType;
        public int Owner => ItemData.Owner;
        public Vector3 Position => new Vector3(ItemData.X, ItemData.Y, ItemData.Z);
        public int Dimension => ItemData.Dimension;

        protected virtual string ItemInfo => "Zwykły przedmiot";

        protected Database.Models.Item ItemData { get; }

        protected ItemEntity(Database.Models.Item itemData)
        {
            ItemData = itemData;
        }

        public virtual void UseItem(Character charData)
        {
            charData.ShowItemUi(true, false);
        }

        public void DropItem(Character charData)
        {
            if (!CheckOwner(charData))
            {
                charData.SendError("Przedmiot nie należy do Ciebie.");
                return;
            }

            if (ItemData.Used)
            {
                charData.SendError("Przedmiot nie może być używany.");
                return;
            }

            if (charData.PlayerHandle.IsInVehicle)
            {
                throw new NotImplementedException();
            }
            else
            {
                ItemData.Owner = 0;
                ItemData.OwnerType = 0;
                ItemData.X = charData.PlayerHandle.Position.X;
                ItemData.Y = charData.PlayerHandle.Position.Y;
                ItemData.Z = charData.PlayerHandle.Position.Z;
                ItemData.Dimension = (int) charData.PlayerHandle.Dimension;
                ItemData.RotZ = charData.PlayerHandle.Heading;

                MakeItemOnGround();
            }
        }

        public void PickItem(Character charData)
        {
            if (ItemData.OwnerType == OwnerType.Player)
            {
                charData.SendError("Przedmiot należy do kogoś innego.");
                return;
            }

            if (ItemData.OwnerType == OwnerType.Vehicle)
            {
                throw new NotImplementedException();
            }
            else
            {
                if (NAPI.Entity.DoesEntityExist(ItemData.ObjectHandle))
                {
                    ItemData.ObjectHandle.Delete();
                }

                ItemData.OwnerType = OwnerType.Player;
                ItemData.Owner = charData.Id;
                ItemData.Used = false;

                charData.SendActionMessage("podnosi przedmiot z ziemi.", true);

                SaveItem();
            }
        }

        public void MakeItemOnGround()
        {
            ItemData.ObjectHandle = NAPI.Object.CreateObject(
                Dropable.GetHashFromItem(ItemData.Type, ItemData.Value1),
                Position,
                new Vector3(0, 0, ItemData.RotZ),
                255,
                (uint) Dimension
            );

            SaveItem();
        }

        protected virtual void SaveItem(bool withSave = true)
        {
            using (Database.Database db = new Database.Database())
            {
                db.Items.Update(ItemData);
                if (withSave) db.SaveChanges();
            }
        }

        protected bool CheckFlag()
        {
            throw new NotImplementedException();
        }

        public bool CheckOwner(Character charData)
        {
            return ItemData.OwnerType == OwnerType.Player && ItemData.Owner == charData.Id;
        }

        public void Delete()
        {
            ItemsManager.Delete(ItemData.Id, ItemData);
        }

        public void SetOwner(OwnerType ownerType, int owner)
        {
            ItemData.OwnerType = ownerType;
            ItemData.Owner = owner;
            SaveItem();
        }

        public void ShowInfo(Character charData)
        {
            charData.SendInfo(ItemInfo);
        }
    }
}