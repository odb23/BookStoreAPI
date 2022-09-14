using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserModel> _userManager;

        public UserRepository(UserManager<UserModel> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            var user = new UserModel()
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };

            return await this._userManager.CreateAsync(user, signUpModel.Password);
        }
    }
}
