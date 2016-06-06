using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public Category Category { get; set; }
        public Classification Classification { get; set; }
        public string RunningTime { get; set; }
        public string Description { get; set; }
        public string CoverPhoto { get; set; }
        public Format Format { get; set; }
        public bool TVRecording { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
