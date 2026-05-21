using System;
using System.Collections.Generic;

class HashTableExample
{
    static void Main()
    {
        HashSet<string> usernames = new HashSet<string>();

        usernames.Add("sakib");
        usernames.Add("rahim");
        usernames.Add("karim");
        usernames.Add("sakib"); // Duplicate value

        Console.WriteLine("Registered Usernames:");

        foreach (string username in usernames)
        {
            Console.WriteLine(username);
        }

        Console.WriteLine($"\nTotal unique users: {usernames.Count}");
    }
}