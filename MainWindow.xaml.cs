using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FastFoodly;
using FastFoodly.Model;

namespace Fast_Foodly
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            
            //Manipulação da tabela do cardapio
            var database = new DatabaseService(sqlConnectionString);
            //Lista todos os itens do menu
            List<Produto> menu = database.ListAllMenu();
            //Lista de item de uma determinada categoria
            List<Produto> menuByCategory = database.ListByCategory("Lanches");
            //Pesquisa por produto
            List<Produto> menuBySearch = database.ListBySearch("Hamburguer");

            //Manipulação da tabela Carrinho
            var cart = new DbCartService(sqlConnectionString);
            //Adição de item ao carrinho
            var item = new CartItem(){
                ProductId = 2,
                Name = "Batata frita",
                Price = 2000,
                Quantity = 1,
                Observations = "Sem sal"
            };
            cart.InsertItem(item);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}