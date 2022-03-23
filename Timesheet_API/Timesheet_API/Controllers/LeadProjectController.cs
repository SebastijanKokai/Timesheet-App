using Microsoft.AspNetCore.Mvc;
using Timesheet_API.Models.Dto.LeadProjectDtos;
using Timesheet_API.Services.LeadProjectServices;

namespace Timesheet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadProjectController : ControllerBase
    {
        private ILeadProjectServices leadProjectServices;

        public LeadProjectController(ILeadProjectServices leadProjectServices)
        {
            this.leadProjectServices = leadProjectServices;
        }

        [Route("/error-development")]
        public IActionResult HandlerError() => Problem();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(leadProjectServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(LeadProjectDto leadProjectDto)
        {
            if (leadProjectDto == null)
            {
                throw new ArgumentNullException("UserID and ProjectID must be passed.");
            }
            return Ok(leadProjectServices.FindByID(leadProjectDto));
        }

        [HttpPost]
        public IActionResult Add(LeadProjectDto leadProjectDto)
        {
            if (leadProjectDto == null)
            {
                throw new ArgumentNullException("UserID and ProjectID must be passed.");
            }
            return Created("", leadProjectServices.Create(leadProjectDto));
        }

        [HttpDelete]
        public IActionResult Delete(LeadProjectDto leadProjectDto)
        {
            if (leadProjectDto == null)
            {
                throw new ArgumentNullException("UserID and ProjectID must be passed.");
            }
            return Ok(leadProjectServices.Delete(leadProjectDto));
        }
    }
}
