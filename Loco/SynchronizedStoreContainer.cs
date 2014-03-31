using System;
using System.Collections.Generic;

namespace Loco
{
    public static class SynchronizedStoreContainer
    {
        private static readonly Dictionary<Type, ISynchronizedStore> _storeDictionary = new Dictionary<Type, ISynchronizedStore>();

        public static void Clear()
        {
            _storeDictionary.Clear();
        }

        public static ISynchronizedStore<T> GetSynchronizedStore<T>()
            where T : Model
        {
            SynchronizedStore<T> retval = null;

            if (_storeDictionary.ContainsKey(typeof(T)))
                retval = (SynchronizedStore<T>)_storeDictionary[typeof(T)];

            return retval;
        }

        public static void RegisterType<T>(ILocalStoreConfig localStoreConfig, ICloudStoreConfig cloudStoreConfig)
            where T : Model
        {
            if (localStoreConfig == null)
                throw new ArgumentNullException("localStoreConfig");

            if (cloudStoreConfig == null)
                throw new ArgumentNullException("cloudStoreConfig");

            var synchronizedStore = new SynchronizedStore<T>(localStoreConfig, cloudStoreConfig);

            _storeDictionary.Add(typeof(T), synchronizedStore);
        }
    }
}