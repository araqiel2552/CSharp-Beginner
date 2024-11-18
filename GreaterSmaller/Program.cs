// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Get user input
Console.WriteLine("Enter the first value:");
int value1 = int.Parse(Console.ReadLine());

Console.WriteLine("Enter the second value:");
int value2 = int.Parse(Console.ReadLine());

// Determine greater and smaller values
int greaterValue = value1 > value2 ? 
                                    value1 
                                    : 
                                    value2;

if(value1 > value2)
{
    greaterValue = value1;
}
else
{
    greaterValue = value2;
}

int smallerValue = value1 < value2 ? value1 : value2;
if(value1 < value2)
{
    smallerValue = value1;
}
else
{
    smallerValue = value2;
}


Console.WriteLine($"Greater value: {greaterValue}");
Console.WriteLine($"Smaller value: {smallerValue}");