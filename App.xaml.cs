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
        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<NavigationStore>();
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));
            services.AddTransient<CategoryViewModel>(s => new CategoryViewModel("Lanches",s.GetRequiredService<NavigationStore>()));

            services.AddSingleton<MainWindow>(s => new MainWindow
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();
            
            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();  
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<CategoryViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<CategoryViewModel>());
        }

        string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
    }
}
