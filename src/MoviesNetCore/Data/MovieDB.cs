using MoviesNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Data
{
    public class MovieDB
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string Category { get; set; }
        public string Classification { get; set; }
        public double RunningTime { get; set; }
        public string Description { get; set; }
        public string CoverPhoto { get; set; }
        public string Format { get; set; }
        public bool TVRecording { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
