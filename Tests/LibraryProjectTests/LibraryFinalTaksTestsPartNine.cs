using ConsoleApp.Models;
using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LibraryProjectTests
{
    public class LibraryFinalTaksTestsPartNine : BaseLibraryTestTemplate
    {
        /// <summary>
        /// тестим: получение списка книг, сортировка по году в порядке убывания
        /// 

        [Test]
        public void AssertThatBooksListsSortedByYearDescendingManuallyAndByMethodAreEqual()
        {
            //достаем книги из репозитория и в порядке убывания по годам вручную вносим в список

            var b1 = _bookRepository.GetBookById(3);
            var b2 = _bookRepository.GetBookById(2);
            var b3 = _bookRepository.GetBookById(1);
            var b4 = _bookRepository.GetBookById(4);

            IEnumerable<Book> expectedSortedBooks = [b1, b2, b3, b4];
            var actualSortedTitles = _bookRepository.GetAllBooksSortedByYearDescending();

            Assert.That(expectedSortedBooks, Is.EqualTo(actualSortedTitles));
        }
    }
}
