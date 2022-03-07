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
    public class Human
    {
        
        public int Id { get; set; }
        
        [Required]
        public string Name  { get; set; }
        
        [Required]
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime Birthday { get; set;  }
    }
}
