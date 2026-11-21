# Product API

A small REST API for managing a shop's product inventory, built with C# and ASP.NET Core (minimal API). Products are saved to a CSV file, so the data stays after the server restarts.

## Features

- List all products, or only the low-stock ones (quantity of 5 or less)
- Add a product with validation
- Update a product's quantity
- Delete a product
- Data is saved to `products.csv` after every change
- You can now Add products in the web as I added HTML for frontend

## How to run

```
cd ProductApi
dotnet run
```

The terminal shows the address, for example `http://localhost:5146`. The port can differ on your machine.

## Endpoints

| Method | Route | What it does |
|---|---|---|
| GET | `/products` | Returns all products |
| GET | `/products/low` | Returns products with a quantity of 5 or less |
| POST | `/products` | Adds a product (JSON body) |
| PUT | `/products/{name}` | Updates a product's quantity (JSON body) |
| DELETE | `/products/{name}` | Removes a product |

Names are matched ignoring capital letters.

## Example requests (PowerShell)

Add a product:

```powershell
Invoke-RestMethod -Uri http://localhost:5146/products -Method Post -ContentType "application/json" -Body '{"name":"Eggs","quantity":12,"price":9.5}'
```

Update a quantity:

```powershell
Invoke-RestMethod -Uri http://localhost:5146/products/Eggs -Method Put -ContentType "application/json" -Body '{"name":"Eggs","quantity":3,"price":9.5}'
```

Delete a product:

```powershell
Invoke-RestMethod -Uri http://localhost:5146/products/Eggs -Method Delete
```

## Validation rules

Adding or updating a product is refused with a `400 Bad Request` when:

- the name is blank
- the quantity or price is negative
- the name already exists (ignoring capitals)
- the name contains a comma, because the data file uses commas to separate values

Updating or deleting a product that doesn't exist returns `404 Not Found`.

## Data storage

Products are stored in `products.csv`, one per line:

```
Eggs,12,9.5
```

Lines that can't be read are skipped when the file is loaded.

## What I practiced

Minimal API routes (GET, POST, PUT, DELETE), request validation, returning HTTP status codes, and reading and writing files.

## Possible next steps

- A web page with a table and form to use the API
- Replace the CSV file with a database
- add more interactable pages such as DELETE AND PUT 