using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Models
{
    public class UserModel : IdentityUser
    {
        public string? FirstName { get; set; }   
        public string? LastName { get; set; }    
    }
}
