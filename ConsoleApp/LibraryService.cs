using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp
{
    public class LibraryService
    {
        private readonly AppContext _context;

        private readonly UserRepository _userRepository;

        private readonly BookRepository _bookRepository;

        private readonly AuthorRepository _authorRepository;

        public LibraryService(AppContext context, UserRepository userRepository, BookRepository bookRepository, AuthorRepository authorRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        // Метод для выдачи книги на руки юзеру по его email и названию книги
        public void GiveBookToUser(string usrEmail, string title)
        {
            // проверяем, есть ли такая книга в библиотеке
            var bk = _bookRepository.GetBookByTitle(title);
            if (bk == null)
            {
                Console.WriteLine($"книга {title} не найдена!");
            }
            // проверяем, есть ли такой пользователь
            var usr = _userRepository.GetUserByEmail(usrEmail);
            if (usr == null)
            {
                Console.WriteLine($"Пользователь с email {usrEmail} не найден!");

            }
            if (bk != null && usr != null)
            {
                bk.User = usr;
                Console.WriteLine($"Выдали книгу {bk.Title} пользователю {usr.Name}");
            }
        }

        // метод для получения кол-ва книг определенного автора, итоговое задание 25, пункт 2
        public int GetQuantityOfBooksWrittenByExactAuthor(string authorName)
        {
            var author = _authorRepository.GetAuthorByName(authorName);
            int booksCount = 0;
            // если автор найден, считаем книги
            if (author != null)
            {
                booksCount = _bookRepository.GetBooksListByAuthor(author).Count();
            }
            return booksCount;
        }

        // метод для получения кол-ва книг определенного жанра, итоговое задание 25, пункт 3
        public int GetQuantityOfExactGenreBooksInLibrary(string genre)
        {
            var booksOfGenreList = _bookRepository.GetBooksListByGenre(genre);
            var result = booksOfGenreList.Count();
            Console.WriteLine($"Книг жанра {genre} в библиотеке: {result}");
            return result;
        }

        // метод для проверки есть ли определенная книга определенного автора, итоговое задание 25, пункт 4
        public bool IsBookByExactAuthorWithExactTitleInLibrary(Book book, Author author)
        {
            if (book != null && author != null && (book.Author == author))
            {
                Console.WriteLine($"Книга {book.Title} автора {author.Name} есть в библиотеке!");
                return true;
            }
            else
            {
                Console.WriteLine("Такого сочетания книга+автор в библиотеке нет");
                return false;
            }
        }

        // метод для получения кол-ва книг у пользователя, итоговое задание, пункт 5
        public bool DoesExactUserHaveExactBook(User user, Book book)
        {
            if(book == null || user == null)
            {
                Console.WriteLine("нет такой книги или пользователя, проверьте данные!");
                return false;
            }
            var result = user.Books.Contains(book);
            string textToShow = result ? "Да, такая книга у пользователя есть" : "Нет, такой книги у пользователя нет";
            Console.WriteLine(textToShow);
            return result;
        }

        // метод для получения кол-ва книг у пользователя, итоговое задание 25, пункт 6
        public int GetQuantityOfBooksUserHas(User user)
        {
            int bookQuantity;
            if (user == null)
            {
                Console.WriteLine($"В библиотеке нет такого пользователя!");
                bookQuantity = -1;
            }
            else
            {
                bookQuantity = user.Books.Count;
                Console.WriteLine($"Количество книг на руках у {user.Name} ({user.Email}): {bookQuantity}");
            }
            return bookQuantity;
        }
    }
}
