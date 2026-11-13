class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n [1] Add note \n [2] Show all notes \n [3] Quit");
            Console.Write("What do you want to do?: ");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                AddNote();
            }
            else if (choice == "2")
            {
                ShowNotes();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Please choose 1 to 3.");
            }
        }
    }

    static void AddNote()
    {
        Console.Write("Enter your text: ");
        string? text = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Please Enter a Text.");
            return;
        }
        File.AppendAllText("notes.txt", text.Trim() + "\n");
        Console.WriteLine("Text printed");
    }

    static void ShowNotes()
    {
        if (!File.Exists("notes.txt"))
        {
            Console.WriteLine("No notes yet.");
        }
        else
        {
            string[] lines = File.ReadAllLines("notes.txt");
            if (lines.Length == 0)
            {
                Console.WriteLine("No notes yet.");
            }
            else
            {
                for(int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {lines[i]}");
                }
            }
        }
    }
}