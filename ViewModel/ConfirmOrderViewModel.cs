using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Commands;
using FastFoodly.Services;
using FastFoodly.Stores;

namespace FastFoodly.ViewModel;

public class ConfirmOrderViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private ICommand NavigateToHome {get;}
    private int? _orderId;
    //Propriedade OrderId, que representa os ids do pedido.
    public int? OrderId
    {
        get { return _orderId; }
        //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
        set { SetProperty(ref _orderId, value); }
    }
    public ConfirmOrderViewModel(NavigationStore navigationStore)
    {
        var orderDb = new DbOrderService();
        //salva o id do ultimo pedido
        OrderId = orderDb.GetLastOrder();

        _navigationStore = navigationStore;
        NavigateToHome = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore)));
    }

}