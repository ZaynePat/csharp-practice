using System.Diagnostics.Metrics;

Console.Write("Enter a Word here: ");
string? input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Please enter some text.");
    return;
}
input = input.ToLower();
VowelsCounter(input);
static void VowelsCounter(string userInput)
{
    int counter = 0;
    foreach(char c in userInput)
    {
        if ("aeiou".Contains(c))
        {
            counter++;
        }
    }
    Console.WriteLine($"Total vowels is : {counter}");
}

