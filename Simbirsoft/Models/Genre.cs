using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Models
{
    public class Genre
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();

        /// <summary>
        /// доп задание 2
        /// </summary>
        public DateTime DataCreate { get; set; }

        public DateTime DateChange { get; set; }

        public int Version { get; set; }
    }
}
