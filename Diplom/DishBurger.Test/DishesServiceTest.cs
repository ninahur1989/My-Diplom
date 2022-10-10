using System.Collections.Generic;
using Xunit;
using DishBurger.Data.Services;
using DishBurger.Models;
using DishBurger.Data.Enums;
using Moq;
using DishBurger.Data.Services.ServiceInterfaces;

namespace DishBurger.Test
{
    public class DishesServiceTest
    {
        [Fact]
        public async void GetDishesAsync_ValidDishes_ReturnListDishes()
        {
            var allDishes = new List<ItemEntity> {
                new ItemEntity {
                    product = Product.Dish,
                    Id = 3,
                },
                new ItemEntity {
                    product = Product.Dish,
                    Id = 4,
                }
            };
            List<ItemEntity> sortedDishes = new List<ItemEntity>();

            foreach (var a in allDishes)
            {
                if (a.product == Product.Dish)
                {
                    var dataMock = new Mock<IDishesService>();
                    dataMock
                        .Setup(x => x.GetDishByIdAsync(It.IsAny<int>()))
                        .ReturnsAsync(() => new ItemEntity() { Id = a.Id, Dish = new Dish() { Id = a.Id } });
                    var item = await dataMock.Object.GetDishByIdAsync(a.Id);

                    sortedDishes.Add(item);
                }
            }

            var expectedItem1 = new ItemEntity() { Id = 3, Dish = new Dish() { Id = 3 } };
            var ourItem1 = sortedDishes.Find(x => x.Id == 3);
            var expectedItem2 = new ItemEntity() { Id = 4, Dish = new Dish() { Id = 4 } };
            var ourItem2 = sortedDishes.Find(x => x.Id == 4);

            Assert.Equal(expectedItem1.Dish.Id, ourItem1.Dish.Id);
            Assert.Equal(expectedItem2.Dish.Id, ourItem2.Dish.Id);

        }

        [Fact]
        public void GetDishByIdAsync_ValidDish_ReturnDish()
        {
            var service = new DishesService();
            var items = service.GetDishByIdAsync(3);
            Assert.NotNull(items);
        }

        [Fact]
        public void GetNewDishDropdownsValues_ValidResponse_ReturnResponse()
        {
            var service = new DishesService();
            var items = service.GetNewDishDropdownsValues();
            Assert.NotNull(items);
        }

        [Fact]
        public void GetSortedDishesAsync_SortedDishes_ReturnSortedDishes()
        {
            var sortService = new SortService();

            var allDishes = new List<ItemEntity> {
                new ItemEntity {
                    product = Product.Dish,
                    Id = 3,
                },
                new ItemEntity {
                    product = Product.Dish,
                    Id = 4,
                }
            };

            sortService.Sort(allDishes, SortTypes.None);
            Assert.NotNull(allDishes);
        }
    }
}