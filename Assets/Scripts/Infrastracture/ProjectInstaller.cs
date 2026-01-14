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
                _context ??= new ProjectContext(_config, _ticksDispatcher, _animationPlayer);
                return _context;
            }
        }

        [SerializeField] private ScriptableObjectsProviderConfig _config;
        [SerializeField] private TicksDispatcher _ticksDispatcher;
        [SerializeField] private AnimationPlayer _animationPlayer;

        private ISceneContext _context;
    }
}
