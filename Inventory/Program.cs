class Product
{
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public void PrintInfo()
    {

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
                Console.WriteLine("Add a product: ");
                string? NewItem = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(NewItem))
                {
                    Console.WriteLine("Please Dont leave the item blank");
                    continue;
                }

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
                Console.WriteLine("Show all product: ");
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

    public void AddItem(List<Product> products)
    {
        
    }
    public void UpdateItem(List<Product> products)
    {

    }
    public void RemoveItem(List<Product> products)
    {

    }
}