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
    public class DrinksService : EntityBaseRepository<ItemEntity>, IDrinksService
    {
        private readonly AppDbContext _context;
        private readonly ISortService _sort;

        public DrinksService(AppDbContext context, ISortService sort) : base(context)
        {
            _context = context;
            _sort = sort;
        }
        public DrinksService()
        {
        }

        private async Task<List<ItemEntity>> GetDrinksAsync()
        {
            var allDrinks = await GetAllAsync();
            List<ItemEntity> sortedDrinks = new List<ItemEntity>();

            foreach (var a in allDrinks)
            {
                if (a.product == Product.Drink)
                {
                    a.Drink = GetDrinkByIdAsync(a.Id).Result.Drink;
                    sortedDrinks.Add(a);
                }
            }

            return (sortedDrinks);
        }

        public async Task AddNewDrinkAsync(NewDrinkVM data)
        {
            var NewDrink = new Drink()
            {
                DrinkType = data.DrinkType,
                ManufacturerId = data.ManufacturerId,
                Volume = data.Volume,
            };
            var newItem = new ItemEntity()
            {
                Name = data.Name,
                ImageURL = data.ImageURL,
                Price = data.Price,
                product = Product.Drink,
                Drink = NewDrink
            };

            await _context.ItemEntitys.AddAsync(newItem);
            await _context.Drinks.AddAsync(NewDrink);
            await _context.SaveChangesAsync();
        }

        public async Task<ItemEntity> GetDrinkByIdAsync(int id)
        {
            var drinkDetails = await _context.ItemEntitys
                .Include(c => c.Drink.Manufacturer)
                .FirstOrDefaultAsync(n => n.Id == id);

            return drinkDetails;
        }

        public async Task<NewDrinkDropdownsVM> GetNewDrinkDropdownsValues()
        {
            var response = new NewDrinkDropdownsVM()
            {
                Manufacturers = await _context.Manufacturers.OrderBy(n => n.Name).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateDrinkAsync(NewDrinkVM data)
        {
            var dbDrink = await _context.ItemEntitys.FirstOrDefaultAsync(n => n.Id == data.Id);
            dbDrink = GetDrinkByIdAsync(dbDrink.Id).Result;

            if (dbDrink != null)
            {
                dbDrink.Drink.Volume = data.Volume;
                dbDrink.Drink.ManufacturerId = data.ManufacturerId;
                dbDrink.Drink.DrinkType = data.DrinkType;
                dbDrink.Name = data.Name;
                dbDrink.Price = data.Price;
                dbDrink.ImageURL = data.ImageURL;
                dbDrink.product = Product.Drink;

                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<ItemEntity>> GetSortedDrinksAsync(SortTypes? sortType)
        {
            var drinks = await GetDrinksAsync();
            return (List<ItemEntity>)_sort.Sort(drinks, sortType);
        }
    }
}
