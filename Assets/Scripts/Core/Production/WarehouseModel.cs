using System;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class WarehouseModel
    {
        public event Action<int> updated;

        public ResourceType resourceType { get; private set; }
        public int capacity { get; private set; }
        public int count { get; private set; }

        public WarehouseModel(ResourceType resourceType, int capacity)
        {
            this.resourceType = resourceType;
            this.capacity = capacity;
        }

        public void Store()
        {
            if (count >= capacity)
            {
                Debug.LogError("Warehouse is full!");
                return;
            }

            count++;
            updated?.Invoke(count);
        }

        public void Take()
        {
            if (count <= 0)
            {
                Debug.LogError("Warehouse is empty!");
                return;
            }

            count--;
            updated?.Invoke(count);
        }

        public bool CanStore()
        {
            return count < capacity;
        }

        public bool HasResource()
        {
            return count > 0;
        }
    }
}