using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
    }
}