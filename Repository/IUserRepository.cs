using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Repository
{
    public interface IUserRepository
    {
        Task<string> LoginAsync(LoginModel loginModel);
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
    }
}