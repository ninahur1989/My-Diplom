using System.Net.Http;
using System.Threading.Tasks;

namespace DishBurger.Data.Services.ServiceInterfaces
{
    public interface IAuthorizeService
    {
        public Task<HttpResponseMessage> GetTokenAsync();
    }
}
