using UnityEngine;

namespace ChainCraft.Core.Production
{
    [RequireComponent(typeof(WarehouseView))]
    public class WarehouseBuilder : MonoBehaviour 
    {
        public Warehouse Build(ResourceType resourceType, int capacity)
        {
            var model = new WarehouseModel(resourceType, capacity);
            var view = GetComponent<WarehouseView>();
            view.Init(model);
            return new Warehouse(model, view);
        }
    }
}