using System;

// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        Console.WriteLine($"Hello, {firstName} {lastName}!");
    }
}
