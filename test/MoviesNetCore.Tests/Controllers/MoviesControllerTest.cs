using MoviesNetCore.Controllers;
using MoviesNetCore.Services;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesNetCore.Models;

namespace MoviesNetCore.Tests.Controllers
{
    public class MoviesControllerTest
    {
        private Mock<IMovieService> _mockMovieService;
        
        public MoviesControllerTest()
        {
            _mockMovieService = new Mock<IMovieService>();
        }

        [Fact]
        public void ShouldGetMoviesFromService()
        {
            var movieQuery = new MovieQuery();
            var controller = new MoviesController(_mockMovieService.Object);

            controller.Get(movieQuery);

            _mockMovieService.Verify(m => m.All(movieQuery), Times.Once);
        }

        [Fact]
        public void ShouldGetMoviesFromServiceWithFilter()
        {
            var query = new MovieQuery
            {
                SearchFilter = "My Movie",
                Take = 10,
                Skip = 1
            };
            var controller = new MoviesController(_mockMovieService.Object);

            controller.Get(query);

            _mockMovieService.Verify(m => m.All(query), Times.Once);
        }

        [Fact]
        public void ShouldGetMovieFromService()
        {
            var movieId = 20;

            var controller = new MoviesController(_mockMovieService.Object);

            controller.Get(movieId);

            _mockMovieService.Verify(m => m.Get(movieId), Times.Once);
        }

        [Fact]
        public void ShouldReturnMoviesFromController()
        {
            var movieQuery = new MovieQuery();
            var movies = new List<Movie> { new Movie { Id = 1, Title = "The Movie" } };
            _mockMovieService.Setup(m => m.All(movieQuery)).Returns(movies);
            var controller = new MoviesController(_mockMovieService.Object);

            var result = controller.Get(movieQuery);

            Assert.Equal(movies, result);
        }

        [Fact]
        public void ShouldReturnMovieFromController()
        {
            const int movieId = 1;
            var movie = new Movie { Id = movieId, Title = "The Movie" };
            _mockMovieService.Setup(m => m.Get(movieId)).Returns(movie);
            var controller = new MoviesController(_mockMovieService.Object);

            var result = controller.Get(movieId);

            Assert.Equal(movie, result);
        }
        
    }
}
