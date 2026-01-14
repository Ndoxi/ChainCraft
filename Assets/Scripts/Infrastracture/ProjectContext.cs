namespace ChainCraft.Infrastracture
{
    public class ProjectContext : ISceneContext
    {
        public void Install()
        {
            ServiceLocator.Register<ISceneLoader>(new SceneLoader());
        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<ISceneLoader>();
        }
    }
}
