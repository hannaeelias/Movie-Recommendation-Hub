using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie_Recommendation_Hub.Models;


namespace Movie_Recommendation_Hub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreID);
        }
        public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            // Seed Genres if not already seeded
            if (!context.Genres.Any())
            {
                context.Genres.AddRange(
                    new Genre { Name = "Action" },
                    new Genre { Name = "Comedy" },
                    new Genre { Name = "Drama" }
                );
                context.SaveChanges();
            }

            // Seed Movies if not already seeded
            if (!context.Movies.Any())
            {
                var actionGenre = context.Genres.FirstOrDefault(g => g.Name == "Action");
                var comedyGenre = context.Genres.FirstOrDefault(g => g.Name == "Comedy");

                if (actionGenre != null && comedyGenre != null)
                {
                    context.Movies.AddRange(
                        new Movie { Title = "Inception", ReleaseDate = new DateTime(2010, 7, 16), Genre = actionGenre, Rating = 4.5f },
                        new Movie { Title = "The Hangover", ReleaseDate = new DateTime(2009, 6, 5), Genre = comedyGenre, Rating = 4.2f }
                    );
                    context.SaveChanges();
                }
            }

            // Seed Users if none exist
            if (!userManager.Users.Any())
            {
                var user1 = new IdentityUser
                {
                    EmailConfirmed = true,
                    UserName = "admin.admin@example.com",
                    Email = "admin.admin@example.com"
                };

                var result1 = userManager.CreateAsync(user1, "Password123!").Result;

                if (result1.Succeeded)
                {
                    userManager.AddToRoleAsync(user1, "User");
                }
            }
        }

    }

}
