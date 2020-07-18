using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Classes
{
    public class MenuRepository
    {
        public List<MenuItem> _listOfMenuItems = new List<MenuItem>();

        public void AddMenuItem(MenuItem menuItem)
        {
            _listOfMenuItems.Add(menuItem);
        }

        public bool RemoveMenuItem(MenuItem menuItem)
        {
            bool deletedMenuItem = _listOfMenuItems.Remove(menuItem);
            return deletedMenuItem;
        }

        public List<MenuItem> ListMenuItems()
        {
            return _listOfMenuItems;
        }


    }
}
