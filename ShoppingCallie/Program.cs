using System;
using System.Collections.Generic;

namespace ShoppingCallie
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating a list
            List<string> basket = new List<string>();

            IDictionary<string, double> itemLookup = new Dictionary<string, double>();
            itemLookup = OpenStore();

            // declaring a variable
            double basketSubTotal = 0.00;
            basketSubTotal = AddToBasket(itemLookup, basket, basketSubTotal);

            ShowBasket(basket, basketSubTotal, itemLookup);

            string userInput = "";
            userInput = Console.ReadLine();
            if (userInput == "1")
            {
                HandleDiscounts(userInput, basketSubTotal);
            }

            Console.WriteLine("-----------------\n\nThank you for shopping with Callies Crafts\n\n-----------------");            
            Console.ReadLine();
        }

        /// <summary>
        /// Displays items in the store with prices. 
        /// </summary>
        /// <returns></returns>
        static IDictionary<string, double> OpenStore()
        {
            // creating a dictionary
            IDictionary<string, double> itemLookup = new Dictionary<string, double>();
            itemLookup["Paint"] = 3.99;
            itemLookup["Paper"] = 1.00;
            itemLookup["Glitter"] = 2.50;

            Console.WriteLine("Welcome to Callies Crafts \n----------------- \nToday you can buy:");
            int counter = 1;

            // for each item in the dictionary, show the item and its value
            foreach (KeyValuePair<string, double> item in itemLookup)
            {
                Console.WriteLine(counter + ". " + item.Key + " = £" + string.Format("{0:0.00}", item.Value));
                counter++;
            }

            Console.WriteLine("-----------------\nWhat would you like to buy?");
            return itemLookup;
        }

        /// <summary>
        /// Add items to the users basket
        /// </summary>
        /// <param name="itemLookup">List of items</param>
        /// <param name="basket">Stores user selected items</param>
        /// <param name="basketSubTotal">Total of current basket</param>
        /// <returns></returns>
        static double AddToBasket(IDictionary<string, double> itemLookup, List<string> basket, double basketSubTotal)
        {
            string newItem = "";

            while (newItem != "1")
            {
                newItem = Console.ReadLine().ToLower(); // converts string to lowercase
                newItem = newItem.Substring(0).ToUpper()[0] + newItem.Substring(1); // converts first letter to uppercase
                if (newItem == "1")
                {
                    break;
                }

                if (!itemLookup.ContainsKey(newItem))
                {
                    Console.WriteLine(newItem + " does not exist. Please try again or press '1' to checkout");
                }
                else
                {
                    basket.Add(newItem);
                    basketSubTotal = basketSubTotal + itemLookup[newItem];

                    Console.WriteLine("-----------------\nAdded to basket: " + newItem + ". Add another item or press '1' to checkout");
                }
            }
            return basketSubTotal;
        }

        /// <summary>
        /// Displays the users basket items 
        /// </summary>
        /// <param name="basket">Stores user selected items</param>
        /// <param name="basketSubTotal">Total of current basket</param>
        /// <param name="itemLookup">List of items</param>
        static void ShowBasket(List<string> basket, double basketSubTotal, IDictionary<string, double> itemLookup)
        {
            Console.WriteLine("-----------------\nYour basket contains: ");
            foreach (var basketItem in basket)
            {
                Console.WriteLine(basketItem + " = £" + string.Format("{0:0.00}", itemLookup[basketItem]));
            }
            Console.WriteLine("-----------------\nBasket subtotal: £" + string.Format("{0:0.00}", basketSubTotal) + "\n-----------------\nPress '1' to add a discount or '2' to continue");
        }

        /// <summary>
        /// Handles discount interaction
        /// </summary>
        /// <param name="userInput">Users input</param>
        /// <param name="basketSubTotal">Total of current basket</param>
        static void HandleDiscounts(string userInput, double basketSubTotal)
        {

            IDictionary<string, double> discountLookup = new Dictionary<string, double>();
            discountLookup["shitisbananas"] = 0.2;
            discountLookup["nodiscount4u"] = 0;
            discountLookup["halfpriceplz"] = 0.5;

            string discountCode = "";
            double discountTotal = 0.00;
            double basketTotal = 0.00;
            while (userInput != "2")
            {
                Console.WriteLine("Please enter your discount code:");
                discountCode = Console.ReadLine().ToLower();

                if (!discountLookup.ContainsKey(discountCode))
                {
                    Console.WriteLine("Invalid discount code. Press '1' to try again or press '2' to checkout");
                    string option = Console.ReadLine();
                    if (option == "2")
                    {
                        break;
                    }
                }
                else
                {
                    discountTotal = (basketSubTotal * discountLookup[discountCode]);
                    basketTotal = (basketSubTotal - discountTotal);
                    Console.WriteLine(
                        "-----------------\nDiscount code '" + discountCode + "' succesfully applied for a discount of " + (discountLookup[discountCode] * 100) +
                        "%\n-----------------\nBasket subtotal: £" + string.Format("{0:0.00}", basketSubTotal) +
                        "\nDiscount applied: -£" + string.Format("{0:0.00}", discountTotal) +
                        "\nBasket total: £" + string.Format("{0:0.00}", basketTotal)
                    );
                    break;
                }
            }
        }

    }
}
