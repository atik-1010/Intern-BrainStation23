using System;

// Abstract class
abstract class Vehicle
{
    // Abstract method
    public abstract void Start();

    // Normal method
    public void Stop()
    {
        Console.WriteLine("Vehicle Stopped");
    }
}

// Derived class
class Car : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Car Started");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car c = new Car();

        c.Start();
        c.Stop();
    }
}