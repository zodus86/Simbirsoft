using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Simbirsoft.Data
{
    /// <summary>
    /// 1.2.3 статические списки вместо базы
    /// </summary>
    public class HumanRepository
    {
        public static List<Human> humans;

        static HumanRepository()
        {
            humans = new List<Human>()
            {
                new Human(){Id = 0, Name = "Ivan", Surname = "Ivanov" , Patronymic = "Ivanovich", Birthday = DateTime.Now},
                new Human(){Id = 1, Name = "Petr", Surname = "Petrov" , Patronymic = "Petrovich", Birthday = DateTime.Now},
                new Human(){Id = 2, Name = "Stepa", Surname = "Stepkin" , Patronymic = "Stepanovich", Birthday = DateTime.Now}
            };
        }

        public static void Add(Human human)
        {
            humans.Add(human);
        }


        public static IEnumerable<Human> GetAuthor() => humans.Where(x => (BookRepository.books.Select(x => x.AuthorId).ToList().Distinct()).Contains(x.Id));

        public static IEnumerable<Human> SearchName(string text) =>  humans.Where( x => (x.Name + x.Surname + x.Patronymic).Contains(text));


        public static IEnumerable<Human> GetHumans() => humans;
        public static void Delete(int id)
        {
            humans.Remove (humans.FirstOrDefault(x => x.Id == id));
        }

    }
}
