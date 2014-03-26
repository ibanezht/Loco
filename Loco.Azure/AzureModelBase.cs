using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.WindowsAzure.MobileServices;

namespace Loco.Azure
{
    public abstract class AzureModelBase : ModelBase, INotifyPropertyChanged
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
                OnPropertyChanged();
            }
        }

        [UpdatedAt]
        public DateTime UpdatedAt
        {
            get { return _updatedAt; }
            set
            {
                _updatedAt = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}