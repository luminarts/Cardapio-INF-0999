using FastFoodly.Stores;
using FastFoodly.ViewModel;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationMVVM.Commands
{
    public class NavigateToCategoryCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateToCategoryCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new CategoryViewModel(_navigationStore);
        }
    }
}
