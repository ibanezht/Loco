using System;
using System.Threading.Tasks;

namespace Loco
{
    public class SynchronizedStore<T> : ISynchronizedStore<T>
        where T : Model
    {
        private readonly ICloudStore<T> _cloudStore;
        private readonly ILocalStore<T> _localStore;

        internal SynchronizedStore(ILocalStoreConfig localStoreConfig, ICloudStoreConfig cloudStoreConfig)
        {
            _localStore = localStoreConfig.GetLocalStore<T>();
            _cloudStore = cloudStoreConfig.GetCloudStore<T>();
        }

        #region ISynchronizedStore<T> Members

        public Task AddAsync(T model)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}