using System;
using System.Collections.Generic;

class ListExample
{
    static void Main()
    {
        List<string> shoppingCart = new List<string>();

        shoppingCart.Add("Milk");
        shoppingCart.Add("Bread");
        shoppingCart.Add("Eggs");

        Console.WriteLine("Shopping Cart:");

        foreach (string item in shoppingCart)
        {
            Console.WriteLine(item);
        }

        shoppingCart.Remove("Bread");

        Console.WriteLine("\nAfter removing Bread:");

        foreach (string item in shoppingCart)
        {
            Console.WriteLine(item);
        }
    }
}