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
using FastFoodly.Model;
using FastFoodly.ViewModel;

namespace FastFoodly.View
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class HomeWindow : UserControl
    {
        public HomeWindow()
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
            var item = new CartItem()
            {
                ProductId = 2,
                Name = "Batata frita",
                Price = 2000,
                Quantity = 1,
                Observations = "Sem sal"
            };
            cart.InsertItem(item);

            //Lista todos os itens do carrinho
            List<CartItem> cartItems = cart.ListAllItems();

            //Deleta um item especifico do carrinho
            cart.DeleteItem(cartItems[0].ItemId);
            //Lista todos os itens do carrinho - deve retornar lista sem o item deletado
            cartItems = cart.ListAllItems();

            //Deleta todos os itens do carrihno
            cart.DeleteAllItems();
            //Lista todos os itens do carrinho - deve retornar lista vazia
            cartItems = cart.ListAllItems();

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