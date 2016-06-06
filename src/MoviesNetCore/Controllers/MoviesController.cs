using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesNetCore.Models;
using MoviesNetCore.Data;

namespace MoviesNetCore.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            var movie1 = new Movie
            {
                Id = 1,
                Title = "Die Hard",
                ReleaseYear = "1988",
                Category = Category.Action,
                Classification = Classification.M,
                RunningTime = "131",//TimeSpan.FromMinutes(131),
                Description = "John McClane, officer of the NYPD, tries to save his wife Holly Gennaro and several others that were taken hostage by German terrorist Hans Gruber during a Christmas party at the Nakatomi Plaza in Los Angeles.",
                Format = Format.BluRay,
                CoverPhoto = "http://www.imdb.com/media/rm2525146112/tt0095016?ref_=tt_ov_i",
                DateAdded = DateTime.Today
            };

            var movie2 = new Movie
            {
                Id = 2,
                Title = "Back To The Future",
                ReleaseYear = "1985",
                Category = Category.Adventure,
                Classification = Classification.PG,
                RunningTime = "116", //TimeSpan.FromMinutes(116),
                Description = "A young man is accidentally sent thirty years into the past in a time-traveling DeLorean invented by his friend, Dr. Emmett Brown, and must make sure his high-school-age parents unite in order to save his own existence.",
                Format = Format.DVD,
                CoverPhoto = "http://www.imdb.com/media/rm554638848/tt0088763?ref_=tt_ov_i",
                DateAdded = DateTime.Today
            };

            //return new Movie[] { movie1, movie2 };
            return _movieRepository.GetAll();
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            /*
            return new Movie
            {
                Id = id,
                Title = "Spaceballs",
                ReleaseYear = "1987",
                Category = Category.Comedy,
                Classification = Classification.PG,
                RunningTime = TimeSpan.FromMinutes(96),
                Description = "Planet Spaceballs' President Skroob sends Lord Dark Helmet to steal planet Druidia's abundant supply of air to replenish their own, and only Lone Starr can stop them.",
                Format = Format.DVD,
                CoverPhoto = "http://ia.media-imdb.com/images/M/MV5BMTM3Mzg0Mzc2NF5BMl5BanBnXkFtZTcwNDEwNTk0NA@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                DateAdded = DateTime.Today
            };*/

            return _movieRepository.Get(id);

        }

        // POST api/movies
        [HttpPost]
        public void Post([FromBody]Movie movie)
        {
        }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Movie movie)
        {
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
