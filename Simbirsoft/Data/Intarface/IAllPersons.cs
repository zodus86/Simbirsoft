using Simbirsoft.Models;
using System.Collections.Generic;

namespace Simbirsoft.Data.Intarface
{
    public interface IAllPersons
    {
        IEnumerable<Person> Persons { get; }

        Person Get(int id);

        void Add(Person person);

        void Delete(int id);

        void Set(Person person);

        void TakeBook(int PersonId, int BookId);
    }
}
