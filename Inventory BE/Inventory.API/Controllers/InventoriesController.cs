using Inventory.API.Controllers;
using Inventory.BLL.DTOs;
using Inventory.BLL.Services;

namespace MySample.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoriesController : BaseController<InventoryService, InventoryDTO>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public InventoriesController(InventoryService service) : base(service)
        {
        }
    }
}
