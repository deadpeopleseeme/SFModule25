namespace ConsoleApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        // вряд ли это свойство требует отдельного класса, легче при необходимости делать выборку по жанру
        public string Genre { get; set; } 

        // инфа о пользователе, на руках у которого сейчас находится книга
        // nullable для возможности удаления инфы о юзере, т.е. о возврате книги в библиотеку
        public User? User { get; set; }

        public Author Author { get; set; }


    }
}
