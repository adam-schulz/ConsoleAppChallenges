using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Classes
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDatabase = new Dictionary<int, List<string>>();

        public void CreateBadge(int badgeID, List<string> accessDoor)
        {
            _badgeDatabase.Add(badgeID, accessDoor);
        }

        public void AddDoorAccess(int badgeID, string accessDoor)
        {
            _badgeDatabase[badgeID].Add(accessDoor);
        }

        public void RemoveDoorAcess(int badgeID, string acessDoor)
        {
            _badgeDatabase[badgeID].Remove(acessDoor);
        }

        public Dictionary<int, List<string>> ShowAllBadges()
        {
            return _badgeDatabase;
        }

    }
}
