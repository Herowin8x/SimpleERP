using AutoMapper;
using Inventory.BLL.DTOs;
using Inventory.BLL.Exceptions;
using Inventory.DLL.Entities;
using Inventory.DLL.Repositories;

namespace Inventory.BLL.Services
{
    public class InventoryService : BaseService<InventoryEntity, InventoryDTO>
    {
        public InventoryService(InventoryRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
