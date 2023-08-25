using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastFoodly.Commands;
using FastFoodly.Services;
using FastFoodly.Stores;

namespace FastFoodly.ViewModel;

public class HomeViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ICommand NavigateToCategory { get; set; }
    private readonly ObservableCollection<FoodItemsViewModel> _foodItemsViewModels;
    public IEnumerable<FoodItemsViewModel> FoodItemsViewModels => _foodItemsViewModels;

    public HomeViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        NavigateToCategory = new NavigateCommand<CategoryViewModel>(new NavigationService<CategoryViewModel>(navigationStore, () => new CategoryViewModel(navigationStore)));

        _foodItemsViewModels = new ObservableCollection<FoodItemsViewModel>()
        {
            new FoodItemsViewModel("X-Bacon","Um delicioso hamburguer de carne bovina de 200g com lascas de bacon crocantes e um queijo cheddar derretido de dar água na boca"/*, 29.99*/, "\\Assets\\Images\\front-view-burgers-stand.jpg"),
            new FoodItemsViewModel("X-Egg","Um delicioso hamburguer de ovo bovino de 200g com lascas de ovo crocantes e um queijo cheddar derretido de dar água na boca"/*, 29.99*/, "\\Assets\\Images\\front-view-burgers-stand.jpg"),
            new FoodItemsViewModel("X-Tudo","Um delicioso hamburguer de tudo bovino de 200g com lascas de tudo crocantes e um queijo cheddar derretido de dar água na boca"/*, 29.99*/, "\\Assets\\Images\\front-view-burgers-stand.jpg"),
            new FoodItemsViewModel("X-Tudo","Um delicioso hamburguer de tudo bovino de 200g com lascas de tudo crocantes e um queijo cheddar derretido de dar água na boca"/*, 29.99*/, "\\Assets\\Images\\front-view-burgers-stand.jpg"),
            new FoodItemsViewModel("X-Tudo","Um delicioso hamburguer de tudo bovino de 200g com lascas de tudo crocantes e um queijo cheddar derretido de dar água na boca"/*, 29.99*/, "\\Assets\\Images\\front-view-burgers-stand.jpg"),
            new FoodItemsViewModel("X-Tudo","Um delicioso hamburguer de tudo bovino de 200g com lascas de tudo crocantes e um queijo cheddar derretido de dar água na boca"/*, 29.99*/, "\\Assets\\Images\\front-view-burgers-stand.jpg"),
            new FoodItemsViewModel("X-Tudo","Um delicioso hamburguer de tudo bovino de 200g com lascas de tudo crocantes e um queijo cheddar derretido de dar água na boca"/*, 29.99*/, "\\Assets\\Images\\front-view-burgers-stand.jpg")
        };
    }
    
}