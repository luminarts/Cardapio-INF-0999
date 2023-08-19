using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Services;

namespace FastFoodly.ViewModel;
public class MainViewModel : ObservableObject
{
    private INavigationService _navigation;

    public INavigationService Navigation
    {
        get => _navigation;
        set => SetProperty(ref _navigation, value);
    }

    public RelayCommand NavigateHomeCommand {get; set;}
    public MainViewModel(INavigationService navService)
    {
        Navigation = navService;
        NavigateHomeCommand = new RelayCommand(Navigation.NavigateTo<HomeViewModel>);
    }
}