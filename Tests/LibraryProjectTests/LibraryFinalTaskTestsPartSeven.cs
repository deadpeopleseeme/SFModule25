namespace LibraryProjectTests
{
    public class LibraryFinalTaskTestsPartSeven: BaseLibraryTestTemplate
    {
        /// <summary>
        /// тестим: получение последней вышедшей книги
        /// </summary>
        /// 

        [Test]
        public void AssertThatLatestBookInProperLibraryIsNotNull()
        {
            Assert.That(_bookRepository.GetLatestBook(), Is.Not.Null);
        }

        [Test]
        public void AssertThatLatestBookInEmptyLibraryIsNotNull()
        {
            _appContext.Database.EnsureDeleted();
            Assert.That(_bookRepository.GetLatestBook(), Is.Null);
        }

        [Test]
        public void AssertThatLatestBookIsEqualToExpectedResult()
        {
            var expected = _bookRepository.GetBookByTitle("Книга с годом и жанром хоррор2");
            var recieved = _bookRepository.GetLatestBook();
            Assert.That(expected, Is.EqualTo(recieved));
        }

        [Test]
        public void AssertThatLatestBookIsNotEqualToUnexpectedResult()
        {
            var expected = _bookRepository.GetBookByTitle("Книга с годом и без жанра");
            var recieved = _bookRepository.GetLatestBook();
            Assert.That(expected, Is.Not.EqualTo(recieved));
        }
    }
}
