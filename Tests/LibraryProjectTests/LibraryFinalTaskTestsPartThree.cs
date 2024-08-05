using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectTests
{

    public class LibraryFinalTaskTestsPartThree: BaseLibraryTestTemplate
    {
        /// <summary>
        /// тестим: получение количества книг определенного определенного жанра в библиотеке.
        /// </summary>

        [Test]
        public void AssertThatLibraryHas2HorrorBooks()
        {
            Assert.That(_libraryService.HowManyBooksOfGenreHasLibrary("хоррор") == 2);
        }

    }
}
