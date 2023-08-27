using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodly.Services;
using FastFoodly.ViewModel;

namespace FastFoodly.Commands
{
    /// <summary>
    /// Classe para executar o comando de navegar para a Janela de Categoria selecionada
    /// </summary>
    public class CategoryCommand : CommandBase
    {
        /// <summary>
        /// atributo que armazena um serviço de navegar para outra janela do tipo CategoryViewModel 
        /// e enviar um parâmetro do tipo string
        /// </summary>
        private readonly ParameterNavigationService<string, CategoryViewModel> _navigationService;

        /// <summary>
        /// Propriedade que armazena o comando de navegar usando o serviço como parâmetro
        /// </summary> 
        /// <param name="navigationService"></param>
        public CategoryCommand(ParameterNavigationService<string, CategoryViewModel> navigationService)
        {
            _navigationService = navigationService;
        }
        /// <summary>
        /// Método que é executado sempre que o comando é chamado.
        /// Essa função chama o método de navegar, enviando um parâmtro, do serviço registrado 
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            string buttonName = parameter as string;
            _navigationService.Navigate(buttonName);
        }
    }
}