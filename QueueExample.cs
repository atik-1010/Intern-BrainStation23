using System;
using System.Collections.Generic;

class QueueExample
{
    static void Main()
    {
        Queue<string> customers = new Queue<string>();

        customers.Enqueue("Hasan");
        customers.Enqueue("Nayeem");
        customers.Enqueue("Rafi");

        Console.WriteLine("Serving Customers:");

        while (customers.Count > 0)
        {
            string currentCustomer = customers.Dequeue();

            Console.WriteLine($"Serving: {currentCustomer}");
        }
    }
}