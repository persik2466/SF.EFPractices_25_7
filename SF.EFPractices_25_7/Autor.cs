using System;
using System.Collections.Generic;
using System.Text;

namespace SF.EFPractices_25_7
{
    /// <summary>
    /// Писатели
    /// </summary>
    public class Autor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Навигационное свойство
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
