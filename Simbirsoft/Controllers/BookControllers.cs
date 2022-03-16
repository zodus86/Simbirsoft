using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Simbirsoft.Data;
using Simbirsoft.Data.Intarface;
using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Controllers
{
    [Route("book/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IAllBooks _allBooks;

        public BookController(IAllBooks allBooks)
        {
            _allBooks = allBooks;
        }

        [HttpGet]
        [Route("GetBooks")]
        public IEnumerable<Book> GetBooks()
        {
            return _allBooks.Books;
        }

        [HttpPost]
        [Route("CreateBook")]
        public void CreateBook([FromBody] Book value)
        {
            _allBooks.Add(value);
        }

        [HttpPost]
        [Route("ChangeGenre")]
        public void ChangeGenre(int BookId, int GanresId)
        {
            _allBooks.ChangeGenre(BookId, GanresId);
        }

    }
}
