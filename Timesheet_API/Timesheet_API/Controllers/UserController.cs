using Microsoft.AspNetCore.Mvc;
using Timesheet_API.Models.Dto.UserDtos;
using Timesheet_API.Services.UserServices;

namespace Timesheet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public IUserServices userServices;

        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [Route("/error-development")]
        public IActionResult HandlerError() => Problem();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(userServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid ID)
        {
            return Ok(userServices.FindByID(ID));
        }

        [HttpPost]
        public IActionResult Add(UserPostDto userPostDto)
        {
            return Created("", userServices.Create(userPostDto));
        }

        [HttpPut]
        public IActionResult Update(UserUpdateDto userUpdateDto)
        {
            return Ok(userServices.Update(userUpdateDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid ID)
        {
            return Ok(userServices.Delete(ID));
        }
    }
}
