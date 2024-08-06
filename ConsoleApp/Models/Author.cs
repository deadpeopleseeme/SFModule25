namespace ConsoleApp.Models
namespace ConsoleApp.Models
{
    public class Author
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public List<Book> BooksAuthorWrote { get; set; }

        public Author() 
        { 
            BooksAuthorWrote = new List<Book>();
        }

    }
}