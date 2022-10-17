using DishBurger.Data.Services.ServiceInterfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DishBurger.Data.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        public async Task<HttpResponseMessage> GetTokenAsync()
        {
            var url = "http://localhost:59001/connect/token";
            //for docker
            //var url = "http://host.docker.internal:59001/connect/token";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            var data = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"client_id", "ropc_client"},
                    {"client_secret", "secret_1"},
                    {"scope", "openid"},
                    {"username", "admin.admin@google.com" },
                    {"password", "admin_1"}
                };

            var response = await client.PostAsync(url, new FormUrlEncodedContent(data));
            return response;
        }
    }
}
