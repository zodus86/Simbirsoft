using Simbirsoft.Data.Intarface;
using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Simbirsoft.Data
{

    public class PersonRepository : IAllPersons
    {
        private readonly DataContext dataContext;

        public PersonRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

        //    if (dataContext.Persons.Count() == 0)
        //        InitBD();
        }

        public void InitBD()
        {
           
                Random random = new Random();

                for (int i=0; i<10; i++)
                {
                    dataContext.Persons.Add(new Person {
                    FirstName = $"Имя{i}",
                    LastName = $"Фамилия{i}",
                    MiddleName = $"Отчество{i}",
                    Birthday = new DateTime(1990, 1, 1).AddDays(random.Next(1, 100)),
                    DataCreate = DateTime.Now
                    });
                    dataContext.SaveChangesAsync();
                
                }
        }

        public IEnumerable<Person> Persons => dataContext.Persons;

        public void Add(Person person)
        {
            dataContext.Persons.Add(person);
            dataContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var itme = dataContext.Persons.Where(x => x.Id == id);
            dataContext.Persons.RemoveRange(itme);
            dataContext.SaveChangesAsync();
        }

        public Person Get(int id) => dataContext.Persons.FirstOrDefault(x => x.Id == id);

        public void Set(Person person)
        {
            dataContext.Persons.Update(person);
            dataContext.SaveChangesAsync();
        }

        public void TakeBook(int PersonId, int BookId)
        {
            //Person person = dataContext.Persons.FirstOrDefault(x => x.Id == PersonId);
            Book book = dataContext.Books.FirstOrDefault(x => x.Id == BookId);

            //person.Books.Add(book);
            //person.LibraryCards.Add(new LibraryCard { Book = book , DateTake = DateTime.Now});

            dataContext.Persons.FirstOrDefault(x => x.Id == PersonId).LibraryCards.Add(new LibraryCard 
            { 
                Book = book,
                BookId = BookId,
                PersonId = PersonId,
                Person = dataContext.Persons.FirstOrDefault(x => x.Id == PersonId),
                DateTake = DateTime.Now
            });
            
            dataContext.SaveChangesAsync();

        }


    }

    #region hw1
    //{
    //    public static List<Human> humans;

    //    static HumanRepository()
    //    {
    //        humans = new List<Human>()
    //        {
    //            new Human(){Id = 0, Name = "Ivan", Surname = "Ivanov" , Patronymic = "Ivanovich", Birthday = DateTime.Now},
    //            new Human(){Id = 1, Name = "Petr", Surname = "Petrov" , Patronymic = "Petrovich", Birthday = DateTime.Now},
    //            new Human(){Id = 2, Name = "Stepa", Surname = "Stepkin" , Patronymic = "Stepanovich", Birthday = DateTime.Now}
    //        };
    //    }

    //    public static void Add(Human human)
    //    {
    //        humans.Add(human);
    //    }


    //    public static IEnumerable<Human> GetAuthor() => humans.Where(x => (BookRepository.books.Select(x => x.AuthorId).ToList().Distinct()).Contains(x.Id));

    //    public static IEnumerable<Human> SearchName(string text) =>  humans.Where( x => (x.Name + x.Surname + x.Patronymic).Contains(text));


    //    public static IEnumerable<Human> GetHumans() => humans;
    //    public static void Delete(int id)
    //    {
    //        humans.Remove (humans.FirstOrDefault(x => x.Id == id));
    //    }
    #endregion
}
