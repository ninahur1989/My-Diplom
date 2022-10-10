using DishBurger.Data.Base;
using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Models;

namespace DishBurger.Data.Services
{
    public class IngredientsService : EntityBaseRepository<Ingredient>, IIngredientsService
    {
        public IngredientsService(AppDbContext context) : base(context) { }
    }
}
