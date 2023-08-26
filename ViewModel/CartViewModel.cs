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

public class CartViewModel : ViewModelBase
{
    private ObservableCollection<CartItem> _cartItems;
    public ObservableCollection<CartItem> CartItems
    {
        get { return _cartItems; }
        set => SetProperty(ref _cartItems, value);
    }
    private readonly NavigationStore _navigationStore;
    public RelayCommand<int> DeleteItem { get; set; }
    public RelayCommand DeleteAllItems { get; set; }
    public ICommand NavigateToHome { get; set; }
    public CartViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        //Manipulação da tabela Carrinho
        var cart = new DbCartService();
        //Lista todos os itens do carrinho
        CartItems = cart.ListAllItems();

        DeleteItem = new RelayCommand<int>(DeleteItemCommand);
        DeleteAllItems = new RelayCommand(DeleteAllItemsCommand);

        NavigateToHome = new NavigateCommand<HomeViewModel>(
            new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));
    }

    //O método DeleteItemCommand() é chamado quando o comando DeleteItem é executado. 
    private void DeleteItemCommand(int itemId)
    {
        var cart = new DbCartService();

        //Deleta um item especifico do carrinho
        cart.DeleteItem(itemId);
    }

    //O método DeleteAllItemsCommand() é chamado quando o comando DeleteAllItems é executado. 
    private void DeleteAllItemsCommand()
    {
        var cart = new DbCartService();

        //Deleta todos os itens do carrihno
        cart.DeleteAllItems();
    }

    //adicionar serviço de salvar pedido no banco de dados
}