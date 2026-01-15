using ChainCraft.Core.Production;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public class CanvasService : ICanvasService
    {
        public WorldUICanvas worldUICanvas { get; }

        public CanvasService(WorldUICanvas worldUICanvas)
        {
            this.worldUICanvas = worldUICanvas;
        }
    }

}