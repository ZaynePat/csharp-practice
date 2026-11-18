using System.Globalization;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Product> products = ProductStorage.Load();

app.MapGet("/", () => "Product API is running");
app.MapGet("/products", () => products);
app.MapGet("/products/low", () =>
{
    List<Product> low = new List<Product>();
    foreach (Product product in products)
    {
        if (product.Quantity <= 5)
        {
            low.Add(product);
        }
    }
    return low;
});

app.MapPost("/products", (Product newProduct) =>
{

    if (string.IsNullOrWhiteSpace(newProduct.Name))
    {
        return Results.BadRequest("Name is required.");
    }
    if (newProduct.Quantity < 0)
    {
        return Results.BadRequest("Quantity can't be negative.");
    }
    if (newProduct.Price < 0)
    {
        return Results.BadRequest("Price can't be negative.");
    }
    if (newProduct.Name.Contains(','))
    {
        return Results.BadRequest("Names can't contain commas.");
    }
    foreach (Product product in products)
    {
        if (product.Name.ToLower() == newProduct.Name.Trim().ToLower())
        {
            return Results.BadRequest("Product already exists.");
        }
    }
    newProduct.Name = newProduct.Name.Trim();
    products.Add(newProduct);
    ProductStorage.Save(products);
    return Results.Ok(newProduct);
});

app.MapDelete("/products/{name}", (string name) =>
{
    // stage 2: find the product
    Product? found = null;
    foreach (Product product in products)
    {
        if (product.Name.Trim().ToLower() == name.Trim().ToLower())
        {
            found = product;
        }
    }
    // stage 2: handle "not found"
    if (found == null)
    {
        return Results.NotFound("Product not found.");
    }
    // stage 3: remove it and reply
    products.Remove(found);
    ProductStorage.Save(products);
    return Results.Ok("Removed.");
});
app.MapPut("/products/{name}", (string name, Product updated) =>
{
    Product? found = null;
    foreach (Product product in products)
    {
        if (product.Name.Trim().ToLower() == name.Trim().ToLower())
        {
            found = product;
        }
    }
    if (found == null)
    {
        return Results.NotFound("Product not found.");
    }
    if (updated.Quantity < 0)
    {
        return Results.BadRequest("Quantity cant be negative. ");
    }
    found.Quantity = updated.Quantity;
    ProductStorage.Save(products);
    return Results.Ok(found);
});

app.Run();

class Product
{
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

static class ProductStorage
{
    const string FileName = "products.csv";

    public static void Save(List<Product> products)
    {
        List<string> lines = new List<string>();// 1. create a List<string> called lines
        foreach (Product product in products)
        {
            string price = product.Price.ToString(CultureInfo.InvariantCulture);
            string line = $"{product.Name},{product.Quantity},{price}";
            lines.Add(line);
        }
        File.WriteAllLines(FileName, lines);
    }

    public static List<Product> Load()
    {
        List<Product> products = new List<Product>();

        if (!File.Exists(FileName))
        {
            return products;
        }

        string[] lines = File.ReadAllLines(FileName);

        foreach (string line in lines)
        {
            Product? product = ParseProduct(line);
            if (product != null)
            {
                products.Add(product);
            }
        }
        return products;
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