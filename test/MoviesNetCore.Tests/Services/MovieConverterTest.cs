using MoviesNetCore.Services;
using MoviesNetCore.Data;
using MoviesNetCore.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Tests.Services
{
    public class MovieConverterTest
    {
        [Fact]
        public void ShouldConvertMovieDBToMovie()
        {
            var movieDB = new MovieDB
            {
                Title = "The Movie",
                Description = "Some Description",
                Category = "Action",
                Classification = "PG",
                Format = "DVD",
                ReleaseYear = "1999",
                RunningTime = 123,
                DateAdded = new DateTime(2015, 01, 01),
                CoverPhoto = "TheMovie.bmp",
                TVRecording = true,
                Id = 1
            };

            var converter = new MovieConverter();

            var movie = converter.ConvertToMovie(movieDB);

            Assert.Equal(movieDB.Title, movie.Title);
            Assert.Equal(movieDB.Description, movie.Description);
            Assert.Equal(movieDB.Category, movie.Category.ToString());
            Assert.Equal(movieDB.Classification, movie.Classification.ToString());
            Assert.Equal(movieDB.Format, movie.Format.ToString());
            Assert.Equal(movieDB.ReleaseYear, movie.ReleaseYear);
            Assert.Equal(movieDB.RunningTime, movie.RunningTime.TotalMinutes);
            Assert.Equal(movieDB.DateAdded, movie.DateAdded);
            Assert.Equal(movieDB.CoverPhoto, movie.CoverPhoto);
            Assert.Equal(movieDB.TVRecording, movie.TVRecording);
            Assert.Equal(movieDB.Id, movie.Id);
        }

        [Fact]
        public void ShouldConvertMovieToMovieDB()
        {
            var movie = new Movie
            {
                Title = "The Movie",
                Description = "Some Description",
                Category = Category.Action,
                Classification = Classification.PG,
                Format = Format.DVD,
                ReleaseYear = "1999",
                RunningTime = TimeSpan.FromMinutes(123),
                DateAdded = new DateTime(2015, 01, 01),
                CoverPhoto = "TheMovie.bmp",
                TVRecording = true,
                Id = 1
            };

            var converter = new MovieConverter();

            var movieDB = converter.ConvertToMovieDB(movie);

            Assert.Equal(movie.Title, movieDB.Title);
            Assert.Equal(movie.Description, movieDB.Description);
            Assert.Equal(movie.Category.ToString(), movieDB.Category);
            Assert.Equal(movie.Classification.ToString(), movieDB.Classification);
            Assert.Equal(movie.Format.ToString(), movieDB.Format);
            Assert.Equal(movie.ReleaseYear, movieDB.ReleaseYear);
            Assert.Equal(movie.RunningTime.TotalMinutes, movieDB.RunningTime);
            Assert.Equal(movie.DateAdded, movieDB.DateAdded);
            Assert.Equal(movie.CoverPhoto, movieDB.CoverPhoto);
            Assert.Equal(movie.TVRecording, movieDB.TVRecording);
            Assert.Equal(movie.Id, movieDB.Id);
        }
    }
}
