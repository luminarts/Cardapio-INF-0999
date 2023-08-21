using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using FastFoodly.Stores;
using NavigationMVVM.Commands;
using NavigationMVVM.ViewModels;

namespace FastFoodly.ViewModel;

public class CategoryViewModel : ViewModelBase
{
    public ICommand NavigateToHome { get; set; }
    public CategoryViewModel(NavigationStore navigationStore)
    {
        NavigateToHome = new NavigateToHomeCommand(navigationStore);
    }
}