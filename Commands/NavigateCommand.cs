using FastFoodly.Stores;
using FastFoodly.ViewModel;
using System;
using FastFoodly.Services;
using System.Collections.Generic;
using System.Text;

namespace FastFoodly.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase 
        where TViewModel : ViewModelBase
    {
        private readonly NavigationService<TViewModel> _navigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationStore)
        {
            _navigationService = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
