int SecretNum = 42;
int maxAttempts = 7;
int attempts = 0;
bool won = false;
Console.WriteLine("Welcome to the Guessing Game!");

while (attempts <maxAttempts)
{
    Console.Write("Enter your guess number: ");
    if (!int.TryParse(Console.ReadLine(), out int GuessNum))
    {
        Console.WriteLine("Please enter a valid whole number.");
        continue;
    }
    attempts++;
    if (GuessNum == SecretNum)
    {
        Console.WriteLine("Congratulations! You guessed the Correct Number!");
        won = true;
        break;
    }
    else if (GuessNum < SecretNum)
    {
        Console.WriteLine("Your guess is too low. Try again.");
    }
    else
    {
        Console.WriteLine("Your guess is too high. Try again.");
    }
}

if (!won)
{
    Console.WriteLine($"Sorry, you've run out of guesses. The correct number was: {SecretNum} ");
}
Console.WriteLine($"Attempts {attempts}.");