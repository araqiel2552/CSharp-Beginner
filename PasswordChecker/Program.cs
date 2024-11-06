using System;

int minLength = 8;
char[] lowers = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
char[] uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
char[] digits = "0123456789".ToCharArray();
char[] specials = "!\"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~".ToCharArray();

Console.Write("Enter Password: ");
string? password = Console.ReadLine();

int score = 0;
score += (password?.Length >= minLength) ? 1 : 0;
score += (password?.IndexOfAny(lowers, 0) > -1) ? 1 : 0;
score += (password?.IndexOfAny(uppers, 0) > -1) ? 1 : 0;
score += (password?.IndexOfAny(digits, 0) > -1) ? 1 : 0;
score += (password?.IndexOfAny(specials, 0) > -1) ? 1 : 0;

if (password == "password" || password == "1234")
{
    score = 0;
}

switch (score)
{
    case 5:
        Console.WriteLine("Extremely Strong Password!");
        break;
    case 4:
        Console.WriteLine("Extremely Strong Password!");
        break;
    case 3:
        Console.WriteLine("Strong Password!");
        break;
    case 2:
        Console.WriteLine("Medium Strength Password!");
        break;
    case 1:
        Console.WriteLine("Weak Password!");
        break;
    default:
        Console.WriteLine("Invalid Password!");
        break;
}