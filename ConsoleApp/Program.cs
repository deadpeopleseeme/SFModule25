using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                // Пересоздаём базу
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // Создаём репозитории
                UserRepository usrRepository = new(db);
                BookRepository bokRepository = new(db);
                AuthorRepository authorRepository = new(db);

                // Создаём объект, отвечающий за библиотечные операции
                LibraryService libraryService = new(db, usrRepository, bokRepository, authorRepository);

                // создаём объекты авторов, книг и пользователей
                var author1 = new Author { Name = " Лев Толстой" };
                var author2 = new Author { Name = "Егор Летов" };
                var author3 = new Author { Name = "Толстый Лев" };

                var book1 = new Book { Title = "Война и мир", Year = 777, Author = author1, Genre = "классика"};
                var book2 = new Book { Title = "Мир или война", Year = 666, Author = author2, Genre = "неклассика"};
                var book3 = new Book { Title = "Офигенная книга", Year = 555, Author = author2, Genre = "скучища"};
                var book4 = new Book { Title = "Такая себе книга", Year = 444, Author = author3, Genre = "неклассика"};

                var usr1 = new User { Name = "Валян", Email = "tst@gmail.com"};
                var usr2 = new User { Name = "Нечитайка", Email = "nobooks@gmail.com"};

                // добавляем объекты авторов, книг и пользователей в репозитории

                db.Authors.AddRange(author1, author2, author3);

                db.Books.AddRange(book1, book2, book3, book4);

                db.Users.AddRange(usr1, usr2);

                // сохраняем изменения
                db.SaveChanges();
            }
        }
    }
}
