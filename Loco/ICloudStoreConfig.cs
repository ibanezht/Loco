namespace Loco
{
    public interface ICloudStoreConfig
    {
        ICloudStore<T> GetCloudStore<T>()
            where T : Model;
    }
}