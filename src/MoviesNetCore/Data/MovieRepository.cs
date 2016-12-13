using Microsoft.Extensions.Logging;
using MoviesNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Data
{
    public interface IMovieRepository
    {
        IEnumerable<MovieDB> GetAll();

        IEnumerable<MovieDB> GetAll(string searchFilter, int take, int skip);

        MovieDB Get(int id);

        int Create(MovieDB movie);

        void Update(MovieDB movie);

        void Delete(int id);
    }

    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;
        private readonly ILogger _logger;

        public MovieRepository(MovieContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("MovieRepository");
        }

        public int Create(MovieDB movie)
        {
            _logger.LogDebug("Creating movie with title {0}", movie.Title);
            _context.Add(movie);
            _context.SaveChanges();
            return movie.Id;
        }

        public void Delete(int id)
        {
            _logger.LogDebug("Deleting Movie Record for ID {0}", id);
            var movie = Get(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public MovieDB Get(int id)
        {
            _logger.LogDebug("Getting Movie Record for ID {0}", id);
            return _context.Movies.Single(m => m.Id == id);
        }

        public IEnumerable<MovieDB> GetAll()
        {
            _logger.LogDebug("Getting all Movie Records");
            return _context.Movies.ToList();
        }

        public IEnumerable<MovieDB> GetAll(string searchFilter, int take, int skip)
        {
            _logger.LogDebug("Getting filtered Movie Records with filter: {0}", searchFilter);
            return _context.Movies.Where(m => m.Title.Contains(searchFilter)).OrderBy(m => m.Title).Take(take).Skip(skip);
        }

        public void Update(MovieDB movie)
        {
            _logger.LogDebug("Updating Movie Record for ID {0}", movie.Id);
            var existingMovie = Get(movie.Id); // todo: try catch as may not exist

            _context.Update(movie);
            _context.SaveChanges();
        }
    }
}
