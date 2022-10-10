using DishBurger.Data.Base;
using DishBurger.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace DishBurger.Models
{
    public class ItemEntity : IEntityBase 
    {
        [Key]
        public int Id { get; set; }

        public Product product { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public string? ShortDescription { get; set; }

        public Dish? Dish { get; set; }

        public Drink? Drink { get; set; }
    }
}
