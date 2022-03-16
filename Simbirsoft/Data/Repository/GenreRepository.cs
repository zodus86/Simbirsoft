using Simbirsoft.Data.Intarface;
using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Data.Repository
{
    public class GenreRepository : IAllGenres
    {
        private readonly DataContext dataContext;

        public GenreRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
           
            //if (dataContext.Genres.Count() == 0)
            //    InitBD();
        }

    public void InitBD()
    {
        
        dataContext.Genres.AddRange(new Genre
        {
            DataCreate = DateTime.Now,
            Name = "Комедия"
        }, new Genre 
        {
            DataCreate = DateTime.Now,
            Name = "Боевик"
        }, new Genre 
        {
            DataCreate = DateTime.Now,
            Name = "Фэнтази"
        });
        dataContext.SaveChangesAsync();
                    
    }

    public IEnumerable<Genre> Genres => dataContext.Genres;

        public void Add(Genre genre)
        {
            dataContext.Genres.Add(genre);
            dataContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var itme = dataContext.Genres.Where(x => x.Id == id);
            dataContext.Genres.RemoveRange(itme);
            dataContext.SaveChangesAsync();
        }

        public Genre Get(int id) => dataContext.Genres.FirstOrDefault(x => x.Id == id);

        public void Set(Genre genre)
        {
            dataContext.Genres.Update(genre);
            dataContext.SaveChangesAsync();
        }
    }
}
