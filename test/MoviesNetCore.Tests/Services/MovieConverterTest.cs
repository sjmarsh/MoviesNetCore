using MoviesNetCore.Services;
using MoviesNetCore.Data;
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
            throw new NotImplementedException();
        }
    }
}
