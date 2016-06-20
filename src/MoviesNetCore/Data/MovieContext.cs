using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesNetCore.Models;

namespace MoviesNetCore.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        } 

        public DbSet<MovieDB> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDB>().ForSqliteToTable("movie");
            modelBuilder.Entity<MovieDB>().HasKey(m => m.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
