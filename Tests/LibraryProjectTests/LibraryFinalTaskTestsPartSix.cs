using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectTests
{
    public class LibraryFinalTaskTestsPartSix: BaseLibraryTestTemplate
    {
        /// <summary>
        /// тестим: получение количества книг на руках у пользователя.
        /// </summary>
        /// 

        [Test]
        public void AssertThatUserHaveTwoBooks()
        {
            var usr = _userRepository.GetUserByEmail("user1@gmail.com");
            Assert.That(_libraryService.GetQuantityOfBooksUserHas(usr), Is.EqualTo(2));
        }

        [Test]
        public void AssertThatUserHaveNoBooks()
        {
            var usr = _userRepository.GetUserByEmail("user2@gmail.com");
            Assert.That(_libraryService.GetQuantityOfBooksUserHas(usr), Is.EqualTo(0));
        }

        [Test]
        public void AssertThatWrongEmailInGetQuantityOfBooksUserHasMethodGivesUsMinusOne()
        {
            var usr = _userRepository.GetUserByEmail("неправильный емейл");
            Assert.That(_libraryService.GetQuantityOfBooksUserHas(usr), Is.EqualTo(-1));
        }
    }
}
