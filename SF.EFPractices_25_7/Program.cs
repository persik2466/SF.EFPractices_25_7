using System;
using System.Linq;

namespace SF.EFPractices_25_7
{
    class Program
    {
        static void Main(string[] args)
        {
             //Создание библиотеки с пользователями и книгами
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "Arthur", Email = "arthur@gmail.com" };
                var user2 = new User { Name = "Klim", Email = "klim@gmail.com" };
                var user3 = new User { Name = "Lisa", Email = "liza@gmail.com" };

                db.Users.Add(user1);
                db.Users.AddRange(user2, user3);

                var book1 = new Book { Name = "Маугли", Year = 1960 };
                var book2 = new Book { Name = "Незнайка на луне", Year = 2005 };
                var book3 = new Book { Name = "Простоквашино", Year = 2022 };

                db.Books.AddRange(book1, book2, book3);
                //Сохранение в БД
                db.SaveChanges();

                //удаленние пользователя
                db.Users.Remove(user2);
                db.SaveChanges();

                // Выбор первого пользователя в таблице
                var firstUser = db.Users.FirstOrDefault();
                Console.WriteLine(firstUser.Name);

                // Изменить у первого пользователя поле Email
                firstUser.Email = "arthur_big@gmail.com";
                db.SaveChanges();

                // Выбор пользователя по ID
                User user = db.Users.FirstOrDefault(p => p.Id == 3);
                if (user != null)
                    Console.WriteLine(user.Name);
                //обновление имени пользователя
                user.Name = "arthur_big";

                // Выбор книги по ID
                Book book = db.Books.FirstOrDefault(p => p.Id == 2);
                //Обновление года выпуска
                book.Year = 1996;

                // Выбор всех пользователей
                var allUsers = db.Users.ToList();
                foreach (User us in allUsers)
                    Console.WriteLine($"{us.Name} - {us.Email}");

                // Выбор всех книг
                var allBooks = db.Books.ToList();
                foreach (Book bk in allBooks)
                    Console.WriteLine($"{bk.Name} - {bk.Year}");
            }

            //добавить в книгу автора
            //Отношение один Autor ко многим Book
            using (var db = new AppContext())
            {
                var autor1 = new Autor { Name = "Киплинг" };
                var autor2 = new Autor { Name = "Носов" };
                var autor3 = new Autor { Name = "Успенский" };
                db.Autors.Add(autor3);
                db.SaveChanges();

                var book1 = new Book { Name = "Маугли", Year = 1960 };
                var book2 = new Book { Name = "Незнайка на луне", Year = 2005 };
                var book3 = new Book { Name = "Простоквашино", Year = 2022 };

                book1.Autor = autor1;
                autor2.Books.Add(book2);
                book3.AutorId = autor3.Id;

                db.Autors.AddRange(autor1, autor2);
                db.Books.AddRange(book1, book2, book3);

                db.SaveChanges();
            }

            //Выдача книги на руки пользователю
            //Отношение один User ко многим Book
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "Petr", Email = "petr@gmail.com" };
                var user2 = new User { Name = "Gleb", Email = "gleb@gmail.com" };
                var user3 = new User { Name = "Masha", Email = "masha@gmail.com" };
                var user4 = new User { Name = "Dina", Email = "Dina@gmail.com" };
                // Добавляем user2 и сохраняем, чтобы получить Id
                db.Users.Add(user2);
                db.SaveChanges();

                var book1 = new Book { Name = "Маугли", Year = 1960 };
                var book2 = new Book { Name = "Незнайка на луне", Year = 2005 };
                var book3 = new Book { Name = "Простоквашино", Year = 2022 };

                user2.Books.Add(book1);

                db.Users.AddRange(user1, user3, user4);
                db.Books.AddRange(book1, book2, book3);

                //Сохранение в БД
                db.SaveChanges();
            }

            //добавить к книге Book жанр книги
            //Отношение многие ко многим Genre
            using (var db = new AppContext())
            {
                var genre1 = new Genre { Name = "Сказка" };
                var genre2 = new Genre { Name = "Приключения" };
                var genre3 = new Genre { Name = "Рассказ" };

                var book1 = new Book { Name = "Маугли", Year = 1960 };
                var book2 = new Book { Name = "Чудесный доктор", Year = 2005 };
                var book3 = new Book { Name = "Денискины рассказы", Year = 1984 };
                var book4 = new Book { Name = "Зелёная лампа", Year = 2001 };
                var book5 = new Book { Name = "Приключения Незнайки", Year = 1996 };

                genre1.Books.AddRange(new[] { book1, book5 });
                genre2.Books.AddRange(new[] { book3, book5 });
                book2.Genres.AddRange(new[] { genre3 });
                book4.Genres.AddRange(new[] { genre3 });

                db.Genres.AddRange(genre1, genre2, genre3);
                db.Books.AddRange(book1, book2, book3, book4, book5);

                //Сохранение в БД
                db.SaveChanges();
            }

        }
    }
}
