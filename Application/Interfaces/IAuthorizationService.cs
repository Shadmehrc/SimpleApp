using Domain.Models;

namespace Application.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<TokenResponseModel?> ValidateLogin(UserLoginModel loginModel);
        Task<bool> RegisterNewUser(UserSignUpModel signUpModel);
    }
}