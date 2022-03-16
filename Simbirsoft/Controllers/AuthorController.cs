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
    [Route("author/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {

        private readonly IAllAuthors _allAuthor;

        public AuthorController (IAllAuthors allAuthors)
        {
            _allAuthor = allAuthors;
        }

        [HttpGet]
        [Route("GetAuthors")]
        public IEnumerable<Author> GetAuthors()
        {
            return _allAuthor.Authors;
        }

        [HttpPost]
        [Route("CreateAuthor")]
        public void CreateAuthor([FromBody] Author value)
        {
            _allAuthor.Add(value);
        }



    }
}
