namespace Movie_Recommendation_Hub.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public required string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Description { get; set; }
        public string? PosterURL { get; set; }
        public float Rating { get; set; }

        public int GenreID { get; set; }
        public required Genre Genre { get; set; }

        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<Watchlist>? Watchlists { get; set; }
    }
}
