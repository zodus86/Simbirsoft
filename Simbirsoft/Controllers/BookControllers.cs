using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Simbirsoft.Data;
using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Controllers
{   /// <summary>
    /// 1.4 - контроллер книги
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        #region 2.2.3 ILogger
        //private readonly ILogger _logger;
        //public string Message { get; set; }
        //public BookController (ILogger<BookController> logger)
        //{
        //    _logger = logger;
        //}

        #endregion

        /// <summary>
        /// 1.4.1.1.	Список всех книг.
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("GetBooks")]
        public IEnumerable<Book> GetBooks()
        {
            //Message = $"Use GetBooks start- {DateTime.Now.ToLongTimeString()}";
            //_logger.LogInformation(Message);

            return BookRepository.GetBooks();
        }

        /// <summary>
        /// 1.4.1.2.	Список всех книг по автору (фильтрация AuthorId).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBooksAutherId/{id}")]
        public IEnumerable<Book> GetBookAutherId(int id)
        {
            return BookRepository.GetBooksAutherId(id);
        }

        /// <summary>
        /// 1.4.2 Реализовать метод POST добавляющий нового.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            BookRepository.Add(book);
        }

        /// <summary>
        /// 1.4.3.	Реализовать метод DELETE удаляющий .
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("DelBook/{id}")]
        public void Delete(int id)
        {
            BookRepository.Delete(id);
        }

        /// <summary>
        /// 2.2.2 сортировка по полю
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSortedAuther/{param}")]
        public IEnumerable<Book> GetSortedAuther(string param)
        {
            return BookRepository.GetSortTitleGenreAuther(param);
        }

    }
}
