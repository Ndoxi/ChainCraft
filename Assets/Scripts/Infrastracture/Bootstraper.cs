using ChainCraft.Data.Constants;
using System.Collections;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public class Bootstraper : MonoBehaviour
    {
        private void Awake()
        {
            Init();
            LoadMainScene();
        }

        private void Init()
        {
            var prefab = Resources.Load<GameObject>(BootstraperResourceNames.ProjectInstaller);
            var installer = Instantiate(prefab);
            DontDestroyOnLoad(installer);
        }

        private async void LoadMainScene()
        {
            var loader = ServiceLocator.Resolve<ISceneLoader>();
            await loader.LoadAsync(SceneNames.Main);
        }
    }
}
