using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Models
{
    public class MovieResponse
    {
        public MovieResponse()
        {
            Movies = new List<Movie>();
        }

        public IEnumerable<Movie> Movies { get; set; }
        public int Count { get; set; }
    }
}
