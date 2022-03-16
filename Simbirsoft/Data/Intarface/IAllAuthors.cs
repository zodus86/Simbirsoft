using Simbirsoft.Models;
using System.Collections.Generic;

namespace Simbirsoft.Data.Intarface
{
    public interface IAllAuthors
    {
        IEnumerable<Author> Authors { get; }

        Author Get(int id);

        void Add(Author author);

        void Delete(int id);

        void Set(Author author);
    }
}
