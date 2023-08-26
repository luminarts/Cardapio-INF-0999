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
	private Product product;
	private int quantity;

	private string observations;
	public Product Product
	{
		get { return product; }
		set
		{
			SetProperty(ref product, value);
			// product = value;
		}
	}

	public int Quantity
	{
		get { return quantity; }
		set
		{
			SetProperty(ref quantity, value);
			// quantity = value;
		}
	}

	public string Observations
	{
		get { return observations; }
		set
		{
			SetProperty(ref observations, value);
			// observations = value;
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
		Product = database.GetProductByName(ProductName);
		_navigationStore = navigationStore;
		AddToCart = new RelayCommand(AddToCartCommand);
		NavigateToHome = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));
	}

	//O método AddToCartCommand() é chamado quando o comando AddToCart é executado. 
	private void AddToCartCommand()
	{
		var cart = new DbCartService();

		//Adição de item ao carrinho
		var item = new CartItem()
		{
			ProductId = Product.ProductId,
			Name = Product.Name,
			Price = Product.Price,
			Quantity = Quantity,//pega o valor da variavel que vai ter biding
			Observations = Observations//pega o valor da variavel de oservacoes
		};
		cart.InsertItem(item);
	}

}