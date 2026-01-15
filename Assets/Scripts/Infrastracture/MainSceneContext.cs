using ChainCraft.Core.Input;
using ChainCraft.Core.Production;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public class MainSceneContext : ISceneContext
    {
        private readonly WorldUICanvas _worldUICanvas;

        public MainSceneContext(WorldUICanvas worldUICanvas) 
        {
            _worldUICanvas = worldUICanvas;
        }

        public void Install()
        {
            ServiceLocator.Register<IInputChanel>(new InputChanel());   
            ServiceLocator.Register<ICanvasService>(new CanvasService(_worldUICanvas));
        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<IInputChanel>();
            ServiceLocator.Unregister<ICanvasService>();
        }
    }
}
