using Timesheet_API.Models.Dto.ProjectDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Services.ProjectServices
{
    public interface IProjectServices : IServices<Project>
    {
        public Project Create(ProjectPostDto projectPostDto);
            public Project Update(ProjectUpdateDto projectUpdateDto);
    }
}
