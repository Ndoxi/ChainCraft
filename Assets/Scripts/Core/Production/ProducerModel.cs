using ChainCraft.Data;
using ChainCraft.Infrastracture;
using System;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngineInternal;

namespace ChainCraft.Core.Production
{
    public class ProducerModel : ITickable, IDisposable
    {
        public enum ProductionStopReason
        {
            None,
            NoInput,
            OutputFull
        }

        public event Action<ProductionStopReason> productionStoped;
        public event Action productionResumed;

        public float productionProgress => _productionCycle != null ? _productionCycle.progress : 0f;

        private WarehouseModel[] _input;
        private WarehouseModel _output;

        private Recipe _recipe;
        private ProductionCycle _productionCycle;
        private ITicksDispatcher _ticksDispatcher;
        private ProducerState _state;

        public ProducerModel(Recipe recipe, WarehouseModel[] input, WarehouseModel output)
        {
            _recipe = recipe;
            _input = input;
            _output = output;

            ValidateScheme();

            _state = ProducerState.Idle;
            _productionCycle = new ProductionCycle(_recipe.craftDuration);

            _ticksDispatcher = ServiceLocator.Resolve<ITicksDispatcher>();
            _ticksDispatcher.Register(this);
        }

        public void Tick(float delta)
        {
            switch (_state)
            {
                case ProducerState.Idle:

                    if (CanProduce(out var stopReason))
                    {
                        ConsumeInputs();
                        _productionCycle.Reset();
                        _state = ProducerState.Producing;

                        productionResumed?.Invoke();
                    }
                    else
                    {
                        productionStoped?.Invoke(stopReason);
                    }
                    break;

                case ProducerState.Producing:

                    _productionCycle.Tick(delta);

                    if (_productionCycle.isDone)
                    {
                        _output.Store();
                        _productionCycle.Reset();

                        if (CanProduce(out _))
                            ConsumeInputs();
                        else
                            _state = ProducerState.Idle;
                    }
                    break;
            }
        }

        public void Dispose()
        {
            _ticksDispatcher.Unregister(this);
        }

        private void ValidateScheme()
        {
            if (_recipe.input.Length != _input.Length)
                throw new Exception("Invalid scheme detected. Input warehouse count doesn't match recipe.");

            for (int i = 0; i < _recipe.input.Length; i++)
            {
                if (_recipe.input[i] != _input[i].resourceType)
                    throw new Exception($"Invalid scheme: Input {i} type {_input[i].resourceType} " +
                        $"doesn't match recipe {_recipe.input[i]}.");
            }

            if (_recipe.output != _output.resourceType)
                throw new Exception($"Invalid scheme: Output type {_output.resourceType} " +
                    $"doesn't match recipe {_recipe.output}.");
        }

        private bool CanProduce(out ProductionStopReason stopReason)
        {
            foreach (var input in _input)
            {
                if (!input.HasResource())
                {
                    stopReason = ProductionStopReason.NoInput;
                    return false;
                }
            }

            if (!_output.CanStore())
            {
                stopReason = ProductionStopReason.OutputFull;
                return false;
            }

            stopReason = ProductionStopReason.None;
            return true;
        }

        private void ConsumeInputs()
        {
            foreach (var input in _input)
                input.Take();
        }
    }
}