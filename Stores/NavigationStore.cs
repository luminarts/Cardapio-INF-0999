using CommunityToolkit.Mvvm.ComponentModel;
using FastFoodly.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodly.Stores
{
    public class NavigationStore : ObservableObject
    {
        private ObservableObject _currentViewModel;
        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                SetProperty(ref _currentViewModel, value);
            }
        }
    }
}