using Xunit;
using DishBurger.Data.Services;

namespace DishBurger.Test
{
    public class OrdersServiceTest
    {
        [Fact]
        public void GetOrdersByUserIdAndRoleAsync_ValidResponse_ReturnListOfOrdersAdmin()
        {
            var service = new OrdersService();
            var items = service.GetOrdersByUserIdAndRoleAsync("76524653-9950-43f9-b75b-f7f9ad212a33", "Admin");
            Assert.NotNull(items);
        }

        [Fact]
        public void GetOrdersByUserIdAndRoleAsync_ValidResponse_ReturnListOfOrdersUser()
        {
            var service = new OrdersService();
            var items = service.GetOrdersByUserIdAndRoleAsync("236258df-aef7-4870-ac6f-ed9553ba7145", "User");
            Assert.NotNull(items);
        }
    }
}