namespace Infrastructure
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
