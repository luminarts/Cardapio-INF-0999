using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Commands;
using FastFoodly.Services;
using FastFoodly.Stores;

namespace FastFoodly.ViewModel;

public class ConfirmOrderViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private ICommand NavigateToHome {get;}
    public ConfirmOrderViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        NavigateToHome = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));
    }
}