using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using FastFoodly.Services;
using FastFoodly.Stores;
using FastFoodly.View;
using FastFoodly.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoodly
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private readonly ServiceProvider _serviceProvider;
        /*public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeWindow>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, ObservableObject>>(serviceProvider => viewModelType => (ObservableObject)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }*/

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            NavigationStore navigationStore = new NavigationStore
            {
                CurrentViewModel = new HomeViewModel()
            };
            var mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            mainWindow.Show();  
        } 

        string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
    }
}
