namespace Loco
{
    public interface ILocalStoreConfig
    {
        ILocalStore<T> GetLocalStore<T>()
            where T : Model;
    }
}