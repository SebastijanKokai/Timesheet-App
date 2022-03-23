using Microsoft.AspNetCore.Mvc;
using Timesheet_API.Models.Dto.RoleDtos;
using Timesheet_API.Services.RoleServices;

namespace Timesheet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private IRoleServices roleServices;

        public RoleController(IRoleServices roleServices)
        {
            this.roleServices = roleServices;
        }

        [Route("/error-development")]
        public IActionResult HandlerError() => Problem();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(roleServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid ID)
        {
            return Ok(roleServices.FindByID(ID));
        }

        [HttpPost]
        public IActionResult Add(RoleDto roleDto)
        {
            return Created("", roleServices.Create(roleDto));
        }

        [HttpPut]
        public IActionResult Update(RoleUpdateDto roleUpdateDto)
        {
            return Ok(roleServices.Update(roleUpdateDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid ID)
        {
            return Ok(roleServices.Delete(ID));
        }
    }
}
