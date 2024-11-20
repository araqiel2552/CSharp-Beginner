using System;

bool exit = false;
do
{
    // Get user input
    Console.WriteLine("Enter the first value:");
    int value1 = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the second value:");
    int value2 = int.Parse(Console.ReadLine());

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

            Console.WriteLine("Do you want to continue? (Y/N)");
            exit = Console.ReadLine().ToUpper() == "Y";
        }
        else
        {
            Console.WriteLine("Invalid input, please enter a number.");
        }
    }
} while (!exit);

void CompareGreaterThan(int a, int b) => Compare(a, b, true);

void CompareSmallerThan(int a, int b)
{
    Compare(a, b, false);
}

int GetGreater(int a, int b) => a > b ? a : b;

int GetSmaller(int a, int b)
{
    return a < b ? a : b;
}

void Compare(int a, int b, bool isGreater)
{
    var greater = GetGreater(a, b);
    var smaller = GetSmaller(a, b);

    if (isGreater)
    {
        Console.WriteLine($"'{greater}' is greater than '{smaller}'");
    }
    else
    {
        Console.WriteLine($"'{smaller}' is smaller than '{greater}'");
    }
}