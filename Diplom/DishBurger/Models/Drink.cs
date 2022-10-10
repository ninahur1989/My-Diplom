using DishBurger.Data;
using DishBurger.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishBurger.Models
{
    public class Drink : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ItemEntity")]
        public int ItemEntityId { get; set; }

        public double Volume { get; set; }

        public DrinkType DrinkType { get; set; }

        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }

    }
}
