using DishBurger.Data.Enums;
using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Models;
using System.Collections.Generic;

namespace DishBurger.Data.Services
{
    public class SortService : ISortService
    {
        public IEnumerable<ItemEntity> Sort(List<ItemEntity> list , SortTypes? sortType)
        {
            switch (sortType)
            {
                case SortTypes.Name:
                    list.Sort(delegate (ItemEntity x, ItemEntity y)
                    {
                        return x.Name.CompareTo(y.Name);
                    });
                    break;
                case SortTypes.Price:
                    list.Sort(delegate (ItemEntity x, ItemEntity y)
                    {
                        return x.Price.CompareTo(y.Price);
                    });
                    break;
                default:
                    break;
            }
            return list;
        }
    }
}
