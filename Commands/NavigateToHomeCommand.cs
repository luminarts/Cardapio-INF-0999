using FastFoodly.Stores;
using FastFoodly.ViewModel;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationMVVM.Commands
{
    public class NavigateToHomeCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateToHomeCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }
    }
}
