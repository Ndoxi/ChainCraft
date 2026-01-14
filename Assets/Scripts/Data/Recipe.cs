using ChainCraft.Core.Production;
using System;

namespace ChainCraft.Data
{
    [Serializable]
    public struct Recipe
    {
        public ResourceType[] input;
        public ResourceType output;
        public float craftDuration;
    }

}