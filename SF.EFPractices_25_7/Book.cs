using System;
using System.Collections.Generic;
using System.Text;

namespace SF.EFPractices_25_7
{
    /// <summary>
    /// Класс библиотеки
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        // Внешний ключ
        public int AutorId { get; set; }
        // Навигационное свойство
        public Autor Autor { get; set; }

        // Внешний ключ
        public int UserId { get; set; }
        // Навигационное свойство
        public User User { get; set; }

        // Навигационное свойство
        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
