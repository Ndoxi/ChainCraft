using ChainCraft.Data.Providers;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public class ProjectContext : ISceneContext
    {
        private readonly ScriptableObjectsProviderConfig _config;
        private readonly ITicksDispatcher _ticksDispatcher;

        public ProjectContext(ScriptableObjectsProviderConfig config, ITicksDispatcher ticksDispatcher)
        {
            _config = config;
            _ticksDispatcher = ticksDispatcher;
        }

        public void Install()
        {
            ServiceLocator.Register<ISceneLoader>(new SceneLoader());
            ServiceLocator.Register<IProvider<ScriptableObject>>(new ScriptableObjectsProvider(_config));
            ServiceLocator.Register(_ticksDispatcher);
        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<ISceneLoader>();
            ServiceLocator.Unregister<IProvider<ScriptableObject>>();
            ServiceLocator.Unregister<ITicksDispatcher>();
        }
    }
}
