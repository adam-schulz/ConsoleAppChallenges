using System;
using System.Collections.Generic;
using ChallengeThree_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThree_Tests
{
    [TestClass]
    public class BadgeTests
    {
        Badge _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new Badge();
        }

        [TestMethod]
        public void AddNewBadgeTest()
        {
            List<string> badgeAccess = new List<string>();

            badgeAccess.Add("A1");

            int expected = 1;
            int actual = badgeAccess.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
