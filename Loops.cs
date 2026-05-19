using System;
class Loops
{
    static void Main()
    {

        // for loop
        for (int i = 0; i < 5; i++)
        {

            Console.WriteLine("For Loop: " + i);
        }



        // while loop
        int j = 0;
        while (j < 5)
        {
            Console.WriteLine("While Loop: " + j);
            j++;
        }


        // do-while loop
        int k = 0;
        do
        {
            Console.WriteLine("Do-While Loop: " + k);
            k++;
        } while (k < 5);



        // foreach loop
        int[] numbers = { 1, 2, 3, 4, 5 };
        foreach (int number in numbers)
        {
            Console.WriteLine("Foreach Loop: " + number);
        }

        // nested loops 
        for (int m = 1; m <= 3; m++)
        {
            for (int n = 1; n <= 3; n++)
            {
                Console.WriteLine("Nested Loop: " + m + ", " + n);
            }
        }








    }
}