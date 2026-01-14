namespace ChainCraft.Infrastracture
{
    public interface ITicksDispatcher
    {
        void Register(ITickable tickable);
        void Unregister(ITickable tickable);
    }
}