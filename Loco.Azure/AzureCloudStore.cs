using System;
using System.Threading.Tasks;

namespace Loco.Azure
{
    internal class AzureCloudStore : ICloudStore<AzureModel>
    {
        #region ICloudStore<AzureModel> Members

        public Task AddAsync(AzureModel model)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}