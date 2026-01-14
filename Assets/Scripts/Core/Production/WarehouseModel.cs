using System;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class WarehouseModel
    {
        public event Action<int> updated;

        public readonly ResourceType resourceType;

        private readonly int _capacity;
        private int _count;

        public WarehouseModel(ResourceType resourceType, int capacity)
        {
            this.resourceType = resourceType;
            _capacity = capacity;
        }

        public void Store()
        {
            if (_count >= _capacity)
            {
                Debug.LogError("Warehouse is full!");
                return;
            }

            _count++;
            updated?.Invoke(_count);
        }

        public void Get()
        {
            if (_count <= 0)
            {
                Debug.LogError("Warehouse is empty!");
                return;
            }

            _count--;
            updated?.Invoke(_count);
        }

        public bool CanStore()
        {
            return _count < _capacity;
        }

        public bool HasResource()
        {
            return _count > 0;
        }
    }

    public class WarehouseView : MonoBehaviour
    {
        [SerializeField] private Transform _pivot;
        private WarehouseModel _model;

        public void Init(WarehouseModel model)
        {
            _model = model;

            _model.updated += OnUpdated;
        }

        private void OnDestroy()
        {
            if (_model != null)
                _model.updated -= OnUpdated;
        }

        private void OnUpdated(int count)
        {

        }
    }
}