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

	private CartItem _cartItem;
	public CartItem CartItem
	{
		get { return _cartItem; }
        set => SetProperty(ref _cartItem, value);
	}

	private Product _product;
	public Product Product
	{
		get { return _product; }
        set => SetProperty(ref _product, value);
	}

	private readonly NavigationStore _navigationStore;
	//Essas propriedades representam os comandos que podem ser executados na ViewModel. 
	//Os comandos são implementados utilizando a classe RelayCommand do Community Toolkit MVVM.
	public RelayCommand AddToCart { get; set; }
	public ICommand NavigateToHome { get; }
	public ICommand NavigateToCart { get; }
	public string ProductName { get; set; }

	public AddProductViewModel(string productName, NavigationStore navigationStore)
	{
		ProductName = productName;
		var database = new DbMenuService();
		Product = database.GetProductByName(ProductName);
		CartItem = new CartItem()
		{
			ProductId = Product.ProductId,
			Name = Product.Name,
			Price = Product.Price,
			Quantity = 1,
			Observations = " ",
			ImagePath = Product.ImagePath
		};

		_navigationStore = navigationStore;

		AddToCart = new RelayCommand(AddToCartCommand);

		NavigateToHome = new NavigateCommand<HomeViewModel>(
			new NavigationService<HomeViewModel>(
				navigationStore, () => new HomeViewModel(navigationStore)));

		NavigateToCart = new NavigateCommand<CartViewModel>(
			new NavigationService<CartViewModel>(navigationStore, () => new CartViewModel(navigationStore)));
	}

	//O método AddToCartCommand() é chamado quando o comando AddToCart é executado. 
	private void AddToCartCommand()
	{
		var cart = new DbCartService();

		//Configurar observações de acordo com o que foi selecionado.
		//Adição de item ao carrinho
		cart.InsertItem(CartItem);
	}

}