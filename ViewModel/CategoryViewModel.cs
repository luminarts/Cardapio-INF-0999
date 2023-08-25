using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using FastFoodly.Commands;
using FastFoodly.Services;
using FastFoodly.Stores;
using FastFoodly.Models;
using System.Collections.Generic;

namespace FastFoodly.ViewModel;

public class CategoryViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ICommand NavigateToHome { get; set; }
    public string CategoryName { get; set; }
    public CategoryViewModel(string categoryName, NavigationStore navigationStore)
    {
        CategoryName = categoryName;
        //Lista de itens de uma determinada categoria
        //List<Product> menuByCategory = database.ListByCategory(CategoryName);
        _navigationStore = navigationStore;
        NavigateToHome = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));
    }
}