using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodly.ViewModel
{
    public class FoodItemsViewModel
    {
        public string Name { get; }
        public string Description { get; }
        //public double Price { get; }
        public string ImagePath { get; }

        public FoodItemsViewModel(string name, string description/*, double price*/, string imagePath)
        {
            Name = name;
            Description = description;
            //Price = price;
            ImagePath = imagePath;
        }
    }
}
