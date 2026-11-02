Console.Write("Enter a Whole Number here: ");
if (!int.TryParse(Console.ReadLine(), out int num))
{
    Console.WriteLine("Please enter a valid whole number.");
    return;
}
int total = 0;
for (int i = 1; i <= 10; i++)
{
    total += i * num;
    Console.WriteLine($"{num} x {i} = {i * num}");
}
Console.WriteLine($"The total of the multiplication table for {num} is: {total}");