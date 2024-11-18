using System;

// See https://aka.ms/new-console-template for more information
Console.Write("Enter your first name: ");
string firstName = Console.ReadLine();

Console.Write("Enter your last name: ");
string lastName = Console.ReadLine();

Console.WriteLine("Your first name is " + firstName);
Console.WriteLine("Your last name is " + lastName);

string name = firstName + " " + lastName;
string name2 = $"Mon nom est {firstName} et {lastName}. Voila.";
string name3 = String.Format("Mon nom est {0} {1} dasd dasd {2}", firstName, lastName);

Console.WriteLine(firstName + lastName);
Console.WriteLine($"{firstName} {lastName}");

string name4 = firstName;
name4 += " ";
name4 += lastName;
System.Console.WriteLine(name4);

var sb = new System.Text.StringBuilder();
sb.Append(firstName);
sb.Append(" ");
sb.Append(lastName);
System.Console.WriteLine(sb.ToString());

string mySrt = "Hello World";
char s = mySrt[0];
var len = mySrt.Length;
var hIndex = mySrt.IndexOf("H");