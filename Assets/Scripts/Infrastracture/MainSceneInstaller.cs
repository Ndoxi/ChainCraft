using ChainCraft.Core.Production;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public class MainSceneInstaller : SceneInstaller
    {
        protected override ISceneContext _sceneContext
        {
            get
            {
                _context ??= new MainSceneContext(_worldUICanvas);
                return _context;
            }
        }

        [SerializeField] private WorldUICanvas _worldUICanvas;

        private ISceneContext _context;
    }
}
