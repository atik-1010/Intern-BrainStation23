using System;
class BranchingStatements
{
    static void Main()
    {

        // if statement
        int number = 10;
        if (number > 5)
        {
            Console.WriteLine("Number is greater than 5");
        }


        // f-else statement
        if (number % 2 == 0)
        {
            Console.WriteLine("Number is even");
        }
        else
        {
            Console.WriteLine("Number is odd");
        }


        // if-Else-if statement
        if (number > 0)
        {
            Console.WriteLine("Number is positive");
        }
        else if (number < 0)
        {
            Console.WriteLine("Number is negative");
        }
        else
        {
            Console.WriteLine("Number is zero");
        }


        //nested if statement
        int age = 25;
        if (age >= 18)
        {
            if (age < 65)
            {
                Console.WriteLine("Atikur");
            }
            else
            {
                Console.WriteLine("Rahman");
            }
        }
        else
        {
            Console.WriteLine("Minor");

        }



        // switch statement
        int day = 3;
        switch (day)
        {
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            case 4:
                Console.WriteLine("Thursday");
                break;
            case 5:
                Console.WriteLine("Friday");
                break;
            case 6:
                Console.WriteLine("Saturday");
                break;
            case 7:
                Console.WriteLine("Sunday");
                break;
            default:
                Console.WriteLine("Invalid day");
                break;


        }






    }
}