using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure;

//public class Query
//{
//    private readonly InventoryDbContext _db;

//    public Query(InventoryDbContext db)
//    {
//        _db = db;
//    }

//    public IQueryable<Product> GetProductsByWarehouse(int warehouseId)
//        => _db.Products.Where(p => p.WarehouseId == warehouseId);
//}


public class Query
{
    private readonly HttpClient _httpClient;

    public Query(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("DataService");
    }

    public async Task<List<Product>> GetProductsByWarehouse(int warehouseId)
    {
        var response = await _httpClient.GetAsync($"/api/products/by-warehouse/{warehouseId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<Product>>();
    }
    //public async Task<List<Product>> GetProductsByWarehouse(int warehouseId)
    //{
    //    var response = await _httpClient.GetFromJsonAsync<List<Product>>(
    //        $"http://inventory-data-service/api/warehouses/{warehouseId}/products");
    //    return response ?? new();
    //}
}