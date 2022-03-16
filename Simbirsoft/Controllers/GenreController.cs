using Microsoft.AspNetCore.Mvc;
using Simbirsoft.Data;
using Simbirsoft.Data.Intarface;
using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Controllers
{
    [Route("genre/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IAllGenres _allGenres;

        public GenreController(IAllGenres allGenres)
        {
            _allGenres = allGenres;
        }

        [HttpGet]
        [Route("GetGenre")]
        public IEnumerable<Genre> GetGenre()
        {
            return _allGenres.Genres;
        }

        [HttpPost]
        [Route("CreateGenre")]
        public void CreateGenre([FromBody] Genre value)
        {
            _allGenres.Add(value);
        }
    }
}
