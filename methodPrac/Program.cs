Console.Write("Enter a Whole Number here: ");
if (!int.TryParse(Console.ReadLine(), out int num))
{
    Console.WriteLine("Please enter a valid whole number.");
    return;
}
int result = square(num);

static int square(int number)
{
    return number * number;
}
bool even = isEven(num);
static bool isEven(int number)
{
    return number % 2 == 0;
}

Console.WriteLine($"The square of {num} is: {result}");
Console.WriteLine($"The number {num} is {(even ? "even" : "odd")}.");