using System;

namespace LSVRP.New.Core.Items
{
    [Serializable]
    public class ClientItem
    {
        public ClientItem(int itemId, string itemName, bool itemUsed)
        {
            Id = itemId;
            Name = itemName;
            Used = itemUsed;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Used { get; set; }
    }
}