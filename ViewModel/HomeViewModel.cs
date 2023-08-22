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
    public ICommand NavigateToCategory { get; set; }
    public HomeViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        NavigateToCategory = new NavigateCommand<CategoryViewModel>(new NavigationService<CategoryViewModel>(navigationStore, () => new CategoryViewModel(navigationStore)));
    }
}