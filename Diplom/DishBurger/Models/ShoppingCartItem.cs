using System.ComponentModel.DataAnnotations;

namespace DishBurger.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public ItemEntity Item { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
