using DishBurger.Data.Base;
using DishBurger.Data.Enums;
using DishBurger.Data.ViewModels;
using DishBurger.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DishBurger.Data.Services.ServiceInterfaces
{
    public interface IDishesService : IEntityBaseRepository<ItemEntity>
    {
        Task<ItemEntity> GetDishByIdAsync(int id);
        Task<NewDishDropdownsVM> GetNewDishDropdownsValues();
        Task AddNewDishAsync(NewDishVM data);
        Task UpdateDishAsync(NewDishVM data);
        Task<List<ItemEntity>> GetSortedDishesAsync(SortTypes sortType);
    }
}
