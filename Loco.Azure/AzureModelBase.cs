using System;
using Microsoft.WindowsAzure.MobileServices;

namespace Loco.Azure
{
    public abstract class AzureModelBase : ModelBase
    {
        private DateTime _createdAt;
        private DateTime _updatedAt;

        [CreatedAt]
        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set
            {
                _createdAt = value;
                RaisePropertyChanged();
            }
        }

        [UpdatedAt]
        public DateTime UpdatedAt
        {
            get { return _updatedAt; }
            set
            {
                _updatedAt = value;
                RaisePropertyChanged();
            }
        }
    }
}