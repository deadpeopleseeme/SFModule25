
using ConsoleApp.Repositories;

namespace ConsoleApp
{
    internal class LibraryService
    {
        private readonly AppContext _context;

        private readonly UserRepository _userRepository;

        private readonly BookRepository _bookRepository;

        public LibraryService(AppContext context, UserRepository userRepository, BookRepository bookRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
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
                usr.Books.Add(bk);
                Console.WriteLine($"Выдали книгу {bk.Title} пользователю {usr.Name}");
                _context.SaveChanges(); // не знаю, насколько вообще допустимо сохранение проводить непосредственно тут, но пусть будет
            }
        }

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

    }
}
