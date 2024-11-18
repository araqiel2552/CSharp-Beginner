using System;

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

