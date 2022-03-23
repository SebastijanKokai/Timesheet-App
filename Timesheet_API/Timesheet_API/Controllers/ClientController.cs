using Microsoft.AspNetCore.Mvc;
using Timesheet_API.Models.Dto.ClientDtos;
using Timesheet_API.Services.ClientServices;

namespace Timesheet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        public IClientServices clientServices;

        public ClientController(IClientServices clientServices)
        {
            this.clientServices = clientServices;
        }

        [Route("/error-development")]
        public IActionResult HandlerError() => Problem();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(clientServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid ID)
        {
            return Ok(clientServices.FindByID(ID));
        }

        [HttpPost]
        public IActionResult Add(ClientPostDto clientPostDto)
        {
            return Created("", clientServices.Create(clientPostDto));
        }

        [HttpPut]
        public IActionResult Update(ClientUpdateDto clientUpdateDto)
        {
            return Ok(clientServices.Update(clientUpdateDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid ID)
        {
            return Ok(clientServices.Delete(ID));
        }
    }
}
