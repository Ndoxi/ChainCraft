using ChainCraft.Data;
using System;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class ProducerBuilder : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] private WarehouseBuilder[] _inputWarehouseBuilders;
        [Header("Output")]
        [SerializeField] private WarehouseBuilder _outputWarehouseBuilder;
        [SerializeField] private BufferWarehouseBuilder _outputbufferBuilder;
        [Header("Storage")]
        [SerializeField] private WarehouseBuilder _storageWarehouseBuilder;

        private ProducerModel _producer;

        public void Build(Recipe recipe, int capacity)
        {
            var models = new WarehouseModel[_inputWarehouseBuilders.Length];
            for (int i = 0; i < _inputWarehouseBuilders.Length; i++)
            {
                var warehouse = _inputWarehouseBuilders[i].Build(recipe.input[i], capacity);
                models[i] = warehouse.model;
            }

            var output = _outputWarehouseBuilder.Build(recipe.output, capacity);
            var storage = _storageWarehouseBuilder.Build(recipe.output, capacity);
            _outputbufferBuilder.Build(output, storage);

            _producer = new ProducerModel(recipe, models, output.model);
        }

        private void OnDestroy()
        {
            _producer?.Dispose();
        }
    }
}