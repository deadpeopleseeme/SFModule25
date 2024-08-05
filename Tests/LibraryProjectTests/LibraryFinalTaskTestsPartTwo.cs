namespace LibraryProjectTests
{    
    public class LibraryFinalTaskTestsPartTwo: BaseLibraryTestTemplate
    {
        /// <summary>
        /// тестим: получение количества книг определенного автора в библиотеке.
        /// </summary>
        /// 
        
        [Test]
        public void AssertThatAuthorHasOneBook()
        {
            Assert.That(_libraryService.GetQuantityOfBooksWrittenByExactAuthor("Тестовый автор с 1 книгой"), Is.EqualTo(1));
        }

        [Test]
        public void AssertThatAuthorHasThreeBooks()
        {
            Assert.That(_libraryService.GetQuantityOfBooksWrittenByExactAuthor("Тестовый автор с 3 книгами"), Is.EqualTo(3));
        }

        [Test]
        public void AssertThatAuthorHasNoBooks()
        {
            Assert.That(_libraryService.GetQuantityOfBooksWrittenByExactAuthor("Тестовый автор без книг"), Is.EqualTo(0));
        }
    }
}
