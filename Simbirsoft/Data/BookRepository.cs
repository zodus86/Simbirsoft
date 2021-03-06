using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Data
{
    /// <summary>
    /// 1.2.3 статические списки вместо базы  
    /// </summary>
    public class BookRepository
    {
        public static List<Book> books;

        static BookRepository()
        {
            books = new List<Book>()
            {
                new Book(){Id= 0, Title = "Book1", AuthorId = 0, Genre = "Genre1"},
                new Book(){Id= 1, Title = "Book2", AuthorId = 1, Genre = "Genre2"},
                new Book(){Id= 2, Title = "Book3", AuthorId = 0, Genre = "Genre1"},
            };
        }

        public static void Add(Book book)
        {
            books.Add(book);
        }

        public static IEnumerable<Book> GetBooks() => books;

        public static IEnumerable<Book> GetBooksAutherId(int id) => books.Where(x => x.AuthorId == id);

        /// <summary>
        /// сортировка по полю параметру
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IEnumerable<Book> GetSortTitleGenreAuther(string param)
        {
            param = param.ToLower();
            if (param == "title") return books.OrderBy(x => x.Title);
            if (param == "genre") return books.OrderBy(x => x.Genre);
            if (param == "auther")
            {
                return books.Join(HumanRepository.humans, book => book.AuthorId, hum => hum.Id, (book, hum) => new
                {
                    Name = hum.Name,
                    Id = book.Id,
                    Title = book.Title,
                    Genre = book.Genre,
                    AuthorId = book.AuthorId
                }).OrderBy(x => x.Name).Select(x => new Book
                {
                    Id = x.Id,
                    Title = x.Title,
                    AuthorId = x.AuthorId,
                    Genre = x.Genre
                });
            }
            return books;
        }

        public static void Delete(int id) 
        {
            books.Remove(books.FirstOrDefault(x=>x.Id == id));
        }
        
    }
}
