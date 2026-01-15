using ChainCraft.Data.Providers;
using ChainCraft.Infrastracture;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

namespace ChainCraft.Core.Production
{
    public class WarehouseView : MonoBehaviour
    {
        private const float ItemOffset = 0.02f;

        [SerializeField] private Transform _content;
        private WarehouseModel _model;
        private ResourceView _prefab;
        private List<ResourceView> _items;

        public void Init(WarehouseModel model)
        {
            _model = model;

            _prefab = ServiceLocator.Resolve<IProvider<ScriptableObject>>()
                .Get<ResourcePrefabsConfig>()
                .Get(_model.resourceType);

            InitStackView();

            _model.updated += UpdateView;
        }

        private void OnDestroy()
        {
            if (_model != null)
                _model.updated -= UpdateView;
        }

        private void UpdateView(int count)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].gameObject.SetActive(i < count);
            }
        }

        private void InitStackView()
        {
            _items = new List<ResourceView>(_model.capacity);
            for (int i = 0; i < _model.capacity; i++)
            {
                var resource = Instantiate(_prefab, _content);
                Vector3 pos = new()
                {
                    y = i * (resource.height + ItemOffset)
                };

                resource.transform.localPosition = pos;
                resource.gameObject.SetActive(false);
                _items.Add(resource);
            }
        }
    }
}