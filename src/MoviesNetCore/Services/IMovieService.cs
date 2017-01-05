using MoviesNetCore.Data;
using MoviesNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Services
{
    public interface IMovieService
    {
        Movie Get(int id);
        MovieResponse All();
        MovieResponse All(MovieQuery query);
        int Save(Movie movie);
        void Delete(int id);
    }

    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;
        private IMovieConverter _movieConverter;

        public MovieService(IMovieRepository movieRepository, IMovieConverter movieConverter)
        {
            _movieRepository = movieRepository;
            _movieConverter = movieConverter;
        }

        public Movie Get(int id)
        {
            var movieDb = _movieRepository.Get(id);
            if (movieDb != null)
            {
                return _movieConverter.ConvertToMovie(movieDb);
            }
            return null;
        }

        public MovieResponse All()
        {
            var movieResponse = new MovieResponse();
            var movieDbResponse = _movieRepository.GetAll();
            if (movieDbResponse != null && movieDbResponse.Count > 0)
            {
                movieResponse.Count = movieDbResponse.Count;
                movieResponse.Movies =  movieDbResponse.Movies.Select(m => _movieConverter.ConvertToMovie(m)).OrderBy(m => m.Title);
            }
            return movieResponse;
        }

        public MovieResponse All(MovieQuery query)
        {
            var movieResponse = new MovieResponse();
            var movieDbResponse = _movieRepository.GetAll(query);
            if (movieDbResponse != null && movieDbResponse.Count > 0)
            {
                movieResponse.Count = movieDbResponse.Count;
                movieResponse.Movies =  movieDbResponse.Movies.Select(m => _movieConverter.ConvertToMovie(m)).OrderBy(m => m.Title);
            }
            return movieResponse;
        }

        public int Save(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
