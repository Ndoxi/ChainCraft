using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public abstract class SceneInstaller : MonoBehaviour
    {
        protected abstract ISceneContext _sceneContext { get; }
        private bool _installed;

        public void Run()
        {
            _sceneContext.Install();
            _installed = true;
        }

        private void OnDestroy()
        {
            if (!_installed)
                return;

            _sceneContext.Uninstall();
            _installed = false;
        }
    }
}
