using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Data
{
    public class MovieDBResponse
    {
        public MovieDBResponse()
        {
            Movies = new List<MovieDB>();
        }

        public IEnumerable<MovieDB> Movies { get; set; }

        public int Count { get; set; }
    }
}
