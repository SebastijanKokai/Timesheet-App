using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Timesheet_API.Models.Dto.ProjectDtos;
using Timesheet_API.Models.Parameters;
using Timesheet_API.Services.ProjectServices;

namespace Timesheet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private IProjectServices projectServices;

        public ProjectController(IProjectServices projectServices)
        {
            this.projectServices = projectServices;
        }

        [Route("/error-development")]
        public IActionResult HandlerError() => Problem();

        [HttpGet]
        public IActionResult GetAll([FromQuery] ProjectParameters projectParameters)
        {
            var projects = projectServices.FindAll(projectParameters);

            var metadata = new
            {
                projects.TotalCount,
                projects.PageSize,
                projects.CurrentPage,
                projects.HasNext,
                projects.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(projects);
        }

        [HttpGet("FirstLettersArray")]
        public IActionResult GetFirstLettersArrayOfProjectsThatExist()
        {
            return Ok(projectServices.FindFirstLettersOfProjectsThatExist());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid ID)
        {
            return Ok(projectServices.FindByID(ID));
        }

        [HttpPost]
        public IActionResult Add(ProjectPostDto projectPostDto)
        {
            return Created("", projectServices.Create(projectPostDto));
        }

        [HttpPut]
        public IActionResult Update(ProjectUpdateDto projectUpdateDto)
        {
            return Ok(projectServices.Update(projectUpdateDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid ID)
        {
            return Ok(projectServices.Delete(ID));
        }
    }
}
