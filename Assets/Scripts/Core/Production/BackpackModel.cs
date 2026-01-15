using System;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class BackpackModel
    {
        public event Action resourceAdded;
        public event Action resourceRemoved;

        public ResourceType currentResource { get; private set; }
        public int capacity { get; private set; }
        public int count { get; private set; }

        public BackpackModel(int capacity)
        {
            this.capacity = capacity;
        }

        public void SetResourceType(ResourceType resourceType)
        {
            if (currentResource == ResourceType.None)
                currentResource = resourceType;
        }

        public bool CanStore(ResourceType resourceType)
        {
            if (count >= capacity)
                return false;

            return currentResource == ResourceType.None || currentResource == resourceType;
        }

        public bool HasResource(ResourceType resourceType)
        {
            return currentResource == resourceType && count > 0;
        }

        public void Store(ResourceType resourceType)
        {
            if (!CanStore(resourceType))
            {
                Debug.LogError($"Backpack cant store resource! " +
                    $"Type:{resourceType} count:{count} capacity:{capacity}");
                return;
            }

            if (currentResource == ResourceType.None)
                currentResource = resourceType;

            count++;
            resourceAdded?.Invoke();
        }

        public void Take(ResourceType resourceType)
        {
            if (!HasResource(resourceType))
            {
                Debug.LogError($"Backpack doesnt have resource! " +
                    $"Type:{resourceType} count:{count} capacity:{capacity}");
                return;
            }

            count--;
            if (count <= 0)
                currentResource = ResourceType.None;
            resourceRemoved?.Invoke();
        }
    }
}