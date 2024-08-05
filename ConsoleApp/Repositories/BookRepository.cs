using ConsoleApp.Models;
using System.Linq;

namespace ConsoleApp.Repositories
{
    public class BookRepository
    {
        private readonly AppContext _context;

        public BookRepository(AppContext context)
        {
            _context = context;
        }

        // Метод для получения всех книг
        public IEnumerable<Book> GetAllBooks()
        {
            return [.. _context.Books];
        }

        // Метод для получения пользователя по названию
        // Можно использовать нахождение по Id, но это не очень логично, т.к. мы скорее знаем название книги, чем ID в базе
        public Book GetBookByTitle(string title)
        {
            return _context.Books.FirstOrDefault(b => b.Title == title);
        }

        // Метод для добавления новой книги
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        // Метод для обновления года книги по id
        public void UpdateBookYearById(int id, int newYear)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                book.Year = newYear;
            }
            _context.SaveChanges();
        }

        // Метод для удаления книги по id
        public void DeleteBookById(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }


        // Метод для удаления книги по названию
        public void DeleteBookByTitle(string title)
        {
            var book = _context.Books.FirstOrDefault(b => b.Title == title);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Book> GetBooksListByGenre(string genre)
        {
            return [.. _context.Books.Where(b => b.Genre == genre)];
        }

        // Метод для получения списка книг определенного жанра
        public IEnumerable<Book> GetBooksListByAuthor(string genre)
        {
            return [.. _context.Books.Where(b => b.Genre == genre)];
        }

        // Метод для получения списка книг определенного автора

    }
}

