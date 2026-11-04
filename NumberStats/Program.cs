List<int> numbers = new List<int>();
while (true)
{
    Console.Write("Enter a number: ");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Please enter a number.");
        continue;
    }
    if(input.ToLower() == "done")
    {
        break;
    }
    if(!int.TryParse(input, out int number))
    {
        Console.WriteLine("Please enter a valid Whole number, or Type Done");
        continue;
    }
    numbers.Add(number);
}
if (numbers.Count == 0)
{
    Console.WriteLine("No numbers were entered.");
    return;
}

int sum = numbers.Sum();
double average = (double)sum / numbers.Count;
Console.WriteLine($"The count of the list is {numbers.Count}");
Console.WriteLine($"The sum of the whole list is {sum}");
Console.WriteLine($"The Average number is {average}");
Console.WriteLine($"The Highest number of the List is {numbers.Max()}");

int largest = numbers[0];
for(int i = 0; i < numbers.Count; i++)
{
    if(largest < numbers[i])
    {
        largest = numbers[i];
    }
}
Console.WriteLine($"The largest is {largest}");