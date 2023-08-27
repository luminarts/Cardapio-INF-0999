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
        private readonly ParameterNavigationService<string, AddProductViewModel> _navigationService; ///< Atributo que armazena o serviço de navegar entre janelas com parâmetro
        
        /// <summary>
        /// Objeto que armazena comando usado para navegar até o AddProductViewModel passando um parâmetro a ele
        /// Utiliza um serviço de navegação por parâmetro
        /// </summary>
        /// <param name="navigationService"></param>
        public ProductCommand(ParameterNavigationService<string, AddProductViewModel> navigationService)
        {
            _navigationService = navigationService;
        }
        
        /// <summary>
        /// Método que executa a função de navegar para uma outra janela passando um parâmetro para ela
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            string buttonName = parameter as string;
            _navigationService.Navigate(buttonName);
        }
    }
}