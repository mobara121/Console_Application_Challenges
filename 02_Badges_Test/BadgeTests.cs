using System;
using _02_Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Badges_Test
{
    [TestClass]
    public class BadgeTests
    {
        [TestMethod]
        public void SetNumber_ShouldGetCorrectInteger()
        {
            //Arrange
            Badge badge = new Badge();

            //Act
            badge.BadgeId = 12345;

            int expected = 12345;
            int actual = badge.BadgeId;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
