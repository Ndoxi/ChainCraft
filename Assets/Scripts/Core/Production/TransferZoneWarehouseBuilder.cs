using ChainCraft.Core.Gameplay;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    [RequireComponent(typeof(WarehouseView), typeof(ResourceTransferZone))]
    public class TransferZoneWarehouseBuilder : WarehouseBuilder
    {
        public override Warehouse Build(ResourceType resourceType, int capacity)
        {
            var warehouse = base.Build(resourceType, capacity);
            var transferZone = GetComponent<ResourceTransferZone>();
            transferZone.Init(warehouse);

            return warehouse;
        }
    }
}