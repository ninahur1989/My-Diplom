using DishBurger.Data.Base;
using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Models;

namespace DishBurger.Data.Services
{
    public class RestaurantsService:EntityBaseRepository<Restaurant>, IRestaurantsService
    {
        public RestaurantsService(AppDbContext context) : base(context)
        {
        }
    }
}
