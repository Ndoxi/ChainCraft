using ChainCraft.Data;
using ChainCraft.Data.Providers;
using ChainCraft.Infrastracture;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    [RequireComponent(typeof(WorldUIMarker))]
    public class ProducerUIBuilder : MonoBehaviour
    {
        public void Build(ProducerModel producerModel)
        {
            var marker = GetComponent<WorldUIMarker>();
            var prefab = ServiceLocator.Resolve<IProvider<ScriptableObject>>().Get<PrefabsConfig>().producerUIPrefab;
            var canvas = ServiceLocator.Resolve<ICanvasService>().worldUICanvas;

            var ui = canvas.Spawn(prefab, marker);
            ui.Init(producerModel);
        }
    }
}