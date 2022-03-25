using Timesheet_API.Models.Dto.ProjectDtos;
using Timesheet_API.Models.Helpers;
using Timesheet_API.Models.Models;
using Timesheet_API.Models.Parameters;

namespace Timesheet_API.Services.ProjectServices
{
    public interface IProjectServices : IServices<Project>
    {
        public PagedList<Project> FindAll(ProjectParameters projectParameters);
        public Project Create(ProjectPostDto projectPostDto);
        public Project Update(ProjectUpdateDto projectUpdateDto);
        public List<string> FindFirstLettersOfProjectsThatExist();
    }
}
