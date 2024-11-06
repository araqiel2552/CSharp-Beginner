using System;

class Calculator
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Simple Calculator");
            Console.WriteLine("-----------------");

            double num1;
            while (true)
            {
                Console.Write("Enter first number: ");
                if (double.TryParse(Console.ReadLine(), out num1))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            char op;
            while (true)
            {
                Console.Write("Enter an operator (+, -, *, /): ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && "+-*/".Contains(input))
                {
                    op = input[0];
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid operator.");
                }
            }

            double num2;
            while (true)
            {
                Console.Write("Enter second number: ");
                if (double.TryParse(Console.ReadLine(), out num2))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            double result = 0;

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        continue;
                    }
                    break;
                default:
                    Console.WriteLine("Error: Invalid operator.");
                    continue;
            }

            Console.WriteLine($"Result: {num1} {op} {num2} = {result}");

            Console.Write("Do you want to perform another calculation? (y/n): ");
            char retry = Console.ReadLine()[0];
            if (retry != 'y' && retry != 'Y')
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }
}