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
            var type = typeof(T);

            if (!_storeDictionary.ContainsKey(type))
                throw new InvalidOperationException(string.Format("The type {0} is not registered.", type));

            return (SynchronizedStore<T>)_storeDictionary[type];
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

            var synchronizedStore = new SynchronizedStore<T>(localStore, cloudStore);

            _storeDictionary.Add(typeof(T), synchronizedStore);
        }
    }
}