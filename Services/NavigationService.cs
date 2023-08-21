using System;
using System.Data.SqlClient;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FastFoodly.Services;

public interface INavigationService
{
    ObservableObject CurrentView {get; }
    void NavigateTo<T>() where T : ObservableObject;
}

public class NavigationService : ObservableObject, INavigationService
{
    private ObservableObject _currentView;
    private readonly Func<Type, ObservableObject> _viewModelFactory;

    public ObservableObject CurrentView
    {
        get => _currentView;
        private set => SetProperty(ref _currentView, value);
    }

    public NavigationService(Func<Type, ObservableObject> viewModelFactory)
    {   
        _viewModelFactory = viewModelFactory;
    }

    public void NavigateTo<TViewModel>() where TViewModel : ObservableObject
    {
        ObservableObject viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        CurrentView = viewModel;
    }
}