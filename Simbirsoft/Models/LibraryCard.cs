using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Models
{
    /// <summary>
    /// 2.1 карта библиотеки
    /// </summary>
    public class LibraryCard
    {
        public int Id { get; set; }

        [Required]
        public int HumanId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTimeOffset Date { get; set; }
    }
}
