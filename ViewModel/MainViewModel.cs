using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Services;
using FastFoodly.Stores;
using NavigationMVVM.ViewModels;

namespace FastFoodly.ViewModel;
public class MainViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

    /*public INavigationService Navigation
    {
        get => _navigation;
        set => SetProperty(ref _navigation, value);
    }*/
    public MainViewModel(NavigationStore navStore)
    {
        _navigationStore = navStore;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}