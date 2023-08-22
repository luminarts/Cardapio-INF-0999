using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FastFoodly.Models
{
    //A classe ObservableObject, fornecida pelo Community Toolkit MVVM, permite a notificação de alterações de propriedades.
    //A classe Produto guarda as informações sobre o produto do cardápio
    public class Product : ObservableObject
    {
        private int? productId;
        private string? name;
        private decimal? price;
        private string? description;
        private List<string>? ingredients;
        private string? category;

        //Propriedade productId, que representa o id do produto.
        public int? ProductId
        {
            get { return productId; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref productId, value); }
        }

        //Propriedade Name, que representa o nome do produto.
        public string? Name
        {
            get { return name; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref name, value); }
        }

        //Propriedade price, que representa o preço do produto.
        public decimal? Price
        {
            get { return price; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref price, value); }
        }

        //Propriedade Description, que representa o descrição do produto.
        public string? Description
        {
            get { return description; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref description, value); }
        }

        //Propriedade Ingredients, que representa os ingredientes do produto.
        public List<string>? Ingredients
        {
            get { return ingredients; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref ingredients, value); }
        }

        public string? Category
        {
            get { return category; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref category, value); }
        }

    }
}