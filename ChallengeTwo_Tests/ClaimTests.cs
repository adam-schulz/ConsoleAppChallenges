using System;
using ChallengeTwo_Classes;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeTwo_Tests
{
    [TestClass]
    public class ClaimTests
    {
        ClaimRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
        }

        [TestMethod]
        public void AddClaimToQueueTest()
        {
            Claim claimExample1 = new Claim(5, ClaimType.Home, "Burglary", 5500.00m, new DateTime(2020, 05, 15), new DateTime(2020, 05, 27), true);
            Claim claimExample2 = new Claim(6, ClaimType.Car, "Stolen Bumper", 500.00m, new DateTime(2020, 05, 21), new DateTime(2020, 06, 25), false);

            _repo.AddNewClaim(claimExample1);
            _repo.AddNewClaim(claimExample2);

            int expected = 2;
            int actual = _repo.GetNumberOfClaims();

            Assert.AreEqual(expected, actual);
        }
    }
}
