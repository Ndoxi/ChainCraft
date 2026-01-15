using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class WorldUIMarker : MonoBehaviour
    {
        public Vector3 markerPosition => transform.position + _offset;
        [SerializeField] private Vector3 _offset;
    }
}