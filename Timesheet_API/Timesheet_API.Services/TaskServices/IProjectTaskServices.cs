using Timesheet_API.Models.Dto.ProjectTaskDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Services.TaskServices
{
    public interface IProjectTaskServices : IServices<ProjectTask>
    {
        ProjectTask Create(ProjectTaskPostDto projectTaskDto);
        ProjectTask Update(ProjectTaskUpdateDto projectTaskDto);
    }
}
