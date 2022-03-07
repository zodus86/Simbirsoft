using Microsoft.AspNetCore.Mvc;
using Simbirsoft.Data;
using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Controllers
{
    /// <summary>
    /// 2.1.2 Контроллер получения книг
    /// </summary>
    public class LibraryCardController : Controller
    {
        /// <summary>
        /// 2.1.4 	В контроллере создать метод POST отвечающий за взятие книги читателем. На вход - вышеописанный объект.
        /// </summary>
        /// <param name="libraryCard"></param>
        [HttpPost]
        [Route("AddCard")]
        public void Post([FromBody] LibraryCard libraryCard)
        {
            LibraryCardRepository.Add(libraryCard);
        }

        /// <summary>
        /// список карт
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCards")]
        public IEnumerable<LibraryCard> GetCards()
        {
            return LibraryCardRepository.GetCards();
        }

    }
}
