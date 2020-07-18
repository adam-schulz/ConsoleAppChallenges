using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Classes
{
       public class MenuItem
    {
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemIngredients { get; set; }
        public decimal ItemPrice { get; set; }


        
        public MenuItem() { }

        public MenuItem(int itemNumber, string itemName, string itemDescription, string itemIngredients, decimal itemPrice)
        {
            ItemNumber = itemNumber;
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemIngredients = itemIngredients;
            ItemPrice = itemPrice;
        }
    }
}
