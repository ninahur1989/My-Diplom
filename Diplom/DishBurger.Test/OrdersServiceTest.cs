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
            var items = service.GetOrdersByUserIdAndRoleAsync("2c9f926b-3d89-4902-ba7d-cc975e2023f7", "Admin");
            Assert.NotNull(items);
        }

        [Fact]
        public void GetOrdersByUserIdAndRoleAsync_ValidResponse_ReturnListOfOrdersUser()
        {
            var service = new OrdersService();
            var items = service.GetOrdersByUserIdAndRoleAsync("350abe2e-c892-4250-98c6-36e107719e0c", "User");
            Assert.NotNull(items);
        }
    }
}