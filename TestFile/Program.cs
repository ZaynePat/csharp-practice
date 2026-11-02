using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Add first number: ");
        if (!double.TryParse(Console.ReadLine(), out Double num1))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }
        Console.WriteLine("Add second number: ");
        if (!double.TryParse(Console.ReadLine(), out Double num2))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        double sum = num1 + num2;
        double diff = num1 - num2;
        double product = num1 * num2;

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {diff}");
        Console.WriteLine($"Product: {product}");
        if (num2 != 0)
        {
            double quotient = num1 / num2;
            Console.WriteLine($"Quotient: {quotient}");
        }
        else
        {
            Console.WriteLine("Cannot divide by zero.");
        }

    }
}