using DishBurger.Data.Base;
using DishBurger.Data.Enums;
using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DishBurger.Data.Services
{
    public class HomeService : EntityBaseRepository<ItemEntity>, IHomeService
    {
        private readonly AppDbContext _context;
        private readonly ISortService _sort;

        public HomeService()
        {
        }
        public HomeService(AppDbContext context, ISortService sort) : base(context)
        {
            _context = context;
            _sort = sort;
        }

        private async Task<List<ItemEntity>> GetItemsAsync()
        {
            var allItems = await GetAllAsync();
            List<ItemEntity> sortedItems = new List<ItemEntity>();

            foreach (var item in allItems)
            {
                if (item.product == Product.Dish)
                {
                    item.Dish = GetItemByIdAsync(item.Id).Result.Dish;
                    sortedItems.Add(item);
                }
                else
                {
                    item.Drink = GetItemByIdAsync(item.Id).Result.Drink;
                    sortedItems.Add(item);
                }
            }
            return (sortedItems);
        }

        public async Task<ItemEntity> GetItemByIdAsync(int id)
        {
            var dishDetails = await _context.ItemEntitys
                .Include(c => c.Dish.Restaurant)
                .Include(am => am.Dish.Ingredient_Dish).ThenInclude(a => a.Ingredient)
                .FirstOrDefaultAsync(n => n.Id == id);

            return dishDetails;
        }

        public async Task<List<ItemEntity>> GetSortedItemsAsync(SortTypes? sortType)
        {
            var items = await GetItemsAsync();
            return (List<ItemEntity>)_sort.Sort(items, sortType);
        }
    }
}
