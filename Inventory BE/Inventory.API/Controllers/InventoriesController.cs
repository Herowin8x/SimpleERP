using Inventory.BLL.DTOs;
using Inventory.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MySample.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOnlyInventoryUIApp")]
    public class InventoriesController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventoryService"></param>
        public InventoriesController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventoryDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "Editor")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InventoryDTO inventoryDTO)
        {
            return CreatedAtAction(nameof(Get),
                                   new { id = inventoryDTO.Id },
                                   _inventoryService.Create(inventoryDTO));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Viewer,Editor")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_inventoryService.Read());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventoryDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "Editor")]
        [HttpPut]
        public IActionResult Put([FromBody] InventoryDTO inventoryDTO)
        {
            var dto = _inventoryService.Read(inventoryDTO.Id);
            if (dto == null)
                return NotFound("Inventory does not exist!");

            _inventoryService.Update(inventoryDTO);
            return NoContent();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = "Editor")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _inventoryService.Delete(id);
            NoContent();
        }
    }
}
