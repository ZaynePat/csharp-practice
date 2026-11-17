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
    foreach (Product product in products)
    {
        if (product.Name.ToLower() == newProduct.Name.Trim().ToLower())
        {
            return Results.BadRequest("Product already exists.");
        }
    }
    newProduct.Name = newProduct.Name.Trim();
    products.Add(newProduct);
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
    if(updated.Quantity < 0)
    {
        return Results.BadRequest("Quantity cant be negative. ");
    }
    found.Quantity = updated.Quantity;
    return Results.Ok(found);
});

app.Run();

class Product
{
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}