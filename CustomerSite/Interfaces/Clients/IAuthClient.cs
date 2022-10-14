using CommonModel.Auth;

namespace CustomerSite.Interfaces.Clients
{
    public interface IAuthClient
    {
        Task<SigninResponseDto> SigninAsync(string email, string password);
    }
}
