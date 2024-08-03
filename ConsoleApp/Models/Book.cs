namespace ConsoleApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        // инфа о пользователе, на руках у которого сейчас находится книга
        public User? User { get; set; }

        public Author Author { get; set; }
    }
}
