using System;
using System.Collections.Generic;

namespace FastFoodly.Model
{
    //Vai usar toolkit mvvm?
    //A classe ObservableObject, fornecida pelo Community Toolkit MVVM, permite a notificação de alterações de propriedades.
    public class Produto
    {
        private int? productId;
        private string? name;
        private decimal? price;
        private string? description;
        private List<string>? ingredients;

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

        //Propriedade Description, que representa o descrição do produto.
        public string? Description
        {
            get { return description; }
            set { description = value; }
        }

        //Propriedade Ingredients, que representa os ingredientes do produto.
        public List<string>? Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
        // public Produto(int id, string productName, decimal productPrice, string productDescription, List<string> productIngredients)
        public Produto()
        {
            // ProductId = id;
            // Name = productName;
            // Price = productPrice;
            // Description = productDescription;
            // Ingredients = productIngredients;
        }

    }
}