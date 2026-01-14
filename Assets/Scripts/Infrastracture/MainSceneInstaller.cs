namespace ChainCraft.Infrastracture
{
    public class MainSceneInstaller : SceneInstaller
    {
        protected override ISceneContext _sceneContext
        {
            get
            {
                _context ??= new MainSceneContext();
                return _context;
            }
        }

        private ISceneContext _context;
    }
}
