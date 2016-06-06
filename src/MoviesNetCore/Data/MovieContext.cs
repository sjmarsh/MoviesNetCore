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

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ForSqliteToTable("movie");
            modelBuilder.Entity<Movie>().HasKey(m => m.Id);
            //modelBuilder.Entity<Movie>().Property(p => p.RunningTime).ForSqliteHasColumnType("string"); // todo: how to cast string to timespan?
            base.OnModelCreating(modelBuilder);
        }
    }
}
