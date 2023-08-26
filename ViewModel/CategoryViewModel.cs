using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using FastFoodly.Commands;
using FastFoodly.Services;
using FastFoodly.Stores;
using FastFoodly.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FastFoodly.ViewModel;

public class CategoryViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ICommand NavigateToHome { get; set; }
    public string CategoryName { get; set; }
    private ObservableCollection<Product> _menuByCategory;
    public ObservableCollection<Product> MenuByCategory
    {
        get { return _menuByCategory; }
        set => SetProperty(ref _menuByCategory, value);
    }
    public CategoryViewModel(string categoryName, NavigationStore navigationStore)
    {
        CategoryName = categoryName;

        //Manipulação da tabela do cardapio
        var database = new DbMenuService();
        //Lista de itens de uma determinada categoria
        MenuByCategory = database.ListByCategory(CategoryName);

        _navigationStore = navigationStore;
        NavigateToHome = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));
    }
}