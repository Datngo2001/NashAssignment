using CommonModel.Auth;

namespace CustomerSite.Interfaces
{
    public interface IAuthService
    {
        Task<SigninResponseDto> SigninAsync(string email, string password);
    }
}
