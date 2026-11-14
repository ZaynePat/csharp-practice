class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n [1] Add note \n [2] Show all notes \n [3] Remove a note \n [4] Quit");
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
                deleteText();
            }
            else if (choice == "4")
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
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {lines[i]}");
            }
        }
    }

    static void deleteText()
    {
        List<string> notes = new List<string>(File.ReadAllLines("notes.txt"));
        if(notes.Count  == 0)
        {
            Console.WriteLine("No notes to delete yet.");
            return;
        }
        if (!File.Exists("notes.txt"))
        {
            Console.WriteLine("No notes yet.");
            return;
        }
        ShowNotes();
        Console.Write("Which note number do you want to delete?: ");
        if (!int.TryParse(Console.ReadLine(), out int input))
        {
            Console.WriteLine("Please input a valid number.");
            return;
        }
        if (input <= 0 || input > notes.Count)
        {
            Console.WriteLine("Please input only positive numbers.");
            return;
        }
        notes.RemoveAt(input - 1);
        File.WriteAllLines("notes.txt", notes);
        Console.WriteLine($"Line {input}, Removed");
    }
}