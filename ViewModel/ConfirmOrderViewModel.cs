using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Commands;
using FastFoodly.Services;
using FastFoodly.Stores;

namespace FastFoodly.ViewModel;

/// <summary>
/// Classe que implementa o ViewModel para a View ConfirmOrderWindow
/// Herda a classe ViewModelBase
/// </summary>
public class ConfirmOrderViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore; ///< atributo que referencia o registro de navegação atual

    /// <summary>
    /// Comando para voltar à tela inicial Home
    /// </summary>
    private ICommand NavigateToHome {get;}

    /// <summary>
    /// Construtor da ViewModel da View ConfirmOrder que mostra ao usuário a página de conclusão de pedido.
	/// Precisa receber o registro de navegação atual para gerar essa View nova.
    /// </summary>
    /// <param name="navigationStore"></param>
    public ConfirmOrderViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        NavigateToHome = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));
    }
}