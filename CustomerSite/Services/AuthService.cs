using CommonModel.Auth;
using CustomerSite.Extensions;
using CustomerSite.Interfaces;

namespace CustomerSite.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory clientFactory;

        public AuthService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<SigninResponseDto?> SigninAsync(string email, string password)
        {

            var param = new SigninRequestDto() { Email = email, Password = password };

            var httpClient = clientFactory.CreateClient();

            var data = await httpClient.PostApiAsync<SigninRequestDto, SigninResponseDto>("Auth/signin", param);

            return data;
        }
    }
}
