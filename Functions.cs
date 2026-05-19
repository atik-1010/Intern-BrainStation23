using System;
class Functions
{
    static void Main()
    {
        // Function without parameters
        void Fun()
        {
            Console.WriteLine("Hello, World!");
        }
        Fun(); // Calling the function    

        // Function with parameters
        void FunPerson(string name)
        {
            Console.WriteLine("Hello, " + name + "!");
        }
        FunPerson("Atik"); // Calling the function with an argument


        // Function with return value
        int Add(int a, int b)
        {
            return a + b; // Returning the sum of a and b       
        }
        int result = Add(5, 3); // Calling the function with arguments and storing the return value
        Console.WriteLine("The sum is: " + result);


        // Function with optional parameters
        void FunWithOptional(string name = "SoFunny")
        {
            Console.WriteLine("Hello, " + name + "!");
        }
        FunWithOptional(); // Calls the function with the default parameter
        FunWithOptional("Bappy"); // Calls the function with a custom parameter

        // Function with params keyword
        void PrintNumbers(params int[] numbers)
        {
            Console.WriteLine("Numbers: " + string.Join(", ", numbers));
        }
        PrintNumbers(1, 2, 3); // Calling the function with multiple arguments
        PrintNumbers(4, 5); // Calling the function with different number of arguments


        // Recursive function
        int Factorial(int n)
        {
            if (n == 0)
            {
                return 1; // Base case: factorial of 0 is 1 
            }
            return n * Factorial(n - 1); // Recursive case: n! = n * (n-1)!
        }
        int factorialResult = Factorial(5); // Calling the recursive function
        Console.WriteLine("Factorial of 5 is: " + factorialResult);






    }
}