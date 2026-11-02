Console.Write("Enter a Number here: ");
if (!int.TryParse(Console.ReadLine(), out int num))
{
    Console.WriteLine("Please enter a valid number.");
    return;
}
if (num % 2 == 0)
{
    Console.WriteLine($"The number {num} is even.");
}
else
{
    Console.WriteLine($"The number {num} is odd.");
}