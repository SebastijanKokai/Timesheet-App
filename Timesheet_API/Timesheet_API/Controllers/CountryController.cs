using Microsoft.AspNetCore.Mvc;
using Timesheet_API.Models.Dto.CountryDtos;
using Timesheet_API.Services.CountryServices;

namespace Timesheet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private ICountryServices countryServices;

        public CountryController(ICountryServices countryServices)
        {
            this.countryServices = countryServices;
        }

        [Route("/error-development")]
        public IActionResult HandlerError() => Problem();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(countryServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid ID)
        {
            return Ok(countryServices.FindByID(ID));
        }

        [HttpPost]
        public IActionResult Create(CountryDto countryDto)
        {
            return Created("", countryServices.Create(countryDto));
        }

        [HttpPut]
        public IActionResult Update(CountryUpdateDto countryUpdateDto)
        {
            return Ok(countryServices.Update(countryUpdateDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid ID)
        {
            return Ok(countryServices.Delete(ID));
        }
    }
}
