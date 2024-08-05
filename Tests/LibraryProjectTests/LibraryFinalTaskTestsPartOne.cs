namespace LibraryProjectTests
{
    internal class LibraryFinalTaskTestsPartOne: BaseLibraryTestTemplate
    {
        /// <summary>
        /// тестим: получение списка книг определенного жанра между определенными годами
        /// </summary>
        /// 

        [Test]
        public void AssertThatLibraryHasOneHorrorBookBetween554And556Years()
        {
            var result = _bookRepository.GetBooksByGenreAndYearRange(genre: "хоррор", startYear: 554, endYear: 556);
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void AssertThatLibraryHasTwoHorrorBooksBetween1And1000Years()
        {
            var result = _bookRepository.GetBooksByGenreAndYearRange(genre: "хоррор", startYear: 1, endYear: 1000);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void AssertThatLibraryHasNoLovestoryBooksBetween778And780Years()
        {
            var result = _bookRepository.GetBooksByGenreAndYearRange(genre: "лавстори", startYear: 778, endYear: 780);
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}
