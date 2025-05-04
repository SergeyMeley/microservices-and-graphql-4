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
        var products = _db.Products.Where(p => p.WarehouseId == warehouseId).ToList();
        return Ok(products);
    }
}