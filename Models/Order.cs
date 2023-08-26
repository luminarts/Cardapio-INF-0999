using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodly.Models
{
    public class Order : ObservableObject
    {
        private string? productIds;
        private decimal? totalPrice;
        private string? observations;

        //Propriedade productIds, que representa os ids do produto.
        public string? ProductIds
        {
            get { return productIds; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref productIds, value); }
        }

        //Propriedade totalPrice, que representa o preço total do pedido.
        public decimal? TotalPrice
        {
            get { return totalPrice; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref totalPrice, value); }
        }

        //Propriedade observations, que representa observações sobre o pedido e seus adicionais.
        public string? Observations
        {
            get { return observations; }
            //método SetProperty para notificar os assinantes sobre a alteração e atualizar o valor da propriedade.
            set { SetProperty(ref observations, value); }
        }
    }
}