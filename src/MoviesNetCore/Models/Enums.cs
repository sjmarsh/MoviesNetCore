using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Models
{
    public enum Category
    {
        Action,
        Adventure,
        Animation,
        Childrens,
        Christmas,
        Comedy,
        Documentary,
        Drama,
        Horror,
        Music,
        Other,
        SciFi,
        Thriller,
        TV
    }


    public enum Classification
    {
        G,
        PG,
        M,
        MA,
        R
    }

    public enum Format
    {
        DVD,
        BluRay,
        Copy,
        File,
        TVRecording,
        VHS
    }
}
