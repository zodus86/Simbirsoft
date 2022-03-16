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
    [Route("person/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IAllPersons _allPersons;

        public PersonController(IAllPersons allPersons)
        {
            _allPersons = allPersons;
        }

        [HttpGet]
        [Route("GetPersons")]
        public IEnumerable<Person> GetPersons()
        {
            return _allPersons.Persons;
        }

        [HttpPost]
        [Route("CreatePerson")]
        public void CreatePerson([FromBody] Person value)
        {
            _allPersons.Add(value);
        }

        [HttpPost]
        [Route("TakeBook")]
        public void TakeBook(int PersonId, int BookId)
        {
            _allPersons.TakeBook(PersonId, BookId);
        }

    }
}
