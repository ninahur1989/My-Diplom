using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DishBurger.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Drink> Drinks { get; set; }
    }
}
