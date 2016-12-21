using Microsoft.AspNetCore.Mvc;
using MoviesNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Controllers
{
    public class ReferenceDataController : Controller
    {
        [HttpGet]
        [Route("api/referenceData/categories")]
        public IEnumerable<string> Categories()
        {
            var categories = Enum.GetValues(typeof(Category));
           
            foreach(var cat in categories)
            {
                yield return cat.ToString();
            }
        }

    }
}
