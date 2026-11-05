int [] scores = new int[5];

for(int i = 0; i < scores.Length; i++)
{
    Console.Write($"Enter Score {i + 1}: ");
    if(!int.TryParse(Console.ReadLine(), out int input))
    {
        Console.WriteLine("Please enter a Whole Number.");
        i--;
        continue;
    }
    if (input < 0 || input > 100)
    {
        Console.WriteLine("Please Enter a valid Score");
        i--;
        continue;
    }
    else if(input > 0 || input < 100)
    {
        scores[i] = input;
    }
}
int largest = scores[0];
int lowest = scores[0];
int sum = scores.Sum();
double average = (double)sum / scores.Length;
for(int c = 0;c < scores.Length; c++)
{
    if (largest < scores[c])
    {
        largest = scores[c];
    }
    if (lowest > scores[c])
    {
        lowest = scores[c];
    }
}
Console.WriteLine($"The largest score is {largest}");
Console.WriteLine($"The lowest score is {lowest}");
Console.WriteLine($"The Average of all the scores is {average:F2}");