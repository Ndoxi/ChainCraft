using ChainCraft.Data;
using System;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class PowderProducerBuilder : ProducerBuilder
    {
        [Header("Output")]
        [SerializeField] private WarehouseBuilder _outputWarehouseBuilder;
        [SerializeField] private BufferWarehouseBuilder _outputbufferBuilder;
        [Header("Storage")]
        [SerializeField] private WarehouseBuilder _storageWarehouseBuilder;

        private ProducerModel _producer;

        public override void Build(Recipe recipe, int capacity)
        {
            var output = _outputWarehouseBuilder.Build(recipe.output, capacity);
            var storage = _storageWarehouseBuilder.Build(recipe.output, capacity);
            _outputbufferBuilder.Build(output, storage);

            _producer = new ProducerModel(recipe, Array.Empty<WarehouseModel>(), output.model);
        }

        private void OnDestroy()
        {
            _producer?.Dispose();
        }
    }
}