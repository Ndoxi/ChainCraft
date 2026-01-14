using ChainCraft.Data;
using ChainCraft.Infrastracture;
using System;

namespace ChainCraft.Core.Production
{
    public class ProducerModel : ITickable, IDisposable
    {
        private readonly Recipe _recipe;
        private readonly WarehouseModel[] _input;
        private readonly WarehouseModel _output;
        private readonly ITicksDispatcher _dispatcher;
        private ProductionCycle _productionCycle;

        private ProducerState _state;

        public ProducerModel(Recipe recipe, WarehouseModel[] input, WarehouseModel output)
        {
            _recipe = recipe;
            _input = input;
            _output = output;

            _dispatcher = ServiceLocator.Resolve<ITicksDispatcher>();
        }

        public void Init()
        {
            ValidateScheme();

            _state = ProducerState.Idle;
            _productionCycle = new ProductionCycle(_recipe.craftDuration);

            _dispatcher.Register(this);
        }

        public void Tick(float delta)
        {
            switch (_state)
            {
                case ProducerState.Idle:

                    if (CanProduce())
                    {
                        ConsumeInputs();
                        _productionCycle.Reset();
                        _state = ProducerState.Producing;
                    }
                    break;

                case ProducerState.Producing:

                    _productionCycle.Tick(delta);

                    if (_productionCycle.isDone)
                    {
                        _output.Store();
                        _productionCycle.Reset();

                        if (CanProduce())
                            ConsumeInputs();
                        else
                            _state = ProducerState.Idle;
                    }
                    break;
            }
        }

        public void Dispose()
        {
            _dispatcher.Unregister(this);
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

        private bool CanProduce()
        {
            foreach (var input in _input)
            {
                if (!input.HasResource())
                    return false;
            }

            return _output.CanStore();
        }

        private void ConsumeInputs()
        {
            foreach (var input in _input)
                input.Get();
        }
    }
}