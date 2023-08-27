using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Services;
using FastFoodly.Stores;

namespace FastFoodly.ViewModel;
public class MainViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore; ///< Atributo que referencia o registro de navegação atual

    /// <summary>
    /// Propriedade que guarda uma referência para a ViewModel do registro de navegação atual
    /// </summary>
    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

    /// <summary>
    /// Construtor da ViewModel da MainWindow que é utilizada para gerar um fundo onde todas as outras Views podem ser colocadas.
	/// Precisa receber o registro de navegação atual para gerar criar uma view na inicialização do app
    /// </summary>
    /// <param name="navStore"></param>
    public MainViewModel(NavigationStore navStore)
    {
        _navigationStore = navStore;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    /// <summary>
    /// Método que inscreve um outro método de que uma propriedade mudou para avisar a interfacede usuário que a ViewModel atual mudou
    /// </summary>
    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}