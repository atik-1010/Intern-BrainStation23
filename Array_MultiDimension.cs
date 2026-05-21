using System;

class Array_MultiDimension
{
    static void Main()
    {
        int[,] marks =
        {
            { 85, 90, 78 },
            { 88, 76, 95 },
            { 92, 81, 87 }
        };

        int totalRows = marks.GetLength(0);
        int totalColumns = marks.GetLength(1);

        Console.WriteLine("Student Marks Table:\n");

        for (int row = 0; row < totalRows; row++)
        {
            for (int column = 0; column < totalColumns; column++)
            {
                Console.Write(marks[row, column] + "\t");
            }

            Console.WriteLine();
        }
    }
}