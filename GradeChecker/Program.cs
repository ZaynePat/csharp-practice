Console.WriteLine("Enter your grade here: ");
if (!double.TryParse(Console.ReadLine(), out double grade))
{
    Console.WriteLine("Please enter a valid grade.");
    return;
}
if (grade < 0 || grade > 100)
{
    Console.WriteLine("Grade must be between 0 and 100.");
    return;
}
Console.WriteLine($"Your grade is: {grade}");
if (grade >= 90)
{
    Console.WriteLine("You got an A!");
}
else if (grade >= 80)
{
    Console.WriteLine("You got a B!");
}
else if (grade >= 70)
{
    Console.WriteLine("You got a C!");
}
else if (grade >= 60)
{
    Console.WriteLine("You got a D!");
}
else
{
    Console.WriteLine("You got an F!");
}