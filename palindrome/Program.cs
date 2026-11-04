Console.Write("Enter a word: ");
string? input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Please Make sure to input anything.");
    return;
}

input = input.Trim().ToLower();

if (IsPalindrome(input))
{
    Console.WriteLine("Your word is a Palindrome");
}
else
{
    Console.WriteLine("Your word is not a Palindrome");
}
static bool IsPalindrome(string text)
{
    for(int i = 0; i < text.Length / 2; i++)
    {
        if(text[i] != text[text.Length - 1 -i])
        {
            return false;
        }
    }
    return true;
}