using ChainCraft.Core.Production;
using System;
using UnityEngine;

namespace ChainCraft.Data.Providers
{
    [CreateAssetMenu(menuName = "Scriptable Objects/ResoursesPrefabsConfig")]
    public class ResourcePrefabsConfig : ScriptableObject
    {
        [SerializeField] private ResourceView[] _prefabs;

        public ResourceView Get(ResourceType resourceType)
        {
            foreach (var prefab in _prefabs)
            {
                if (prefab.resourceType == resourceType)
                    return prefab;
            }

            throw new Exception($"Prefab for {resourceType} type not found!");
        }
    }
}
