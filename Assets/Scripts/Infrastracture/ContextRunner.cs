using UnityEngine;

namespace ChainCraft.Infrastracture
{
    [RequireComponent(typeof(SceneInstaller))]
    public class ContextRunner : MonoBehaviour
    {
        private void Awake()
        {
            var context = GetComponent<SceneInstaller>();
            context.Run();
        }
    }
}
