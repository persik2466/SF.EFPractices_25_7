using System;
using System.Collections.Generic;
using System.Text;

namespace SF.EFPractices_25_7
{
    /// <summary>
    /// Класс пользователь 
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Навигационное свойство
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
