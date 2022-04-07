using System;
using System.Collections.Generic;
using System.Text;

namespace SF.EFPractices_25_7
{
    /// <summary>
    /// Жанры книг
    /// </summary>
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Навигационное свойство
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
