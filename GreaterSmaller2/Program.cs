// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

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
        // Determine greater and smaller values
        int greaterValue = value1 > value2 ? value1 : value2;
        Console.WriteLine($"Greater value: {greaterValue}");
        break;
    case 2:
        int smallerValue = value1 < value2 ? value1 : value2;
        Console.WriteLine($"Smaller value: {smallerValue}");
        break;
    default:
        Console.WriteLine("Invalid choice");
        break;
}