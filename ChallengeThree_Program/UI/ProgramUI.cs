using ChallengeThree_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Program.UI
{
    public class ProgramUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedBadgeList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.WriteLine("Welcome to the Komodo Insurance security center. Please select an option from the list below to continue : \n" +
                    "\n" +
                    "1. Add a new badge \n" +
                    "2. Edit access for an existing badge \n" +
                    "3. See all registered badges \n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        //   EditBadgeAccess();
                        break;
                    case "3":
                        ShowAllBadges();
                        break;
                    case "4":
                        continueRunning = false;
                        Console.WriteLine("Have a nice day!");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option");
                        Console.ReadLine();
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddNewBadge()
        {
            Console.Clear();
            Console.WriteLine("Please follow the prompts below to register a new badge.");
            Console.WriteLine();

            Badge newBadge = new Badge();
            List<string> newBadgeAccess = new List<string>();
            Console.WriteLine("Please enter an ID number for this badge: ");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Please list the first door this badge will need access to: ");
            newBadgeAccess.Add(Console.ReadLine());
            Console.WriteLine();

            string additionalAccess = "y";
            while (additionalAccess != "n")
            {
                Console.WriteLine("Are there any additional doors that this badge will need access to? (Y/N) ");
                additionalAccess = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (additionalAccess == "y")
                {
                    Console.WriteLine("Please list an additional door this badge will need access to: ");
                    newBadgeAccess.Add(Console.ReadLine());
                    Console.WriteLine();
                }
                else if (additionalAccess == "n")
                {
                    Console.WriteLine("Thank you, this badge has been added to the database. Press any key to return to the main menu.");
                    break;
                }
                else
                {
                    Console.WriteLine("Unable to compute. Please input a valid option. (Y/N) ");
                    additionalAccess = Console.ReadLine().ToLower();
                }
            }
        }

        private void EditBadgeAccess()
        {

        }

        private void ShowAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> badgeDatabase = _badgeRepo.ShowAllBadges();

            foreach (KeyValuePair<int, List<string>> badge in badgeDatabase)
            {
                string accessList = "";
                foreach (string accessDoor in badge.Value)
                {
                    accessList = accessDoor + " " + accessList;
                }
                Console.WriteLine($"Badge #: {badge.Key}\n" +
                                  $"Door Access: {accessList}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to return to the main menu.");
        }

        private void SeedBadgeList()
        {
            List<string> badgeOneDoors = new List<string>();
            badgeOneDoors.Add("A7");
            Badge badgeOne = new Badge(12345, badgeOneDoors);
            _badgeRepo.CreateBadge(12345, badgeOneDoors);

            List<string> badgeTwoDoors = new List<string>();
            badgeTwoDoors.Add("A1");
            badgeTwoDoors.Add("A4");
            badgeTwoDoors.Add("B1");
            badgeTwoDoors.Add("B2");
            Badge badgeTwo = new Badge(22345, badgeTwoDoors);
            _badgeRepo.CreateBadge(22345, badgeTwoDoors);

            List<string> badgeThreeDoors = new List<string>();
            badgeThreeDoors.Add("A4");
            badgeThreeDoors.Add("A5");
            Badge badgeThree = new Badge(32345, badgeThreeDoors);
            _badgeRepo.CreateBadge(32345, badgeThreeDoors);



        }
    }
}
