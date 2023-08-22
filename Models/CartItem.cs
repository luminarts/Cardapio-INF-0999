using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FastFoodly.Models
{
    //A classe ObservableObject, fornecida pelo Community Toolkit MVVM, permite a notificação de alterações de propriedades.
    //A classe CartItem guarda as informações do carrinho de compras
    public class CartItem : ObservableObject
    {
		private int itemId;
        private int? productId;
        private string? name;
        private decimal? price;
        private int? quantity;
        private string? observations;

        //Propriedade itemId, que representa o id do item do carrinho.
        public int ItemId
        {
            get { return itemId; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref itemId, value); }
        }

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

		//Propriedade quantity, que representa a quantidade de itens desse produto.
        public int? Quantity
        {
            get { return quantity; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref quantity, value); }
        }


        //Propriedade observations, que representa observações sobre o item do carrinho.
        public string? Observations
        {
            get { return observations; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref observations, value); }
        }

    }
}