using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies1.Models;

namespace BlazorWebAppMovies1.Data
{
    public class BlazorWebAppMovies1Context : DbContext
    {
        public BlazorWebAppMovies1Context (DbContextOptions<BlazorWebAppMovies1Context> options)
            : base(options)
        {
        }

        public DbSet<BlazorWebAppMovies1.Models.Movies> Movies { get; set; } = default!;
        public DbSet<BlazorWebAppMovies1.Models.Genre> Genre { get; set; } = default!;
    }
}
