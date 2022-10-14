using CommonModel.Auth;
using CustomerSite.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CustomerSite.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;

        public AuthService(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory.CreateClient();
        }

        public async Task<SigninResponseDto> SigninAsync(string email, string password)
        {

            var param = new SigninRequestDto() { Email = email, Password = password };

            var jsonInString = JsonConvert.SerializeObject(param);
            
            var response = await httpClient.PostAsync("Auth/signin", new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<SigninResponseDto>(contents);

            return data;
        }
    }
}
