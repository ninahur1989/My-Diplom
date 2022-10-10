namespace DishBurger.Models
{
    public class Ingredient_Dish
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
