using CommunityToolkit.Mvvm.ComponentModel;

namespace FastFoodly.ViewModel;

public class AddProductViewModel : ObservableObject
{
	//Essas propriedades representam os comandos que podem ser executados na ViewModel. 
	//Os comandos são implementados utilizando a classe RelayCommand do Community Toolkit MVVM.
	public RelayCommand AddToCart { get; set; }

	public AddProductViewModel()
	{
		AddToCart = new RelayCommand(AddToCartCommand);
	}

	//O método AddToCartCommand() é chamado quando o comando Play é executado. Ele envia uma mensagem através do 
	//mecanismo de mensagens para definir uma nova mídia selecionada e solicita a reprodução. Também define a 
	//propriedade IsPlaying como true.
	private void AddToCartCommand()
	{
		//Adição de item ao carrinho
		var item = new CartItem()
		{
			ProductId = 2,
			Name = "Batata frita",
			Price = 2000,
			Quantity = 1,
			Observations = "Sem sal"
		};
		cart.InsertItem(item);
	}

}