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

        // Метод для получения книги по названию
        public Book GetBookByTitle(string title)
        {
            return _context.Books.FirstOrDefault(b => b.Title == title);
        }

        // Метод для получения книги по Id
        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        // Метод для обновления года книги по id
        public void UpdateBookYearById(int id, int newYear)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                book.Year = newYear;
            }
        }

        // Метод для удаления книги по id
        public void DeleteBookById(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        // метод для удаления книги по названию
        public void DeleteBookByTitle(string title)
        {
            var book = _context.Books.FirstOrDefault(b => b.Title == title);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }
        
        // возвращает все книги определенного жанра
        public IEnumerable<Book> GetBooksListByGenre(string genre)
        {
            return [.. _context.Books.Where(b => b.Genre == genre)];
        }

        public IEnumerable<Book> GetBooksListByAuthor(Author author)
        {
            return [.. _context.Books.Where(b => b.Author == author)];
        }
        // метод для получения книг определенного жанра в определенных годах, итоговое задание 25, пункт 1
        public IEnumerable<Book> GetBooksByGenreAndYearRange(string genre, int startYear, int endYear)
        {
            return [.. _context.Books.Where(b => b.Genre == genre && b.Year >= startYear && b.Year <= endYear)];
        }
        // метод для получения последней вышедшей книги, итоговое задание 25, пункт 7
        public Book GetLatestBook()
        {
            return _context.Books.OrderByDescending(b => b.Year).FirstOrDefault();
        }
        // метод для получения списка книг с сортировкой по алфавиту, итоговое задание 25, пункт 8
        public IEnumerable<Book> GetAllBooksSortedByTitle()
        {
            return [.. _context.Books.OrderBy(b => b.Title)];
        }

        // метод для получения списка книг с сортировкой по алфавиту, итоговое задание 25, пункт 9
        public IEnumerable<Book> GetAllBooksSortedByYearDescending()
        {
            return [.. _context.Books.OrderByDescending(b => b.Year)];
        }
    }
}

