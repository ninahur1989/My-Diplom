using DishBurger.Data;
using DishBurger.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishBurger.Models
{
    public class Dish : IEntityBase
    {
        [Key]
        [ForeignKey("ItemEntity")]
        public int Id { get; set; }

        [ForeignKey("ItemEntity")]
        public int ItemEntityId { get; set; }

        public string Description { get; set; }

        public Cuisine DishCuisine { get; set; }

        public List<Ingredient_Dish> Ingredient_Dish { get; set; }

        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
    }
}
