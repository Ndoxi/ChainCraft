using ChainCraft.Data.Providers;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public class ProjectContext : ISceneContext
    {
        private readonly ScriptableObjectsProviderConfig _config;
        private readonly ITicksDispatcher _ticksDispatcher;
        private readonly IAnimationPlayer _animationPlayer;

        public ProjectContext(ScriptableObjectsProviderConfig config,
                              ITicksDispatcher ticksDispatcher,
                              IAnimationPlayer animationPlayer)
        {
            _config = config;
            _ticksDispatcher = ticksDispatcher;
            _animationPlayer = animationPlayer;
        }

        public void Install()
        {
            ServiceLocator.Register<ISceneLoader>(new SceneLoader());
            ServiceLocator.Register<IProvider<ScriptableObject>>(new ScriptableObjectsProvider(_config));
            ServiceLocator.Register(_ticksDispatcher);
            ServiceLocator.Register(_animationPlayer);
        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<ISceneLoader>();
            ServiceLocator.Unregister<IProvider<ScriptableObject>>();
            ServiceLocator.Unregister<ITicksDispatcher>();
            ServiceLocator.Unregister<IAnimationPlayer>();
        }
    }
}
