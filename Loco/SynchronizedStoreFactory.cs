using System;
using Microsoft.Practices.ServiceLocation;

namespace Loco
{
    public class SynchronizedStoreFactory
    {
        public ISynchronizedStore<T> Create<T>() where T : Model
        {
            var localStore = ServiceLocator.Current.GetInstance<ILocalStore<T>>();
            if (localStore == null)
                throw new InvalidOperationException("ILocalStore<T> implementation not registered.");

            var cloudStore = ServiceLocator.Current.GetInstance<ICloudStore<T>>();
            if (cloudStore == null)
                throw new InvalidOperationException("ICloudStore<T> implementation not registered.");

            return new SynchronizedStore<T>(localStore, cloudStore);
        }
    }
}