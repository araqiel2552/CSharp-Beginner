using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            // Display menu
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Find Greater Value");
            Console.WriteLine("2. Find Smaller Value");
            Console.WriteLine("3. Exit");
            
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CompareGreaterThan(value1, value2);
                        break;
                    case 2:
                        CompareSmallerThan(value1, value2);
                        break;
                    case 3:
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number.");
            }
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