using ChainCraft.Data.Providers;
using ChainCraft.Infrastracture;
using System;
using UnityEngine;
using UnityEngine.Windows;

namespace ChainCraft.Core.Production
{
    public class WarehouseBufferLogic : ITickable, IDisposable
    {
        private Warehouse _input;
        private Warehouse _output;
        private IAnimationPlayer _animationPlayer;
        private ResourceView _prefab;
        private AnimationsConfig.Animation _animation;
        private ITicksDispatcher _ticksDispatcher;
        private int _count;

        public WarehouseBufferLogic(Warehouse input, Warehouse output)
        {
            _input = input;
            _output = output;

            _animationPlayer = ServiceLocator.Resolve<IAnimationPlayer>();

            var provider = ServiceLocator.Resolve<IProvider<ScriptableObject>>();
            _prefab = provider.Get<ResourcePrefabsConfig>().Get(_input.model.resourceType);
            _animation = provider.Get<AnimationsConfig>().throwAnimation;

            _ticksDispatcher = ServiceLocator.Resolve<ITicksDispatcher>();
            _ticksDispatcher.Register(this);

            ValidateData();
        }

        private void ValidateData()
        {
            if (_input.model.resourceType != _output.model.resourceType)
                throw new Exception("Input and output resource types does not match!");
        }

        public void Tick(float delta)
        {
            if (!_input.model.HasResource() || 
                !TransferAllowed())
            {
                return;
            }

            _input.model.Take();
            _count++;

            var resourceView = UnityEngine.Object.Instantiate(_prefab);

            _animationPlayer.Play(
                resourceView.gameObject, 
                _input.view.transform.position, 
                _output.view.transform.position, 
                _animation,
                onComplete: () =>
                {
                    _output.model.Store();
                    _count--;
                });
        }

        public void Dispose()
        {
            _ticksDispatcher.Unregister(this);
        }

        private bool TransferAllowed()
        {
            return _output.model.CanStore() 
                && _output.model.count + _count <= _output.model.capacity;
        }
    }
}