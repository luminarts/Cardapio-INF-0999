using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodly.Services;
using FastFoodly.ViewModel;

namespace FastFoodly.Commands
{
    public class ProductCommand : CommandBase
    {
        private readonly ParameterNavigationService<string, AddProductViewModel> _navigationService; 
        
        public ProductCommand(ParameterNavigationService<string, AddProductViewModel> navigationService)
        {
            _navigationService = navigationService;
        }
        
        public override void Execute(object parameter)
        {
            string buttonName = parameter as string;
            _navigationService.Navigate(buttonName);
        }
    }
}