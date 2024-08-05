using ConsoleApp.Repositories;

namespace ConsoleApp
{
    internal class LibraryService
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

        // инфа о всех пользователях библиотеки
        public void ShowAllLibraryUsersInfo()
        {
            var users = _userRepository.GetAllUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}: {user.Name}");
                if (user.Books.Count == 0)
                {
                    Console.WriteLine("У этого пользователя на данный момент нет книг на руках");
                }
                else
                {
                    Console.WriteLine("На данный момент у этого пользователя следующие книги:");
                    foreach (var book in user.Books)
                    {
                        Console.WriteLine($"{book.Title}, год выхода{book.Year}");
                    }
                }
            }
        }

        // метод для получения кол-ва книг определенного автора, итоговое задание 25, пункт 2
        public int HowManyBooksOfAuthorHasLibrary(string authorName)
        {
            var author = _authorRepository.GetAuthorByName(authorName);
            int booksCount = 0;
            // если автор найден, считаем книги
            if (author != null)
            {
                booksCount = author.BooksAuthorWrote.Count;
            }
            if (author == null || booksCount == 0)
            {
                Console.WriteLine("У этого автора книг в библиотеке не найдено! ");
            }
            else
            {
                Console.WriteLine($"Книг в библиотеке, которые написал {author.Name}: {booksCount}");
            }
            return booksCount;
        }

        // метод для получения кол-ва книг определенного жанра, итоговое задание 25, пункт 3
        public int HowManyBooksOfGenreHasLibrary(string genre)
        {
            var booksOfGenreList = _bookRepository.GetBooksListByGenre(genre);
            var result = booksOfGenreList.Count();
            Console.WriteLine($"Количество книг жанра {genre} в библиотеке: {result}");
            return result;
        }

        // метод для получения кол-ва книг у пользователя, итоговое задание 25, пункт 6
        public void ShowHowManyBooksHasUser(string email)
        {
            var usr = _userRepository.GetUserByEmail(email);
            if (usr == null)
            {
                Console.WriteLine($"В библиотеке нет пользователя с email {email}!");
            }
            else
            {
                Console.WriteLine($"Количество книг на руках у {usr.Name} ({usr.Email}): {usr.Books.Count}");
            }
        }

    }
}
