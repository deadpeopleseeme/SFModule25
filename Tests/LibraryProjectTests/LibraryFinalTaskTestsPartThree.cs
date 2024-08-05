namespace LibraryProjectTests
{
    public class LibraryFinalTaskTestsPartThree: BaseLibraryTestTemplate
    {
        /// <summary>
        /// тестим: получение количества книг определенного определенного жанра в библиотеке.
        /// </summary>

        [Test]
        public void AssertThatLibraryHasTwoHorrorBooks()
        {
            Assert.That(_libraryService.GetQuantityOfExactGenreBooksInLibrary("хоррор"), Is.EqualTo(2));
        }

        [Test]
        public void AssertThatLibraryHasOneLoveStoryBook()
        {
            Assert.That(_libraryService.GetQuantityOfExactGenreBooksInLibrary("лавстори"), Is.EqualTo(1));
        }

        [Test]
        public void AssertThatLibraryHasNoComedyBooks()
        {
            Assert.That(_libraryService.GetQuantityOfExactGenreBooksInLibrary("комедия"), Is.EqualTo(0));
        }
    }
}
