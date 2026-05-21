using System;
using System.Collections.Generic;

class StackExample
{
    static void Main()
    {
        Stack<string> browserHistory = new Stack<string>();

        browserHistory.Push("google.com");
        browserHistory.Push("youtube.com");
        browserHistory.Push("github.com");

        Console.WriteLine($"Current Page: {browserHistory.Peek()}");

        browserHistory.Pop();

        Console.WriteLine($"After Back Button: {browserHistory.Peek()}");
    }
}