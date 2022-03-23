using Microsoft.AspNetCore.Mvc;
using Timesheet_API.Models.Dto.UserProjectDtos;
using Timesheet_API.Services.UserProjectServices;

namespace Timesheet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProjectController : Controller
    {

        private IUserProjectServices userProjectServices;

        public UserProjectController(IUserProjectServices userProjectServices)
        {
            this.userProjectServices = userProjectServices;
        }

        [Route("/error-development")]
        public IActionResult HandlerError() => Problem();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(userProjectServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(UserProjectDto userProjectDto)
        {
            if (userProjectDto == null)
            {
                throw new ArgumentNullException("UserID and ProjectID must be passed.");
            }
            return Ok(userProjectServices.FindByID(userProjectDto));
        }

        [HttpPost]
        public IActionResult Add(UserProjectDto userProjectDto)
        {
            if (userProjectDto == null)
            {
                throw new ArgumentNullException("UserID and ProjectID must be passed.");
            }
            return Created("", userProjectServices.Create(userProjectDto));
        }

        [HttpDelete]
        public IActionResult Delete(UserProjectDto userProjectDto)
        {
            if (userProjectDto == null)
            {
                throw new ArgumentNullException("UserID and ProjectID must be passed.");
            }
            return Ok(userProjectServices.Delete(userProjectDto));
        }
    }
}
