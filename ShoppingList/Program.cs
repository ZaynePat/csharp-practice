List<string> items = new List<string>();

while (true)
{
    Console.WriteLine("\n Add[1] \n Remove[2] \n Show[3] \n Stop[4]");
    Console.Write("What do you want to do? ");
    string? choice = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(choice))
    {
        Console.WriteLine("Please input a valid choice from [1] to [4]");
        continue;
    }
    if (choice == "1") // add
    {
        Console.Write("What item do you want to add?: ");
        string? itemName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(itemName))
        {
            Console.WriteLine("Please Enter an Item name.");
            continue;
        }
        if (items.Contains(itemName.Trim().ToLower()))
        {
            Console.WriteLine("Item is already in the list.");
            continue;
        }
        else
        {
            items.Add(itemName.Trim().ToLower());
            Console.WriteLine($"{itemName} added");
        }

    }
    else if (choice == "2") // remove
    {
        Console.Write("What Item do you want to remove?: ");
        string? itemRemove = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(itemRemove))
        {
            Console.WriteLine("Please type anything.");
            continue;
        }
        if (items.Remove(itemRemove.Trim().ToLower()))
        {
            Console.WriteLine("Item Removed");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"[{i + 1}. {items[i]}]");
        }

    }
    else if (choice == "3") // show list
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Your List is Empty");
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i]}");
            }
        }
    }
    else if (choice == "4") // done
    {
        Console.WriteLine("Thank you for using the Shoppinglist");
        break;
    }
    else
    {
        Console.WriteLine("Please choose 1 to 4.");
    }
}