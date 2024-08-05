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
            Assert.That(_libraryService.HowManyBooksOfAuthorHasLibrary("Тестовый автор с 1 книгой") == 1);
        }

        [Test]
        public void AssertThatAuthorHasThreeBooks()
        {
            Assert.That(_libraryService.HowManyBooksOfAuthorHasLibrary("Тестовый автор с 3 книгами") == 3);
        }

        [Test]
        public void AssertThatAuthorHasNoBooks()
        {
            Assert.That(_libraryService.HowManyBooksOfAuthorHasLibrary("Тестовый автор без книг") == 0);
        }
        




}
}
