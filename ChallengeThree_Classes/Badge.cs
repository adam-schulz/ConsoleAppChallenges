using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Classes
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> AccessDoor { get; set; }

        public Badge() { }

        public Badge(int badgeID, List<string> accessDoor)
        {
            BadgeID = badgeID;
            AccessDoor = accessDoor;
        }
    }
}
