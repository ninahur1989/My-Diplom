using DishBurger.Data.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DishBurger.Test
{
    public class AuthorizeServiceTest
    {
        [Fact]
        public async Task GetTokenAsync_ValidResponse_ReturnResponse()
        {
            var service = new AuthorizeService();

            var response = await service.GetTokenAsync();
            var ourResult = new HttpResponseMessage();

            Assert.NotNull(response);
            Assert.Equal(ourResult.IsSuccessStatusCode, response.IsSuccessStatusCode);
        }
    }
}
