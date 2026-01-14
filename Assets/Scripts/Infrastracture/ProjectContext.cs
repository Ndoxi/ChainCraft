using ChainCraft.Data.Providers;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public class ProjectContext : ISceneContext
    {
        private readonly ScriptableObjectsProviderConfig _config;

        public ProjectContext(ScriptableObjectsProviderConfig config)
        {
            _config = config;
        }

        public void Install()
        {
            ServiceLocator.Register<ISceneLoader>(new SceneLoader());
            ServiceLocator.Register<IProvider<ScriptableObject>>(new ScriptableObjectsProvider(_config));
        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<ISceneLoader>();
            ServiceLocator.Unregister<IProvider<ScriptableObject>>();
        }
    }
}
