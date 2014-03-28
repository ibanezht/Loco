using System;
using Microsoft.WindowsAzure.MobileServices;

namespace Loco.Azure
{
    public abstract class AzureModel : Model
    {
        private DateTime _createdAt;
        private DateTime _updatedAt;
        private string _version;

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

        [Version]
        public string Version
        {
            get { return _version; }
            set
            {
                _version = value;
                RaisePropertyChanged();
            }
        }
    }
}