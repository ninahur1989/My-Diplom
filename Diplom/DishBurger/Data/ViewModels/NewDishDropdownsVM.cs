using DishBurger.Models;
using System.Collections.Generic;

namespace DishBurger.Data.ViewModels
{
    public class NewDishDropdownsVM
    {
        public NewDishDropdownsVM()
        {
            Restaurants = new List<Restaurant>();
            Ingredients = new List<Ingredient>();
        }

        public List<Restaurant> Restaurants { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
