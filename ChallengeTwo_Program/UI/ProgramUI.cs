using ChallengeTwo_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Program.UI
{
    public class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            SeedClaimList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.WriteLine("Welcome to the Komodo Department Claims center. Please select an option from the list below to continue : \n" +
                    "\n" +
                    "1. See all available claims \n" +
                    "2. Process next available claim \n" +
                    "3. Add new claim \n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        ProcessNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
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

        private void SeeAllClaims()
        {
            Queue<Claim> _claims = _claimRepo.SeeAllClaims();

            Console.Clear();

            Console.WriteLine("The list of available claims ready for processing are listed below:");
            Console.WriteLine();

            Console.WriteLine(String.Format("{0, -10} {1, -10} {2, -20} {3, 10:C} {4, 15} {5, 15} {6, 8}", "ClaimID", "Claim Type", "Description", "Claim Amount", "Date of Incident", "Date of Claim", "Valid?"));
            foreach (Claim claim in _claims)

            {
                Console.WriteLine(String.Format("{0, -10} {1, -10} {2, -20} {3, 10:C} {4, 15} {5, 15} {6, 8}", claim.ClaimID, claim.ClaimType, claim.Description, claim.ClaimAmount, claim.DateOfIncident.ToShortDateString(), claim.DateOfClaim.ToShortDateString(), claim.IsValid));
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu.");
        }

        private void ProcessNextClaim()
        {
            Console.Clear();
            Console.WriteLine("The next available claim waiting to be processed is: ");
            Console.WriteLine();

            Claim nextClaim = _claimRepo.SeeNextClaim();

            Console.WriteLine(String.Format("{0, -10} {1, -10} {2, -20} {3, 10:C} {4, 15} {5, 15} {6, 8}", "ClaimID", "Claim Type", "Description", "Claim Amount", "Date of Incident", "Date of Claim", "Valid?"));

            Console.WriteLine(String.Format("{0, -10} {1, -10} {2, -20} {3, 10:C} {4, 15} {5, 15} {6, 8}", nextClaim.ClaimID, nextClaim.ClaimType, nextClaim.Description, nextClaim.ClaimAmount, nextClaim.DateOfIncident.ToShortDateString(), nextClaim.DateOfClaim.ToShortDateString(), nextClaim.IsValid));
            Console.WriteLine();

            Console.WriteLine("Do you wish to process this claim? (Y/N)");

            string process = Console.ReadLine().ToLower();

            if (process == "y")
            {
                _claimRepo.ProcessNextClaim();
                Console.WriteLine("Thank you, this claim has been processed. Press any key to return to the main menu.");
            }
            else
            {
                Console.Clear();
                RunMenu();
            }
        }

        private void AddNewClaim()
        {
            Console.Clear();
            Console.WriteLine("Please follow the prompts below to add a new claim to the queue.");
            Console.WriteLine();

            Claim newClaim = new Claim();
            Console.WriteLine("Please enter an ID number for this claim: ");
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Please enter the number corresponding to the applicable claim type: \n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft \n");
            string claimType = Console.ReadLine();
            int claimTypeNumber = int.Parse(claimType);
            newClaim.ClaimType = (ClaimType)claimTypeNumber;
            Console.WriteLine();

            Console.WriteLine("Please enter in a detailed description for this claim: ");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please enter the claim amount: ");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Please enter the date of the claim incident (YYYY/MM/DD): ");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Please enter the date this claim was processed (YYYY/MM/DD): ");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();

            int claimValidity = (newClaim.DateOfClaim - newClaim.DateOfIncident).Days;
            if (claimValidity <= 30)
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            Console.WriteLine("Thank you, this claim has been created. Press any key to return to the main menu");

            _claimRepo.AddNewClaim(newClaim);

        }

        private void SeedClaimList()
        {
            Claim claimOne = new Claim(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            Claim claimTwo = new Claim(2, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            Claim claimThree = new Claim(3, ClaimType.Theft, "Stolen pancakes", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);


            _claimRepo.AddNewClaim(claimOne);
            _claimRepo.AddNewClaim(claimTwo);
            _claimRepo.AddNewClaim(claimThree);
        }
    }
}
