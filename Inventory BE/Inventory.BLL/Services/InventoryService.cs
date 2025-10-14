using AutoMapper;
using Inventory.BLL.DTOs;
using Inventory.DLL.Entities;
using Inventory.DLL.Repositories;

namespace Inventory.BLL.Services
{
    public class InventoryService
    {
        private readonly InventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
        public InventoryService(InventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public InventoryDTO Create(InventoryDTO inventoryDTO)
        {
            var newEntity = _inventoryRepository.Create(_mapper.Map<InventoryEntity>(inventoryDTO));
            return _mapper.Map<InventoryDTO>(newEntity);
        }

        public List<InventoryDTO> Read()
        {
            return _mapper.Map<List<InventoryDTO>>(_inventoryRepository.Read());
        }

        public InventoryDTO Read(int id)
        {
            return _mapper.Map<InventoryDTO>(_inventoryRepository.Read(id));
        }

        public void Update(InventoryDTO inventoryDTO)
        {
            var entity = _inventoryRepository.Read(inventoryDTO.Id);
            if (entity != null)
            {
                entity.Name = inventoryDTO.Name;
                entity.Description = inventoryDTO.Description;
                entity.Color = inventoryDTO.Color;
                entity.Suppliers = inventoryDTO.Suppliers;
                entity.Manufacturers = inventoryDTO.Manufacturers;

                _inventoryRepository.Update(entity);
            }
        }

        public void Delete(int id)
        {
            _inventoryRepository.Delete(id);
        }
    }
}
