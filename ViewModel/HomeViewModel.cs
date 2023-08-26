using System;
using System.Collections.Generic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Commands;
using FastFoodly.Models;
using FastFoodly.Services;
using FastFoodly.Stores;

namespace FastFoodly.ViewModel;

public class HomeViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public RelayCommand<string> SearchItem { get; set; }
    public ICommand NavigateToCategory { get;}
    public ICommand NavigateToProduct { get;}
    public ICommand NavigateToCart { get;}
    private List<Product> menu;
	public List<Product> Menu
	{
		get { return menu; }
		set { menu = value; }
	}
    public HomeViewModel(NavigationStore navigationStore)
    {
        //Manipulação da tabela do cardapio
        var database = new DatabaseService();
        //Lista todos os itens do menu
        menu = database.ListAllMenu();

        SearchItem = new RelayCommand<string>(SearchItemCommand);

        _navigationStore = navigationStore;
        NavigateToCategory = new CategoryCommand(new ParameterNavigationService<string, CategoryViewModel>(navigationStore, (parameter) => new CategoryViewModel(parameter, navigationStore)));
        NavigateToProduct = new ProductCommand(new ParameterNavigationService<string, AddProductViewModel>(navigationStore, (parameter) => new AddProductViewModel(parameter, navigationStore)));
        NavigateToCart = new NavigateCommand<CartViewModel>(new NavigationService<CartViewModel>(navigationStore, () => new CartViewModel(navigationStore)));
    }

    //O método SearchItemCommand() é chamado quando o comando SearchItem é executado. 
	private void SearchItemCommand(string item)
	{
        //Manipulação da tabela do cardapio
        var database = new DatabaseService();
        //Pesquisa por produto
        menu = database.ListBySearch(item);
	}
}