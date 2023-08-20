using System;
using System.Collections.Generic;

namespace FastFoodly.Model
{
    public class CartItem
    {
		private int? itemId;
        private int? productId;
        private string? name;
        private decimal? price;
        private int? quantity;
        private string? observations;

        //Propriedade itemId, que representa o id do item do carrinho.
        public int? ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

		//Propriedade productId, que representa o id do produto.
        public int? ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        //Propriedade Name, que representa o nome do produto.
        public string? Name
        {
            get { return name; }
            set { name = value; }
        }

        //Propriedade price, que representa o preço do produto.
        public decimal? Price
        {
            get { return price; }
            set { price = value; }
        }

		//Propriedade quantity, que representa a quantidade de itens desse produto.
        public int? Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }


        //Propriedade observations, que representa observações sobre o item do carrinho.
        public string? Observations
        {
            get { return observations; }
            set { observations = value; }
        }

    }
}