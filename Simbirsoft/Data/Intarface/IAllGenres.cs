using Simbirsoft.Models;
using System.Collections.Generic;

namespace Simbirsoft.Data.Intarface
{
    public interface IAllGenres
    {
        IEnumerable<Genre> Genres { get; }

        Genre Get(int id);

        void Add(Genre genre);

        void Delete(int id);

        void Set(Genre genre);
    }
}
