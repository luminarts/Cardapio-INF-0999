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
        private readonly NavigationService<TViewModel> _navigationService; ///< atributo que armazena serviço usado para navegar entre janelas

        /// <summary>
        /// Objeto que armazena o comando para navegar entre janelas.
        /// Utiliza o serviço de navegação
        /// </summary>
        /// <param name="navigationService"></param>
        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        /// <summary>
        /// Método que contém lógica utilizada para navegar entre janelas.
        /// Utiliza o método Navigate() do serviço de navegação.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
            
        }
    }
}
