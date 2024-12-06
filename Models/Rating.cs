using Microsoft.AspNetCore.Identity;

namespace Movie_Recommendation_Hub.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public float RatingValue { get; set; }
        public required string Review { get; set; }
        public DateTime RatedAt { get; set; }

        public required IdentityUser User { get; set; }
        public required Movie Movie { get; set; }
    }
}
