using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using FastFoodly.Commands;
using FastFoodly.Services;
using FastFoodly.Stores;

namespace FastFoodly.ViewModel;

public class CategoryViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ICommand NavigateToHome { get; set; }
    public CategoryViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        NavigateToHome = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));
    }
}