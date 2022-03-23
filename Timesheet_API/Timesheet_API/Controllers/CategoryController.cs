using Microsoft.AspNetCore.Mvc;
using Timesheet_API.Models.Dto.CategoryDtos;
using Timesheet_API.Services.CategoryServices;

namespace Timesheet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryServices categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
        }

        [Route("/error-development")]
        public IActionResult HandlerError() => Problem();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(categoryServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid ID)
        {
            return Ok(categoryServices.FindByID(ID));
        }

        [HttpPost]
        public IActionResult Create(CategoryPostDto categoryPostDto)
        {
            return Created("", categoryServices.Create(categoryPostDto));
        }

        [HttpPut]
        public IActionResult Update(CategoryUpdateDto categoryUpdateDto)
        {
            return Ok(categoryServices.Update(categoryUpdateDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid ID)
        {
            return Ok(categoryServices.Delete(ID));
        }
    }
}
