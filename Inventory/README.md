# Inventory Manager

A console app for tracking products in a small shop. Built with C# and .NET as practice for a web CRUD app.

## Features

- Add products (name, quantity, price) with input validation
- Update a product's quantity
- Remove a product
- Show all products
- Low-stock report (quantity of 5 or less)
- Data is saved to `inventory.csv`, so it stays after you close the program

## How to run

```
cd Inventory
dotnet run
```

## Menu

| Option | What it does |
|---|---|
| 1 | Add a product |
| 2 | Update quantity |
| 3 | Remove a product |
| 4 | Show all products |
| 5 | Low-stock report |
| 6 | Quit |

## Notes

- Product names are matched ignoring capitals, and duplicates are refused.
- Names can't contain commas, since the data file uses commas to separate values.

## What I practiced

Classes, lists, input validation, file reading and writing, and splitting code into small methods.

