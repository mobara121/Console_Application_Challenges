using System;
using System.Collections.Generic;
using _02_Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Badges_Test
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private BadgeRepository _repo;
        private Badge _badge;

        public void Arrange()
        {
            _repo = new BadgeRepository();
            //_badge = new Badge(12345, "Romeo", 1);
        }

        [TestMethod]
        public void GetDictionary_ToReturnCorrectKeyValuePair()
        {
            //Arrange
            BadgeRepository repo = new BadgeRepository();
            Badge choco = new Badge();
            repo.AddBadgeDictionary(1, choco);

            //Act
            var test = repo.GetBadgeDictionary();
            bool testHasChoco = test.ContainsValue(choco);

            //Assert
            Assert.IsTrue(testHasChoco);
        }
    }
}
