using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FastFoodly.ViewModel
{
    public class ViewModelBase : ObservableObject, INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Dispose() { }
    }
}