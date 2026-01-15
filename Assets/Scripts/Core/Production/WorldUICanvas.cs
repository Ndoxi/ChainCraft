using Unity.VisualScripting;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class WorldUICanvas : MonoBehaviour
    {
        public T Spawn<T>(T prefab, WorldUIMarker marker) where T : Object
        {
            var item = Instantiate(prefab, transform);
            var worldUi = item.AddComponent<WorldUI>();
            worldUi.Init(marker);

            return item;
        }
    }
}