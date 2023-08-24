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
    public ConfirmOrderViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }
}