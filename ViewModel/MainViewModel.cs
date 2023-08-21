using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Services;
using FastFoodly.Stores;

namespace FastFoodly.ViewModel;
public class MainViewModel : ObservableObject
{
    private readonly NavigationStore _navigationStore;

    public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

    /*public INavigationService Navigation
    {
        get => _navigation;
        set => SetProperty(ref _navigation, value);
    }*/

    public RelayCommand NavigateToHome {get; set;}
    public MainViewModel(NavigationStore navStore)
    {
        _navigationStore = navStore;
    }
}