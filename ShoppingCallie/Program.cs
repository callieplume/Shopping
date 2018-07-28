using System;
using System.Collections.Generic;

namespace ShoppingCallie
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] prices = new int[3];
            //string[] items = { "Paint", "Paper", "Glitter" };
            // For loop for an array
            //for (int counter = 0; counter < items.Length; counter++)
            //{
            //    Console.WriteLine( counter+1 + ". " + items[counter]);
            //}

            // creating a list
            List<string> basket = new List<string>();

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


            Console.WriteLine("What would you like to buy?");

            // declaring a variable
            double basketTotal = 0.00;
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
                    continue;
                }
                else
                {
                    basket.Add(newItem);
                    basketTotal = basketTotal + itemLookup[newItem];

                    Console.WriteLine("Added to basket: " + newItem + ". Press '1' to checkout");
                    continue;     
                }

            }
            Console.WriteLine("Your basket contains: ");
            foreach (var basketItem in basket)
            {
                Console.WriteLine(basketItem + " = £" + string.Format("{0:0.00}", itemLookup[basketItem]));
            }
            Console.WriteLine("----------------- \nBasket total: £" + string.Format("{0:0.00}", basketTotal + "\nPress '1' to add a discount or '2' to continue" ));

            string userInput = Console.ReadLine();
            string discountCode = "";

            IDictionary<string, int > discountLookup = new Dictionary<string, int>();
            discountLookup["shitisbananas"] = 20;
            discountLookup["nodiscount4u"] = 0;
            discountLookup["halfpriceplz"] = 50;

            if (userInput == "1")
            {
                Console.WriteLine("Please enter your discount code:");
                discountCode = Console.ReadLine().ToLower();

                if (!discountLookup.ContainsKey(discountCode))
                {
                    Console.WriteLine("Invalid discount code. Please try again or press '2' to checkout");
                    
                }
                else
                {
                }
            }



            Console.ReadLine();
        }
    }
}
