namespace LibraryProjectTests
{
    public class LibraryFinalTaskTestsPartFive : BaseLibraryTestTemplate
    {
        /// <summary>
        /// тестим: получение количества книг определенного определенного жанра в библиотеке.
        /// </summary>
        [Test]
        public void AssertThatExactUserHasExactBook()
        {
            var user = _userRepository.GetUserByEmail("user1@gmail.com");
            var book = _bookRepository.GetBookById(2);
            Assert.That(_libraryService.DoesExactUserHaveExactBook(user, book), Is.True);
        }

        [Test]
        public void AssertThatExactUserHasNoBookBecauseBookNotFound()
        {
            var user = _userRepository.GetUserByEmail("user1@gmail.com");
            var book = _bookRepository.GetBookById(55);
            Assert.That(_libraryService.DoesExactUserHaveExactBook(user, book), Is.Not.True);
        }

        [Test]
        public void AssertThatExactUserHasNoBookBecauseUserNotFound()
        {
            var user = _userRepository.GetUserByEmail("неправильный емейл");
            var book = _bookRepository.GetBookById(2);
            Assert.That(_libraryService.DoesExactUserHaveExactBook(user, book), Is.Not.True);
        }

        [Test]
        public void AssertThatBothUserAndBookFoundButExactUserDoesNotHaveExactBook()
        {
            var user = _userRepository.GetUserByEmail("user1@gmail.com");
            var book = _bookRepository.GetBookById(4);
            Assert.That(_libraryService.DoesExactUserHaveExactBook(user, book), Is.Not.True);
        }
    }
}
