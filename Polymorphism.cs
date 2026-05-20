using System;


// Compile-time Polymorphism (Method Overloading)
class Calculator
{
    // same method name, different parameters
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

// Run-time Polymorphism (Method Overriding)
class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal makes sound");
    }
}

class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Dog Geuww");
    }
}

class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Cat meows ");
    }
}


// Main Program
class Program
{
    static void Main(string[] args)
    {
        //Compile-time Polymorphism 
        Calculator calc = new Calculator();

        Console.WriteLine("Compile-time Polymorphism:");
        Console.WriteLine(calc.Add(10, 20));
        Console.WriteLine(calc.Add(10, 20, 30));

        Console.WriteLine();

        // Run-time Polymorphism
        Console.WriteLine("Run-time Polymorphism:");

        Animal a;

        a = new Dog();
        a.Speak();   // Dog version

        a = new Cat();
        a.Speak();   // Cat version
    }
}