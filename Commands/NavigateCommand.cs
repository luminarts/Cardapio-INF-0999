using FastFoodly.Stores;
using FastFoodly.ViewModel;
using System;
using FastFoodly.Services;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;

namespace FastFoodly.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase 
        where TViewModel : ViewModelBase
    {
        private readonly NavigationService<TViewModel> _navigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
            
        }
    }
}
