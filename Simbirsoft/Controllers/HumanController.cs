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
    /// 1.3 - контроллер человека
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : Controller
    {
        /// <summary>
        /// 1.3.1.1 	Список всех людей.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHuman")]
        public IEnumerable<Human> GetHuman()
        {
            return HumanRepository.GetHumans();
        }

        /// <summary>
        /// 1.3.1.2 	Список людей авторов.
        /// </summary>
        /// <returns></returns
        [HttpGet]
        [Route("GetAuthor")]
        public IEnumerable<Human> GetAuthor()
        {
            return HumanRepository.GetAuthor();
        }
        /// <summary>
        /// 1.3.1.3 поиск людей по фразе
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHumanSearch/{text}")]
        public IEnumerable<Human> GetHumanSearch(string text)
        {
            return HumanRepository.SearchName(text);
        }

        /// <summary>
        /// 1.3.2 Реализовать метод POST добавляющий нового человека.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] Human human)
        {
            HumanRepository.Add(human);
        }

        /// <summary>
        /// 1.3.3.	Реализовать метод DELETE удаляющий человека.
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("DelHuman/{id}")]
        public void Delete(int id )
        {
            HumanRepository.Delete(id);
        }

    }
}
