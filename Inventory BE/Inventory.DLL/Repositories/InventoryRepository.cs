using Inventory.DLL.Entities;

namespace Inventory.DLL.Repositories
{
    public class InventoryRepository : BaseRepository<InventoryEntity>
    {
        public InventoryRepository(InventoryDBContext dbContext) : base(dbContext)
        {
        }
    }
}
