using Microsoft.AspNetCore.Mvc;
using Timesheet_API.Models.Dto.ProjectTaskDtos;
using Timesheet_API.Services.TaskServices;

namespace Timesheet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectTaskController : ControllerBase
    {
        private IProjectTaskServices projectTaskServices;

        public ProjectTaskController(IProjectTaskServices projectTaskServices)
        {
            this.projectTaskServices = projectTaskServices;
        }

        [Route("/error-development")]
        public IActionResult HandlerError() => Problem();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(projectTaskServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid ID)
        {
            return Ok(projectTaskServices.FindByID(ID));
        }

        [HttpPost]
        public IActionResult Add(ProjectTaskPostDto projectTaskPostDto)
        {
            return Created("", projectTaskServices.Create(projectTaskPostDto));
        }

        [HttpPut]
        public IActionResult Update(ProjectTaskUpdateDto projectTaskUpdateDto)
        {
            return Ok(projectTaskServices.Update(projectTaskUpdateDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid ID)
        {
            return Ok(projectTaskServices.Delete(ID));
        }
    }
}
