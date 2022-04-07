using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SF.EFPractices_25_7
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books{ get; set; }

        public DbSet<Autor> Autors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = MASHA; Database = EF; Persist Security Info = False; Integrated Security = sspi; TrustServerCertificate = true; Encrypt = false;");
        }
    }
}
