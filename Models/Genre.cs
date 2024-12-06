namespace Movie_Recommendation_Hub.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public required string Name { get; set; }

        public  ICollection<Movie>? Movies { get; set; }
    }
}
