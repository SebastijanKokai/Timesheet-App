﻿using Microsoft.AspNetCore.Mvc;
using Timesheet_API.Models.Dto.ProjectDtos;
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
        public IActionResult GetAll()
        {
            return Ok(projectServices.FindAll());
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
