using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodly.Stores;
using FastFoodly.ViewModel;

namespace FastFoodly.Services
{
    /// <summary>
    /// Classe de serviço que possui capacidade de navegar entre classes usadas para representar janelas ViewModelBase
    /// e passar um parâmetro a essa nova classe.
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    public class ParameterNavigationService<TParameter, TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore; ///< atributo que armazena uma classe que guarda a janela que está sendo visualizada no momento
        private readonly Func<TParameter, TViewModel> _createViewModel; ///< Delegate que executa um método que cria uma ViewModel nova

        /// <summary>
        /// Cria o serviço com referência para um registro de navegação atual e um delegate que cria nova VieModel e envia um parâmetro
        /// </summary>
        /// <param name="navigationStore"></param>
        /// <param name="createViewModel"></param>
        public ParameterNavigationService(NavigationStore navigationStore, Func<TParameter, TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        /// <summary>
        /// Método que executa a navegação do serviço, atualizando o registro de navegação atual.
        /// Passa um parâmetro para a nova ViewModel criada
        /// </summary>
        /// <param name="parameter"></param>
        public void Navigate(TParameter parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel(parameter);
        }
    }
}