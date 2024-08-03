namespace ConsoleApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }

        // список книг у пользователя на руках
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
