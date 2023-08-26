using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Commands;
using FastFoodly.Models;
using FastFoodly.Services;
using FastFoodly.Stores;

namespace FastFoodly.ViewModel;

/// <summary>
/// Classe que implementa o ViewModel para a View CartWindow
/// Herda a classe ViewModelBase
/// </summary>
public class CartViewModel : ViewModelBase
{
    private CartItem cartItem; ///< Atributo para guardar um item do carrinho.

    /// <summary>
    /// Propriedade para guardar um item do carrinho
    /// </summary>
	public CartItem CartItem
	{
		get { return cartItem; }
		set { cartItem = value; }
	}
    private readonly NavigationStore _navigationStore; ///< Atributo que referencia o registro de navegação atual

    /// <summary>
    /// Comando para deletar um item do carrinho
    /// </summary>
    public RelayCommand<int> DeleteItem { get; set; }

    /// <summary>
    /// Comando para deletar todos os itens do carrinho
    /// </summary>
    public RelayCommand DeleteAllItems { get; set; }

    /// <summary>
    /// Comando para navegar até a página inicial novamente
    /// </summary>
    public ICommand NavigateToHome { get; set; }

    /// <summary>
    /// Construtor da ViewModel da View Cart que mostra ao usuário a página que mostra o carrinho
	/// Precisa receber o registro de navegação atual para gerar essa View nova
	/// </summary>
    /// <param name="navigationStore"></param>
    public CartViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        //Manipulação da tabela Carrinho
        var cart = new DbCartService();
        //Lista todos os itens do carrinho
        ObservableCollection<CartItem> cartItems = cart.ListAllItems();

        // Cria os comandos
		DeleteItem = new RelayCommand<int>(DeleteItemCommand);
		DeleteAllItems = new RelayCommand(DeleteAllItemsCommand);

        NavigateToHome = new NavigateCommand<HomeViewModel>(
            new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));
    }

    /// <summary>
    /// Método chamado quando o comando DeleteItem é executado.
    /// </summary>
    /// <param name="itemId"></param>
	private void DeleteItemCommand(int itemId)
	{
		var cart = new DbCartService();

	    //Deleta um item especifico do carrinho
        cart.DeleteItem(itemId);
	}

    /// <summary>
    /// Método chamado quando o comando DeleteAllItems é executado.
    /// </summary>
	private void DeleteAllItemsCommand()
	{
		var cart = new DbCartService();

	    //Deleta todos os itens do carrihno
        cart.DeleteAllItems();
	}

    //adicionar serviço de salvar pedido no banco de dados
}