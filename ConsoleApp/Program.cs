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
                UserRepository usrRepository = new(db);
                BookRepository bokRepository = new(db);

                LibraryService libraryService = new(db, usrRepository, bokRepository);

                var author1 = new Author { Name = "Толстой" };
                var book1 = new Book { Title = "Война и мир", Year = 777, Author = author1};
                author1.BooksAuthorWrote.Add(book1);
                db.SaveChanges();

                Console.WriteLine($"Книгу {book1.Title} написал {book1.Author.Name}");

                Console.WriteLine($"{author1.Name} написал следующие книги: ");
                foreach (var b in author1.BooksAuthorWrote)
                {
                    Console.WriteLine(b.Title);
                }
            }
        }
    }
}
