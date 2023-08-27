using CommunityToolkit.Mvvm.ComponentModel;
using FastFoodly.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodly.Stores
{
    /// <summary>
    /// Classe que armazena a ViewModel atual que é visualizada pela MainWindow
    /// </summary>
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged; ///< Evento usado para mostrar que a ViewModel atual mudou
        private ViewModelBase _currentViewModel; ///< Atributo que guarda a instância da nova ViewModel

        /// <summary>
        /// Propriedade que guarda a instância da nova ViewModel.
        /// Chama um evento sempre que a instância muda
        /// </summary>
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged(); 
            }
        }

        /// <summary>
        /// Método para invocar o que está inscrito no evento de mudar ViewModel
        /// </summary>
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}