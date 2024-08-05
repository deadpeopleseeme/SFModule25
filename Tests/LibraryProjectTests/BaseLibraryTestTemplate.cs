using ConsoleApp.Repositories;
using ConsoleApp;
using Microsoft.EntityFrameworkCore;
using ConsoleApp.Models;


namespace LibraryProjectTests
{
    public class BaseLibraryTestTemplate
    {

        protected ConsoleApp.AppContext _appContext;
        protected UserRepository _userRepository;
        protected BookRepository _bookRepository;
        protected AuthorRepository _authorRepository;
        protected LibraryService _libraryService;

        public ConsoleApp.AppContext CreateInMemoryDatabase()
        {   // создаём базу данных в памяти
            var options = new DbContextOptionsBuilder<ConsoleApp.AppContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _appContext = new ConsoleApp.AppContext(options);
            return _appContext;

        }
        public void SeedDatabase()
        {
            // Создание и добавление тестовых данных
            var auth1 = new Author { Name = "Тестовый автор с 1 книгой" };
            var auth2 = new Author { Name = "Тестовый автор с 3 книгами" };
            var auth3 = new Author { Name = "Тестовый автор без книг" };
            _appContext.Authors.AddRange(auth1, auth2, auth3);

            var book1 = new Book { Title = "Книга с годом и без жанра", Author = auth1, Year = 555, Genre = "безжанра" };
            var book2 = new Book { Title = "Книга с годом и жанром хоррор1", Author = auth2, Year = 555, Genre = "хоррор" };
            var book3 = new Book { Title = "Книга с годом и жанром хоррор2", Author = auth2, Year = 666, Genre = "хоррор" };
            var book4 = new Book { Title = "Книга с годом и жанром лавстори1", Author = auth2, Year = 777, Genre = "лавстори" };

            _appContext.Books.AddRange(book1, book2, book3, book4);

            var user = new User { Name = "Юзер1", Email = "user1@gmail.com" };
            _appContext.Users.Add(user);

            _appContext.SaveChanges();
        }

        [SetUp]
        public void Setup()
        {
            _appContext = CreateInMemoryDatabase();
            _userRepository = new UserRepository(_appContext);
            _authorRepository = new AuthorRepository(_appContext);
            _bookRepository = new BookRepository(_appContext);
            _libraryService = new LibraryService(_appContext, _userRepository, _bookRepository, _authorRepository);
            SeedDatabase();
        }

        [TearDown]
        public void TearDown()
        {
            _appContext.Database.EnsureDeleted();
        }
    }
}
