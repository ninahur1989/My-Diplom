using DishBurger.Data.Enums;
using DishBurger.Models;
using System.Collections.Generic;

namespace DishBurger.Data.Services.ServiceInterfaces
{
    public interface ISortService
    {
        public IEnumerable<ItemEntity> Sort(List<ItemEntity> list, SortTypes? sortType);
    }
}
