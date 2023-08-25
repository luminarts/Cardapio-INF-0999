using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Commands;
using FastFoodly.Services;
using FastFoodly.Stores;

namespace FastFoodly.ViewModel;

public class HomeViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ICommand NavigateToCategory { get;}
    public ICommand NavigateToCart { get;}
    public HomeViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        NavigateToCategory = new CategoryCommand(new ParameterNavigationService<string, CategoryViewModel>(navigationStore, (parameter) => new CategoryViewModel(parameter, navigationStore)));
        NavigateToCart = new NavigateCommand<CartViewModel>(new NavigationService<CartViewModel>(navigationStore, () => new CartViewModel(navigationStore)));
    }
}