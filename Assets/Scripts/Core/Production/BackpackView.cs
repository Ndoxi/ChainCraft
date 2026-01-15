using ChainCraft.Data.Providers;
using ChainCraft.Infrastracture;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class BackpackView : MonoBehaviour
    {
        private const float ItemOffset = 0.02f;

        [SerializeField] private Transform _content;
        private BackpackModel _model;
        private ResourcePrefabsConfig _config;
        private List<ResourceView> _items;

        public void Init(BackpackModel model)
        {
            _model = model;
            _config = ServiceLocator.Resolve<IProvider<ScriptableObject>>().Get<ResourcePrefabsConfig>();
            _items = new List<ResourceView>(_model.capacity);

            _model.resourceAdded += AddView;
            _model.resourceRemoved += RemoveView;
        }

        private void OnDestroy()
        {
            _model.resourceAdded -= AddView;
            _model.resourceRemoved -= RemoveView;
        }

        private void AddView()
        {
            var prefab = _config.Get(_model.currentResource);
            var resource = Instantiate(prefab, _content);

            float y;
            var last = _items.LastOrDefault();

            if (last != null)
                y = last.transform.localPosition.y + last.height + ItemOffset;
            else
                y = 0f;

            resource.transform.localPosition = new Vector3(0f, y, 0f);
            _items.Add(resource);
        }

        private void RemoveView()
        {
            if (_items.Count == 0)
                return;

            var view = _items[^1];
            Destroy(view.gameObject);
            _items.RemoveAt(_items.Count - 1);
        }
    }
}