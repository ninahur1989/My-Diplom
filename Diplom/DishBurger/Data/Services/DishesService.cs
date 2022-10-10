using DishBurger.Data.Base;
using DishBurger.Data.Enums;
using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Data.ViewModels;
using DishBurger.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DishBurger.Data.Services
{
    public class DishesService : EntityBaseRepository<ItemEntity>, IDishesService
    {
        private readonly AppDbContext _context;
        private readonly ISortService _sort;

        public DishesService()
        {
        }

        public DishesService(AppDbContext context, ISortService sort) : base(context)
        {
            _context = context;
            _sort = sort;
        }
        

        private async Task<List<ItemEntity>> GetDishesAsync()
        {
            var allDishes = await GetAllAsync();
            List<ItemEntity> sortedDishes = new List<ItemEntity>();

            foreach (var a in allDishes)
            {
                if (a.product == Product.Dish)
                {
                    a.Dish = GetDishByIdAsync(a.Id).Result.Dish;
                    sortedDishes.Add(a);
                }
            }
            return (sortedDishes);
        }

        public async Task AddNewDishAsync(NewDishVM data)
        {
            var NewDish = new Dish()
            {
                RestaurantId = data.RestaurantId,
                DishCuisine = data.DishCuisine,
            };
            var newItem = new ItemEntity()
            {
                Name = data.Name,
                ImageURL = data.ImageURL,
                Price = data.Price,
                product = Product.Dish,
                Dish = NewDish
            };

            await _context.ItemEntitys.AddAsync(newItem);
            await _context.Dishes.AddAsync(NewDish);
            await _context.SaveChangesAsync();

            foreach (var ingredientId in data.IngredientIds)
            {
                var newIngredientDish = new Ingredient_Dish()
                {
                    DishId = NewDish.Id,
                    IngredientId = ingredientId
                };
                await _context.Ingredient_Dish.AddAsync(newIngredientDish);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ItemEntity> GetDishByIdAsync(int id)
        {
            var dishDetails = await _context.ItemEntitys
                .Include(c => c.Dish.Restaurant)
                .Include(am => am.Dish.Ingredient_Dish).ThenInclude(a => a.Ingredient)
                .FirstOrDefaultAsync(n => n.Id == id);

            return dishDetails;
        }

        public async Task<NewDishDropdownsVM> GetNewDishDropdownsValues()
        {
            var response = new NewDishDropdownsVM()
            {
                Ingredients = await _context.Ingredients.OrderBy(n => n.FullName).ToListAsync(),
                Restaurants = await _context.Restaurants.OrderBy(n => n.Name).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateDishAsync(NewDishVM data)
        {
            var dbDish = await _context.ItemEntitys.FirstOrDefaultAsync(n => n.Id == data.Id);
            dbDish = GetDishByIdAsync(dbDish.Id).Result;

            if (dbDish != null)
            {
                dbDish.Dish.Description = data.Description;
                dbDish.Dish.RestaurantId = data.RestaurantId;
                dbDish.Dish.DishCuisine = data.DishCuisine;
                dbDish.Name = data.Name;
                dbDish.Price = data.Price;
                dbDish.ImageURL = data.ImageURL;

                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<ItemEntity>> GetSortedDishesAsync(SortTypes sortType)
        {
            var dishes = await GetDishesAsync();
            return (List<ItemEntity>)_sort.Sort(dishes, sortType); ;
        }
    }
}
