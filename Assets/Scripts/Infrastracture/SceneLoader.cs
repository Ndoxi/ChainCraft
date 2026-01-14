using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace ChainCraft.Infrastracture
{
    public class SceneLoader : ISceneLoader
    {
        public Task LoadAsync(string sceneName)
        {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            var tcs = new TaskCompletionSource<object>();
            asyncOperation.completed += result => tcs.SetResult(null);

            return tcs.Task;
        }
    }
}
