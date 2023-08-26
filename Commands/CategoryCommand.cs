using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodly.Services;
using FastFoodly.ViewModel;

namespace FastFoodly.Commands
{
    public class CategoryCommand : CommandBase
    {
        private readonly ParameterNavigationService<string, CategoryViewModel> _navigationService; 
        
        public CategoryCommand(ParameterNavigationService<string, CategoryViewModel> navigationService)
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