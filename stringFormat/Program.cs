Console.Write("Enter your name here: ");
string? name = Console.ReadLine();
if (string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("Invalid input. Please enter a valid name.");
    return;
}
name = name.Trim();
nameUpper(name);
nameLower(name);
nameCharCount(name);
nameFirstLetter(name);

Console.WriteLine($"Trimmed version is {name}");

static void nameUpper(string inputName)
{
    string formattedName = inputName.ToUpper();
    Console.WriteLine($"UpperCase {formattedName}");
    return;
}
static void nameLower(string inputName)
{
    string formattedName = inputName.ToLower();
    Console.WriteLine($"LowerCase {formattedName}");
    return;
}
static void nameCharCount(string inputName)
{
    string s = inputName;
    Console.WriteLine($"the Char count is {s.Length}");
    return;
}
static void nameFirstLetter(string inputName)
{
    Console.WriteLine($"the First letter is {inputName[0]}");
}