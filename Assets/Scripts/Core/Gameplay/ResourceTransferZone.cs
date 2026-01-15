using ChainCraft.Core.Production;
using ChainCraft.Data.Providers;
using ChainCraft.Infrastracture;
using System;
using UnityEngine;

namespace ChainCraft.Core.Gameplay
{
    public class ResourceTransferZone : MonoBehaviour
    {
        public enum Mode 
        { 
            ToBackpack,
            ToWarehouse
        }

        [SerializeField] private InteractableZone _zone;
        [SerializeField] private Mode _loadMode;
        [SerializeField] private float _loadingIntervals = 0.75f;

        private int _transferingCount;
        private Warehouse _warehouse;
        private IAnimationPlayer _animationPlayer;
        private AnimationsConfig.Animation _throwAnimationParams;
        private ResourcePrefabsConfig _prefabs;
        private double _lastLoadingTime;

        public void Init(Warehouse warehouse)
        {
            _warehouse = warehouse;

            _animationPlayer = ServiceLocator.Resolve<IAnimationPlayer>();

            var provider = ServiceLocator.Resolve<IProvider<ScriptableObject>>();
            _throwAnimationParams = provider.Get<AnimationsConfig>().throwAnimation;
            _prefabs = provider.Get<ResourcePrefabsConfig>();
        }

        private void OnEnable()
        {
            _zone.onStay += TransferResource;
        }

        private void OnDisable()
        {
            _zone.onStay -= TransferResource;
        }

        private void TransferResource(Player player)
        {
            if (_lastLoadingTime + _loadingIntervals > Time.timeAsDouble)
                return;
            if (TryLoad(player))
                _lastLoadingTime = Time.timeAsDouble;
        }

        private bool TryLoad(Player player)
        {
            if (!CanStore(player))
                return false;
            if (!HasResource(player))
                return false;

            switch (_loadMode)
            {
                case Mode.ToBackpack:
                    TransferToBackpack(player);
                    return true;

                case Mode.ToWarehouse:
                    TransferToWarehouse(player);
                    return true;

                default:
                    throw new InvalidOperationException($"Unsupported mode! Mode:{_loadMode}");

            }
        }

        private bool CanStore(Player player)
        {
            return _loadMode switch
            {
                Mode.ToBackpack => player.backpack.model.CanStore(_warehouse.model.resourceType) 
                                        && player.backpack.model.count + _transferingCount < player.backpack.model.capacity,

                Mode.ToWarehouse => _warehouse.model.resourceType == player.backpack.model.currentResource
                                        && _warehouse.model.CanStore() 
                                        && _warehouse.model.count + _transferingCount < _warehouse.model.capacity,

                _ => throw new InvalidOperationException($"Unsupported mode! Mode:{_loadMode}"),
            };
        }

        private bool HasResource(Player player)
        {
            return _loadMode switch
            {
                Mode.ToBackpack => _warehouse.model.HasResource() 
                    && player.backpack.model.CanStore(_warehouse.model.resourceType),

                Mode.ToWarehouse => player.backpack.model.HasResource(_warehouse.model.resourceType),

                _ => throw new InvalidOperationException($"Unsupported mode! Mode:{_loadMode}"),
            };
        }

        private void TransferToBackpack(Player player)
        {
            player.backpack.model.SetResourceType(_warehouse.model.resourceType);

            _warehouse.model.Take();
            _transferingCount++;

            var resourceView = CreateResourceView(_warehouse.model.resourceType);

            _animationPlayer.PlayHoming(
                resourceView, 
                _warehouse.view.transform.position, 
                () => player.backpack.view.transform.position, 
                _throwAnimationParams, 
                onComplete: () =>
                {
                    _transferingCount--;
                    player.backpack.model.Store(_warehouse.model.resourceType);
                }); 
        }

        private void TransferToWarehouse(Player player)
        {
            player.backpack.model.Take(_warehouse.model.resourceType);
            _transferingCount++;

            var resourceView = CreateResourceView(_warehouse.model.resourceType);

            _animationPlayer.Play(
                resourceView,
                player.backpack.view.transform.position,
                _warehouse.view.transform.position,
                _throwAnimationParams,
                onComplete: () =>
                {
                    _transferingCount--;
                    _warehouse.model.Store();
                });
        }

        private GameObject CreateResourceView(ResourceType resourceType)
        {
            var prefab = _prefabs.Get(resourceType);
            return Instantiate(prefab).gameObject;
        }
    }
}
