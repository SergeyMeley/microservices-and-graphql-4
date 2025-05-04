namespace InventoryDataService.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
