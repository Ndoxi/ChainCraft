namespace ChainCraft.Data.Providers
{
    public interface IProvider<TObject>
    {
        T Get<T>() where T : TObject;
    }
}
