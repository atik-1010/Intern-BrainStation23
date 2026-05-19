using System;
class ExceptionHandling
{
    static void Main()
    {

        // try-catch block
        try
        {
            int a = 10;
            int b = 0;
            int result = a / b; // This will throw a DivideByZeroException
            Console.WriteLine("Result: " + result);

        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Cannot divide by zero. " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("This block will always execute.");
        }


        // throw statement
        void ValidateAge(int age)
        {
            if (age < 18)
            {
                throw new ArgumentException("Age must be 18 or older.");
            }
            Console.WriteLine("Age is valid.");

        }
        try
        {
            ValidateAge(16); // This will throw an exception
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Validation error: " + ex.Message);
        }








    }
}