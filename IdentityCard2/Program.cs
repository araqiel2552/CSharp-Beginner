using System;

// See https://aka.ms/new-console-template for more information
Console.Write("Enter your first name: ");
string firstName = Console.ReadLine();
firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();

Console.Write("Enter your last name: ");
string lastName = Console.ReadLine();
lastName = lastName.ToUpper();

Console.WriteLine($"Hello, {firstName} {lastName}!");
