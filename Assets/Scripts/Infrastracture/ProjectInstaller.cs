namespace ChainCraft.Infrastracture
{
    public class ProjectInstaller : SceneInstaller
    {
        protected override ISceneContext _sceneContext 
        {
            get 
            {
                _context ??= new ProjectContext();
                return _context;
            }
        }
        
        private ISceneContext _context;
    }
}
