using System;
using System.Threading.Tasks;

namespace Loco
{
    public class SynchronizedStore<T> : ISynchronizedStore<T>
        where T : Model
    {
        private readonly ICloudStore<T> _cloudStore;
        private readonly ILocalStore<T> _localStore;

        internal SynchronizedStore(ILocalStore<T> localStore, ICloudStore<T> cloudStore)
        {
            if (localStore == null)
                throw new ArgumentNullException("localStore");

            if (cloudStore == null)
                throw new ArgumentNullException("cloudStore");

            _localStore = localStore;
            _cloudStore = cloudStore;
        }

        #region ISynchronizedStore<T> Members

        public Task AddAsync(T model)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}