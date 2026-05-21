using System;
using System.Collections.Generic;

class DictionaryExample
{
    static void Main()
    {
        Dictionary<int, string> students = new Dictionary<int, string>();

        students.Add(101, "Atik");
        students.Add(102, "Rahman");
        students.Add(103, "Bappy");

        Console.WriteLine("Student List:");

        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Key}, Name: {student.Value}");
        }

        int studentId = 102;

        if (students.ContainsKey(studentId))
        {
            Console.WriteLine($"\nStudent Found: {students[studentId]}");
        }
    }
}