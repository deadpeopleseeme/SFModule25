namespace LibraryProjectTests
{
    public class LibraryFinalTaskTestsPartFour: BaseLibraryTestTemplate
    {
        /// <summary>
        /// тестим: получение количества книг определенного определенного жанра в библиотеке.
        /// </summary>

        [Test]
        public void AssertThatLibraryHasExactBookOfExactAuthor()
        {
            var author = _authorRepository.GetAuthorByName("Тестовый автор с 1 книгой");
            var book = _bookRepository.GetBookByTitle("Книга с годом и без жанра");
            Assert.That(_libraryService.IsBookByExactAuthorWithExactTitleInLibrary(book, author), Is.True);
        }

        [Test]
        public void AssertThatLibraryDoesNotHaveExactBookOfExactAuthorBecauseAuthorMissing()
        {
            var author = _authorRepository.GetAuthorByName("Неправильный автор");
            var book = _bookRepository.GetBookByTitle("Книга с годом и без жанра");
            Assert.That(_libraryService.IsBookByExactAuthorWithExactTitleInLibrary(book, author), Is.False);
        }

        [Test]
        public void AssertThatLibraryDoesNotHaveExactBookOfExactAuthorBecauseBookMissing()
        {
            var author = _authorRepository.GetAuthorByName("Тестовый автор с 1 книгой");
            var book = _bookRepository.GetBookByTitle("Неправильное название книги");
            Assert.That(_libraryService.IsBookByExactAuthorWithExactTitleInLibrary(book, author), Is.False);
        }

        [Test]
        public void AssertThatLibraryDoesNotHaveExactBookOfExactAuthorBecauseBookWrittenByOtherAuthor()
        {
            var author = _authorRepository.GetAuthorByName("Тестовый автор с 1 книгой");
            var book = _bookRepository.GetBookByTitle("Книга с годом и жанром лавстори1");
            Assert.That(_libraryService.IsBookByExactAuthorWithExactTitleInLibrary(book, author), Is.False);
        }



    }
}
