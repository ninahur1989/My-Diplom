using DishBurger.Data.Base;
using DishBurger.Data.Enums;
using DishBurger.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DishBurger.Data.Services.ServiceInterfaces
{
    public interface IHomeService : IEntityBaseRepository<ItemEntity>
    {
        Task<ItemEntity> GetItemByIdAsync(int id);
        Task<List<ItemEntity>> GetSortedItemsAsync(SortTypes? sortType);
    }
}
