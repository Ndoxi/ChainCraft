using ChainCraft.Core.Input;

namespace ChainCraft.Infrastracture
{
    public class MainSceneContext : ISceneContext
    {
        public void Install()
        {
            ServiceLocator.Register<IInputChanel>(new InputChanel());   
        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<IInputChanel>();
        }
    }
}
