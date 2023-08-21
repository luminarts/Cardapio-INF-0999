using CommunityToolkit.Mvvm.ComponentModel;
using FastFoodly.ViewModel;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodly.Stores
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged;
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged(); 
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}