using System.ComponentModel.DataAnnotations;

namespace DishBurger.Data.ViewModels
{
    public class NewDrinkVM
    {
        public int Id { get; set; }

        [Display(Name = "Drink name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Volume in L.")]
        [Required(ErrorMessage = "Volume is required")]
        public double Volume { get; set; }

        [Display(Name = "Dish poster URL")]
        [Required(ErrorMessage = "Drink poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Select a Drink type ")]
        [Required(ErrorMessage = "Drink type is required")]
        public DrinkType DrinkType { get; set; }

        [Display(Name = "Select a manufacturer")]
        [Required(ErrorMessage = "Drink manufacturer is required")]
        public int ManufacturerId { get; set; }
    }
}
