using System;
using System.Collections.Generic;

namespace Loco
{
    public class SynchronizedStoreFactory
    {
        private static readonly Dictionary<Type, ISynchronizedStore> _storeDictionary = new Dictionary<Type, ISynchronizedStore>();

        public ISynchronizedStore<T> Get<T>() where T : Model
        {
            var modelType = typeof(T);
            var retval = _storeDictionary[modelType] as SynchronizedStore<T>;

            if (retval == null)
            {
                retval = new SynchronizedStore<T>(null, null);

                _storeDictionary.Add(modelType, retval);
            }

            return retval;
        }
    }
}