using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base (options)
        {

        }
        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder md)
        {
            md.Entity<Category>().HasData(
                new Category { CategoryID=1, CategoryName = "Action"},
                new Category { CategoryID=2, CategoryName="Romantic Comedy"},
                new Category { CategoryID=3, CategoryName="Comic Action"},
                new Category { CategoryID=4, CategoryName="Drama"},
                new Category { CategoryID=5, CategoryName="Mystery"},
                new Category { CategoryID=6, CategoryName="Thriller"},
                new Category { CategoryID=7, CategoryName="Horror"},
                new Category { CategoryID=8, CategoryName="Comedy"},
                new Category { CategoryID=9, CategoryName="Western"},
                new Category { CategoryID=10, CategoryName="Romance"}
                );

            md.Entity<MovieResponse>().HasData(
                new MovieResponse
                {
                    MovieID = 1,
                    CategoryID = 1,
                    MovieTitle ="The Dark Knight",
                    Year = 2012,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Cool Batman Movie"
                },
            new MovieResponse
            {
                MovieID = 2,
                CategoryID = 2,
                MovieTitle = "How to Lose a Guy in 10 Days",
                Year = 2003,
                Director = "Donald Petrie",
                Rating = "PG-13",
                Edited = false,
                LentTo = "",
                Notes = "Funny movie about love"
            },
            new MovieResponse
            {
                MovieID = 3,
                CategoryID = 3,
                MovieTitle = "Avengers: Infinity War",
                Year = 2018,
                Director = "The Russo Brothers",
                Rating = "PG-13",
                Edited = false,
                LentTo = "",
                Notes = "Crazy"
            }
            );
        }

    }
}
