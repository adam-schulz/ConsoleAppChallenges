using System;
using System.Collections.Generic;
using ChallengeOne_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOne_Tests
{
    [TestClass]
    public class MenuTests
    {
        MenuRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
             _repo = new MenuRepository();
        }

        [TestMethod]
        public void AddMenuItemTest()
        {
            MenuRepository _menuRepo = new MenuRepository();
            MenuItem sweetSourChicken = new MenuItem();

            _menuRepo.AddMenuItem(sweetSourChicken);
            List<MenuItem> menuList = _menuRepo.ListMenuItems();

            int expected = 1;
            int actual = menuList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveMenuItemTest()
        {
            List<MenuItem> menuList = _repo.ListMenuItems();
            MenuItem newItem = new MenuItem();
            menuList.Add(newItem);

            bool result = _repo.RemoveMenuItem(newItem);

            Assert.IsTrue(result);
        }
    }
}
