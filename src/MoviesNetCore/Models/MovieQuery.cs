using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Models
{
    public class MovieQuery
    {
        public string SearchFilter { get; set; }
        public List<string> Categories { get; set; }

        public int? Take { get; set; }
        public int? Skip { get; set; }
    }
}
