using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class ResourceView : MonoBehaviour
    {
        public ResourceType resourceType => _resourceType;
        public float height => _height;

        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private float _height = 1f;
    }
}