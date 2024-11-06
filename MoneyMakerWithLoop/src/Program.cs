// See https://aka.ms/new-console-template for more information

const double goldCoinsValue = 10;
const double silverCoinsValue = 5;
double amount = 0;

Console.WriteLine("Welcome to Money Maker!");

do
{
    if (amount <= 0)
        Console.WriteLine("Enter an amount to convert to coins:");

} while (!Double.TryParse(Console.ReadLine(), out amount));

double goldCoins = Math.Floor(amount / goldCoinsValue);
double remainderAfterGold = amount % goldCoinsValue;
double silverCoins = Math.Floor(remainderAfterGold / silverCoinsValue);
double remainder = amount % silverCoinsValue;

Console.WriteLine("" + amount + " cents is equal to ...");
Console.WriteLine("Gold Coins: " + goldCoins + "");
Console.WriteLine("silver Coins: " + silverCoins + "");
Console.WriteLine("Bronze Coins: " + remainder + "");