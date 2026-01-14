using ChainCraft.Data;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    public abstract class ProducerBuilder : MonoBehaviour
    {
        public abstract void Build(Recipe recipe, int capacity);
    }
}