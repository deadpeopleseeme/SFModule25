using ConsoleApp.Models;
namespace LibraryProjectTests
{
    public class LibraryFinalTaskTestsPartEight: BaseLibraryTestTemplate
    {
        /// <summary>
        /// тестим: получение списка книг, сортировка по алфавиту
        /// </summary>
        /// 

        [Test]
        public void AssertThatBooksListsSortedByTitleManuallyAndByMethodAreEqual()
        {   
            //достаем книги из репозитория и в алфавитном порядке вручную вносим в список

            var b1 = _bookRepository.GetBookByTitle("Книга с годом и без жанра");
            var b2 = _bookRepository.GetBookByTitle("Книга с годом и жанром лавстори1");
            var b3 = _bookRepository.GetBookByTitle("Книга с годом и жанром хоррор1");
            var b4 = _bookRepository.GetBookByTitle("Книга с годом и жанром хоррор2");

            IEnumerable<Book> expectedSortedBooks = [b1, b2, b3, b4];
            var actualSortedTitles = _bookRepository.GetAllBooksSortedByTitle();

            Assert.That(expectedSortedBooks, Is.EqualTo(actualSortedTitles));
        }

    }
}
