Console.Write("Enter a Whole Number here: ");
if (!int.TryParse(Console.ReadLine(), out int num))
{
    Console.WriteLine("Please Enter a Valid Whole number.");
    return;
}
if (num <= 0 || num > 100)
{
    Console.WriteLine("Please Enter number greater than 1.");
    return;
}
while (num > 0)
{
    Console.WriteLine($"{num}");
    num--;
}
Console.WriteLine("LIFT OFF!");