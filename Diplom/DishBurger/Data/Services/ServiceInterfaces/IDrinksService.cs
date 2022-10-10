using DishBurger.Data.Base;
using DishBurger.Data.Enums;
using DishBurger.Data.ViewModels;
using DishBurger.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DishBurger.Data.Services.ServiceInterfaces
{
    public interface IDrinksService : IEntityBaseRepository<ItemEntity>
    {
        Task<ItemEntity> GetDrinkByIdAsync(int id);
        Task<NewDrinkDropdownsVM> GetNewDrinkDropdownsValues();
        Task AddNewDrinkAsync(NewDrinkVM data);
        Task UpdateDrinkAsync(NewDrinkVM data);
        Task<List<ItemEntity>> GetSortedDrinksAsync(SortTypes? sortType);
    }
}
