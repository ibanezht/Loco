using System;
using System.Collections.Generic;

namespace Loco
{
    public static class SyncStoreContainer
    {
        private static readonly Dictionary<Type, ISyncStore> _storeDictionary = new Dictionary<Type, ISyncStore>();

        public static void Clear()
        {
            _storeDictionary.Clear();
        }

        public static ISyncStore<T> GetSyncStore<T>()
            where T : Model
        {
            var type = typeof(T);

            if (!_storeDictionary.ContainsKey(type))
                throw new InvalidOperationException(string.Format("The type {0} is not registered.", type));

            return (SyncStore<T>)_storeDictionary[type];
        }

        public static void RegisterType<T>(ILocalStoreConfig localStoreConfig, ICloudStoreConfig cloudStoreConfig)
            where T : Model
        {
            if (localStoreConfig == null)
                throw new ArgumentNullException("localStoreConfig");

            if (cloudStoreConfig == null)
                throw new ArgumentNullException("cloudStoreConfig");

            var localStore = localStoreConfig.GetLocalStore<T>();
            var cloudStore = cloudStoreConfig.GetCloudStore<T>();

            var synchronizedStore = new SyncStore<T>(localStore, cloudStore);

            _storeDictionary.Add(typeof(T), synchronizedStore);
        }
    }
}