using AutoMapper;
using Inventory.BLL.DTOs;
using Inventory.DLL.Entities;

namespace Inventory.BLL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InventoryDTO, InventoryEntity>();
            CreateMap<InventoryEntity, InventoryDTO>();
            CreateMap<UserDTO, UserEntity>();
            CreateMap<UserEntity, UserDTO>();
        }
    }
}
