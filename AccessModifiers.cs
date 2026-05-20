using System;

class cSharpOOP
{
    class Person
    {
        // Public -> accessible everywhere
        public string Name = "Rahim";

        // Private -> only inside this class
        private int Age = 22;

        // Protected -> accessible in this class + child class
        protected string University = "DUET";

        // Internal -> accessible inside same project
        internal string Department = "CSE";

        // Protected Internal
        protected internal string City = "Dhaka";

        public void ShowInfo()
        {
            Console.WriteLine("Inside Person Class:");
            Console.WriteLine(Name);
            Console.WriteLine(Age);
            Console.WriteLine(University);
            Console.WriteLine(Department);
            Console.WriteLine(City);
        }
    }

    // Child class
    class Student : Person
    {
        public void ShowStudentInfo()
        {
            Console.WriteLine("\nInside Student Class:");

            // Public
            Console.WriteLine(Name);

            // Private -> not accessible
            // Console.WriteLine(Age);

            // Protected
            Console.WriteLine(University);

            // Internal
            Console.WriteLine(Department);

            // Protected Internal
            Console.WriteLine(City);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            Console.WriteLine("From Main Method:\n");

            // Public
            Console.WriteLine(p.Name);

            // Private -> not accessible
            // Console.WriteLine(p.Age);

            // Protected -> not accessible
            // Console.WriteLine(p.University);

            // Internal
            Console.WriteLine(p.Department);

            // Protected Internal
            Console.WriteLine(p.City);

            p.ShowInfo();

            Student s = new Student();
            s.ShowStudentInfo();
        }
    }
}
