using Microsoft.AspNetCore.Identity;

namespace Movie_Recommendation_Hub.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }

}
