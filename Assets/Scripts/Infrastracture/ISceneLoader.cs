using System.Threading.Tasks;

namespace ChainCraft.Infrastracture
{
    public interface ISceneLoader
    {
        Task LoadAsync(string sceneName);
    }
}
