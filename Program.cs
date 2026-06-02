using System;
using System.Collections;
using System.Collections.Generic;
namespace ListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            names.Add("Atik");
            names.Add("Rahman");
            names.Add("Bappy");

            Console.WriteLine("Names in the list:");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine($"Total names: {names.Count}");

            ArrayList mixedList = new ArrayList();
            mixedList.Add("Hello");
            mixedList.Add(42);
            mixedList.Add(3.14);
            Console.WriteLine("\nMixed List:");
            foreach (var item in mixedList)
            {
                Console.WriteLine(item);
            }

        }
    }
}