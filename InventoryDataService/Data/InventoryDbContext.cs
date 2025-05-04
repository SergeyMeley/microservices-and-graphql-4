﻿using InventoryDataService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryDataService.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
