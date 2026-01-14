using ChainCraft.Data.Providers;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public class ProjectInstaller : SceneInstaller
    {
        protected override ISceneContext _sceneContext 
        {
            get 
            {
                _context ??= new ProjectContext(_config, _ticksDispatcher);
                return _context;
            }
        }

        [SerializeField] private ScriptableObjectsProviderConfig _config;
        [SerializeField] private TicksDispatcher _ticksDispatcher;

        private ISceneContext _context;
    }
}
