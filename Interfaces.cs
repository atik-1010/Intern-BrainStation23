using System;

interface IWork
{
    void DoWork();
}

interface IStudy
{
    void Study();
}

interface ISleep
{
    void Sleep();
}

class Student : IWork, IStudy, ISleep
{
    public void DoWork()
    {
        Console.WriteLine("Rahim is doing part-time work");
    }

    public void Study()
    {
        Console.WriteLine("Rahim is studying C# OOP");
    }

    public void Sleep()
    {
        Console.WriteLine("Rahim is sleeping at night");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student rahim = new Student();

        rahim.DoWork();
        rahim.Study();
        rahim.Sleep();
    }
}