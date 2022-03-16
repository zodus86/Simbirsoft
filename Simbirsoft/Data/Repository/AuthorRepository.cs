using Simbirsoft.Data.Intarface;
using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Data.Repository
{
    public class AuthorRepository : IAllAuthors
    {
        private readonly DataContext dataContext;

        public AuthorRepository (DataContext dataContext)
        {
            this.dataContext = dataContext;
            
            //if (dataContext.Authors.Count() == 0)
            //    InitBD();
        }

        public void InitBD()
        {
                Random random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    dataContext.Authors.Add(new Author
                    {
                        FirstName = $"FirstName{i}",
                        LastName = $"LastName{i}",
                        MiddleName = $"MiddleName{i}",
                        DataCreate = DateTime.Now
                        
                    });
                    dataContext.SaveChangesAsync();
                }
       
        }

        public IEnumerable<Author> Authors => dataContext.Authors;

        public void Add(Author author)
        {
            dataContext.Authors.Add(author);
            dataContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var itme = dataContext.Authors.Where(x => x.Id == id);
            dataContext.Authors.RemoveRange(itme);
            dataContext.SaveChangesAsync();
        }

        public Author Get(int id) =>   dataContext.Authors.FirstOrDefault(x => x.Id == id);
        
        public void Set(Author author)
        {
            dataContext.Authors.Update(author);
            dataContext.SaveChangesAsync();
        }

    }
}
