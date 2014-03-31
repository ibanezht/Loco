using System;
using System.Threading.Tasks;

namespace Loco.Azure
{
    internal class AzureCloudStore<T> : ICloudStore<T>
        where T : AzureModel
    {
        #region ICloudStore<T> Members

        public Task AddAsync(T model)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}