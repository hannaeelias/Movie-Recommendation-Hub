using Microsoft.AspNetCore.Identity;

namespace Movie_Recommendation_Hub.Models
{
    public class Watchlist
    {
        public int WatchlistID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public DateTime AddedAt { get; set; }

        public required IdentityUser User { get; set; }
        public required Movie Movie { get; set; }
    }
}
