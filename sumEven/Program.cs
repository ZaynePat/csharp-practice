Console.Write("Enter a Whole Number here: ");
if (!int.TryParse(Console.ReadLine(), out int num))
{
    Console.WriteLine("Please enter a valid whole number.");
    return;
}
if (num <= 0)
{
    Console.WriteLine("The number should be not below 1.");
    return;
}
int sum = 0;
int count= 0;
for (int i = 1; i <= num; i++)
{
    if (i % 2 == 0)
    {
       sum += i;
       Console.WriteLine($"The even number is {i}");
       count++;
    }
}
Console.WriteLine($"The Sum of all even numbers is {sum}");
Console.WriteLine($"The Count of all even numbers is {count}");