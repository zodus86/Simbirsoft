using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Data.Intarface
{
    public interface IAllBooks
    {
        IEnumerable<Book> Books { get; }

        Book Get(int id);

        void Add(Book book);

        void Delete(int id);

        void Set(Book book);

        void ChangeGenre(int BookId, int GenreId);
    }
}
