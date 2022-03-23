using Timesheet_API.Models.Dto.LeadProjectDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Services.LeadProjectServices
{
    public interface ILeadProjectServices
    {
        IList<LeadProject> FindAll();
        LeadProject FindByID(LeadProjectDto userProjectDto);
        LeadProject Create(LeadProjectDto userProjectDto);
        LeadProject Delete(LeadProjectDto userProjectDto);
    }
}
