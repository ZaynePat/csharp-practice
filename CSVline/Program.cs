using System.Globalization;

class Product
{
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public void PrintInfo()
    {
        Console.WriteLine($"{Name} - Qty: {Quantity} - Price: {Price:N2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] testLines =
        {
            "Rice,20,55.50",
            "Rice,abc,55.50",
            "Rice,20",
            ",20,55.50",
            "Rice,-3,55.50",
            ""
        };

        foreach (string line in testLines)
        {
            Product? result = ParseProduct(line);
            if (result == null)
            {
                Console.WriteLine($"\"{line}\" -> Invalid");
            }
            else
            {
                Console.Write($"\"{line}\" -> ");
                result.PrintInfo();
            }
        }
    }

    static Product? ParseProduct(string line)
    {
        string[] parts = line.Split(',');
        if (parts.Length != 3)
        {
            return null;
        }
        if (string.IsNullOrWhiteSpace(parts[0]))
        {
            return null;
        }
        if (!int.TryParse(parts[1], out int quantity) || quantity < 0)
        {
            return null;
        }
        if (!decimal.TryParse(parts[2], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price) || price < 0)
        {
            return null;
        }
        Product product = new Product();
        product.Name = parts[0].Trim();
        product.Quantity = quantity;
        product.Price = price;
        return product;
    }
}