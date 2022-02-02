using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            //Blank
        }

        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category {CategoryId = 1, CategoryName = "Comedy"},
                new Category {CategoryId = 2, CategoryName = "Action/Adventure"},
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" },
                new Category { CategoryId = 9, CategoryName = "Other" }
                );

            mb.Entity<MovieResponse>().HasData(
                new MovieResponse
                {
                    MovieID = 1,
                    CategoryId = 1,
                    Title = "Lord of The Rings Return of the King",
                    Year = 2003,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = "",
                    Notes = "",
                },

            
            new MovieResponse
            {
                MovieID = 2,
                CategoryId = 1,
                Title = "Prince of Persia: The Sands of Time",
                Year = 2010,
                Director = "Mike Newell",
                Rating = "PG-13",
                Edited = false,
                Lent = "",
                Notes = "",
            },

            new MovieResponse
            {
                MovieID = 3,
                CategoryId = 1,
                Title = "Shrek",
                Year = 2001,
                Director = "Vicky Jenson",
                Rating = "PG",
                Edited = false,
                Lent = "",
                Notes = "",
            }

            );
        }
    }
}
