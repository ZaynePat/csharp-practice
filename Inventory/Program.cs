class Product
{
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public void PrintInfo()
    {
        Console.WriteLine($"{Name} - Qty: {Quantity} - Price: {Price:N2}");
    }
    public bool IsLowStocks()
    {
        return Quantity <= 5;
    }

}

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
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
                UpdateItem(products);
            }
            else if (choice == "3") // 3. Remove product
            {
                RemoveItem(products);
            }
            else if (choice == "4") // 4. Show all
            {
                ShowAll(products);
            }
            else if (choice == "5") // 5. Low-stock report
            {
                LowStockReport(products);
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
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please Dont leave the item blank");
            return;
        }
        if (FindProduct(products, name.Trim()) != null)
        {
            Console.WriteLine("This Item already exist");
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
                Console.WriteLine("Please Enter only positive numbers");
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
                Console.WriteLine("Please Enter only positive numbers");
                continue;
            }
            break;
        }
        Console.WriteLine($"Added new Item {name}, with a Quantity of {quantity} , and a Price of {price:N2}");
        Product product = new Product();
        name = name.Trim();
        product.Name = name;
        product.Quantity = quantity;
        product.Price = price;
        products.Add(product);
    }

    static void ShowAll(List<Product> products)
    {
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

    static Product? FindProduct(List<Product> products, string name)
    {
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].Name.ToLower() == name.ToLower())// if products[i].Name lowercase equals name lowercase
            {
                return products[i];
            }
        }
        return null;
    }
    public static void UpdateItem(List<Product> products)
    {
        if (products.Count == 0)
        {
            Console.WriteLine("The inventory is empty");
            return;
        }
        Console.Write("Which item do you want to update?: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please enter a product name.");
            return;
        }
        Product? found = FindProduct(products, name.Trim());
        if (found == null)
        {
            Console.WriteLine("Product not found");
            return;
        }
        int quantity = 0;
        while (true)
        {
            Console.Write("Add new Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Please enter only quantity number");
                continue;
            }
            if (quantity < 0)
            {
                Console.WriteLine("Please Enter only positive numbers");
                continue;
            }
            break;
        }
        found.Quantity = quantity;
        Console.WriteLine($"Updated an Item name: {found.Name}, Qty: {quantity}");


    }
    public static void RemoveItem(List<Product> products)
    {
        if (products.Count == 0)
        {
            Console.WriteLine("The inventory is empty");
            return;
        }
        Console.Write("Which item do you want to remove?: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please enter a product name.");
            return;
        }
        Product? found = FindProduct(products, name.Trim());
        if (found == null)
        {
            Console.WriteLine("Product not found");
            return;
        }
        Console.WriteLine($"Item: {found.Name} removed");
        products.Remove(found);
    }
    static void LowStockReport(List<Product> products)
    {
        int lowCount = 0;
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].IsLowStocks())
            {
                products[i].PrintInfo();
                lowCount++;
            }
        }
        if (products.Count == 0)
        {
            Console.WriteLine("The inventory is empty.");
            return;
        }
        if (lowCount == 0)
        {
            Console.WriteLine("No products are low on stock.");
        }
    }
}