using MoviesNetCore.Data;
using MoviesNetCore.Models;
using MoviesNetCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Services
{
    public interface IMovieConverter
    {
        Movie ConvertToMovie(MovieDB movie);
        MovieDB ConvertToMovieDB(Movie movie);
    }

    public class MovieConverter : IMovieConverter
    {
        public Movie ConvertToMovie(MovieDB movie)
        {
            return new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Category = movie.Category.FromString<Category>(),
                Classification = movie.Classification.FromString<Classification>(),
                RunningTime = TimeSpan.FromMinutes(movie.RunningTime),
                Description = movie.Description,
                CoverPhoto = movie.CoverPhoto,
                Format = movie.Format.FromString<Format>(),
                TVRecording = movie.TVRecording,
                DateAdded = movie.DateAdded
            };
        }

        public MovieDB ConvertToMovieDB(Movie movie)
        {
            return new MovieDB
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Category = movie.Category.ToString(),
                Classification = movie.Classification.ToString(),
                RunningTime = movie.RunningTime.TotalMinutes,
                Description = movie.Description,
                CoverPhoto = movie.CoverPhoto,
                Format = movie.Format.ToString(),
                TVRecording = movie.TVRecording,
                DateAdded = movie.DateAdded
            };
        }
    }
}
