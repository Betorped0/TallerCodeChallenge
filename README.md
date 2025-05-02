# TallerCodeChallenge
# Products API

A RESTful API built with C# and ASP.NET Core that manages a collection of products with in-memory storage.

## Features

- CRUD operations for Products
- In-memory data storage
- Basic error handling
- Unit tests for API endpoints

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/products/get-all | Get all products |
| GET    | /api/products/get-byid/{id} | Get product by ID |
| POST   | /api/products/add-product | Create new product |
| PUT    | /api/products/update-product/{id} | Update existing product |
| DELETE | /api/products/delete-product/{id} | Delete product |
| POST   | /api/products/bulk-add-dummy | Delete product |

## Product Model
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```
## Project Structure
├── src/
│   ├── Controllers/
│   │   └── ProductsController.cs
│   ├── Models/
│   │   └── Product.cs
|   ├── Business/
|   |   └── Handler.cs
│   └── Program.cs
├── TallerCodeChallengexUnitTests/
│   └── ProductsControllerTests.cs
└── README.md

## Error Handling
404 Not Found: When product ID doesn't exist
400 Bad Request: When invalid data is submitted
200 OK: Successful operations
201 Created: Successful product creation
Technologies Used
C#
ASP.NET Core
xUnit (for testing)