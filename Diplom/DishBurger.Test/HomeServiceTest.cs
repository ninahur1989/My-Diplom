using System.Collections.Generic;
using Xunit;
using DishBurger.Data.Services;
using DishBurger.Models;
using DishBurger.Data.Enums;
using Moq;
using DishBurger.Data.Services.ServiceInterfaces;

namespace DishBurger.Test
{
    public class HomeServiceTest
    {
        [Fact]
        public async void GetItemAsync_ValidItem_ReturnListItems()
        {
            var allItems = new List<ItemEntity> {
                new ItemEntity {
                    product = Product.Dish,
                    Id = 3,
                },
                new ItemEntity {
                    product = Product.Drink,
                    Id = 4,
                }
            };
            List<ItemEntity> sortedItems = new List<ItemEntity>();


            foreach (var a in allItems)
            {

                if (a.product == Product.Dish)
                {
                    var dataMock = new Mock<IHomeService>();
                    dataMock
                        .Setup(x => x.GetItemByIdAsync(It.IsAny<int>()))
                        .ReturnsAsync(() => new ItemEntity() { Id = a.Id });
                    var item = await dataMock.Object.GetItemByIdAsync(a.Id);

                    sortedItems.Add(item);
                }
                else
                {
                    var dataMock = new Mock<IHomeService>();
                    dataMock
                        .Setup(x => x.GetItemByIdAsync(It.IsAny<int>()))
                        .ReturnsAsync(() => new ItemEntity() { Id = a.Id });
                    var item = await dataMock.Object.GetItemByIdAsync(a.Id);

                    sortedItems.Add(item);
                }
            }

            var expectedItem1 = new ItemEntity() { Id = 3,};
            var ourItem1 = sortedItems.Find(x => x.Id == 3);
            var expectedItem2 = new ItemEntity() { Id = 4, };
            var ourItem2 = sortedItems.Find(x => x.Id == 4);

            Assert.Equal(expectedItem1.Id, ourItem1.Id);
            Assert.Equal(expectedItem2.Id, ourItem2.Id);

        }

        [Fact]
        public void GetItemByIdAsync_ValidItem_ReturnItem()
        {
            var service = new HomeService();
            var items = service.GetItemByIdAsync(3);
            Assert.NotNull(items);
        }

        [Fact]
        public void GetSortedItemsAsync_SortedItems_ReturnSortedItems()
        {
            var sortService = new SortService();

            var allItems = new List<ItemEntity> {
                new ItemEntity {
                    product = Product.Dish,
                    Id = 3,
                },
                new ItemEntity {
                    product = Product.Drink,
                    Id = 4,
                }
            };

            sortService.Sort(allItems, SortTypes.None);
            Assert.NotNull(allItems);
        }
    }
}