using System;

class Program
{
    static void Main()
    {
        // Get user input
        Console.WriteLine("Enter the first value:");
        int value1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second value:");
        int value2 = int.Parse(Console.ReadLine());

        // Display menu
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Find Greater Value");
        Console.WriteLine("2. Find Smaller Value");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                CompareGreaterThan(value1, value2);
                break;
            case 2:
                CompareSmallerThan(value1, value2);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

    static void CompareGreaterThan(int a, int b)
    {
        Console.WriteLine($"Greater value: {GetGreater(a, b)}");
    }

    static void CompareSmallerThan(int a, int b)
    {
        Console.WriteLine($"Smaller value: {GetSmaller(a, b)}");
    }

    static int GetGreater(int a, int b)
    {
        return a > b ? a : b;
    }

    static int GetSmaller(int a, int b)
    {
        return a < b ? a : b;
    }
}