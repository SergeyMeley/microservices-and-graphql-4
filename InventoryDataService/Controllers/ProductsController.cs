using Infrastructure.Data;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly InventoryDbContext _db;

    public ProductsController(InventoryDbContext db) => _db = db;

    [HttpGet("by-warehouse/{warehouseId}")]
    public IActionResult GetByWarehouse(int warehouseId)
    {
        var productList = new List<Product>
            {
                new Product() {Id = 1, Name = "Яблоко", Quantity = 43245, WarehouseId = 1},
                new Product() {Id = 1, Name = "Яблоко", Quantity = 124142, WarehouseId = 2},
                new Product() {Id = 1, Name = "Яблоко", Quantity = 1243, WarehouseId = 3},
                new Product() {Id = 2, Name = "Груша", Quantity = 0, WarehouseId = 1},
                new Product() {Id = 2, Name = "Груша", Quantity = 425435, WarehouseId = 2},
                new Product() {Id = 2, Name = "Груша", Quantity = 23423, WarehouseId = 3},
                new Product() {Id = 3, Name = "Банан", Quantity = 3252, WarehouseId = 1},
                new Product() {Id = 3, Name = "Банан", Quantity = 2311, WarehouseId = 2},
                new Product() {Id = 3, Name = "Банан", Quantity = 23, WarehouseId = 3},
            };
        var products = productList.Where(p => p.WarehouseId == warehouseId).ToList();
        return Ok(products);
    }
}