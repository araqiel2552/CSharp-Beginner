// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to Money Maker! Enter an amount to convert to coins:");
double amount = Convert.ToDouble(Console.ReadLine());
double goldCoinsValue = 10;
double silverCoinsValue = 5;
double goldCoins = Math.Floor(amount / goldCoinsValue);
double remainderAfterGold = amount % goldCoinsValue;
double silverCoins = Math.Floor(remainderAfterGold / silverCoinsValue);
double remainder = amount % silverCoinsValue;
Console.WriteLine("" + amount + " cents is equal to ...");
Console.WriteLine("Gold Coins: " + goldCoins + "");
Console.WriteLine("silver Coins: " + silverCoins + "");
Console.WriteLine("Bronze Coins: " + remainder + "");