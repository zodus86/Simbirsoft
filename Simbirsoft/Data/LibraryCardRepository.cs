using Simbirsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Data
{
    /// <summary>
    /// 2.1.3 список для карт библиотеки
    /// </summary>
    public class LibraryCardRepository
    {
        public static List<LibraryCard> libraryCards;
        static LibraryCardRepository()
        {
            libraryCards = new List<LibraryCard>();
        }

        public static void Add(LibraryCard libraryCard)
        {
            libraryCards.Add(libraryCard);
        }

        public static IEnumerable<LibraryCard> GetCards() => libraryCards;
    }
}
