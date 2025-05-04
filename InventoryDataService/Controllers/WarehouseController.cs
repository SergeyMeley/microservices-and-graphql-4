using InventoryDataService.Data;
using InventoryDataService.Data;
using InventoryDataService.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryDataService.Controllers
{
    [ApiController]
    [Route("api/warehouses")]
    public class WarehouseController : ControllerBase
    {
        private readonly InventoryDbContext _db;
        public WarehouseController(InventoryDbContext db) => _db = db;

        [HttpGet("{id}/products")]
        public IActionResult GetProducts(int id)
        {
            //var products = _db.Products.Where(p => p.WarehouseId == id).ToList();
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
            var products = productList.Where(p => p.WarehouseId == id).ToList();
            return Ok(products);
        }
    }
}
