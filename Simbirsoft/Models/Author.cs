using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        /// <summary>
        /// доп задание 2
        /// </summary>
        public DateTime DataCreate { get; set; }

        public DateTime DateChange { get; set; }

        public int Version { get; set; }
    }

}

