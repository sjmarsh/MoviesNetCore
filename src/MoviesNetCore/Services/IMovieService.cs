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
        IEnumerable<Movie> All();
        IEnumerable<Movie> All(MovieQuery query);
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

        public IEnumerable<Movie> All()
        {
            var movies = _movieRepository.GetAll();
            if (movies != null && movies.Any())
            {
                return movies.Select(m => _movieConverter.ConvertToMovie(m));
            }
            return new List<Movie>();
        }

        public IEnumerable<Movie> All(MovieQuery query)
        {
            var movies = _movieRepository.GetAll(query).ToList();
            if (movies != null && movies.Any())
            {
                return movies.Select(m => _movieConverter.ConvertToMovie(m)).OrderBy(m => m.Title);
            }
            return new List<Movie>();
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
