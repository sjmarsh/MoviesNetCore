using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Infrastructure
{
    public static class EnumExtensions
    {        
        public static T FromString<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
