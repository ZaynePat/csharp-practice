var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Product> products = new List<Product>
{
    new Product { Name = "Rice", Quantity = 20, Price = 55.50m },
    new Product { Name = "Soap", Quantity = 3, Price = 22.00m }
};

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
    
});

app.Run();

class Product
{
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}