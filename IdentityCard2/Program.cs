using System;

// See https://aka.ms/new-console-template for more information
Console.Write("Enter your first name: ");
string firstName = Console.ReadLine();

var firstLetter = firstName[0];
var firstLetterUpper = char.ToUpper(firstLetter);

var lastLetters = firstName.Substring(1);
var lastLettersLower = lastLetters.ToLower();

firstName = firstLetterUpper + lastLettersLower;

Console.Write("Enter your last name: ");
string lastName = Console.ReadLine();
lastName = lastName.ToUpper();

Console.WriteLine($"Your name is {firstName} {lastName}!");

int minus = 5;
int max = 15;
var numberMax= Math.Max(minus, max);
System.Console.WriteLine(numberMax);