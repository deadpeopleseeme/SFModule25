using ConsoleApp.Models;

namespace ConsoleApp.Repositories
{
    public class AuthorRepository
    {
        //не вижу смысла сейчас имплементить все методы, чтоб не затягивать с заданием

        private readonly AppContext _context;
        public AuthorRepository(AppContext context) 
        {
            _context = context;
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public Author GetAuthorByName(string authorName)
        {
            return _context.Authors.FirstOrDefault(a => a.Name == authorName);
        }
    }
}
