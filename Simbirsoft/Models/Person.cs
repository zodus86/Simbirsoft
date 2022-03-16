using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Models
{
    /// <summary>
    /// 1.2.1 - класс Человек
    /// </summary>
    public class Person
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FirstName  { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set;  }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();

        public ICollection<LibraryCard> LibraryCards { get; set; } = new HashSet<LibraryCard>();

        /// <summary>
        /// доп задание 2
        /// </summary>
        public DateTime DataCreate { get; set; }

        public DateTime DateChange { get; set; }

        public int Version { get; set; }

    }
}
