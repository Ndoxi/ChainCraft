using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class BufferWarehouseBuilder : MonoBehaviour
    {
        private WarehouseBufferLogic _buffer;

        public void Build(Warehouse input, Warehouse output)
        {
            _buffer = new WarehouseBufferLogic(input, output);
        }

        private void OnDestroy()
        {
            _buffer?.Dispose();
        }
    }
}