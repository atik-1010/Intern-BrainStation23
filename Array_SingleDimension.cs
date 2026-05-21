using System;

class Array_SingleDimension
{
    static void Main()
    {
        int[] marks = { 85, 90, 78, 92, 88 };

        Console.WriteLine("Student Marks:\n");

        for (int i = 0; i < marks.Length; i++)
        {
            Console.WriteLine($"Student {i + 1}: {marks[i]}");
        }

        Console.WriteLine($"\nTotal Students: {marks.Length}");
    }
}