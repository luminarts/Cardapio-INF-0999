using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using FastFoodly.Models;
using FastFoodly.Stores;
using System.Windows.Input;
using FastFoodly.Commands;
using FastFoodly.Services;
using System.Collections.ObjectModel;
using System.IO;


namespace FastFoodly.ViewModel;

public class AddProductViewModel : ViewModelBase
{

	private CartItem cartItem;

	public CartItem CartItem
	{
		get { return cartItem; }
		set
		{
			cartItem = value;
		}
	}

	private readonly NavigationStore _navigationStore;
	//Essas propriedades representam os comandos que podem ser executados na ViewModel. 
	//Os comandos são implementados utilizando a classe RelayCommand do Community Toolkit MVVM.
	public RelayCommand AddToCart { get; set; }
	public ICommand NavigateToHome { get; }
	public string ProductName { get; set; }

	public AddProductViewModel(string productName, NavigationStore navigationStore)
	{
		ProductName = productName;
		var database = new DatabaseService();
		Product product = database.GetProductByName(ProductName);
		CartItem = new CartItem()
		{
			ProductId = product.ProductId,
			Name = product.Name,
			Price = product.Price,
			Quantity = 1,//pega o valor da variavel que vai ter biding
			Observations = " ",//pega o valor da variavel de oservacoes
			ImagePath = product.ImagePath
		};
		_navigationStore = navigationStore;
		AddToCart = new RelayCommand(AddToCartCommand);
		NavigateToHome = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));
	}

	//O método AddToCartCommand() é chamado quando o comando AddToCart é executado. 
	private void AddToCartCommand()
	{
		var cart = new DbCartService();

		//Adição de item ao carrinho
		cart.InsertItem(CartItem);
	}

}