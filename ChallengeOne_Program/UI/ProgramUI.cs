using ChallengeOne_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Program.UI
{
    public class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            SeedMenuList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.WriteLine("You are now viewing the Komodo Cafe menu editor console. Please select a menu option: \n" +
                    "1. Create new menu item \n" +
                    "2. Delete a menu item \n" +
                    "3. List all menu items \n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ShowAllMenuItems();
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

        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItem newMenuItem = new MenuItem();

            Console.WriteLine("Please enter a number that will correspond to this menu item:");
            newMenuItem.ItemNumber = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the name of the new menu item:");
            newMenuItem.ItemName = Console.ReadLine();

            Console.WriteLine("Please enter a description of the new menu item:");
            newMenuItem.ItemDescription = Console.ReadLine();

            Console.WriteLine("Please list the ingredients that make up this new menu item, separating each ingredient by a comma -- \n" +
                              "For example: Chicken, Rice, Beans, Lettuce, Tomato, Cheese");
            newMenuItem.ItemIngredients = Console.ReadLine();

            Console.WriteLine("Please enter the price of the new menu item (example: 7.99): ");
            string priceString = Console.ReadLine();
            newMenuItem.ItemPrice = decimal.Parse(priceString);

            _menuRepo.AddMenuItem(newMenuItem);

            Console.WriteLine("Thank you, your newly created menu item has been added to the menu. Please press any key to continue.");
            Console.ReadKey();
        }

        private void DeleteMenuItem()
        {
            Console.WriteLine("Please enter the Item Number of the meal you would like to remove from the menu: ");
            List<MenuItem> listOfMenuItems = _menuRepo.ListMenuItems();

            int item = 0;

            foreach (MenuItem menuItem in listOfMenuItems)
            {
                item++;
                Console.WriteLine($"{item}. {menuItem.ItemName}");
            }

            int targetMenuID = int.Parse(Console.ReadLine());
            int targetMenuNum = targetMenuID - 1;

            if (targetMenuNum >= 0 && targetMenuNum < listOfMenuItems.Count)
            {
                MenuItem desiredMenuItem = listOfMenuItems[targetMenuNum];
                if (_menuRepo.RemoveMenuItem(desiredMenuItem))
                {
                    Console.WriteLine($"Thank you, {desiredMenuItem.ItemName} was successfully removed from the menu.");
                }
                else
                {
                    Console.WriteLine("Could not compute. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("There is not a menu item with that corresponding menu number.");
            }
            Console.WriteLine("Please press any key to continue.");
            Console.ReadKey();


        }

        private void ShowAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> listOfMenuItems = _menuRepo.ListMenuItems();

            foreach (MenuItem menuItem in listOfMenuItems)
            {
                Console.WriteLine($"Item Number: {menuItem.ItemNumber}\n" +
                    $"Item Name: {menuItem.ItemName}\n:" +
                    $"Item Description: {menuItem.ItemDescription}\n" +
                    $"Item Ingredients: {menuItem.ItemIngredients}\n" +
                    $"Item Price: ${menuItem.ItemPrice} \n");
            }
            Console.WriteLine("Please press any key to continue.");
            Console.ReadKey();
        }

        private void SeedMenuList()
        {
            MenuItem cashewChicken = new MenuItem(1, "Cashew Chicken", "White meat chicken with vegetables, tossed in spicy cashew sauce.", "Chicken, Red Bell Peppers, Onion, Snap Peas, Cashews, Rice", 8.99m);
            MenuItem beefBroccoli = new MenuItem(2, "Beef & Broccoli", "Wok-seared steak, garlic, ginger, and broccoli tossed in sweet soy sauce.", "Steak, Garlic, Ginger, Broccoli, Rice", 7.99m);
            MenuItem kungPaoShrimp = new MenuItem(3, "Kung Pao Shrimp", "Crisy shrimp, garlic, carrots, and snap peas tossed in chili soy sauce.", "Shrimp, Garlic, Carrots, Snap Peas, Rice", 9.99m);
            MenuItem sweetSourChicken = new MenuItem(4, "Sweet & Sour Chicken", "White meat chicken with vegetables and pineapple tossed in a classic sweet and sour sauce.", "Chicken, Ginger, Red Bell Peppers, Onion, Pineapple, Rice", 8.99m);
            MenuItem teriyakiTofu = new MenuItem(5, "Teriyaki Tofu", "Wok-seared tofu with vegetables tossed in a sweet soy glaze.", "Tofu, Red Bell Peppers, Onion, Cabbage, Scallions, Rice", 10.99m);

            _menuRepo.AddMenuItem(cashewChicken);
            _menuRepo.AddMenuItem(beefBroccoli);
            _menuRepo.AddMenuItem(kungPaoShrimp);
            _menuRepo.AddMenuItem(sweetSourChicken);
            _menuRepo.AddMenuItem(teriyakiTofu);
        }
    }
}
