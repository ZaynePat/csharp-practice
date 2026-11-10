class Product
{
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public void PrintInfo()
    {
        Console.WriteLine($"{Name} , {Quantity}, {Price:N2}");
    }
    public void IsLowStocks()
    {

    }

}

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        Product product = new Product();
        Console.WriteLine("Hello Welcome to Inventory System");
        while (true)
        {
            Console.WriteLine("Choose what you want to do.");
            Console.WriteLine(" [1] Add Product \n [2] Update Quantity \n [3] Remove Product \n [4] Show all \n [5] Low stock report \n [6] Quit");
            Console.Write("What do you want to do?: ");
            string? choice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Please dont leave the box empty");
                continue;
            }
            if (choice == "1") // ADD PRODUCT
            {
                AddItem(products);
            }
            else if (choice == "2") // 2. Update quantity
            {
                Console.WriteLine("Update a product: ");
            }
            else if (choice == "3") // 3. Remove product
            {
                Console.WriteLine("Remove a product: ");
            }
            else if (choice == "4") // 4. Show all
            {
                ShowAll(products);
            }
            else if (choice == "5") // 5. Low-stock report
            {
                Console.WriteLine("Show all low-stock report: ");
            }
            else if (choice == "6") // 6. Quit
            {
                Console.WriteLine("Thank you for using the Inventory App");
                break;
            }
            else
            {
                Console.WriteLine("Please only choose between [1 - 6]");
            }
        } // while
    }

    public static void AddItem(List<Product> products)
    {
        int quantity = 0;
        decimal price = 0;
        Console.Write("Add a product: ");
        string? NewItem = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(NewItem))
        {
            Console.WriteLine("Please Dont leave the item blank");
            return;
        }
        while (true)
        {
            Console.Write("Add Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Please enter only quantity number");
                continue;
            }
            if (quantity < 0)
            {
                Console.WriteLine("Please Enter only possitive numbers");
                continue;
            }
            break;
        }
        while (true)
        {
            Console.Write("Enter the Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Please enter only numbers");
                continue;
            }
            if (price < 0)
            {
                Console.WriteLine("Please Enter only possitive numbers");
                continue;
            }
            break;
        }
        Console.WriteLine($"Added new Item {NewItem}, with a Quantity of {quantity} , and a Price of {price}");
        Product product = new Product();
        NewItem = NewItem.Trim();
        product.Name = NewItem;
        product.Quantity = quantity;
        product.Price = price;
        products.Add(product);
    }

    static void ShowAll(List<Product> products)
    {
        Product product = new Product();
        if (products.Count == 0)
        {
            Console.WriteLine("Empty.");
            return;
        }
        for (int i = 0; i < products.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            products[i].PrintInfo();
        }
    }
    public void UpdateItem(List<Product> products)
    {

    }
    public void RemoveItem(List<Product> products)
    {

    }
}