using DishBurger.Data.Base;
using DishBurger.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DishBurger.Models
{
    public class Restaurant : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Restaurant Logo")]
        [Required(ErrorMessage = "Restaurant logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Restaurant Name")]
        [Required(ErrorMessage = "Restaurant name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Restaurant description is required")]
        public string Description { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Restaurant addresss is required")]
        public string Address { get; set; }

        public List<Dish> Dishes { get; set; }
    }
}
