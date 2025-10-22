using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOnlyInventoryUIApp")]
    public class BaseController<TService, TDto> : ControllerBase
    {
        protected readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Editor")]
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto dto)
        {
            var method = typeof(TService).GetMethod("Create");
            if (method == null)
                return BadRequest("Create method not implemented in service.");

            var result = await (Task<TDto>)method.Invoke(_service, new object[] { dto });
            return Created(string.Empty, result);
        }

        [Authorize(Roles = "Editor,Viewer")]
        [HttpGet]
        public virtual async Task<IActionResult> Get([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            var method = typeof(TService).GetMethod("Read", new[] { typeof(int), typeof(int) });
            if (method == null)
                return BadRequest("Read method not implemented in service.");

            var result = await (Task<List<TDto>>)method.Invoke(_service, new object[] { pageSize, pageNumber });
            return Ok(result);
        }

        [Authorize(Roles = "Editor,Viewer")]
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var method = typeof(TService).GetMethod("Read", new[] { typeof(int) });
            if (method == null)
                return BadRequest("Read by Id method not implemented in service.");

            var result = await (Task<TDto>)method.Invoke(_service, new object[] { id });
            return Ok(result);
        }

        [Authorize(Roles = "Editor")]
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TDto dto)
        {
            var method = typeof(TService).GetMethod("Update");
            if (method == null)
                return BadRequest("Update method not implemented in service.");

            await (Task)method.Invoke(_service, new object[] { dto });
            return NoContent();
        }

        [Authorize(Roles = "Editor")]
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var method = typeof(TService).GetMethod("Delete");
            if (method == null)
                return BadRequest("Delete method not implemented in service.");

            await (Task)method.Invoke(_service, new object[] { id });
            return NoContent();
        }
    }
}
