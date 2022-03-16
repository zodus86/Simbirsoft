using Microsoft.EntityFrameworkCore;
using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Book>()
                .HasMany(c => c.Persons)
                .WithMany(s => s.Books)
                .UsingEntity<LibraryCard>(
                   j => j
                    .HasOne(pt => pt.Person)
                    .WithMany(t => t.LibraryCards)
                    .HasForeignKey(pt => pt.PersonId),
                j => j
                    .HasOne(pt => pt.Book)
                    .WithMany(p => p.LibraryCards)
                    .HasForeignKey(pt => pt.BookId),
                j =>
                {
                    j.Property(pt => pt.DateTake).HasDefaultValue(DateTime.Now);
                    j.HasKey(t => new { t.BookId, t.PersonId });
                    j.ToTable("LibraryCard");
                });
        }
    }

}

