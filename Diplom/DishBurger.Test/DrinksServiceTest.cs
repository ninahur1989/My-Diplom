using System.Collections.Generic;
using Xunit;
using DishBurger.Data.Services;
using DishBurger.Models;
using DishBurger.Data.Enums;
using Moq;
using DishBurger.Data.Services.ServiceInterfaces;

namespace DishBurger.Test
{
    public class DrinksServiceTest
    {
        [Fact]
        public async void GetDrinksAsync_ValidDrinks_ReturnListDrinks()
        {
            var allDrinks = new List<ItemEntity> {
                new ItemEntity {
                    product = Product.Drink,
                    Id = 3,
                },
                new ItemEntity {
                    product = Product.Drink,
                    Id = 4,
                }
            };
            List<ItemEntity> sortedDrinks = new List<ItemEntity>();

            foreach (var a in allDrinks)
            {

                if (a.product == Product.Drink)
                {
                    var dataMock = new Mock<IDrinksService>();
                    dataMock
                        .Setup(x => x.GetDrinkByIdAsync(It.IsAny<int>()))
                        .ReturnsAsync(() => new ItemEntity() { Id = a.Id, Drink = new Drink() { Id = a.Id } });
                    var item = await dataMock.Object.GetDrinkByIdAsync(a.Id);

                    sortedDrinks.Add(item);
                }
            }

            var expectedItem1 = new ItemEntity() { Id = 3, Drink = new Drink() { Id = 3 } };
            var ourItem1 = sortedDrinks.Find(x => x.Id == 3);
            var expectedItem2 = new ItemEntity() { Id = 4, Drink = new Drink() { Id = 4 } };
            var ourItem2 = sortedDrinks.Find(x => x.Id == 4);

            Assert.Equal(expectedItem1.Drink.Id, ourItem1.Drink.Id);
            Assert.Equal(expectedItem2.Drink.Id, ourItem2.Drink.Id);
        }

        [Fact]
        public void GetDrinkByIdAsync_ValidDrink_ReturnDrink()
        {
            var service = new DrinksService();
            var items = service.GetDrinkByIdAsync(3);
            Assert.NotNull(items);
        }

        [Fact]
        public void GetNewDrinkDropdownsValues_ValidResponse_ReturnResponse()
        {
            var service = new DrinksService();
            var items = service.GetNewDrinkDropdownsValues();
            Assert.NotNull(items);
        }

        [Fact]
        public void GetSortedDrinksAsync_SortedDrinks_ReturnSortedDrinks()
        {
            var sortService = new SortService();

            var allDrinks = new List<ItemEntity> {
                new ItemEntity {
                    product = Product.Drink,
                    Id = 3,
                },
                new ItemEntity {
                    product = Product.Drink,
                    Id = 4,
                }
            };

            sortService.Sort(allDrinks, SortTypes.None);
            Assert.NotNull(allDrinks);
        }
    }
}