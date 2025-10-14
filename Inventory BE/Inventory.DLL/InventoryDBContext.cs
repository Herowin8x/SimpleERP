using Microsoft.EntityFrameworkCore;
using Inventory.DLL.Entities;

namespace Inventory.DLL
{
    public class InventoryDBContext : DbContext
    {
        public InventoryDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<InventoryEntity> Inventories { get; set; }
    }
}