﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Models
{
    public class Book
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public int AuthorID { get; set; }

        public virtual ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();

        public ICollection<Person> Persons { get; set; } = new HashSet<Person>();

        public ICollection<LibraryCard> LibraryCards { get; set; } = new HashSet<LibraryCard>();

        public DateTime DataWrite { get; set; }

        public DateTime DataCreate { get; set; }

        public DateTime DateChange { get; set; }

        public int Version { get; set; }

    }
}
