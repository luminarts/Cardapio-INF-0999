using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Stores;
using NavigationMVVM.Commands;
using NavigationMVVM.ViewModels;

namespace FastFoodly.ViewModel;

public class HomeViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ICommand NavigateToCategory { get; set; }
    public HomeViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        NavigateToCategory = new NavigateToCategoryCommand(_navigationStore);
    }
}