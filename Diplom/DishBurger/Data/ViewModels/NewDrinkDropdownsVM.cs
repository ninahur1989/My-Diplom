using DishBurger.Models;
using System.Collections.Generic;

namespace DishBurger.Data.ViewModels
{
    public class NewDrinkDropdownsVM
    {
        public NewDrinkDropdownsVM()
        {
            Manufacturers = new List<Manufacturer>();
        }

        public List<Manufacturer> Manufacturers { get; set; }
    }
}
