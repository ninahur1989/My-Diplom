using DishBurger.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DishBurger.Models
{
    public class NewDishVM
    {
        public int Id { get; set; }

        [Display(Name = "Dish name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Dish description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Dish poster URL")]
        [Required(ErrorMessage = "Dish poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Select a cuisine")]
        [Required(ErrorMessage = "Dish cuisine is required")]
        public Cuisine DishCuisine { get; set; }

        [Display(Name = "Select ingredient(s)")]
        public List<int>? IngredientIds { get; set; }

        [Display(Name = "Select a restaurant")]
        [Required(ErrorMessage = "Dish restaurant is required")]
        public int RestaurantId { get; set; }
    }
}
